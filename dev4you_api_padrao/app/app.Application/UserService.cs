using app.Domain.Exceptions;
using app.Domain.Extensions;
using app.Domain.Models.Authentication;
using app.Domain.Models.Filters;
using app.Domain.Repositories;
using app.Domain.Resources;
using app.Domain.Services;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace app.Application
{
    public class UserService : IUserService
    {
        private readonly JwtOptions _jwtOptions;
        private readonly IUserRepository _userRepository;

        public UserService(IOptions<JwtOptions> options, IUserRepository userRepository)
        {
            _jwtOptions = options.Value;
            _userRepository = userRepository;
        }

        public async Task<UserAuthenticated> Login(User user)
        {
            try
            {
                var result = _userRepository.Login(user.Login, ConvertToEncrypt(user.Password));

                if (result)
                {
                    var userAux = GetByLogin(user.Login);

                    if (userAux == null)
                    {
                        throw new DomainException(string.Format(CustomMessages.UserNotExists, user.Login));
                    }

                    var guid = Guid.NewGuid().ToString();
                    userAux.SessionId = guid;
                    userAux.Profile = null; // Tracking error because of circular dependency caused by GenerateToken method
                    await _userRepository.Update(userAux);

                    var userAux2 = GetByLogin(user.Login);
                    var tokenAplication = GenerateToken(userAux2);

                    return new UserAuthenticated()
                    {
                        Authenticated = true,
                        Acesstoken = tokenAplication,
                        Created = DateTime.Now,
                        Expiration = DateTime.Now.AddMinutes(1440), // 24h
                        Message = CustomMessages.Authenticated,
                        SessionId = guid
                    };
                }

                else
                {
                    return new UserAuthenticated()
                    {
                        Authenticated = false,
                        Acesstoken = "",
                        Created = DateTime.Now,
                        Expiration = DateTime.Now.AddMinutes(1440), // 24h
                        Message = CustomMessages.NotAuthenticated,
                        SessionId = null
                    };
                }
            }

            catch (Exception ex)
            {
                throw new SecurityException(ex.Message);
            }
        }

        public PagedList<User> GetAll(UserSearch search)
        {
            return _userRepository.GetAll(search);
        }

        public User GetByLogin(string login)
        {
            return _userRepository.GetByLogin(login);
        }

        public User GetById(long id)
        {
            return _userRepository.GetById(id);
        }

        public async Task Add(User user)
        {
            var userAlreadyExsists = GetByLogin(user.Login);
            user.Password = ConvertToEncrypt(user.Password);

            if (userAlreadyExsists != null)
            {
                throw new DomainException(string.Format(CustomMessages.UserAlreadyExists, user.Login));
            }

            await _userRepository.Add(user);
        }

        public async Task Update(User user)
        {
            var existingUser = GetById(user.Id);
            user.Password = existingUser.Password;

            if (existingUser == null)
            {
                throw new DomainException(CustomMessages.UserIdNotExists);
            }

            await _userRepository.Update(user);
        }

        public async Task ChangePassword(long id, User user)
        {
            var userExisting = GetById(id);
            var passwordUserExisting = ConvertToDecrypt(userExisting.Password);

            if (passwordUserExisting != user.Password)
            {
                throw new DomainException(CustomMessages.IncorrectPassword);
            }

            else
            {
                userExisting.Profile = null; // Tracking error because of circular dependency caused by GetById method
                userExisting.Password = ConvertToEncrypt(user.NewPassword);
                await _userRepository.Update(userExisting);
            }
        }

        public void DeleteById(long id)
        {
            _userRepository.DeleteById(id);
        }

        private string ConvertToEncrypt(string password)
        {
            if (string.IsNullOrEmpty(password))
            {
                return "";
            }

            password += _jwtOptions.SecretKey;
            var passwordBytes = Encoding.UTF8.GetBytes(password);

            return Convert.ToBase64String(passwordBytes);
        }

        private string ConvertToDecrypt(string base64EncodeData)
        {
            if (string.IsNullOrEmpty(base64EncodeData))
            {
                return "";
            }

            var base64EncodeBytes = Convert.FromBase64String(base64EncodeData);
            var result = Encoding.UTF8.GetString(base64EncodeBytes);
            result = result.Substring(0, result.Length - _jwtOptions.SecretKey.Length);

            return result;
        }

        private string GenerateToken(User user)
        {
            var symmetricKey = Encoding.UTF8.GetBytes(_jwtOptions.SecretKey);
            var tokenHandler = new JwtSecurityTokenHandler();

            var identity = new ClaimsIdentity();
            identity.AddClaim(new Claim(ClaimTypes.PrimarySid, user.Id.ToString()));
            identity.AddClaim(new Claim("Login", user.Login));
            identity.AddClaim(new Claim("Name", user.Name));
            identity.AddClaim(new Claim("SessionId", user.SessionId));

            if (user.Profile.Permissions != null && user.Profile.Permissions.Any())
            {
                identity.AddClaims(user.Profile.Permissions.Select(c => new Claim(ClaimTypes.Role, c.Name)).ToList());
            }

            var symmetricSecurityKey = new SymmetricSecurityKey(symmetricKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = identity,
                NotBefore = DateTime.Now,
                Expires = DateTime.Now.AddMinutes(240),
                SigningCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256Signature),
                Issuer = _jwtOptions.Issuer
            };

            var stoken = tokenHandler.CreateToken(tokenDescriptor);
            var token = tokenHandler.WriteToken(stoken);

            return token;
        }
    }
}
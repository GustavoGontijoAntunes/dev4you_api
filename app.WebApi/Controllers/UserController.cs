﻿using app.Domain.Models.Authentication;
using app.Domain.Models.Filters;
using app.Domain.Services;
using app.WebApi.Dtos.Requests;
using app.WebApi.Dtos.Results;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace app.WebApi.Controllers
{
    [ApiVersion("1.0")]
    [Authorize]
    public class UserController : BaseController
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService,
            IMapper mapper) : base(mapper)
        {
            _userService = userService;
        }

        /// <summary>
        /// Sign up in app.
        /// </summary>
        /// <param name="userPost">User post</param>
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(BadRequestResult), 400)]
        [ProducesResponseType(500)]
        [Authorize(Roles = "POST_USER")]
        public async Task Post([FromBody] UserPost userPost)
        {
            var user = _mapper.Map<User>(userPost);
            await _userService.Add(user);
        }

        /// <summary>
        /// Edit an user in app.
        /// </summary>
        /// <param name="userPut">User put</param>
        [HttpPut]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(BadRequestResult), 400)]
        [ProducesResponseType(500)]
        [Authorize(Roles = "PUT_USER")]
        public async Task Edit([FromBody] UserPut userPut)
        {
            var user = _mapper.Map<User>(userPut);
            await _userService.Update(user);
        }

        /// <summary>
        /// Change password of the user in app.
        /// </summary>
        /// <param name="userPasswordPut">User password post</param>
        [HttpPut("password")]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(BadRequestResult), 400)]
        [ProducesResponseType(500)]
        [Authorize(Roles = "PUT_USER")]
        public async Task EditUserPassword(long id, [FromBody] UserPasswordPut userPasswordPut)
        {
            var user = _mapper.Map<User>(userPasswordPut);
            await _userService.ChangePassword(id, user);
        }

        /// <summary>
        /// Get an user by id in app.
        /// </summary>
        /// <param name="id">User id</param>
        /// <returns>User object</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(BadRequestResult), 400)]
        [ProducesResponseType(500)]
        [Authorize(Roles = "GET_USER")]
        public ActionResult<UserResult> GetById(long id)
        {
            var user = _userService.GetById(id);
            var result = _mapper.Map<UserResult>(user);

            return Ok(result);
        }

        /// <summary>
        /// Get all users in app.
        /// </summary>
        /// <param name="userGet">User object request</param>
        /// <returns>List of users</returns>
        [HttpGet("all")]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(BadRequestResult), 400)]
        [ProducesResponseType(500)]
        [Authorize(Roles = "GET_USER")]
        public ActionResult<CollectionResult<UserResult>> GetAll([FromQuery] UserGet userGet)
        {
            var search = _mapper.Map<UserSearch>(userGet);
            var users = _userService.GetAll(search);
            var result = _mapper.Map<CollectionResult<UserResult>>(users);

            return Ok(result);
        }

        /// <summary>
        /// Delete an user in app.
        /// </summary>
        /// <param name="id">User id</param>
        [HttpDelete]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(BadRequestResult), 400)]
        [ProducesResponseType(500)]
        [Authorize(Roles = "DELETE_USER")]
        public void DeleteById([FromQuery] long id)
        {
            _userService.DeleteById(id);
        }
    }
}
namespace app.WebApi.Dtos.Results
{
    public class UserResult : BaseResult
    {
        public string? Name { get; set; }
        public string? Login { get; set; }
        public string SessionId { get; set; }
        public ProfileResult Profile { get; set; }
    }
}
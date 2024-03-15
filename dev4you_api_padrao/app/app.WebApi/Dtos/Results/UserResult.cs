namespace app.WebApi.Dtos.Results
{
    public class UserResult
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public string? Login { get; set; }
        public DateTime CreatedDate { get; set; }
        public string SessionId { get; set; }
        public ProfileResult Profile { get; set; }
    }
}
namespace app.WebApi.Dtos.Results
{
    public class ProfileResult
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public List<PermissionResult> Permissions { get; set; }
    }
}
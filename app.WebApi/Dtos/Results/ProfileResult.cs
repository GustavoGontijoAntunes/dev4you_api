namespace app.WebApi.Dtos.Results
{
    public class ProfileResult : BaseResult
    {
        public string Name { get; set; }
        public List<PermissionResult> Permissions { get; set; }
    }
}
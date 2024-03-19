namespace app.WebApi.Dtos.Requests
{
    public class ProfileGet : Filter
    {
        /// <summary>
        /// Profile name
        /// </summary>
        public string? Name { get; set; }
    }
}
namespace WEBAPI.Entities
{
    public partial class User
    {
        public int id { get; set; }
        public string? username { get; set; }
        public string? mail { get; set; }
        public string? phone { get; set; }
        public string? skill { get; set; }
        public string? hobby { get; set; }
    }
}
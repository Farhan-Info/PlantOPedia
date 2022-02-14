namespace PlantOPedia.Models.Response
{
    public class Login
    {
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public RoleType RoleType { get; set; }
    }
}

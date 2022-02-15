namespace PlantOPedia.Models.Response
{
    public class User
    {
        public Guid UserId { get; set; }
      
        public string Name { get; set; }
       
        public string Email { get; set; }
     
        public string Password { get; set; }
        public string Address { get; set; }
    
        public string MobileNo { get; set; }
        public Guid RoleId { get; set; }
        public Role? Role { get; set; }
    }
}

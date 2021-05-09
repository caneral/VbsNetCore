namespace StudentInfo.Entity.DTO.Authentication
{
    public class UserRegisterDTO
    {
        public string TCNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public int UserRole { get; set; }
    }
}

namespace ApiStore.DTOs
{
    public class UserResponse
    {
        public int Id { get; set; }

        public string Username { get; set; } = null!;

        public string Userpassword { get; set; } = null!;

        public string UserRole { get; set; } = null!;
    }
    public class UserRequest
    {
        //public int Id { get; set; }

        public string Username { get; set; } = null!;

        public string Userpassword { get; set; } = null!;

        public string UserRole { get; set; } = null!;

    }

}


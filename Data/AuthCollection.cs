using MSC_55.Models;

namespace MSC_55.Data
{
    public static class AuthCollection
    {
        public static List<User> Users = new List<User>
        {
            new User
            {
                Id = 1,
                Role = "admin",
                UserName = "admin",
                Email = "admin@example.com",
                Password = "Password123!"
            },
            new User
            {
                Id = 2,
                Role = "staff",
                UserName = "smith",
                Email = "jane.smith@example.com",
                Password = "SecurePass456!"
            },
            new User
            {
                Id = 3,
                Role = "staff",
                UserName = "bob_jackson",
                Email = "bob.jackson@example.com",
                Password = "BobStrong789!"
            }
        };


    }
}

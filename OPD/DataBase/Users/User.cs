using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using OPD.DataBase.Products;

namespace OPD.DataBase.Users
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public Roles Role { get; set; }
        public UserBasket UserBasket { get; set; }
        public string Password { get; set; }

        public User(string firstName, string lastName, string email, string password)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
            UserBasket = new UserBasket()
            {
                UserId = Id
            };
            Role = Roles.User;
        }

    }
    public class Login
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public Login(string email, string password)
        {
            Email = email;
            Password = password;
        }
    }
}

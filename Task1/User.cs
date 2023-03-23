using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Task1
{
    public class User
    {
        [Key]
        public string User_ID { get; set; }
        public string First_Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        public string Last_Name { get; set; } = string.Empty;

        //   [ForeignKey("Location")]
        public string Location { get; set; } = string.Empty;
      //  public string Username { get; set; } = string.Empty;

        //authentication
      //  public byte[] passwordHash { get; set; }
       // public byte[] PasswordSalt { get; set; } 

    }
}


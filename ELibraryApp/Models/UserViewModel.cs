using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ELibraryApp.Models
{
    public class UserViewModel
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Must Insert Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Must Insert User Name")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Must Insert Email Address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Must Insert Phone Number")]
        public string Phone { get; set; }

        [ForeignKey("Role")]
        public int RoleID { get; set; }
        public string Password { get; set; }

        [NotMapped]
        public string ConfirmPassword { get; set; }
        public bool Status { get; set; }
    }
}

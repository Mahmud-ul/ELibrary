using System.ComponentModel.DataAnnotations;

namespace ELibraryApp.Models
{
    public class RoleViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; }
    }
}

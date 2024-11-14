using System.ComponentModel.DataAnnotations.Schema;

namespace ELibraryApp.Models
{
    public class CartViewModel
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public int ProductID { get; set; }
    }
}

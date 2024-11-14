using System.ComponentModel.DataAnnotations.Schema;

namespace ELibraryApp.Models
{
    public class SaleProductViewModel
    {
        public int SaleID { get; set; }
        public int ProductID { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
    }
}

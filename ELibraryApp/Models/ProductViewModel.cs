using System.ComponentModel.DataAnnotations.Schema;

namespace ELibraryApp.Models
{
    public class ProductViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int Discount { get; set; }
        public int PageAmount { get; set; }
        public string Description { get; set; }
        public int WriterID { get; set; }
        public int PublisherID { get; set; }
        public bool New { get; set; }
        public bool PreOrder { get; set; }
        public bool Featured { get; set; }
        public bool Status { get; set; }
    }
}

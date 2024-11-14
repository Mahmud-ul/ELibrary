using System.ComponentModel.DataAnnotations.Schema;

namespace ELibraryApp.Models
{
    public class ImageViewModel
    {
        public int ID { get; set; }
        public int ProductID { get; set; }
        public bool Featured { get; set; }
        public bool Offered { get; set; }
        public bool Cover { get; set; }
        public bool Status { get; set; }
    }
}

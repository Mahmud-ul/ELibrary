using System.ComponentModel.DataAnnotations.Schema;

namespace ELibraryApp.Models
{
    public class CategoryViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int? MainCat { get; set; }
        public bool Status { get; set; }
    }
}

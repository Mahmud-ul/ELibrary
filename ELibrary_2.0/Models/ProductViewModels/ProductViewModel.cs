using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELibrary_2._0.Models.ProducViewModels
{
    public class ProductViewModel
    {
        public int ID { get; set; }

        [Required(ErrorMessage ="Please Insert Product Name!!!!!")]
        public string Name { get; set; } = string.Empty;
        [Required]
        public int CategoryID { get; set; }
        [Required]
        public int WriterID { get; set; }
        [Required]
        public int PublisherID { get; set; }
        [Required]
        public int CoverID { get; set; }
        public int Price { get; set; }
        public int Discount { get; set; }
        public int PageAmount { get; set; }
        public string Topic { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;        
        public bool Featured { get; set; }
        public bool IsNew { get; set; }
        public bool PreOrderable { get; set; }
        public bool Status { get; set; }
    }
}

using ELibrary_2._0.Model.SaleModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELibrary_2._0.Model.ProductModels
{
    public class Product
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Please Insert Product Name!!!!!")]
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

        [DataType(DataType.MultilineText)]
        public string Description { get; set; } = string.Empty;
        public bool Featured { get; set; }
        public bool IsNew { get; set; }
        public bool PreOrderable { get; set; }
        public bool Status { get; set; }

        public virtual Category? Category { get; set; }
        public virtual Writer? Writer { get; set; }
        public virtual Publisher? Publisher { get; set; }
        public virtual Cover? Cover { get; set; }
        public virtual IEnumerable<Image>? Images { get; set; }
        public virtual IEnumerable<Cart>? Carts { get; set; }
        public virtual IEnumerable<SoldProduct>? SoldProducts { get; set; }
    }
}

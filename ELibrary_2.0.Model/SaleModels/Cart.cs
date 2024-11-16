using ELibrary_2._0.Model.ProductModels;
using ELibrary_2._0.Model.UserModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELibrary_2._0.Model.SaleModels
{
    public class Cart
    {
        public int ID { get; set; }

        [ForeignKey("User")]
        public int UserID { get; set; }

        [ForeignKey("Product")]
        public int ProductID { get; set; }
        public int Quantity { get; set; }

        public virtual User? User { get; set; }
        public virtual Product? Product { get; set; }
    }
}

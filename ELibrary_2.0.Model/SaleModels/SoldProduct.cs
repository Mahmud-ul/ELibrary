using ELibrary_2._0.Model.ProductModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELibrary_2._0.Model.SaleModels
{
    public class SoldProduct
    {
        public int ID { get; set; }

        [ForeignKey("Sale")]
        public int SaleID { get; set; }

        [ForeignKey("Product")]
        public int ProductID { get; set; }
        public int SellingPrice { get; set; }
        public int Quantity { get; set; }

        public virtual Sale? Sale { get; set; }
        public virtual Product? Product { get; set; }
    }
}

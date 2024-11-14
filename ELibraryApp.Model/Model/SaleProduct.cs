using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELibraryApp.Model.Model
{
    public class SaleProduct
    {
        [ForeignKey("Sale")]
        public int SaleID { get; set; }

        [ForeignKey("Product")]
        public int ProductID { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
        public virtual Sale Sale { get; set; }
        public virtual Product Product { get; set; }
    }
}

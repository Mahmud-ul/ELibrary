using ELibrary_2._0.Model.UserModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELibrary_2._0.Model.SaleModels
{
    public class Sale
    {
        public int ID { get; set; }

        [ForeignKey("User")]
        public int UserID { get; set; }

        [ForeignKey("PaymentMethod")]
        public int PaymentMethodID { get; set; }

        public DateTime Date { get; set; } = DateTime.Now;
        public int TotalAmount { get; set; }

        public virtual User? User { get; set; }
        public virtual PaymentMethod? PaymentMethod { get; set; }
        public virtual IEnumerable<SoldProduct>? SoldProducts { get; set; }


    }
}

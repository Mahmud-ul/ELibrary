using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELibraryApp.Model.Model
{
    public class Payment
    {
        public Payment()
        {
            this.Status = string.Empty;
        }
        public int ID { get; set; }

        [ForeignKey("PaymentMethod")]
        public int PaymentMethodID { get; set; }
        public int Amount { get; set; }
        public DateTime Date { get; set; }
        public string Status { get; set; }

        public virtual PaymentMethod PaymentMethod { get; set; }
    }
}

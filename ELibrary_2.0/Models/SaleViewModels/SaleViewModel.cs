using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELibrary_2._0.Models.SaleViewModels
{
    public class SaleViewModel
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public int PaymentMethodID { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public int TotalAmount { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELibrary_2._0.Models.SaleViewModels
{
    public class SoldProductViewModel
    {
        public int ID { get; set; }
        public int SaleID { get; set; }
        public int ProductID { get; set; }
        public int SellingPrice { get; set; }
        public int Quantity { get; set; }
    }
}

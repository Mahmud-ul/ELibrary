using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELibraryApp.Model.Model
{
    public class Sale
    {
        public Sale()
        {
            this.Status = string.Empty;
        }
        public int ID { get; set; }
        public int Price { get; set; }
        public DateTime Date { get; set; }
        public string Status { get; set; }
    }
}

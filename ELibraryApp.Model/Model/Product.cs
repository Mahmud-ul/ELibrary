using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELibraryApp.Model.Model
{
    public class Product
    {
        public Product()
        {
            this.Name = string.Empty;
            this.Status = true;
        }
        public int ID { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int Discount { get; set; }
        public int PageAmount { get; set; }
        public string Description { get; set; }

        [ForeignKey("Writer")]
        public int WriterID { get; set; }

        [ForeignKey("Publisher")]
        public int PublisherID { get; set; }
        public bool New { get; set; }
        public bool PreOrder { get; set; }
        public bool Featured { get; set; }
        public bool Status { get; set; }

        public virtual Writer Writer { get; set; }
        public virtual Publisher Publisher { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELibraryApp.Model.Model
{
    public class Image
    {
        public int ID { get; set; }

        [ForeignKey("Product")]
        public int ProductID { get; set; }
        public bool Featured { get; set; }
        public bool Offered { get; set; }
        public bool Cover { get; set; }
        public bool Status { get; set; }

        public virtual Product Product { get; set; }
    }
}

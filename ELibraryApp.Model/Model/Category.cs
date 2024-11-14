using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELibraryApp.Model.Model
{
    public class Category
    {
        public Category()
        {
            this.Name = string.Empty;
        }
        public int ID { get; set; }
        public string Name { get; set; }

        [ForeignKey("Categories")]
        public int? MainCat { get; set; }
        public bool Status { get; set; }

        public virtual Category Categories { get; set; }
    }
}
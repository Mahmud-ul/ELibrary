using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELibrary_2._0.Models.ProducViewModels
{
    public class CategoryViewModel
    {
        public int ID { get; set; }
        public int MainCatID { get; set; }
        public string Name { get; set; } = string.Empty;
        public bool Status { get; set; }
        
    }
}

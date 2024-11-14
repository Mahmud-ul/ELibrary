using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELibraryApp.Model.Model
{
    public class Writer
    {
        public Writer()
        {
            this.Name = string.Empty;
        }
        public int ID { get; set; }
        public string Name { get; set; }
        public bool Featured { get; set; }
    }
}

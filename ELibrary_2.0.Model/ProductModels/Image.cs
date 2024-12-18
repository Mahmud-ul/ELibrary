﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELibrary_2._0.Model.ProductModels
{
    public class Image
    {
        public int ID { get; set; }

        [ForeignKey("Product")]
        public int ProductID { get; set; }

        [Required(ErrorMessage = "Please Choose a Valid Image!!!")]
        [DataType(DataType.ImageUrl)]
        public string ImageURL { get; set; } = string.Empty;
        public bool Featured { get; set; }
        public bool Slideshow { get; set; }
        public bool Status { get; set; }

        public virtual Product? Product { get; set; }
    }
}

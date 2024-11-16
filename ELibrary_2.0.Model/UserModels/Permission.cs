using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELibrary_2._0.Model.UserModels
{
    public class Permission
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "This is Required!!!")]
        public string Name { get; set; } = string.Empty;
        public bool Status { get; set; }

        public virtual IEnumerable<UserPermission>? UserPermissions { get; set; }
    }
}

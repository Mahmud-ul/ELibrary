using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELibrary_2._0.Model.UserModels
{
    public class UserPermission
    {
        public int ID { get; set; }
        public int UserTypeID { get; set; }
        public int PermissionID { get; set; }

        public virtual UserType? UserType { get; set; }
        public virtual Permission? Permission { get; set; }
    }
}

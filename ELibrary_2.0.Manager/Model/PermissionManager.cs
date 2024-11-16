using ELibrary_2._0.Manager.Base;
using ELibrary_2._0.Manager.Contract;
using ELibrary_2._0.Model.SaleModels;
using ELibrary_2._0.Model.UserModels;
using ELibrary_2._0.Repository.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELibrary_2._0.Manager.Model
{
    public class PermissionManager : BaseManager<Permission>, IPermissionManager
    {
        public PermissionManager(IPermissionRepository repository) : base(repository)
        {
        }
    }
}

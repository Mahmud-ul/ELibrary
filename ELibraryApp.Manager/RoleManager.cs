using ELibraryApp.Manager.Base;
using ELibraryApp.Manager.Contract;
using ELibraryApp.Model.Model;
using ELibraryApp.Repository.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELibraryApp.Manager
{
    public class RoleManager : BaseManager<Role>, IRoleManager
    {
        private readonly IRoleRepository _RoleRepository;
        public RoleManager(IRoleRepository RoleRepository) : base(RoleRepository)
        {
            _RoleRepository = RoleRepository;
        }
    }
}

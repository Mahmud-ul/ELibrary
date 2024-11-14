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
    public class UserManager : BaseManager<User>, IUserManager
    {
        private readonly IUserRepository _UserRepository;
        public UserManager(IUserRepository UserRepository) : base(UserRepository)
        {
            _UserRepository = UserRepository;
        }
    }
}

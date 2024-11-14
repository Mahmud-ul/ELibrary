using ELibraryApp.Model.Model;
using ELibraryApp.Repository.Base;
using ELibraryApp.Repository.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELibraryApp.Repository
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
    }
}

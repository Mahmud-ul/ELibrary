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
    public class CategoryManager : BaseManager<Category>, ICategoryManager
    {
        private readonly ICategoryRepository _CategoryRepository;
        public CategoryManager(ICategoryRepository CategoryRepository) : base(CategoryRepository)
        {
            _CategoryRepository = CategoryRepository;
        }
    }
}

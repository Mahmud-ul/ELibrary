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
    public class ProductManager : BaseManager<Product>, IProductManager
    {
        private readonly IProductRepository _ProductRepository;
        public ProductManager(IProductRepository ProductRepository) : base(ProductRepository)
        {
            _ProductRepository = ProductRepository;
        }
    }
}

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
    public class SaleProductManager : BaseManager<SaleProduct>, ISaleProductManager
    {
        private readonly ISaleProductRepository _SaleProductRepository;
        public SaleProductManager(ISaleProductRepository SaleProductRepository) : base(SaleProductRepository)
        {
            _SaleProductRepository = SaleProductRepository;
        }
    }
}

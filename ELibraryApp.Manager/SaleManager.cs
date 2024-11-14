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
    public class SaleManager : BaseManager<Sale>, ISaleManager
    {
        private readonly ISaleRepository _SaleRepository;
        public SaleManager(ISaleRepository SaleRepository) : base(SaleRepository)
        {
            _SaleRepository = SaleRepository;
        }
    }
}

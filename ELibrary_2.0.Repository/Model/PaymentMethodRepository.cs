using ELibrary_2._0.Model.ProductModels;
using ELibrary_2._0.Model.SaleModels;
using ELibrary_2._0.Repository.Base;
using ELibrary_2._0.Repository.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELibrary_2._0.Repository.Model
{
    public class PaymentMethodRepository : BaseRepository<PaymentMethod>, IPaymentMethodRepository
    {
    }
}


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
    public class PaymentManager : BaseManager<Payment>, IPaymentManager
    {
        private readonly IPaymentRepository _PaymentRepository;
        public PaymentManager(IPaymentRepository PaymentRepository) : base(PaymentRepository)
        {
            _PaymentRepository = PaymentRepository;
        }
    }
}

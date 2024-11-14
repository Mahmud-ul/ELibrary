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
    public class PaymentMethodManager : BaseManager<PaymentMethod>, IPaymentMethodManager
    {
        private readonly IPaymentMethodRepository _paymentMethod;
        public PaymentMethodManager(IPaymentMethodRepository paymentMethod):base(paymentMethod)
        {
            _paymentMethod = paymentMethod;
        }
    }
}

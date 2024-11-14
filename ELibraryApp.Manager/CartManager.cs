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
    public class CartManager : BaseManager<Cart>, ICartManager
    {
        private readonly ICartRepository _CartRepository;
        public CartManager(ICartRepository CartRepository) : base(CartRepository)
        {
            _CartRepository = CartRepository;
        }
    }
}

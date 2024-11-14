using AutoMapper;
using ELibraryApp.Database.Database;
using ELibraryApp.Manager.Contract;
using ELibraryApp.Model.Model;
using ELibraryApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace ELibraryApp.Controllers
{
    public class CartController : Controller
    {
        #region Not Needed
        //public IActionResult Index()
        //{
        //    return View();
        //}
        #endregion

        private readonly ELibraryAppDB _db;
        private readonly IMapper _iMapper;
        private readonly ICartManager _iCartManager;
        public CartController(IMapper iMapper, ICartManager iCartManager)
        {
            _db = new ELibraryAppDB();
            _iMapper = iMapper;
            _iCartManager = iCartManager;
        }

        public async Task<IActionResult> AddToCart(int id)
        {
            try
            {
                if (id != 0)
                {
                    TempData["Error"] = "Product not Found!!!";
                }
                Product? product = _db.Products.FirstOrDefault(p => p.ID == id);
                if (product == null)
                {
                    TempData["Error"] = "Invalid Product!!!";
                }
                Cart? existCart = _db.Carts.Where(p => p.ProductID == id && p.UserID == Convert.ToInt32(HttpContext.Session.GetString("ID"))).FirstOrDefault();
                if (existCart == null)
                {
                    TempData["Error"] = "Already added to the Cart!!!";
                }

                CartViewModel cartViewModel = new CartViewModel() { ProductID=id, UserID = Convert.ToInt32(HttpContext.Session.GetString("ID"))};
                Cart cart = _iMapper.Map<Cart>(cartViewModel);
                bool save = await _iCartManager.Create(cart);

                return RedirectToAction("Index", "Home");
            }
            catch(Exception ex)
            {
                TempData["Error"] = ex.Message;
            }

            return RedirectToAction("Index", "Home");
        }
        public async Task<IActionResult> RemoveFromCart(int id)
        {
            try
            {
                if (id != 0)
                {
                    TempData["Error"] = "Product not Found!!!";
                }
                Cart? existCart = _db.Carts.Where(p => p.ProductID == id && p.UserID == Convert.ToInt32(HttpContext.Session.GetString("ID"))).FirstOrDefault();
                if (existCart == null)
                {
                    TempData["Error"] = "Already added to the Cart!!!";
                }

                CartViewModel cartViewModel = new CartViewModel() { ProductID = id, UserID = Convert.ToInt32(HttpContext.Session.GetString("ID")) };
                Cart cart = _iMapper.Map<Cart>(cartViewModel);
                bool save = await _iCartManager.Remove(cart);

                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
            }

            return RedirectToAction("Index", "Home");
        }
        public IActionResult UpdateCart(int id)
        {
            return View();
        }
    }
}

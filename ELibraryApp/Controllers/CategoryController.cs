using AutoMapper;
using ELibraryApp.Manager.Contract;
using ELibraryApp.Model.Model;
using ELibraryApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace ELibraryApp.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IMapper _iMapper;
        private readonly ICategoryManager _iCategoryManager;

        public CategoryController(IMapper iMapper, ICategoryManager iCategoryManager)
        {
            _iMapper = iMapper;
            _iCategoryManager = iCategoryManager;
        }

        public async Task<ActionResult<IEnumerable<CategoryViewModel>>> Index()
        {
            #region Admin Check
            if (HttpContext.Session.GetString("Membership") != "Admin")
                return StatusCode(403, "Access Denied: You don not have the permission to access this resource");
            #endregion

            IEnumerable<CategoryViewModel> categories = _iMapper.Map<IEnumerable<CategoryViewModel>>(await _iCategoryManager.GetAll());

            return View(categories);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            #region Admin Check
            if (HttpContext.Session.GetString("Membership") != "Admin")
                return StatusCode(403, "Access Denied: You don not have the permission to access this resource");
            #endregion

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CategoryViewModel category)
        {
            #region Admin Check
            if (HttpContext.Session.GetString("Membership") != "Admin")
                return StatusCode(403, "Access Denied: You don not have the permission to access this resource");
            #endregion

            if (ModelState.IsValid)
            {
                Category AddCategory = _iMapper.Map<Category>(category);
                bool IsAdded = await _iCategoryManager.Create(AddCategory);

                if (IsAdded)
                    return RedirectToAction("Index");
                else
                    ViewBag.ErrorMessage = "Failed to Create Category";
            }
            return View(category);
        }

        [HttpGet]
        public async Task<IActionResult> Update(int? id)
        {
            #region Admin Check
            if (HttpContext.Session.GetString("Membership") != "Admin")
                return StatusCode(403, "Access Denied: You don not have the permission to access this resource");
            #endregion

            if (id == null)
                return NotFound();

            CategoryViewModel existCategory = _iMapper.Map<CategoryViewModel>(await _iCategoryManager.GetById(id));

            if (existCategory == null)
                return NotFound();

            return View(existCategory);
        }

        [HttpPost]
        public async Task<IActionResult> Update(CategoryViewModel ExistCategory)
        {
            #region Admin Check
            if (HttpContext.Session.GetString("Membership") != "Admin")
                return StatusCode(403, "Access Denied: You don not have the permission to access this resource");
            #endregion

            if (ModelState.IsValid)
            {
                Category category = _iMapper.Map<Category>(ExistCategory);

                bool IsUpdated = await _iCategoryManager.Update(category);

                if (IsUpdated)
                    return RedirectToAction("Index");
                else
                    ViewBag.ErrorMessage = "Failed to Update Category";
            }
            return View(ExistCategory);
        }

        [HttpGet]
        public async Task<IActionResult> Remove(int? id)
        {
            #region Admin Check
            if (HttpContext.Session.GetString("Membership") != "Admin")
                return StatusCode(403, "Access Denied: You don not have the permission to access this resource");
            #endregion

            if (id == null)
                return NotFound();

            Category existCategory = await _iCategoryManager.GetById(id);

            if (existCategory == null)
                return NotFound();

            bool remove = await _iCategoryManager.Remove(existCategory);

            if (remove)
                return RedirectToAction("Index");
            else
                ViewBag.ErrorMessage = "Failed to Delete Category";

            return BadRequest();
        }
    }
}

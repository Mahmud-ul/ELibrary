using AutoMapper;
using ELibraryApp.Manager.Contract;
using ELibraryApp.Model.Model;
using ELibraryApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace ELibraryApp.Controllers
{
    public class WriterController : Controller
    {
        private readonly IMapper _iMapper;
        private readonly IWriterManager _iWriterManager;

        public WriterController(IMapper iMapper, IWriterManager iWriterManager)
        {
            _iMapper = iMapper;
            _iWriterManager = iWriterManager;
        }

        public async Task<ActionResult<IEnumerable<WriterViewModel>>> Index()
        {
            #region Admin Check
            if (HttpContext.Session.GetString("Membership") != "Admin")
                return StatusCode(403, "Access Denied: You don not have the permission to access this resource");
            #endregion

            IEnumerable<WriterViewModel> writers = _iMapper.Map<IEnumerable<WriterViewModel>>(await _iWriterManager.GetAll());

            return View(writers);
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
        public async Task<IActionResult> Create(WriterViewModel writer)
        {
            #region Admin Check
            if (HttpContext.Session.GetString("Membership") != "Admin")
                return StatusCode(403, "Access Denied: You don not have the permission to access this resource");
            #endregion

            if (ModelState.IsValid)
            {
                Writer AddWriter = _iMapper.Map<Writer>(writer);
                bool IsAdded = await _iWriterManager.Create(AddWriter);

                if (IsAdded)
                    return RedirectToAction("Index");
                else
                    ViewBag.ErrorMessage = "Failed to Create Writer";
            }
            return View(writer);
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

            WriterViewModel existWriter = _iMapper.Map<WriterViewModel>(await _iWriterManager.GetById(id));

            if (existWriter == null)
                return NotFound();

            return View(existWriter);
        }

        [HttpPost]
        public async Task<IActionResult> Update(WriterViewModel ExistWriter)
        {
            #region Admin Check
            if (HttpContext.Session.GetString("Membership") != "Admin")
                return StatusCode(403, "Access Denied: You don not have the permission to access this resource");
            #endregion

            if (ModelState.IsValid)
            {
                Writer writer = _iMapper.Map<Writer>(ExistWriter);

                bool IsUpdated = await _iWriterManager.Update(writer);

                if (IsUpdated)
                    return RedirectToAction("Index");
                else
                    ViewBag.ErrorMessage = "Failed to Update Writer";
            }
            return View(ExistWriter);
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

            Writer existWriter = await _iWriterManager.GetById(id);

            if (existWriter == null)
                return NotFound();

            bool remove = await _iWriterManager.Remove(existWriter);

            if (remove)
                return RedirectToAction("Index");
            else
                ViewBag.ErrorMessage = "Failed to Delete Writer";

            return BadRequest();
        }
    }
}

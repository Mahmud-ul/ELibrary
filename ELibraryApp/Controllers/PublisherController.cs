using AutoMapper;
using ELibraryApp.Manager.Contract;
using ELibraryApp.Model.Model;
using ELibraryApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace ELibraryApp.Controllers
{
    public class PublisherController : Controller
    {
        private readonly IMapper _iMapper;
        private readonly IPublisherManager _iPublisherManager;

        public PublisherController(IMapper iMapper, IPublisherManager iPublisherManager)
        {
            _iMapper = iMapper;
            _iPublisherManager = iPublisherManager;
        }

        public async Task<ActionResult<IEnumerable<PublisherViewModel>>> Index()
        {
            #region Admin Check
            if (HttpContext.Session.GetString("Membership") != "Admin")
                return StatusCode(403, "Access Denied: You don not have the permission to access this resource");
            #endregion

            IEnumerable<PublisherViewModel> publishers = _iMapper.Map<IEnumerable<PublisherViewModel>>(await _iPublisherManager.GetAll());

            return View(publishers);
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
        public async Task<IActionResult> Create(PublisherViewModel publisher)
        {
            #region Admin Check
            if (HttpContext.Session.GetString("Membership") != "Admin")
                return StatusCode(403, "Access Denied: You don not have the permission to access this resource");
            #endregion

            if (ModelState.IsValid)
            {
                Publisher AddPublisher = _iMapper.Map<Publisher>(publisher);
                bool IsAdded = await _iPublisherManager.Create(AddPublisher);

                if (IsAdded)
                    return RedirectToAction("Index");
                else
                    ViewBag.ErrorMessage = "Failed to Create Publisher";
            }
            return View(publisher);
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

            PublisherViewModel existPublisher = _iMapper.Map<PublisherViewModel>(await _iPublisherManager.GetById(id));

            if (existPublisher == null)
                return NotFound();

            return View(existPublisher);
        }

        [HttpPost]
        public async Task<IActionResult> Update(PublisherViewModel ExistPublisher)
        {
            #region Admin Check
            if (HttpContext.Session.GetString("Membership") != "Admin")
                return StatusCode(403, "Access Denied: You don not have the permission to access this resource");
            #endregion

            if (ModelState.IsValid)
            {
                Publisher publisher = _iMapper.Map<Publisher>(ExistPublisher);

                bool IsUpdated = await _iPublisherManager.Update(publisher);

                if (IsUpdated)
                    return RedirectToAction("Index");
                else
                    ViewBag.ErrorMessage = "Failed to Update Publisher";
            }
            return View(ExistPublisher);
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

            Publisher existPublisher = await _iPublisherManager.GetById(id);

            if (existPublisher == null)
                return NotFound();

            bool remove = await _iPublisherManager.Remove(existPublisher);

            if (remove)
                return RedirectToAction("Index");
            else
                ViewBag.ErrorMessage = "Failed to Delete Publisher";

            return BadRequest();
        }
    }
}

using AutoMapper;
using ELibrary_2._0.Manager.Contract;
using ELibrary_2._0.Model.ProductModels;
using ELibrary_2._0.Models.ProducViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ELibrary_2._0.Controllers
{
    public class CoverController : Controller
    {
        private readonly ICoverManager _iCoverManager;
        private readonly IMapper _iMapper;

        public CoverController(ICoverManager iCoverManager, IMapper iMapper)
        {
            _iCoverManager = iCoverManager;
            _iMapper = iMapper;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {
                IEnumerable<CoverViewModel> model = _iMapper.Map<IEnumerable<CoverViewModel>>(await _iCoverManager.GetAll());
                return View(model);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "Error: " + ex.Message;             
            }
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CoverViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    bool save = await _iCoverManager.Create(_iMapper.Map<Cover>(model));
                    if (save)
                    {
                        TempData["SuccessMessage"] = "Create Successfully!!!";
                        return RedirectToAction("Index");
                    }                       
                    TempData["ErrorMessage"] = "Failed to Create!!!";                                  
                }
            }
            catch(Exception ex)
            {
                TempData["ErrorMessage"] = "Error: " + ex.Message;
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            try
            {
                CoverViewModel? model = _iMapper.Map<CoverViewModel>(await _iCoverManager.GetById(id));

                if (model == null)
                    TempData["ErrorMessage"] = "Data not Found!!!";
                else
                    return View(model);
            }
            catch (Exception ex) 
            {
                TempData["ErrorMessage"] = "Error: " + ex.Message;
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Update(CoverViewModel model)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    bool save = await _iCoverManager.Update(_iMapper.Map<Cover>(model));
                    if (save)
                    {
                        TempData["SuccessMessage"] = "Updated Successfully!!!";
                        return RedirectToAction("Index");
                    }
                    TempData["ErrorMessage"] = "Failed to Update!!!";
                }
            }
            catch(Exception ex )
            {
                TempData["ErrorMessage"] = "Error: " + ex.Message;
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                Cover? model = await _iCoverManager.GetById(id);

                if (model == null)
                    TempData["ErrorMessage"] = "Data not Found!!!";
                else
                {
                    bool save = await _iCoverManager.Delete(model);
                    if (save)
                    {
                        TempData["SuccessMessage"] = "Deleted Successfully!!!";
                    }
                    else
                        TempData["ErrorMessage"] = "Failed to Delete!!!";
                }                 
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "Error: " + ex.Message;
            }
            return RedirectToAction("Index");
        }
    }
}

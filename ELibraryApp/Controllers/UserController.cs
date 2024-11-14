using AutoMapper;
using ELibraryApp.Database.Database;
using ELibraryApp.Manager.Contract;
using ELibraryApp.Model.Model;
using ELibraryApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace ELibraryApp.Controllers
{
    public class UserController : Controller
    {
        private readonly ELibraryAppDB _db;
        private readonly IMapper _iMapper;
        private readonly IUserManager _iUserManager;
        private readonly IRoleManager _iRoleManager;
        public UserController(IMapper iMapper, IUserManager iUserManager, IRoleManager iRoleManager)
        {
            _db = new ELibraryAppDB();
            _iMapper = iMapper;
            _iUserManager = iUserManager;
            _iRoleManager = iRoleManager;
        }

        public async Task<ActionResult<IEnumerable<UserViewModel>>> Index()
        {
            return View();
        }

        public async Task<ActionResult<IEnumerable<UserViewModel>>> UserList()
        {
            #region Admin Check
            if (HttpContext.Session.GetString("Membership") != "Admin")
                return StatusCode(403, "Access Denied: You don not have the permission to access this resource");
            #endregion

            IEnumerable<UserViewModel> users = _iMapper.Map<IEnumerable<UserViewModel>>(await _iUserManager.GetAll());

            ViewBag.Roles = _iMapper.Map<IEnumerable<RoleViewModel>>(await _iRoleManager.GetAll());
            return View(users);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(UserViewModel user)
        {
            try
            {
                User? loginUser = _db.Users.Where(e => e.UserName == user.UserName).FirstOrDefault();

                if (loginUser != null)
                {
                    if (loginUser.Password == user.Password)
                    {
                        //User Login Success
                        HttpContext.Session.SetString("ID", loginUser.ID.ToString());
                        HttpContext.Session.SetString("Name", loginUser.Name.ToString());

                        RoleViewModel role = _iMapper.Map<RoleViewModel>(await _iRoleManager.GetById(loginUser.RoleID));
                        HttpContext.Session.SetString("Membership", role.Name.ToString());

                        return RedirectToAction("Index");
                    }
                    else
                        ViewBag.ErrorMessage = "UserName or Passeword is Incorrect!";
                }
                else
                {
                    ViewBag.ErrorMessage = "UserName or Passeword is Incorrect!";
                }
                return View();
            }
            catch (Exception ex)
            {
                return ViewBag.ErrorMessage = "Failed to Login. Error: " + ex.Message;
            }
        }

        #region SignUp
        [HttpGet]
        public IActionResult Signup()
        {
            #region Login Check
            if (HttpContext.Session.GetString("UserID") == "" || HttpContext.Session.GetString("UserID") == null)
            {
                return View();
            }
            #endregion
            return RedirectToAction("Index", "User");
        }

        [HttpPost]
        public async Task<IActionResult> SignupAsync(UserViewModel user)
        {
            try
            {
                #region Validation Check
                bool notValid = false;
                if (user.Phone.Any(char.IsLetter))
                {
                    ViewBag.Phone = "Please insert a valid Phone number!";
                    notValid = true;
                }

                bool emailExists = _db.Users.Any(e => e.Email == user.Email);
                if (emailExists)
                {
                    ViewBag.Email = "Email already exists!";
                    notValid = true;
                }

                bool phoneExists = _db.Users.Any(e => e.Phone == user.Phone);
                if (phoneExists)
                {
                    ViewBag.Phone = "Phone Number already exists!";
                    notValid = true;
                }

                if (user.Password != user.ConfirmPassword)
                {
                    ViewBag.PasswordMismatched = "Password is not matching!";
                    notValid = true;
                }
                if (notValid)
                {
                    return View(user);
                }
                #endregion
                if (ModelState.IsValid)
                {
                    user.Status = true;

                    user.Password = EDPassword(user.Password, true);
                    User newUser = _iMapper.Map<User>(user);
                    bool isAdded = await _iUserManager.Create(newUser);
                    if (isAdded)
                    {

                        HttpContext.Session.SetString("ID", user.ID.ToString());
                        HttpContext.Session.SetString("Name", user.Name.ToString());
                        HttpContext.Session.SetString("Membership", "Customer");

                        return RedirectToAction("Index", "User");
                    }
                    else
                        ViewBag.ErrorMessage = "Failed to Sign Up";
                }
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = "Operation Failed. \nReason: " + ex.Message;
            }
            return View();
        }
        #endregion

        public IActionResult Logout()
        {
            HttpContext.Session.SetString("ID", "");
            HttpContext.Session.SetString("Name", "");
            HttpContext.Session.SetString("Membership", "");

            return RedirectToAction("Login", "User");
        }

        public IActionResult ResetPassword()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            #region Admin Check
            if (HttpContext.Session.GetString("Membership") != "Admin")
                return StatusCode(403, "Access Denied: You don not have the permission to access this resource");
            #endregion

            ViewBag.Roles = _iMapper.Map<IEnumerable<RoleViewModel>>(await _iRoleManager.GetAll());
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(UserViewModel user)
        {
            #region Admin Check
            if (HttpContext.Session.GetString("Membership") != "Admin")
                return StatusCode(403, "Access Denied: You don not have the permission to access this resource");
            #endregion

            if (ModelState.IsValid)
            {
                User AddUser = _iMapper.Map<User>(user);
                bool IsAdded = await _iUserManager.Create(AddUser);

                if (IsAdded)
                    return RedirectToAction("Index");
                else
                    ViewBag.ErrorMessage = "Failed to Create User";
            }
            ViewBag.Roles = _iMapper.Map<IEnumerable<RoleViewModel>>(await _iRoleManager.GetAll());
            return View(user);
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

            UserViewModel existUser = _iMapper.Map<UserViewModel>(await _iUserManager.GetById(id));

            if (existUser == null)
                return NotFound();

            ViewBag.Roles = _iMapper.Map<IEnumerable<RoleViewModel>>(await _iRoleManager.GetAll());
            return View(existUser);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UserViewModel ExistUser)
        {
            #region Admin Check
            if (HttpContext.Session.GetString("Membership") != "Admin")
                return StatusCode(403, "Access Denied: You don not have the permission to access this resource");
            #endregion

            if (ModelState.IsValid)
            {
                User user = _iMapper.Map<User>(ExistUser);

                bool IsUpdated = await _iUserManager.Update(user);

                if (IsUpdated)
                    return RedirectToAction("Index");
                else
                    ViewBag.ErrorMessage = "Failed to Update User";
            }
            ViewBag.Roles = _iMapper.Map<IEnumerable<RoleViewModel>>(await _iRoleManager.GetAll());
            return View(ExistUser);
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

            User existUser = await _iUserManager.GetById(id);

            if (existUser == null)
                return NotFound();

            bool remove = await _iUserManager.Remove(existUser);

            if (remove)
                return RedirectToAction("Index");
            else
                ViewBag.ErrorMessage = "Failed to Delete User";

            return BadRequest();
        }

        #region Encryption and Decryption
        private string EDPassword(string pass, bool en)
        {
            string password = "";
            try
            {

                if (pass != null)
                {
                    if (en)
                    {
                        #region Encrypt the password
                        password = pass;

                        #endregion
                    }
                    else
                    {
                        #region Decrypt the password
                        password = pass;

                        #endregion
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return password;
        }
        #endregion

        #region Session
        private IActionResult GetSetSession()
        {
            #region Admin Check
            if (HttpContext.Session.GetString("Membership") != "Admin")
                return StatusCode(403, "Access Denied: You do not have the permission to access this resource");
            #endregion

            #region User
            HttpContext.Session.SetString("ID", "");
            HttpContext.Session.SetString("Name", "");
            HttpContext.Session.SetString("Membership", "");
            #endregion

            return RedirectToAction("Index");
        }
        #endregion
    }
}

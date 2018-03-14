using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.Mvc;
using Nagarro.EmployeePortal.Shared;
using Nagarro.EmployeePortal.Web.Shared;

namespace Nagarro.EmployeePortal.Web
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View(new Login());
        }

        [HttpPost]
        public ActionResult Login(Login loginInfo)
        {
            ActionResult retVal = null;
            if (ModelState.IsValid)
            {
                IUserFacade userFacade = (IUserFacade)FacadeFactory.Instance.Create(FacadeType.UserManagerFacade);
                OperationResult<IUserDTO> loginResult = userFacade.Login(loginInfo.Username, loginInfo.Password);

                if (loginResult.IsValid())
                {
                    var userInfo = SessionStateManager<UserInfo>.Data;
                    FillDetailsOfLoggedInUser(loginResult.Data, userInfo);
                    retVal = RedirectToAction("Index", "Home");
                }
                else if (loginResult.HasValidationFailed() && (loginResult.ValidationResult != null))
                {
                    foreach (EmployeePortalValidationFailure error in loginResult.ValidationResult.Errors)
                    {
                        ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                    }
                    retVal = View(loginInfo);
                }
                else if (loginResult.HasFailed())
                {
                    ModelState.AddModelError("","Please enter valid username and password");
                    retVal = View(loginInfo);
                }
                else
                {
                    retVal = View("~/Views/Shared/Error.cshtml");
                }
            }
            return retVal;
        }

        [HttpGet]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Login");
        }

        [HttpGet]
        public ActionResult EditProfile()
        {
            User user = new User();
            user.UserId = SessionStateManager<UserInfo>.Data.UserId;
            user.Employee = new Employee();
            user.Employee.FirstName = SessionStateManager<UserInfo>.Data.Employee.FirstName;
            user.Employee.LastName = SessionStateManager<UserInfo>.Data.Employee.LastName;
            user.Employee.Email = SessionStateManager<UserInfo>.Data.Employee.Email;
            user.Employee.DateOfJoining = SessionStateManager<UserInfo>.Data.Employee.DateOfJoining;
            user.Employee.DepartmentId = SessionStateManager<UserInfo>.Data.Employee.DepartmentId;
            user.Employee.Departments = FillDepartmentsFromDepartmentList(user.Employee.DepartmentId);

            return View(user);
        }

        [HttpPost]
        public ActionResult EditProfile(User user)
        {
            ActionResult retVal = null;
            if (ModelState.IsValid)
            {
                bool isPasswordChanged = false;
                user.EmployeeId = SessionStateManager<UserInfo>.Data.EmployeeId;
                user.IsAdmin = SessionStateManager<UserInfo>.Data.IsAdmin;
                user.Employee.EmployeeId = SessionStateManager<UserInfo>.Data.Employee.EmployeeId;
                user.Employee.TerminationDate = SessionStateManager<UserInfo>.Data.Employee.TerminationDate;
                if (user.OldPassword != null)
                {
                    if ((user.OldPassword.Equals(SessionStateManager<UserInfo>.Data.Password)) && (user.NewPassword != null))
                    {
                        user.Password = user.NewPassword;
                        isPasswordChanged = true;
                    }
                }
                else
                {
                    user.Password = SessionStateManager<UserInfo>.Data.Password;
                }

                IUserDTO userDTO = (IUserDTO)DTOFactory.Instance.Create(DTOType.UserDTO);
                DTOConverter.FillDTOFromViewModel(userDTO, user);
                userDTO.EmployeeDTO = (IEmployeeDTO)DTOFactory.Instance.Create(DTOType.EmployeeDTO);
                DTOConverter.FillDTOFromViewModel(userDTO.EmployeeDTO, user.Employee);

                IUserFacade userFacade = (IUserFacade)FacadeFactory.Instance.Create(FacadeType.UserManagerFacade);
                OperationResult<IUserDTO> result = userFacade.UpdateProfile(userDTO);
                if (result.IsValid())
                {
                    if(isPasswordChanged)
                    {
                        retVal = RedirectToAction("Logout");
                    }
                    else
                    {
                        var userInfo = SessionStateManager<UserInfo>.Data;
                        FillDetailsOfLoggedInUser(result.Data, userInfo);
                        retVal = RedirectToAction("Index", "Home");
                    }
                }
                else if (result.HasValidationFailed() && (result.ValidationResult != null))
                {
                    foreach (EmployeePortalValidationFailure error in result.ValidationResult.Errors)
                    {
                        ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                    }
                    retVal = View(user);
                }
                else if (result.HasFailed())
                {
                    
                }
                else
                {
                    retVal = View("~/Views/Shared/Error.cshtml");
                }
            }
            return retVal;
        }

        [HttpGet]
        public ActionResult UnAuthorizeAccess()
        {
            return View();
        }

        [HttpGet]
        public ActionResult About()
        {
            return PartialView("~/Views/Shared/_About.cshtml");
        }

        [HttpGet]
        public ActionResult Contact()
        {
            return PartialView("~/Views/Shared/_Contact.cshtml");
        }

        #region privateActions
        private static void FillDetailsOfLoggedInUser(IUserDTO loginResult, UserInfo userInfo)
        {
            FormsAuthentication.SetAuthCookie(loginResult.EmployeeDTO.Email, false);
            DTOConverter.FillViewModelFromDTO(userInfo, loginResult);
            userInfo.Employee = new EmployeeInfo();
            DTOConverter.FillViewModelFromDTO(userInfo.Employee, loginResult.EmployeeDTO);
        }

        private IEnumerable<SelectListItem> FillDepartmentsFromDepartmentList(int selectedDepartmentId)
        {
            IDepartmentFacade departmentFacade = (IDepartmentFacade)FacadeFactory.Instance.Create(FacadeType.DepartmentManagerFacade);
            OperationResult<IList<IDepartmentDTO>> departmentList = departmentFacade.GetAllDepartments();

            IEnumerable<SelectListItem> departments = null;
            if (departmentList.IsValid())
            {
                departments = new List<SelectListItem>();
                departments = departmentList.Data.Select(dept => new SelectListItem
                {
                    Text = dept.DepartmentName,
                    Value = dept.DepartmentId.ToString(),
                    Selected = (dept.DepartmentId == selectedDepartmentId) ? true : false
                });
            }
            return departments;
        } 
        #endregion
    }
}
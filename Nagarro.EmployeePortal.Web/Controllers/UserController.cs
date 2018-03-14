using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Nagarro.EmployeePortal.Shared;
using Nagarro.EmployeePortal.Web.Shared;

namespace Nagarro.EmployeePortal.Web.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            return RedirectToAction("SearchEmployee");
        }

        //IUserDTO UpdateEmployee(IUserDTO userDTO);


        [HttpGet]
        [UserAuthorize(Roles ="Admin, NonAdmin")]
        public ActionResult SearchEmployee()
        {
            SearchEmployee searchEmployee = new SearchEmployee();
            searchEmployee.Departments = FillDepartmentsFromDepartmentList(null);
            return View(searchEmployee);
        }

        [HttpPost]
        [UserAuthorize(Roles = "Admin, NonAdmin")]
        public ActionResult SearchEmployee(SearchEmployee searchEmployee)
        {
            ActionResult retVal = null;

            if(ModelState.IsValid)
            {
                ISearchEmployeeDTO searchEmployeeDTO = (ISearchEmployeeDTO)DTOFactory.Instance.Create(DTOType.SearchEmployeeDTO);
                DTOConverter.FillDTOFromViewModel(searchEmployeeDTO, searchEmployee);

                IUserFacade userFacade = (IUserFacade)FacadeFactory.Instance.Create(FacadeType.UserManagerFacade);
                OperationResult<IList<IEmployeeDTO>> result = userFacade.SearchEmployeeByRawQuery(searchEmployeeDTO, (User.IsInRole("NonAdmin"))?true:false);

                if(result.IsValid())
                {
                    IList<Employee> employeeList = new List<Employee>();
                    Employee employee = null;

                    IDepartmentFacade departmentFacade = (IDepartmentFacade)FacadeFactory.Instance.Create(FacadeType.DepartmentManagerFacade);
                    //OperationResult<IList<IEmployeeDTO>> result = userFacade.SearchEmployeeByRawQuery(searchEmployeeDTO, true);

                    foreach (var employeeDTO in result.Data)
                    {
                        employee = new Employee();
                        DTOConverter.FillViewModelFromDTO(employee, employeeDTO);

                        OperationResult<IDepartmentDTO> department = departmentFacade.GetADepartment(employeeDTO.DepartmentId);
                        if (department.IsValid())
                        {
                            employee.Department = new Department();
                            DTOConverter.FillViewModelFromDTO(employee.Department, department.Data);
                        }

                        employeeList.Add(employee);
                    }

                    retVal = PartialView("~/Views/User/_SearchEmployeeList.cshtml", employeeList);
                }
                else if(result.HasFailed())
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
        [UserAuthorize(Roles ="Admin")]
        public ActionResult CreateEmployee()
        {
            User user = new User();
            user.Employee = new Employee();
            user.Employee.Departments = FillDepartmentsFromDepartmentList(null);
            ViewBag.Create = true;
            return PartialView("~/Views/User/_CreateEmployee.cshtml", user);
        }

        [HttpPost]
        [UserAuthorize(Roles = "Admin")]
        public ActionResult CreateEmployee(User user)
        {
            ActionResult retVal = null;
            if(ModelState.IsValid)
            {
                IUserDTO userDTO = (IUserDTO)DTOFactory.Instance.Create(DTOType.UserDTO);
                userDTO.EmployeeDTO = (IEmployeeDTO)DTOFactory.Instance.Create(DTOType.EmployeeDTO);

                DTOConverter.FillDTOFromViewModel(userDTO.EmployeeDTO, user.Employee);
                DTOConverter.FillDTOFromViewModel(userDTO, user);

                IUserFacade userFacade = (IUserFacade)FacadeFactory.Instance.Create(FacadeType.UserManagerFacade);
                OperationResult<IUserDTO> result = userFacade.CreateEmployeeByTransaction(userDTO);

                if (result.IsValid())
                {
                    retVal = new JsonResult()
                    {
                        Data = new
                        {
                            Message = "Employee created Successfully",
                            Success = true,
                            RedirectUrl = Url.Action("SearchEmployee", "User")
                        },
                        JsonRequestBehavior = JsonRequestBehavior.AllowGet
                    };
                }
                else if (result.HasValidationFailed() && (result.ValidationResult != null))
                {
                    foreach (EmployeePortalValidationFailure error in result.ValidationResult.Errors)
                    {
                        ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                    }
                    user.Employee.Departments = FillDepartmentsFromDepartmentList(user.Employee.DepartmentId);
                    retVal = PartialView("~/Views/User/_CreateEmployee.cshtml", user);
                    
                }
                else if (result.HasFailed())
                {
                    //retVal = RedirectToAction("GetActiveNotices", "Notice");
                    retVal = new JsonResult()
                    {
                        Data = new
                        {
                            Message = "Employee Creation failed",
                            Success = false,
                            RedirectUrl = Url.Action("SearchEmployee")
                        },
                        JsonRequestBehavior = JsonRequestBehavior.AllowGet
                    };
                }
                else
                {
                    retVal = View("~/Views/Shared/Error.cshtml");
                }
            }
            return retVal;
        }

        [HttpGet]
        [UserAuthorize(Roles = "Admin")]
        public ActionResult EditEmployee(string employeeEmail)
        {
            ActionResult retVal = null;
            IUserFacade userFacade = (IUserFacade)FacadeFactory.Instance.Create(FacadeType.UserManagerFacade);
            OperationResult<IUserDTO> result = userFacade.GetUserByEmailId(employeeEmail);
            if (result.IsValid())
            {
                User user = new User();
                DTOConverter.FillViewModelFromDTO(user, result.Data);

                user.Employee = new Employee();
                DTOConverter.FillViewModelFromDTO(user.Employee, result.Data.EmployeeDTO);

                user.Employee.Departments = FillDepartmentsFromDepartmentList(user.Employee.DepartmentId);
                ViewBag.Create = false;
                retVal = PartialView("~/Views/User/_CreateEmployee.cshtml", user);
            }
            else if (result.HasFailed())
            {
                retVal = RedirectToAction("SearchEmployee", "User");
            }
            else
            {
                retVal = View("~/Views/Shared/Error.cshtml");
            }
            return retVal;
        }

        [HttpPost]
        [UserAuthorize(Roles = "Admin")]
        public ActionResult EditEmployee(User user)
        {
            ActionResult retVal = null;
            if (ModelState.IsValid)
            {
                user.EmployeeId = user.Employee.EmployeeId;
                IUserDTO userDTO = (IUserDTO)DTOFactory.Instance.Create(DTOType.UserDTO);
                userDTO.EmployeeDTO = (IEmployeeDTO)DTOFactory.Instance.Create(DTOType.EmployeeDTO);

                DTOConverter.FillDTOFromViewModel(userDTO.EmployeeDTO, user.Employee);
                DTOConverter.FillDTOFromViewModel(userDTO, user);

                IUserFacade userFacade = (IUserFacade)FacadeFactory.Instance.Create(FacadeType.UserManagerFacade);
                OperationResult<IUserDTO> result = userFacade.UpdateEmployee(userDTO);

                if (result.IsValid())
                {
                    retVal = new JsonResult()
                    {
                        Data = new
                        {
                            Message = "Employee updated Successfully",
                            Success = true,
                            RedirectUrl = Url.Action("SearchEmployee", "User")
                        },
                        JsonRequestBehavior = JsonRequestBehavior.AllowGet
                    };
                }
                else if (result.HasValidationFailed() && (result.ValidationResult != null))
                {
                    foreach (EmployeePortalValidationFailure error in result.ValidationResult.Errors)
                    {
                        ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                    }
                    user.Employee.Departments = FillDepartmentsFromDepartmentList(user.Employee.DepartmentId);
                    retVal = PartialView("~/Views/User/_CreateEmployee.cshtml", user);

                }
                else if (result.HasFailed())
                {
                    retVal = new JsonResult()
                    {
                        Data = new
                        {
                            Message = "Employee updation failed",
                            Success = false,
                            RedirectUrl = Url.Action("SearchEmployee")
                        },
                        JsonRequestBehavior = JsonRequestBehavior.AllowGet
                    };
                }
                else
                {
                    retVal = View("~/Views/Shared/Error.cshtml");
                }
            }
            return retVal;
        }

        private IEnumerable<SelectListItem> FillDepartmentsFromDepartmentList(int? selectedDepartmentId)
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
    }
}
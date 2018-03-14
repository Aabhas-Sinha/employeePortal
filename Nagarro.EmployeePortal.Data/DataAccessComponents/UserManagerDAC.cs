using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nagarro.EmployeePortal.Shared;
using Nagarro.EmployeePortal.EntityDataModel.EntityModel;
using Nagarro.EmployeePortal.EntityDataModel;
using System.Transactions;
using System.Data.SqlClient;
using System.Data.Objects;
using System.Data.Entity;

namespace Nagarro.EmployeePortal.Data
{
    public class UserManagerDAC : DACBase, IUserDAC
    {
        public UserManagerDAC() : base(DACType.UserManagerDAC)
        {

        }


        public IUserDTO CreateEmployeeByTransaction(IUserDTO userDTO)
        {
            IUserDTO createEmployeeRetVal = null;
            try
            {
                using (EmployeePortal2017Entities portal = new EmployeePortal2017Entities())
                {
                    using (var transScope = new TransactionScope())
                    {
                        Employee employee = new Employee();
                        EntityConverter.FillEntityFromDTO(userDTO.EmployeeDTO, employee);
                        portal.Employees.Add(employee);
                        portal.SaveChanges();

                        userDTO.EmployeeId = employee.EmployeeId;
                        User user = new User();
                        EntityConverter.FillEntityFromDTO(userDTO, user);
                        portal.Users.Add(user);
                        portal.SaveChanges();

                        userDTO.UserId = user.UserId;
                        userDTO.EmployeeDTO.EmployeeId = userDTO.EmployeeId;
                        createEmployeeRetVal = userDTO;

                        transScope.Complete();
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex);
                throw new DACException(ex.Message);
            }
            return createEmployeeRetVal;
        }

        public IUserDTO CreateEmployeeBySProc(IUserDTO userDTO)
        {
            IUserDTO createEmployeeRetVal = null;
            try
            {
                using (EmployeePortal2017Entities portal = new EmployeePortal2017Entities())
                {
                    var objParam = new ObjectParameter("Id", typeof(int));
                    portal.CreateEmployee(userDTO.EmployeeDTO.FirstName, userDTO.EmployeeDTO.LastName,
                                          userDTO.EmployeeDTO.Email, userDTO.EmployeeDTO.DateOfJoining.ToString(),
                                          userDTO.EmployeeDTO.DepartmentId, userDTO.Password, userDTO.IsAdmin,
                                          objParam);
                    var user = portal.Users.Include("Employee").Where(u => u.UserId == (int)objParam.Value).SingleOrDefault();
                    if(user != null)
                    {
                        EntityConverter.FillDTOFromEntity(user, userDTO);
                        EntityConverter.FillDTOFromEntity(user.Employee, userDTO.EmployeeDTO);
                        createEmployeeRetVal = userDTO;
                    }                   
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex);
                throw new DACException(ex.Message);
            }
            return createEmployeeRetVal;
        }


        public IUserDTO GetUserByEmailId(string emailId)
        {
            IUserDTO userDTO = null;
            try
            {
                using (EmployeePortal2017Entities portal = new EmployeePortal2017Entities())
                {
                    var user = portal.Users.Include("Employee").Where(u => u.Employee.Email.Equals(emailId)).SingleOrDefault();
                    if (user != null)
                    {
                        userDTO = (IUserDTO)DTOFactory.Instance.Create(DTOType.UserDTO);
                        EntityConverter.FillDTOFromEntity(user, userDTO);

                        userDTO.EmployeeDTO = (IEmployeeDTO)DTOFactory.Instance.Create(DTOType.EmployeeDTO);
                        EntityConverter.FillDTOFromEntity(user.Employee, userDTO.EmployeeDTO);
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex);
                throw new DACException(ex.Message);
            }
            return userDTO;
        }


        public IUserDTO Login(string username, string password)
        {
            IUserDTO userDTO = null;
            try
            {
                using (EmployeePortal2017Entities portal = new EmployeePortal2017Entities())
                {
                    User userEntity = new User();
                    userEntity.Employee = new Employee();
                    IUserDTO user = (IUserDTO)DTOFactory.Instance.Create(DTOType.UserDTO);
                    user.EmployeeDTO = (IEmployeeDTO)DTOFactory.Instance.Create(DTOType.EmployeeDTO);
                    user = GetUserByEmailId(username);

                    EntityConverter.FillEntityFromDTO(user, userEntity);
                    EntityConverter.FillEntityFromDTO(user.EmployeeDTO, userEntity.Employee);
                    if (user != null) {
                        userDTO = (IUserDTO)DTOFactory.Instance.Create(DTOType.UserDTO);
                        EntityConverter.FillDTOFromEntity(userEntity, userDTO);
                        userDTO.EmployeeDTO = (IEmployeeDTO)DTOFactory.Instance.Create(DTOType.EmployeeDTO);
                        
                        EntityConverter.FillDTOFromEntity(userEntity.Employee, userDTO.EmployeeDTO);
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex);
                throw new DACException(ex.Message);
            }
            return userDTO;
        }


        public IList<IEmployeeDTO> SearchEmployeeByRawQuery(ISearchEmployeeDTO searchEmployeeDTO, bool checkTerminationDate)
        {           
            IList<IEmployeeDTO> retVal = null;

            string query = @"SELECT * 
                            FROM Employees
                            WHERE
                            (
	                            (@FirstName IS NOT NULL AND  FirstName LIKE '%' + @FirstName + '%') OR
	                            (@LastName IS NOT NULL AND  LastName LIKE '%' + @LastName + '%') OR
	                            (@Email IS NOT NULL AND  Email LIKE '%' + @Email + '%') OR
	                            (@BeginDate IS NOT NULL AND  DateOfJoining >= @BeginDate ) OR
	                            (@EndDate IS NOT NULL AND  DateOfJoining <= @EndDate) OR
	                            (@Department IS NOT NULL AND  DepartmentId = @Department) 
                            )" + (checkTerminationDate ? "AND TerminationDate IS NULL" : string.Empty);
            try
            {
                using (EmployeePortal2017Entities portal = new EmployeePortal2017Entities())
                {
                    var firstNameParameter = searchEmployeeDTO.Firstname != null ?
                        new SqlParameter("FirstName", searchEmployeeDTO.Firstname) :
                        new SqlParameter("FirstName", DBNull.Value);

                    var lastNameParameter = searchEmployeeDTO.LastName != null ?
                        new SqlParameter("LastName", searchEmployeeDTO.LastName) :
                        new SqlParameter("LastName", DBNull.Value);

                    var emailParameter = searchEmployeeDTO.Email != null ?
                        new SqlParameter("Email", searchEmployeeDTO.Email) :
                    new SqlParameter("Email", DBNull.Value);

                    var startDateParameter = searchEmployeeDTO.BeginDate.HasValue ?
                        new SqlParameter("BeginDate", searchEmployeeDTO.BeginDate) :
                        new SqlParameter("BeginDate", DBNull.Value);

                    var endDateParameter = searchEmployeeDTO.Enddate.HasValue ?
                        new SqlParameter("EndDate", searchEmployeeDTO.Enddate) :
                        new SqlParameter("EndDate", DBNull.Value);

                    var departmentIdParameter = searchEmployeeDTO.DepartmentId.HasValue ?
                        new SqlParameter("Department", searchEmployeeDTO.DepartmentId) :
                        new SqlParameter("Department", DBNull.Value);

                    IList<Employee> employeeList = new List<Employee>();
                    employeeList = portal.ObjectContext.ExecuteStoreQuery<Employee>(query, new object[] { firstNameParameter,
                                                                lastNameParameter, emailParameter, startDateParameter,
                                                                endDateParameter, departmentIdParameter })
                                                        .ToList();
                    if(employeeList.Count > 0)
                    {
                        retVal = new List<IEmployeeDTO>();
                        foreach (var employee in employeeList)
                        {
                            IEmployeeDTO employeeDTO = (IEmployeeDTO)DTOFactory.Instance.Create(DTOType.EmployeeDTO);
                            EntityConverter.FillDTOFromEntity(employee, employeeDTO);
                            retVal.Add(employeeDTO);
                        }
                    }                    
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex);
                throw new DACException(ex.Message);
            }
            return retVal;
        }

        
        public IUserDTO UpdateEmployee(IUserDTO userDTO)
        {
            IUserDTO retVal = null;

            try
            {
                using (EmployeePortal2017Entities portal = new EmployeePortal2017Entities())
                {
                    var user = portal.Users.Include("Employee").Where(u => u.EmployeeId == userDTO.EmployeeDTO.EmployeeId).SingleOrDefault();
                    if (user != null)
                    {
                        userDTO.UserId = user.UserId;
                        EntityConverter.FillEntityFromDTO(userDTO.EmployeeDTO, user.Employee);
                        EntityConverter.FillEntityFromDTO(userDTO, user);
                        portal.SaveChanges();
                        retVal = userDTO;
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex);
                throw new DACException(ex.Message);
            }
            return retVal;
        }


        public IUserDTO UpdateProfile(IUserDTO userDTO)
        {
            IUserDTO retVal = null;

            try
            {
                using (EmployeePortal2017Entities portal = new EmployeePortal2017Entities())
                {
                    var user = portal.Users.Include("Employee").Where(u => u.EmployeeId == userDTO.EmployeeDTO.EmployeeId).SingleOrDefault();
                    if (user != null)
                    {
                        userDTO.UserId = user.UserId;
                        EntityConverter.FillEntityFromDTO(userDTO, user);
                        EntityConverter.FillEntityFromDTO(userDTO.EmployeeDTO, user.Employee);
                        
                        portal.SaveChanges();
                        retVal = userDTO;
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex);
                throw new DACException(ex.Message);
            }
            return retVal;
        }


        public IList<IUserDTO> GetAdmins()
        {
            IList<IUserDTO> userDTOList = null;
            try
            {
                using (EmployeePortal2017Entities portal = new EmployeePortal2017Entities())
                {
                    var userList = portal.Users.Include("Employee").Where(u => u.IsAdmin == true).ToList();
                    if (userList.Count > 0)
                    {
                        userDTOList = new List<IUserDTO>();
                        IUserDTO userDTO = null;
                        foreach(var user in userList)
                        {
                            userDTO = (IUserDTO)DTOFactory.Instance.Create(DTOType.UserDTO);
                            EntityConverter.FillDTOFromEntity(user, userDTO);

                            userDTO.EmployeeDTO = (IEmployeeDTO)DTOFactory.Instance.Create(DTOType.EmployeeDTO);
                            EntityConverter.FillDTOFromEntity(user.Employee, userDTO.EmployeeDTO);

                            userDTOList.Add(userDTO);
                        }
                        
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex);
                throw new DACException(ex.Message);
            }
            return userDTOList;
        }
    }
}

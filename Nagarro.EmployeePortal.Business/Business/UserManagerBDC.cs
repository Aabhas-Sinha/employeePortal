using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nagarro.EmployeePortal.Shared;

namespace Nagarro.EmployeePortal.Business
{
    public class UserManagerBDC : BDCBase, IUserBDC
    {
        public UserManagerBDC() 
            : base(BDCType.UserManagerBDC)
        {

        }

        public OperationResult<IUserDTO> CreateEmployeeByTransaction(IUserDTO userDTO)
        {
            OperationResult<IUserDTO> getUserReturnValue = null;
            try
            {
                EmployeePortalValidationResult validationResult = Validator<UserValidator, IUserDTO>.Validate(userDTO, ValidationConstants.CreateEmployee + "," + ValidationConstants.CommomUservalidations + "," + ValidationConstants.UpdateCreateUser);

                if (!validationResult.IsValid)
                {
                    getUserReturnValue = OperationResult<IUserDTO>.CreateFailureResult(validationResult);
                }
                else
                {
                    IUserDAC userDAC = (IUserDAC)DACFactory.Instance.Create(DACType.UserManagerDAC);
                    userDTO = userDAC.CreateEmployeeByTransaction(userDTO);
                    if (userDTO != null)
                    {
                        getUserReturnValue = OperationResult<IUserDTO>.CreateSuccessResult(userDTO);
                    }
                    else
                    {
                        getUserReturnValue = OperationResult<IUserDTO>.CreateFailureResult("creation Failed");
                    }
                }
            }
            catch (DACException dacEx)
            {
                getUserReturnValue = OperationResult<IUserDTO>.CreateErrorResult(dacEx.Message, dacEx.StackTrace);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex);
                getUserReturnValue = OperationResult<IUserDTO>.CreateErrorResult(ex.Message, ex.StackTrace);
            }
            return getUserReturnValue;
        }

        public OperationResult<IUserDTO> CreateEmployeeBySProc(IUserDTO userDTO)
        {
            OperationResult<IUserDTO> getUserReturnValue = null;
            try
            {
                EmployeePortalValidationResult validationResult = Validator<UserValidator, IUserDTO>.Validate(userDTO, ValidationConstants.CreateEmployee + "," + ValidationConstants.CommomUservalidations + "," + ValidationConstants.UpdateCreateUser);

                if (!validationResult.IsValid)
                {
                    getUserReturnValue = OperationResult<IUserDTO>.CreateFailureResult(validationResult);
                }
                else
                {
                    IUserDAC userDAC = (IUserDAC)DACFactory.Instance.Create(DACType.UserManagerDAC);
                    userDTO = userDAC.CreateEmployeeBySProc(userDTO);
                    if (userDTO != null)
                    {
                        getUserReturnValue = OperationResult<IUserDTO>.CreateSuccessResult(userDTO);
                    }
                    else
                    {
                        getUserReturnValue = OperationResult<IUserDTO>.CreateFailureResult("creation Failed");
                    }
                }
            }
            catch (DACException dacEx)
            {
                getUserReturnValue = OperationResult<IUserDTO>.CreateErrorResult(dacEx.Message, dacEx.StackTrace);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex);
                getUserReturnValue = OperationResult<IUserDTO>.CreateErrorResult(ex.Message, ex.StackTrace);
            }
            return getUserReturnValue;
        }

        public OperationResult<IUserDTO> GetUserByEmailId(string emailId)
        {
            OperationResult<IUserDTO> getUserReturnValue = null;
            try
            {
                IUserDAC userDAC = (IUserDAC)DACFactory.Instance.Create(DACType.UserManagerDAC);
                IUserDTO userDTO = userDAC.GetUserByEmailId(emailId);
                if (userDTO != null)
                {
                    getUserReturnValue = OperationResult<IUserDTO>.CreateSuccessResult(userDTO);
                }
                else
                {
                    getUserReturnValue = OperationResult<IUserDTO>.CreateFailureResult("Get User By Email Id Method Failed");
                }
            }
            catch (DACException dacEx)
            {
                getUserReturnValue = OperationResult<IUserDTO>.CreateErrorResult(dacEx.Message, dacEx.StackTrace);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex);
                getUserReturnValue = OperationResult<IUserDTO>.CreateErrorResult(ex.Message, ex.StackTrace);
            }
            return getUserReturnValue;
        }

        public OperationResult<IUserDTO> Login(string username, string password)
        {
            OperationResult<IUserDTO> getUserReturnValue = null;
            try
            {
                IUserDAC userDAC = (IUserDAC)DACFactory.Instance.Create(DACType.UserManagerDAC);
                IUserDTO userDTO = userDAC.Login(username,password);
                if (userDTO != null)
                {
                    getUserReturnValue = OperationResult<IUserDTO>.CreateSuccessResult(userDTO);
                }
                else
                {
                    getUserReturnValue = OperationResult<IUserDTO>.CreateFailureResult("Login Failed");
                }
            }
            catch (DACException dacEx)
            {
                getUserReturnValue = OperationResult<IUserDTO>.CreateErrorResult(dacEx.Message, dacEx.StackTrace);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex);
                getUserReturnValue = OperationResult<IUserDTO>.CreateErrorResult(ex.Message, ex.StackTrace);
            }
            return getUserReturnValue;
        }

        public OperationResult<IList<IEmployeeDTO>> SearchEmployeeByRawQuery(ISearchEmployeeDTO employeeDTO, bool checkTerminationDate)
        {
            OperationResult<IList<IEmployeeDTO>> searchEmployee = null;
      
            try
            {
                IUserDAC userDAC = (IUserDAC)DACFactory.Instance.Create(DACType.UserManagerDAC);
                IList<IEmployeeDTO> userDTOList = userDAC.SearchEmployeeByRawQuery(employeeDTO, checkTerminationDate);
                if (userDTOList != null)
                {
                    searchEmployee = OperationResult<IList<IEmployeeDTO>>.CreateSuccessResult(userDTOList);
                }
                else
                {
                    searchEmployee = OperationResult<IList<IEmployeeDTO>>.CreateFailureResult("SearchEmployeeByRawQuery Method Failed");
                }
            }
            catch (DACException dacEx)
            {
                searchEmployee = OperationResult<IList<IEmployeeDTO>>.CreateErrorResult(dacEx.Message, dacEx.StackTrace);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex);
                searchEmployee = OperationResult<IList<IEmployeeDTO>>.CreateErrorResult(ex.Message, ex.StackTrace);
            }
            return searchEmployee;
        }



        public OperationResult<IUserDTO> UpdateEmployee(IUserDTO userDTO)
        {
            OperationResult<IUserDTO> updateEmployeeReturnValue = null;
            try
            {
                EmployeePortalValidationResult validationResult = Validator<UserValidator, IUserDTO>.Validate(userDTO, ValidationConstants.UpdateEmployee + "," + ValidationConstants.CommomUservalidations + "," + ValidationConstants.UpdateCreateUser);

                if (!validationResult.IsValid)
                {
                    updateEmployeeReturnValue = OperationResult<IUserDTO>.CreateFailureResult(validationResult);
                }
                else
                {
                    IUserDAC userDAC = (IUserDAC)DACFactory.Instance.Create(DACType.UserManagerDAC);
                    IUserDTO returnedUserDTO = userDAC.UpdateEmployee(userDTO);
                    if (returnedUserDTO != null)
                    {
                        updateEmployeeReturnValue = OperationResult<IUserDTO>.CreateSuccessResult(returnedUserDTO, "Profile updated successfully");
                    }
                }
            }
            catch (DACException dacEx)
            {
                updateEmployeeReturnValue = OperationResult<IUserDTO>.CreateErrorResult(dacEx.Message, dacEx.StackTrace);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex);
                updateEmployeeReturnValue = OperationResult<IUserDTO>.CreateErrorResult(ex.Message, ex.StackTrace);
            }

            return updateEmployeeReturnValue;
        }

        public OperationResult<IUserDTO> UpdateProfile(IUserDTO userDTO)
        {
            OperationResult<IUserDTO> updateProfileReturnValue = null;
            try
            {
                EmployeePortalValidationResult validationResult = Validator<UserValidator, IUserDTO>.Validate(userDTO, ValidationConstants.CommomUservalidations);

                if (!validationResult.IsValid)
                {
                    updateProfileReturnValue = OperationResult<IUserDTO>.CreateFailureResult(validationResult);
                }
                else
                {
                    IUserDAC userDAC = (IUserDAC)DACFactory.Instance.Create(DACType.UserManagerDAC);
                    IUserDTO returnedUserDTO = userDAC.UpdateProfile(userDTO);
                    if (returnedUserDTO != null)
                    {
                        updateProfileReturnValue = OperationResult<IUserDTO>.CreateSuccessResult(returnedUserDTO, "Profile updated successfully");
                    }
                }
            }
            catch (DACException dacEx)
            {
                updateProfileReturnValue = OperationResult<IUserDTO>.CreateErrorResult(dacEx.Message, dacEx.StackTrace);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex);
                updateProfileReturnValue = OperationResult<IUserDTO>.CreateErrorResult(ex.Message, ex.StackTrace);
            }

            return updateProfileReturnValue;
        }

        public OperationResult<IList<IUserDTO>> GetAdmins()
        {
            OperationResult<IList<IUserDTO>> getUserReturnValue = null;
            try
            {
                IUserDAC userDAC = (IUserDAC)DACFactory.Instance.Create(DACType.UserManagerDAC);
                IList<IUserDTO> userDTOList = userDAC.GetAdmins();
                if (userDTOList != null)
                {
                    getUserReturnValue = OperationResult<IList<IUserDTO>>.CreateSuccessResult(userDTOList);
                }
                else
                {
                    getUserReturnValue = OperationResult<IList<IUserDTO>>.CreateFailureResult("Get Admins method failed.");
                }
            }
            catch (DACException dacEx)
            {
                getUserReturnValue = OperationResult<IList<IUserDTO>>.CreateErrorResult(dacEx.Message, dacEx.StackTrace);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex);
                getUserReturnValue = OperationResult<IList<IUserDTO>>.CreateErrorResult(ex.Message, ex.StackTrace);
            }
            return getUserReturnValue;
        }
    }
}

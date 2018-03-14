using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nagarro.EmployeePortal.Shared;

namespace Nagarro.EmployeePortal.Business
{
    public class DepartmentManagerBDC : BDCBase, IDepartmentBDC
    {
        public DepartmentManagerBDC() : base(BDCType.DepartmentManagerBDC)
        {
        }

        public OperationResult<IDepartmentDTO> GetADepartment(int departmentId)
        {
            OperationResult<IDepartmentDTO> getDepartmentReturnValue = null;
            try
            {
                IDepartmentDAC departmentDAC = (IDepartmentDAC)DACFactory.Instance.Create(DACType.DepartmentManagerDAC);
                IDepartmentDTO departmentDTO = departmentDAC.GetADepartment(departmentId);
                if (departmentDTO != null)
                {
                    getDepartmentReturnValue = OperationResult<IDepartmentDTO>.CreateSuccessResult(departmentDTO);
                }
                else
                {
                    getDepartmentReturnValue = OperationResult<IDepartmentDTO>.CreateFailureResult("Get Department Method Failed");
                }
            }
            catch (DACException dacEx)
            {
                getDepartmentReturnValue = OperationResult<IDepartmentDTO>.CreateErrorResult(dacEx.Message, dacEx.StackTrace);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex);
                getDepartmentReturnValue = OperationResult<IDepartmentDTO>.CreateErrorResult(ex.Message, ex.StackTrace);
            }
            return getDepartmentReturnValue;
        }

        public OperationResult<IList<IDepartmentDTO>> GetAllDepartments()
        {
            OperationResult<IList<IDepartmentDTO>> getAllDepartmentsReturnValue = null;
            try
            {
                IDepartmentDAC departmentDAC = (IDepartmentDAC)DACFactory.Instance.Create(DACType.DepartmentManagerDAC);
                IList<IDepartmentDTO> departmentDTOList = departmentDAC.GetAllDepartments();
                if (departmentDTOList != null)
                {
                    getAllDepartmentsReturnValue = OperationResult<IList<IDepartmentDTO>>.CreateSuccessResult(departmentDTOList);
                }
                else
                {
                    getAllDepartmentsReturnValue = OperationResult<IList<IDepartmentDTO>>.CreateFailureResult("Get All Departments Method Failed");
                }
            }
            catch (DACException dacEx)
            {
                getAllDepartmentsReturnValue = OperationResult<IList<IDepartmentDTO>>.CreateErrorResult(dacEx.Message, dacEx.StackTrace);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex);
                getAllDepartmentsReturnValue = OperationResult<IList<IDepartmentDTO>>.CreateErrorResult(ex.Message, ex.StackTrace);
            }
            return getAllDepartmentsReturnValue;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nagarro.EmployeePortal.Shared;
using Nagarro.EmployeePortal.EntityDataModel.EntityModel;
using Nagarro.EmployeePortal.EntityDataModel;

namespace Nagarro.EmployeePortal.Data
{
    public class DepartmentManagerDAC : DACBase, IDepartmentDAC
    {
        /// <summary>
        /// ctor
        /// </summary>
        public DepartmentManagerDAC()
            : base(DACType.DepartmentManagerDAC)
        {

        }

        /// <summary>
        /// Used wherever a specific department is required.
        /// </summary>
        /// <param name="departmentId"></param>
        /// <returns></returns>
        public IDepartmentDTO GetADepartment(int departmentId)
        {
            IDepartmentDTO departmentDTO = null;
            using (EmployeePortal2017Entities portal = new EmployeePortal2017Entities())
            {
                try
                {
                    var department = portal.Departments.Where(d => d.DepartmentId == departmentId)
                                                       .SingleOrDefault<Department>();

                    departmentDTO = (IDepartmentDTO)DTOFactory.Instance.Create(DTOType.DepartmentDTO); ;
                    if (department != null)
                    {
                        EntityConverter.FillDTOFromEntity(department, departmentDTO);
                    }
                }
                catch (Exception ex)
                {
                    ExceptionManager.HandleException(ex);
                    throw new DACException(ex.Message);
                }
            }
            return departmentDTO;
        }

        /// <summary>
        /// Used wherever a list of departments is required
        /// </summary>
        /// <returns></returns>
        public IList<IDepartmentDTO> GetAllDepartments()
        {
            IList<IDepartmentDTO> departmentDTOList = null;
            using (EmployeePortal2017Entities portal = new EmployeePortal2017Entities())
            {
                try
                {
                    departmentDTOList = new List<IDepartmentDTO>();
                    IDepartmentDTO departmentDTO;
                    foreach (Department department in portal.Departments)
                    {
                        departmentDTO = (IDepartmentDTO)DTOFactory.Instance.Create(DTOType.DepartmentDTO);
                        EntityConverter.FillDTOFromEntity(department, departmentDTO);
                        departmentDTOList.Add(departmentDTO);
                    }
                }
                catch (Exception ex)
                {
                    ExceptionManager.HandleException(ex);
                    throw new DACException(ex.Message);
                }
            }
            return departmentDTOList;
        }
    }
}

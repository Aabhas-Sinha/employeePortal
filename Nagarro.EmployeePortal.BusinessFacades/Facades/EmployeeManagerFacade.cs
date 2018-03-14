using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nagarro.EmployeePortal.Shared;

namespace Nagarro.EmployeePortal.BusinessFacades
{
    public class EmployeeManagerFacade : FacadeBase, IEmployeeFacade
    {
        public EmployeeManagerFacade() : base(FacadeType.EmployeeManagerFacade)
        {

        }
    }
}

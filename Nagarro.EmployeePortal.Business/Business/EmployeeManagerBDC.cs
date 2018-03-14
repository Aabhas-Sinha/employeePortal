
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nagarro.EmployeePortal.Shared;

namespace Nagarro.EmployeePortal.Business
{
    public class EmployeeManagerBDC : BDCBase, IEmployeeBDC
    {
        public EmployeeManagerBDC() : base(BDCType.EmployeeManagerBDC)
        {

        }
    }
}

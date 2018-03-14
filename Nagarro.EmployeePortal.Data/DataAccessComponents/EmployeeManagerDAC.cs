using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nagarro.EmployeePortal.Shared;
using Nagarro.EmployeePortal.EntityDataModel;
using Nagarro.EmployeePortal.EntityDataModel.EntityModel;

namespace Nagarro.EmployeePortal.Data
{
    public class EmployeeManagerDAC : DACBase, IEmployeeDAC
    {
        public EmployeeManagerDAC() : base(DACType.EmployeeManagerDAC)
        {

        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nagarro.EmployeePortal.Web.Shared
{
   public interface IViewFactory
    {

       IViewModel Create(ViewType type, params object[] args);
    }
}

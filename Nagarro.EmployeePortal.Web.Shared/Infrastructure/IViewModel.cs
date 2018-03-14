
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Nagarro.EmployeePortal.Web.Shared
{
    public interface IViewModel : ICloneable, INotifyPropertyChanged, INotifyPropertyChanging
    {

        ObjectStateType ObjectState { get; set; }

        /// <summary>
        /// gets the unique ID.
        /// </summary>
        /// <value>The unique ID.</value>        
        Guid? UniqueID { get; }

       ViewType Type { get; }
    }
}

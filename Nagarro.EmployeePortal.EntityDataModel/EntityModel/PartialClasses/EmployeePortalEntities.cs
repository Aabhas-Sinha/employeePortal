namespace Nagarro.EmployeePortal.EntityDataModel.EntityModel
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    public partial class EmployeePortal2017Entities
    {
        public System.Data.Objects.ObjectContext ObjectContext
        {
            get
            {
                return ((IObjectContextAdapter)this).ObjectContext;
            }
        }
    }

    public static class EntityExtensions
    {
        public static System.Data.Objects.ObjectContext ToObjectContext(this DbContext context)
        {
            return ((IObjectContextAdapter)context).ObjectContext;
        }
    }
}
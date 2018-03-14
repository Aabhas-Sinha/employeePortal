using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Nagarro.EmployeePortal.Web
{
    public class SearchEmployee
    {
        public string Firstname { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime? BeginDate { get; set; }
        public DateTime? Enddate { get; set; }
        public int? DepartmentId { get; set; }

        public IEnumerable<SelectListItem> Departments { get; set; }
    }
}
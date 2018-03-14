using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Web;
using Nagarro.EmployeePortal.Shared;

namespace Nagarro.EmployeePortal.Web
{
    public class ComplexIssueHistory
    {
        public int IssueHistoryId { get; set; }
        public int IssueId { get; set; }
        public string Comments { get; set; }
        public int ModifiedBy { get; set; }
        public System.DateTime ModifiedOn { get; set; }
        public Nullable<int> AssignedTo { get; set; }
        public int Status { get; set; }

        [Display(Name = "Assigned Admin")]
        public string AssignedToName { get; set; }

        [Display(Name = "Status")]
        public IssueStatus IssueStatus { get; set; }
    }
}
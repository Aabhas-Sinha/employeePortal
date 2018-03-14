using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Nagarro.EmployeePortal.Shared;

namespace Nagarro.EmployeePortal.Web
{
    public class ComplexIssue
    {
        public int IssueId { get; set; }
        public string Title { get; set; }
        public int Priority { get; set; }
        public int PostedBy { get; set; }
        public string Description { get; set; }
        public Nullable<int> AssignedTo { get; set; }
        public int Status { get; set; }
        public bool IsActive { get; set; }

        [Display(Name ="Posted By")]
        public string PostedByName { get; set; }

        [Display(Name ="Assigned Admin")]
        public string AssignedToName { get; set; }

        [Display(Name = "Priority")]
        public IssuePriority IssuePriority { get; set; }

        [Display(Name ="Status")]
        public IssueStatus IssueStatus { get; set; }
    }
}
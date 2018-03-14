using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Nagarro.EmployeePortal.Shared;

namespace Nagarro.EmployeePortal.Web
{
    public class Issue
    {
        public int IssueId { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        [Required]
        [StringLength(500)]
        public string Description { get; set; }

        public int PostedBy { get; set; }

        public int Priority { get; set; }

        public bool IsActive { get; set; }

        [Display(Name ="Priority")]
        [Required]
        public IssuePriority IssuePriority { get; set; }

        public IList<ComplexIssueHistory> IssueHistories { get; set; }

        public Employee Employee { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Nagarro.EmployeePortal.Shared;

namespace Nagarro.EmployeePortal.Web
{
    public class IssueHistory
    {
        public int IssueHistoryId { get; set; }
        public int IssueId { get; set; }

        [StringLength(500)]
        public string Comments { get; set; }

        public int ModifiedBy { get; set; }

        public DateTime ModifiedOn { get; set; }

        [Required]
        [Display(Name ="Assigned Admin")]
        public int? AssignedTo { get; set; }

        public int Status { get; set; }

        [Required]
        [Display(Name = "Status")]
        public IssueStatus IssueStatus { get; set; }

        [Display(Name = "Assigned Admin")]
        public IEnumerable<SelectListItem> AdminEmployees { get; set; }
    }
}
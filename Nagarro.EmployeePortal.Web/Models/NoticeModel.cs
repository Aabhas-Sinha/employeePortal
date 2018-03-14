using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Nagarro.EmployeePortal.Web
{
    public class NoticeModel
    {
        public int NoticeId { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        [Required]
        [StringLength(500)]
        public string Description { get; set; }

        public int PostedBy { get; set; }

        [Required]
        [Display(Name ="Start Date")]
        public DateTime StartDate { get; set; }

        [Required]
        [Display(Name = "Expiration Date")]
        public DateTime ExpirationDate { get; set; }

        public bool IsActive { get; set; }

        [Display(Name = "Notice Posted By")]
        public string NotifierEmployeeName { get; set; }
    }
}
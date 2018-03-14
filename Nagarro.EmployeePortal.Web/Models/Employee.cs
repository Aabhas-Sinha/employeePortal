using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Nagarro.EmployeePortal.Web
{
    public class Employee
    {
        public int EmployeeId { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(100)]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Date Of Joining")]
        public DateTime DateOfJoining { get; set; }

        [Display(Name = "Termination Date")]
        public DateTime? TerminationDate { get; set; }

        [Required]
        [Display(Name ="Department")]
        public int DepartmentId { get; set; }

        public Department Department { get; set; }

        public IEnumerable<SelectListItem> Departments { get; set; }

    }
}
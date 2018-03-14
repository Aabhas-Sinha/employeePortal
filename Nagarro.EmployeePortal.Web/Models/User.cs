using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Nagarro.EmployeePortal.Web
{
    public class User
    {
        public int UserId { get; set; }

        public int EmployeeId { get; set; }

        [RegularExpression(@"^(?=.*\d+)(?=.*[a-zA-Z])[0-9a-zA-Z!@#$%&^*~.?]{8,16}$")]
        public string Password { get; set; }

        public string OldPassword { get; set; }

        [RegularExpression(@"^(?=.*\d+)(?=.*[a-zA-Z])[0-9a-zA-Z!@#$%&^*~.?]{8,16}$", ErrorMessage ="Password shoud contain atleast one numeric and one special charactere and should be between 8 & 16 characters long")]
        public string NewPassword { get; set; }

        [Compare("NewPassword")]
        public string ConfirmPassword { get; set; }

        [Required]
        public bool IsAdmin { get; set; }

        public Employee Employee { get; set; }

        public string Role { get; set; }
    }
}
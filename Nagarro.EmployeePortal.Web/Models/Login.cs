using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Nagarro.EmployeePortal.Web
{
    public class Login
    {
        [Required]
        [EmailAddress(ErrorMessage ="Please enter valid username and password")]
        public string Username { get; set; }

        [Required]
        [RegularExpression(@"^(?=.*\d+)(?=.*[a-zA-Z])[0-9a-zA-Z!@#$%&^*~.?]{8,16}$", ErrorMessage = "Please enter valid username and password")]
        public String Password { get; set; }

        public string Role { get; set; }
    }
}
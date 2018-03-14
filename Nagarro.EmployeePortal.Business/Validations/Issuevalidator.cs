using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Nagarro.EmployeePortal.Shared;

namespace Nagarro.EmployeePortal.Business
{
   public class Issuevalidator: AbstractValidator<IIssueDTO>
    {
        public Issuevalidator()
        {
            RuleSet(ValidationConstants.UpdateIssue,()=>
            {
                RuleFor(issue => issue.Title).NotEmpty().Length(1, 100);
                RuleFor(issue => issue.Description).NotEmpty().Length(1, 500);
                RuleFor(issue => (IssuePriority)issue.Priority).NotEmpty().IsInEnum();
            }
            );

        }
    }
}

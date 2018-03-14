using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Nagarro.EmployeePortal.Shared;

namespace Nagarro.EmployeePortal.Business
{
   public class IssueHistoryValidator: AbstractValidator<IIssueHistoryDTO>
    {
        public IssueHistoryValidator()
        {
            RuleSet(ValidationConstants.UpdateIssueHistory, () =>
            {
                RuleFor(ih => ih.Comments).Length(1, 500);
                RuleFor(ih => ih.AssignedTo).NotNull();
                RuleFor(ih => (IssueStatus)ih.Status).IsInEnum();
            });
            
        }
    }
}

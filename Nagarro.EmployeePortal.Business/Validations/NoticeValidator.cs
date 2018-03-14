using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nagarro.EmployeePortal.Shared;
using FluentValidation;

namespace Nagarro.EmployeePortal.Business
{
    public class NoticeValidator : AbstractValidator<INoticeDTO>
    {
        public NoticeValidator()
        {
            RuleSet(ValidationConstants.Common, () =>
            {
                RuleFor(notice => notice.Title).NotEmpty().WithMessage("Title should not be empty.").Length(1, 100).WithMessage("Title should be less than 100 characters").WithName("Title");

                RuleFor(notice => notice.Description).NotEmpty().WithMessage("Description should not be empty.").Length(1, 500).WithMessage("Title should be less than 500 characters").WithName("Description");

                RuleFor(notice => notice.PostedBy).NotEmpty().WithMessage("PostedBy should not be empty.").WithName("PostedBy");

                RuleFor(notice => notice.StartDate).NotEmpty().WithMessage("start date should not be empty.").WithName("StartDate");

                RuleFor(notice => notice.ExpirationDate).NotEmpty().WithMessage("ExpirationDate should not be empty.").WithName("ExpirationDate")
                    .GreaterThanOrEqualTo(notice => notice.StartDate).WithMessage("ExpirationDate cannot be less than start date");

            });

            RuleSet(ValidationConstants.CreateNotice, () =>
            {

                RuleFor(notice => notice.StartDate).GreaterThanOrEqualTo(DateTime.Now.Date).WithName("StartDate");

            });


        }
    }
}

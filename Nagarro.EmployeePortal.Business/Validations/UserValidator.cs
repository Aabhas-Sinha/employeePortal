using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Nagarro.EmployeePortal.Shared;

namespace Nagarro.EmployeePortal.Business
{
    public class UserValidator : AbstractValidator<IUserDTO>
    {
        public UserValidator()
        {
            RuleSet(ValidationConstants.CommomUservalidations, () =>
            {
                RuleFor(user => user.EmployeeDTO.FirstName).NotEmpty().Length(1, 50);
                RuleFor(user => user.EmployeeDTO.LastName).NotEmpty().Length(1, 50);
                RuleFor(user => user.EmployeeDTO.DepartmentId).NotEmpty();
                RuleFor(user => user.Password).NotEmpty().Length(8, 16).Matches(ValidationConstants.PasswordRegEx);
            });

            RuleSet(ValidationConstants.UpdateEmployee, () =>
            {               
                RuleFor(user => user.EmployeeDTO.Email).NotEmpty().EmailAddress().Length(1, 100).Must(UniqueEmployeeEmailForUpdate);
            });

            RuleSet(ValidationConstants.CreateEmployee, () =>
             {
                 RuleFor(user => user.EmployeeDTO.Email).NotEmpty().EmailAddress().Length(1, 100).Must(UniqueEmployeeEmail);
             });

            RuleSet(ValidationConstants.UpdateCreateUser, () =>
            {
                RuleFor(user => user.EmployeeDTO.DateOfJoining).NotEmpty().LessThanOrEqualTo(DateTime.Now);
                //RuleFor(user => user.EmployeeDTO.TerminationDate).GreaterThanOrEqualTo(DateTime.Now);
                RuleFor(user => user.IsAdmin).NotNull();
            });
        }

        private bool UniqueEmployeeEmail(string email)
        {
            IUserDAC userDAC = (IUserDAC)DACFactory.Instance.Create(DACType.UserManagerDAC);
            IUserDTO userDTO = userDAC.GetUserByEmailId(email);
            return userDTO == null;
        }

        private bool UniqueEmployeeEmailForUpdate(string email)
        {
            IUserDAC userDAC = (IUserDAC)DACFactory.Instance.Create(DACType.UserManagerDAC);
            IUserDTO userDTO = userDAC.GetUserByEmailId(email);
            return userDTO == null || userDTO.EmployeeDTO.Email.Equals(email);
        }
    }
}

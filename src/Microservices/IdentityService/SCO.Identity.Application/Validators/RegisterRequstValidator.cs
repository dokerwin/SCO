using FluentValidation;
using SCO.Contracts.Requests.Identity;
using SCO.Identity.Application.Common.Interfaces.Persistance;
using SCO.Identity.Domain.Entities.Employees;

namespace SCO.Identity.Aplications.Validators;

public class RegisterRequstValidator : AbstractValidator<RegisterDto>
{
    public RegisterRequstValidator(IUnitOfWork unitOfWork)
    {

        RuleFor(x => x.Email)
           .NotEmpty()
           .EmailAddress();

        RuleFor(x => x.Password).MinimumLength(6);

        RuleFor(x => x.ConfirmPassword).Equal(e => e.Password);

        RuleFor(x => x.Email).Custom(async (value, context) =>
        {
            Cashier emailInUse = await unitOfWork.Cashiers.FindByEmailAsync(value);
            if (emailInUse != null && emailInUse.Email != null)
            {
                context.AddFailure("Email", "That email is taken");
            }
        });
    }
}


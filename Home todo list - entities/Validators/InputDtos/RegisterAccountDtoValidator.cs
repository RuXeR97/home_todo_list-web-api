using FluentValidation;
using Home_todo_list___common;
using Home_todo_list___entities.InputDtos;

namespace Home_todo_list___entities.Validators.InputDtos
{
	public class RegisterAccountDtoValidator : AbstractValidator<RegisterAccountDto>
	{
		public RegisterAccountDtoValidator()
		{
			RuleFor(x => x.Username).Length(SystemConstraints.MinUsernameLength, SystemConstraints.MaxUsernameLength);
			RuleFor(x => x.Password).Length(SystemConstraints.MinPasswordLength, SystemConstraints.MaxPasswordLength);
			RuleFor(x => x.Email).EmailAddress();
		}
	}
}

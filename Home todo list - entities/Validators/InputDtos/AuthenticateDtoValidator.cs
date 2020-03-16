using FluentValidation;
using Home_todo_list___common;
using Home_todo_list___entities.InputDtos;

namespace Home_todo_list___entities.Validators.InputDtos
{
	public class AuthenticateDtoValidator : AbstractValidator<AuthenticateDto>
	{
		public AuthenticateDtoValidator()
		{
			RuleFor(x => x.Username).Length(SystemConstraints.MinUsernameLength, SystemConstraints.MaxUsernameLength);
			RuleFor(x => x.Password).Length(SystemConstraints.MinPasswordLength, SystemConstraints.MaxPasswordLength);
		}
	}
}

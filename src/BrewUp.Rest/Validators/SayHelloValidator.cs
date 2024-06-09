using BrewUp.Rest.Models;
using FluentValidation;

namespace BrewUp.Rest.Validators
{
	public class SayHelloValidator : AbstractValidator<HelloRequest>
	{
		public SayHelloValidator()
		{
			RuleFor(h => h.Name).NotEmpty().MaximumLength(50);
		}
	}
}
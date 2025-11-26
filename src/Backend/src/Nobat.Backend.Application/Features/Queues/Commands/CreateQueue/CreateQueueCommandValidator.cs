using FluentValidation;

namespace Nobat.Backend.Application.Features.Queues.Commands.CreateQueue
{
    public class CreateQueueCommandValidator : AbstractValidator<CreateQueueCommand>
    {
        public CreateQueueCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("نام صف الزامی است")
                .MaximumLength(100);

            RuleFor(x => x.Description)
                .MaximumLength(500);
        }
    }
}

using FluentValidation;

namespace TransportathonHackathon.Application.Features.TransportTypes.Commands.Update
{
    public class UpdateTransportTypeCommandValitor : AbstractValidator<UpdateTransportTypeCommand>
    {
        public UpdateTransportTypeCommandValitor()
        {
            RuleFor(e => e.Id).NotNull().NotEmpty();
            RuleFor(e => e.Type).NotNull().NotEmpty().MinimumLength(1);
        }
    }
}

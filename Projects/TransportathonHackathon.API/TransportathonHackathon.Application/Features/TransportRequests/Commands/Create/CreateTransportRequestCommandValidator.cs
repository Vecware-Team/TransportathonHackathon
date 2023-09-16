using FluentValidation;

namespace TransportathonHackathon.Application.Features.TransportRequests.Commands.Create
{
    public class CreateTransportRequestCommandValidator : AbstractValidator<CreateTransportRequestCommand>
    {
        public CreateTransportRequestCommandValidator()
        {
            RuleFor(e => e.CustomerId).NotNull().NotEmpty();
            RuleFor(e => e.CompanyId).NotNull().NotEmpty();
            RuleFor(e => e.TransportTypeId).NotNull().NotEmpty();
            RuleFor(e => e.CountryFrom).NotNull().NotEmpty().MinimumLength(1);
            RuleFor(e => e.CountryTo).NotNull().NotEmpty().MinimumLength(1);
            RuleFor(e => e.CityFrom).NotNull().NotEmpty().MinimumLength(1);
            RuleFor(e => e.CityTo).NotNull().NotEmpty().MinimumLength(1);
            RuleFor(e => e.PlaceSize).NotNull().NotEmpty().MinimumLength(1);
            RuleFor(e => e.StartDate).NotNull().NotEmpty();
        }
    }
}

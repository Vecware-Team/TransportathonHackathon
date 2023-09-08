using MediatR;
using TransportathonHackathon.Application.Features.Companies.Commands.Create;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace TransportathonHackathon.Application.Features.Customers.Commands.Create
{
    public class CreateCustomerCommand : IRequest<CreatedCustomerResponse>
    {
        public string Email { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
    }
}

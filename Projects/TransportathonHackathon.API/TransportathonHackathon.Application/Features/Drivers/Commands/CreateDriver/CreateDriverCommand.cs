using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportathonHackathon.Application.Features.Drivers.Dtos;

namespace TransportathonHackathon.Application.Features.Drivers.Commands.CreateDriver
{
    public class CreateDriverCommand : IRequest<CreatedDriverDto>
    {
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public Guid CompanyId { get; set; }

    }
}

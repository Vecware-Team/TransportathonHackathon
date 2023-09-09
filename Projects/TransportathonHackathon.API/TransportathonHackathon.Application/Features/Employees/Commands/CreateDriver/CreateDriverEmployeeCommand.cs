using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportathonHackathon.Application.Features.Employees.Dtos;
using TransportathonHackathon.Domain.Entities;

namespace TransportathonHackathon.Application.Features.Employees.Commands.CreateDriver
{
    public class CreateDriverEmployeeCommand:IRequest<CreatedDriverEmployeeDto>
    {
        public Guid CompanyId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Classes { get; set; }
        public bool IsNew { get; set; }
        public DateTime LicenseGetDate { get; set; }
    }
}

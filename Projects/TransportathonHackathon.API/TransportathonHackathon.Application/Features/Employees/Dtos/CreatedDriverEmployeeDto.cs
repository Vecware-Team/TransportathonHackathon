using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportathonHackathon.Application.Features.Employees.Dtos
{
    public class CreatedDriverEmployeeDto
    {
        public Guid EmployeeId { get; set; }
        public bool IsTransitNow { get; set; }
        public string UserName { get; set; }
        public Guid CompanyId { get; set; }
        public string CompanyName { get; set; }
    }
}

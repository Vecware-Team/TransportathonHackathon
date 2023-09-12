using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportathonHackathon.Application.Features.Cars.Commands.Create
{
    public class CreateCarCommand : IRequest<CreatedCarResponse>
    {
        public Guid CompanyId { get; set; }
        public Guid DriverId { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int ModelYear { get; set; }
    }
}

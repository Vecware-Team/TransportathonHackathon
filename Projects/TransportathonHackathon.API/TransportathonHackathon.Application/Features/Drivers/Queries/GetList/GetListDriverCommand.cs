using Core.Application.Requests;
using Core.Persistence.Pagination;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportathonHackathon.Application.Features.Drivers.Responses;

namespace TransportathonHackathon.Application.Features.Drivers.Queries.GetList
{
    public class GetListDriverCommand : IRequest<Paginate<GetListDriverResponse>>
    {
        public PageRequest PageRequest { get; set; }
    }
}

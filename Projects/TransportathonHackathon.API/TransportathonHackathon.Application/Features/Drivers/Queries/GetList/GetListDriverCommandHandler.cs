using AutoMapper;
using Core.Persistence.Pagination;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportathonHackathon.Application.Features.Drivers.Responses;
using TransportathonHackathon.Application.Repositories;
using TransportathonHackathon.Domain.Entities;

namespace TransportathonHackathon.Application.Features.Drivers.Queries.GetList
{
    public class GetListDriverCommandHandler : IRequestHandler<GetListDriverCommand, Paginate<GetListDriverResponse>>
    {
        IEmployeeRepository _employeeRepository;
        IMapper _mapper;

        public GetListDriverCommandHandler(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }

        public async Task<Paginate<GetListDriverResponse>> Handle(GetListDriverCommand request, CancellationToken cancellationToken)
        {
            IPaginate<Employee> driverEmployees = await _employeeRepository.GetListPagedAsync(
                include: e=>e.Include(e=>e.Driver),
                index: request.PageRequest.Index,
                size: request.PageRequest.Size
                );

            Paginate<GetListDriverResponse> result = _mapper.Map<Paginate<GetListDriverResponse>>(driverEmployees);

            return result;
        }
    }
}

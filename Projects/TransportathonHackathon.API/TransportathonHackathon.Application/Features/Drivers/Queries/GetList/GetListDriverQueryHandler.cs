using AutoMapper;
using Core.Persistence.Pagination;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TransportathonHackathon.Application.Repositories;
using TransportathonHackathon.Domain.Entities;

namespace TransportathonHackathon.Application.Features.Drivers.Queries.GetList
{
    public class GetListDriverQueryHandler : IRequestHandler<GetListDriverQuery, Paginate<GetListDriverResponse>>
    {
        private readonly IDriverRepository _driverRepository;
        private readonly IMapper _mapper;

        public GetListDriverQueryHandler(IDriverRepository driverRepository, IMapper mapper)
        {
            _driverRepository = driverRepository;
            _mapper = mapper;
        }

        public async Task<Paginate<GetListDriverResponse>> Handle(GetListDriverQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Driver> drivers = await _driverRepository.GetListPagedAsync(
                include: e => e.Include(e => e.Employee).Include(e => e.DriverLicense).Include(e => e.Employee.Company).Include(e => e.Employee.AppUser),
                index: request.PageRequest.Index,
                size: request.PageRequest.Size
            );

            Paginate<GetListDriverResponse> result = _mapper.Map<Paginate<GetListDriverResponse>>(drivers);
            return result;
        }
    }
}

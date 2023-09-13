using AutoMapper;
using Core.Persistence.Pagination;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TransportathonHackathon.Application.Repositories;
using TransportathonHackathon.Domain.Entities;

namespace TransportathonHackathon.Application.Features.DriverLicenses.Queries.GetList
{
    public class GetListDriverLicenseQueryHandler : IRequestHandler<GetListDriverLicenseQuery, Paginate<GetListDriverLicenseResponse>>
    {
        private readonly IDriverLicenseRepository _driverLicenseRepository;
        private readonly IMapper _mapper;

        public GetListDriverLicenseQueryHandler(IDriverLicenseRepository driverLicenseRepository, IMapper mapper)
        {
            _driverLicenseRepository = driverLicenseRepository;
            _mapper = mapper;
        }

        public async Task<Paginate<GetListDriverLicenseResponse>> Handle(GetListDriverLicenseQuery request, CancellationToken cancellationToken)
        {
            IPaginate<DriverLicense> driverLicenses = await _driverLicenseRepository.GetListPagedAsync(
                include: e => e.Include(e => e.Driver),
                index: request.PageRequest.Index,
                size: request.PageRequest.Size
            );

            driverLicenses.Items.ToList().ForEach(e => e.Driver.DriverLicense = null);
            Paginate<GetListDriverLicenseResponse> response = _mapper.Map<Paginate<GetListDriverLicenseResponse>>(driverLicenses);
            return response;
        }
    }
}

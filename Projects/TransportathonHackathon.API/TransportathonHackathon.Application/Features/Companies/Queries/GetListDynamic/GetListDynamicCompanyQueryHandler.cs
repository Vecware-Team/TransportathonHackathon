using AutoMapper;
using Core.Persistence.Pagination;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TransportathonHackathon.Application.Repositories;
using TransportathonHackathon.Domain.Entities;

namespace TransportathonHackathon.Application.Features.Companies.Queries.GetListDynamic
{
    public class GetListDynamicCompanyQueryHandler : IRequestHandler<GetListDynamicCompanyQuery, Paginate<GetListDynamicCompanyResponse>>
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IMapper _mapper;

        public GetListDynamicCompanyQueryHandler(ICompanyRepository companyRepository, IMapper mapper)
        {
            _companyRepository = companyRepository;
            _mapper = mapper;
        }

        public async Task<Paginate<GetListDynamicCompanyResponse>> Handle(GetListDynamicCompanyQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Company> companies = await _companyRepository.GetListByDynamicPagedAsync(
                request.DynamicQuery,
                index: request.PageRequest.Index,
                size:request.PageRequest.Size,
                include: e=>e.Include(e=>e.AppUser).Include(e=>e.Employees)
            );

            companies.Items.ToList().ForEach(e => e.Employees?.ToList().ForEach(e => e.Company = null));
            Paginate<GetListDynamicCompanyResponse> response = _mapper.Map<Paginate<GetListDynamicCompanyResponse>>(companies);
            return response;
        }
    }
}

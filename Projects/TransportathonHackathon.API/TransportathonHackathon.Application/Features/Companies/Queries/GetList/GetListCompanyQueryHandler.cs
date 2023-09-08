using AutoMapper;
using Core.Persistence.Pagination;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TransportathonHackathon.Application.Repositories;
using TransportathonHackathon.Domain.Entities;

namespace TransportathonHackathon.Application.Features.Companies.Queries.GetList
{
    public class GetListCompanyQueryHandler : IRequestHandler<GetListCompanyQuery, Paginate<GetListCompanyResponse>>
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IMapper _mapper;

        public GetListCompanyQueryHandler(ICompanyRepository companyRepository, IMapper mapper)
        {
            _companyRepository = companyRepository;
            _mapper = mapper;
        }

        public async Task<Paginate<GetListCompanyResponse>> Handle(GetListCompanyQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Company> companies = await _companyRepository.GetListPagedAsync(
                index: request.PageRequest.Index,
                size: request.PageRequest.Size,
                include:e=>e.Include(e=>e.AppUser),
                cancellationToken: cancellationToken
            );

            Paginate<GetListCompanyResponse> response = _mapper.Map<Paginate<GetListCompanyResponse>>(companies);
            return response;
        }
    }
}

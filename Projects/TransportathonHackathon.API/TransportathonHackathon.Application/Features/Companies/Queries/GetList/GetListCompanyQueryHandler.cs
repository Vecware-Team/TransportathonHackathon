using AutoMapper;
using Core.Persistence.Pagination;
using MediatR;
using TransportathonHackathon.Application.Repositories;
using TransportathonHackathon.Domain.Entities;

namespace TransportathonHackathon.Application.Features.Companies.Queries.GetList
{
    public class GetListCompanyQueryHandler : IRequestHandler<GetListCompanyQuery, IPaginate<GetListCompanyResponse>>
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IMapper _mapper;

        public GetListCompanyQueryHandler(ICompanyRepository companyRepository, IMapper mapper)
        {
            _companyRepository = companyRepository;
            _mapper = mapper;
        }

        public async Task<IPaginate<GetListCompanyResponse>> Handle(GetListCompanyQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Company> companies = await _companyRepository.GetListPagedAsync(
                index: request.PageRequest.Index,
                size: request.PageRequest.Size,
                cancellationToken: cancellationToken
            );

            IPaginate<GetListCompanyResponse> response = _mapper.Map<IPaginate<GetListCompanyResponse>>(companies);
            throw new NotImplementedException();
        }
    }
}

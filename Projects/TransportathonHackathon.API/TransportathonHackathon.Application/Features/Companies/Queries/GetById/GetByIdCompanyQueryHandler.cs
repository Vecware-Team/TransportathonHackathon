using AutoMapper;
using MediatR;
using TransportathonHackathon.Application.Repositories;
using TransportathonHackathon.Domain.Entities;

namespace TransportathonHackathon.Application.Features.Companies.Queries.GetById
{
    public class GetByIdCompanyQueryHandler : IRequestHandler<GetByIdCompanyQuery, GetByIdCompanyResponse>
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IMapper _mapper;

        public GetByIdCompanyQueryHandler(ICompanyRepository companyRepository, IMapper mapper)
        {
            _companyRepository = companyRepository;
            _mapper = mapper;
        }

        public async Task<GetByIdCompanyResponse> Handle(GetByIdCompanyQuery request, CancellationToken cancellationToken)
        {
            Company? company = await _companyRepository.GetAsync(e=>e.AppUserId == request.Id);
            if (company is null)
                throw new Exception();

            GetByIdCompanyResponse response = _mapper.Map<GetByIdCompanyResponse>(company);
            return response;    
        }
    }
}

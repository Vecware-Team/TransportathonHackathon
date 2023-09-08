using AutoMapper;
using MediatR;
using TransportathonHackathon.Application.Repositories;
using TransportathonHackathon.Domain.Entities;

namespace TransportathonHackathon.Application.Features.Companies.Commands.Create
{
    public class CreateCompanyCommandHandler : IRequestHandler<CreateCompanyCommand, CreatedCompanyResponse>
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IMapper _mapper;

        public CreateCompanyCommandHandler(ICompanyRepository companyRepository, IMapper mapper)
        {
            _companyRepository = companyRepository;
            _mapper = mapper;
        }

        public async Task<CreatedCompanyResponse> Handle(CreateCompanyCommand request, CancellationToken cancellationToken)
        {
            Company company = _mapper.Map<Company>(request);

            company.DriverCount = 0;
            company.CompletedJobsCount = 0;

            await _companyRepository.AddAsync(company);

            CreatedCompanyResponse response = _mapper.Map<CreatedCompanyResponse>(company);
            return response;
        }
    }
}

using AutoMapper;
using MediatR;
using TransportathonHackathon.Application.Repositories;
using TransportathonHackathon.Domain.Entities;

namespace TransportathonHackathon.Application.Features.Companies.Commands.Update
{
    public class UpdateCompanyCommandHandler : IRequestHandler<UpdateCompanyCommand, UpdatedCompanyResponse>
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IMapper _mapper;

        public UpdateCompanyCommandHandler(ICompanyRepository companyRepository, IMapper mapper)
        {
            _companyRepository = companyRepository;
            _mapper = mapper;
        }

        public async Task<UpdatedCompanyResponse> Handle(UpdateCompanyCommand request, CancellationToken cancellationToken)
        {
            Company companyToUpdate = _mapper.Map<Company>(request);

            Company? company = await _companyRepository.GetAsync(e => e.AppUserId == companyToUpdate.AppUserId, enableTracking: false, cancellationToken: cancellationToken);
            if (company is null)
                throw new Exception();

            companyToUpdate = _mapper.Map(company, companyToUpdate);
            await _companyRepository.UpdateAsync(companyToUpdate);

            UpdatedCompanyResponse response = _mapper.Map<UpdatedCompanyResponse>(companyToUpdate);
            return response;
        }
    }
}

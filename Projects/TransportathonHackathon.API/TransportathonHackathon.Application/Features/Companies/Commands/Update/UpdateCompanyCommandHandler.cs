using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
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

            Company? company = await _companyRepository.GetAsync(
                e => e.AppUserId == companyToUpdate.AppUserId,
                include: e => e.Include(e => e.AppUser),
                cancellationToken: cancellationToken
            );

            if (company is null)
                throw new Exception();

            company.CompanyName = companyToUpdate.CompanyName;
            company.AppUser.UpdatedDate = DateTime.UtcNow;
            company.AppUser.Email = companyToUpdate.AppUser.Email;
            company.AppUser.UserName = companyToUpdate.AppUser.UserName;

            await _companyRepository.SaveChangesAsync();

            UpdatedCompanyResponse response = _mapper.Map<UpdatedCompanyResponse>(companyToUpdate);
            return response;
        }
    }
}

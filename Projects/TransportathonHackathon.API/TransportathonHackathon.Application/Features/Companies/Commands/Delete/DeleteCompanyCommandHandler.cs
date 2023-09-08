using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TransportathonHackathon.Application.Repositories;
using TransportathonHackathon.Domain.Entities;
using TransportathonHackathon.Domain.Entities.Identity;

namespace TransportathonHackathon.Application.Features.Companies.Commands.Delete
{
    public class DeleteCompanyCommandHandler : IRequestHandler<DeleteCompanyCommand, DeletedCompanyResponse>
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IMapper _mapper;
        private readonly UserManager<AppUser> _userManager;

        public DeleteCompanyCommandHandler(ICompanyRepository companyRepository, IMapper mapper, UserManager<AppUser> userManager)
        {
            _companyRepository = companyRepository;
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<DeletedCompanyResponse> Handle(DeleteCompanyCommand request, CancellationToken cancellationToken)
        {
            Company? company = await _companyRepository.GetAsync(e => e.AppUserId == request.AppUserId, include: e => e.Include(e => e.AppUser));
            if (company is null)
                throw new Exception();

            AppUser user = new AppUser()
            {
                UserName = company.AppUser.UserName,
                Email = company.AppUser.Email,
            };

            IdentityResult result = await _userManager.DeleteAsync(company.AppUser);
            if (!result.Succeeded)
                throw new Exception();

            company.AppUser = user;
            DeletedCompanyResponse response = _mapper.Map<DeletedCompanyResponse>(company);
            return response;
        }
    }
}

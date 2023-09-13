using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using TransportathonHackathon.Application.Extensions;
using TransportathonHackathon.Application.Features.Companies.Rules;
using TransportathonHackathon.Application.Repositories;
using TransportathonHackathon.Domain.Entities;
using TransportathonHackathon.Domain.Entities.Identity;

namespace TransportathonHackathon.Application.Features.Companies.Commands.Create
{
    public class CreateCompanyCommandHandler : IRequestHandler<CreateCompanyCommand, CreatedCompanyResponse>
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IMapper _mapper;
        private readonly UserManager<AppUser> _userManager;
        private readonly CompanyBusinessRules _rules;

        public CreateCompanyCommandHandler(ICompanyRepository companyRepository, IMapper mapper, UserManager<AppUser> userManager, CompanyBusinessRules rules)
        {
            _companyRepository = companyRepository;
            _mapper = mapper;
            _userManager = userManager;
            _rules = rules;
        }

        public async Task<CreatedCompanyResponse> Handle(CreateCompanyCommand request, CancellationToken cancellationToken)
        {
            await _rules.CheckIfUserEmailorUserNameDuplicatedWhenInserting(request.Email, request.UserName);
            Company company = _mapper.Map<Company>(request);
            company.DriverCount = 0;
            company.CompletedJobsCount = 0;

            IdentityResult result = await _userManager.CreateAsync(new AppUser()
            {
                UserName = request.UserName,
                Email = request.Email,
                CreatedDate = DateTime.UtcNow,
                Company = company
            }, request.Password);

            if (!result.Succeeded)
                throw new Exception();

            CreatedCompanyResponse response = _mapper.Map<CreatedCompanyResponse>(company);
            return response;
        }
    }
}

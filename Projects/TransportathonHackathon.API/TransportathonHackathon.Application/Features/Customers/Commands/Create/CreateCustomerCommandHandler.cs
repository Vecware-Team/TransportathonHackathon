using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using TransportathonHackathon.Application.Extensions;
using TransportathonHackathon.Application.Features.Customers.Rules;
using TransportathonHackathon.Domain.Entities;
using TransportathonHackathon.Domain.Entities.Identity;

namespace TransportathonHackathon.Application.Features.Customers.Commands.Create
{
    public class CreateCustomerCommandHandler: IRequestHandler<CreateCustomerCommand, CreatedCustomerResponse>
    {
        private readonly IMapper _mapper;
        private readonly UserManager<AppUser> _userManager;
        private readonly CustomerBusinessRules _rules;

        public CreateCustomerCommandHandler(IMapper mapper, UserManager<AppUser> userManager, CustomerBusinessRules rules)
        {
            _mapper = mapper;
            _userManager = userManager;
            _rules = rules;
        }

        public async Task<CreatedCustomerResponse> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            await _rules.CheckIfUserEmailorUserNameDuplicatedWhenInserting(request.Email, request.UserName);
            Customer customer = _mapper.Map<Customer>(request);

            IdentityResult result = await _userManager.CreateAsync(new AppUser()
            {
                UserName = request.UserName,
                Email = request.Email,
                CreatedDate = DateTime.UtcNow,
                Customer = customer
            }, request.Password);

            if (!result.Succeeded)
                throw new Exception();

            CreatedCustomerResponse response = _mapper.Map<CreatedCustomerResponse>(customer);
            return response;
        }
    }
}

using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using TransportathonHackathon.Domain.Entities;
using TransportathonHackathon.Domain.Entities.Identity;

namespace TransportathonHackathon.Application.Features.Customers.Commands.Create
{
    public class CreateCustomerCommandHandler: IRequestHandler<CreateCustomerCommand, CreatedCustomerResponse>
    {
        private readonly IMapper _mapper;
        private readonly UserManager<AppUser> _userManager;

        public CreateCustomerCommandHandler(IMapper mapper, UserManager<AppUser> userManager)
        {
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<CreatedCustomerResponse> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
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

using MediatR;
using Microsoft.AspNetCore.Identity;
using TransportathonHackathon.Application.Repositories;
using TransportathonHackathon.Domain.Entities.Identity;
using TransportathonHackathon.Domain.Entities;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Core.CrossCuttingConcerns.Exceptions.ExceptionTypes;

namespace TransportathonHackathon.Application.Features.Customers.Commands.Delete
{
    public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand, DeletedCustomerResponse> {

        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;
        private readonly UserManager<AppUser> _userManager;

        public DeleteCustomerCommandHandler(ICustomerRepository customerRepository, IMapper mapper, UserManager<AppUser> userManager)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<DeletedCustomerResponse> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            Customer? customer = await _customerRepository.GetAsync(e => e.AppUserId == request.AppUserId, include: e => e.Include(e => e.AppUser));
            if (customer is null)
                throw new NotFoundException("Customer not found");

            AppUser user = new AppUser()
            {
                UserName = customer.AppUser.UserName,
                Email = customer.AppUser.Email,
            };

            IdentityResult result = await _userManager.DeleteAsync(customer.AppUser);
            if (!result.Succeeded)
                throw new Exception();

            customer.AppUser = user;
            DeletedCustomerResponse response = _mapper.Map<DeletedCustomerResponse>(customer);
            return response;
        }
    }
}

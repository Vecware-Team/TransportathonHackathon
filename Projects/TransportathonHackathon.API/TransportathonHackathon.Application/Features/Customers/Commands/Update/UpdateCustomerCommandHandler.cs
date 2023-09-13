using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions.ExceptionTypes;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TransportathonHackathon.Application.Extensions;
using TransportathonHackathon.Application.Features.Customers.Rules;
using TransportathonHackathon.Application.Repositories;
using TransportathonHackathon.Domain.Entities;

namespace TransportathonHackathon.Application.Features.Customers.Commands.Update
{
    public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, UpdatedCustomerResponse>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;
        private readonly CustomerBusinessRules _rules;

        public UpdateCustomerCommandHandler(ICustomerRepository customerRepository, IMapper mapper, CustomerBusinessRules rules)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
            _rules = rules;
        }

        public async Task<UpdatedCustomerResponse> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            await _rules.CheckIfUserEmailorUserNameDuplicatedWhenInserting(request.Email, request.UserName);
            Customer customerToUpdate = _mapper.Map<Customer>(request);

            Customer? customer = await _customerRepository.GetAsync(
                e => e.AppUserId == customerToUpdate.AppUserId,
                include: e => e.Include(e => e.AppUser),
                cancellationToken: cancellationToken
            );

            if (customer is null)
                throw new NotFoundException("Customer not found");

            customer.FirstName = customerToUpdate.FirstName;
            customer.LastName = customerToUpdate.LastName;
            customer.AppUser.UpdatedDate = DateTime.UtcNow;
            customer.AppUser.Email = customerToUpdate.AppUser.Email;
            customer.AppUser.UserName = customerToUpdate.AppUser.UserName;

            await _customerRepository.SaveChangesAsync();

            UpdatedCustomerResponse response = _mapper.Map<UpdatedCustomerResponse>(customer);
            return response;
        }
    }
}

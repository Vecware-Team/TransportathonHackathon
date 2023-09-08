using AutoMapper;
using Core.Persistence.Pagination;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TransportathonHackathon.Application.Repositories;
using TransportathonHackathon.Domain.Entities;

namespace TransportathonHackathon.Application.Features.Customers.Queries.GetList
{
    public class GetListCustomerQueryHandler : IRequestHandler<GetListCustomerQuery, Paginate<GetListCustomerResponse>>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public GetListCustomerQueryHandler(ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        public async Task<Paginate<GetListCustomerResponse>> Handle(GetListCustomerQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Customer> customers = await _customerRepository.GetListPagedAsync(
                index: request.PageRequest.Index,
                size: request.PageRequest.Size,
                include: e => e.Include(e => e.AppUser),
                cancellationToken: cancellationToken
            );

            Paginate<GetListCustomerResponse> response = _mapper.Map<Paginate<GetListCustomerResponse>>(customers);
            return response;
        }
    }
}

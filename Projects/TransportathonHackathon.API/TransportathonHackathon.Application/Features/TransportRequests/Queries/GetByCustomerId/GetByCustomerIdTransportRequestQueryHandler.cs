﻿using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TransportathonHackathon.Application.Repositories;
using TransportathonHackathon.Domain.Entities;

namespace TransportathonHackathon.Application.Features.TransportRequests.Queries.GetByCustomerId
{
    public class GetByCustomerIdTransportRequestQueryHandler : IRequestHandler<GetByCustomerIdTransportRequestQuery, List<GetByCustomerIdTransportRequestResponse>>
    {
        private readonly ITransportRequestRepository _transportRequestRepository;
        private readonly IMapper _mapper;

        public GetByCustomerIdTransportRequestQueryHandler(ITransportRequestRepository transportRequestRepository, IMapper mapper)
        {
            _transportRequestRepository = transportRequestRepository;
            _mapper = mapper;
        }

        public async Task<List<GetByCustomerIdTransportRequestResponse>> Handle(GetByCustomerIdTransportRequestQuery request, CancellationToken cancellationToken)
        {
            IList<TransportRequest> transportRequests = await _transportRequestRepository.GetListAsync(
                e => e.CustomerId == request.CustomerId,
                include: e => e.Include(e => e.Company).Include(e => e.Customer).Include(e => e.TransportType).Include(e => e.PaymentRequest).Include(e => e.Vehicle)
            );

            transportRequests.ToList().ForEach(e =>
            {
                if (e.PaymentRequest is not null) e.PaymentRequest.TransportRequest = null;
                if (e.Vehicle is not null)
                {
                    e.Vehicle.TransportRequest = null;
                    e.Vehicle.Company.TransportRequests?.ToList().ForEach(c =>
                    {
                        c.Vehicle = null;
                        c.Customer = null;
                        c.Company = null;
                        c.Comment = null;
                    });
                    e.Vehicle.Company.TransportRequests = null;
                    e.Vehicle.Company = null;
                }
            });
            List<GetByCustomerIdTransportRequestResponse> response = _mapper.Map<List<GetByCustomerIdTransportRequestResponse>>(transportRequests.ToList());
            return response;
        }
    }
}

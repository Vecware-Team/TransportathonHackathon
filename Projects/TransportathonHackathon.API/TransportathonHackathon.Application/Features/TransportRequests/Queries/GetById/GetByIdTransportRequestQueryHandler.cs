using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions.ExceptionTypes;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TransportathonHackathon.Application.Repositories;
using TransportathonHackathon.Domain.Entities;

namespace TransportathonHackathon.Application.Features.TransportRequests.Queries.GetById
{
    public class GetByIdTransportRequestQueryHandler : IRequestHandler<GetByIdTransportRequestQuery, GetByIdTransportRequestResponse>
    {
        private readonly ITransportRequestRepository _transportRequestRepository;
        private readonly IMapper _mapper;

        public GetByIdTransportRequestQueryHandler(ITransportRequestRepository transportRequestRepository, IMapper mapper)
        {
            _transportRequestRepository = transportRequestRepository;
            _mapper = mapper;
        }

        public async Task<GetByIdTransportRequestResponse> Handle(GetByIdTransportRequestQuery request, CancellationToken cancellationToken)
        {
            TransportRequest? transportRequest = await _transportRequestRepository.GetAsync(
                e => e.Id == request.Id,
                include: e => e.Include(e => e.Company).Include(e => e.Customer).Include(e => e.TransportType).Include(e => e.PaymentRequest)
            );
            if (transportRequest is null)
                throw new NotFoundException("Transport request not found");

            GetByIdTransportRequestResponse response = _mapper.Map<GetByIdTransportRequestResponse>(transportRequest);
            return response;
        }
    }

}

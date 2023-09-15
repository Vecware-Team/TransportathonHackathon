using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TransportathonHackathon.Application.Repositories;
using TransportathonHackathon.Domain.Entities;

namespace TransportathonHackathon.Application.Features.TransportRequests.Commands.Create
{
    public class CreateTransportRequestCommandHandler : IRequestHandler<CreateTransportRequestCommand, CreatedTransportRequestResponse>
    {
        private readonly ITransportRequestRepository _transportRequestRepository;
        private readonly IMapper _mapper;

        public CreateTransportRequestCommandHandler(ITransportRequestRepository transportRequestRepository, IMapper mapper)
        {
            _transportRequestRepository = transportRequestRepository;
            _mapper = mapper;
        }

        public async Task<CreatedTransportRequestResponse> Handle(CreateTransportRequestCommand request, CancellationToken cancellationToken)
        {
            TransportRequest transportRequest = _mapper.Map<TransportRequest>(request);
            transportRequest.ApprovedByCompany = null;
            await _transportRequestRepository.AddAsync(transportRequest);

            transportRequest = await _transportRequestRepository.GetAsync(
                e => e.Id == transportRequest.Id, 
                include: e => e.Include(e => e.Company).Include(e => e.Customer).Include(e => e.TransportType).Include(e => e.PaymentRequest)
            );

            CreatedTransportRequestResponse response = _mapper.Map<CreatedTransportRequestResponse>(transportRequest);
            return response;
        }
    }
}

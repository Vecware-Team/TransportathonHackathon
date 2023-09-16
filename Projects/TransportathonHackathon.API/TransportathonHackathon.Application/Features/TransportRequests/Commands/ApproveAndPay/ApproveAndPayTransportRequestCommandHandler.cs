using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions.ExceptionTypes;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TransportathonHackathon.Application.Repositories;
using TransportathonHackathon.Domain.Entities;

namespace TransportathonHackathon.Application.Features.TransportRequests.Commands.ApproveAndPay
{
    public class ApproveAndPayTransportRequestCommandHandler : IRequestHandler<ApproveAndPayTransportRequestCommand, ApproveAndPayTransportRequestResponse>
    {
        private readonly ITransportRequestRepository _transportRequestRepository;
        private readonly IMapper _mapper;

        public ApproveAndPayTransportRequestCommandHandler(ITransportRequestRepository transportRequestRepository, IMapper mapper)
        {
            _transportRequestRepository = transportRequestRepository;
            _mapper = mapper;
        }

        public async Task<ApproveAndPayTransportRequestResponse> Handle(ApproveAndPayTransportRequestCommand request, CancellationToken cancellationToken)
        {
            TransportRequest? transportRequest = await _transportRequestRepository.GetAsync(
                e => e.Id == request.Id,
                include: e => e.Include(e => e.Company).Include(e => e.Customer).Include(e => e.TransportType).Include(e => e.PaymentRequest).Include(e => e.Vehicle)
            );
            if (transportRequest is null)
                throw new NotFoundException("Transport request not found");

            transportRequest.ApprovedByCompany = request.IsApproved;
            transportRequest.UpdatedDate = DateTime.UtcNow;

            if (!request.IsApproved)
            {
                transportRequest.IsFinished = true;
                transportRequest.FinishDate = DateTime.UtcNow;
                await _transportRequestRepository.SaveChangesAsync();
                if (transportRequest.Vehicle is not null)
                    transportRequest.Vehicle.TransportRequest = null;
                return _mapper.Map<ApproveAndPayTransportRequestResponse>(transportRequest);
            }

            transportRequest.VehicleId = request.VehicleId;
            transportRequest.PaymentRequest = new PaymentRequest()
            {
                TransportRequestId = transportRequest.Id,
                Price = request.Price,
                IsPaid = false,
                CreatedDate = DateTime.UtcNow,
                UpdatedDate = DateTime.UtcNow,
            };
            await _transportRequestRepository.SaveChangesAsync();

            if (transportRequest.Vehicle is not null)
                transportRequest.Vehicle.TransportRequest = null;

            ApproveAndPayTransportRequestResponse response = _mapper.Map<ApproveAndPayTransportRequestResponse>(transportRequest);
            return response;
        }
    }
}

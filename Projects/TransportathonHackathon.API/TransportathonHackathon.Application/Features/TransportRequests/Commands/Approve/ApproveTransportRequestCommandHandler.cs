using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions.ExceptionTypes;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TransportathonHackathon.Application.Repositories;
using TransportathonHackathon.Domain.Entities;

namespace TransportathonHackathon.Application.Features.TransportRequests.Commands.Approve
{
    public class ApproveTransportRequestCommandHandler : IRequestHandler<ApproveTransportRequestCommand, ApproveTransportRequestResponse>
    {
        private readonly ITransportRequestRepository _transportRequestRepository;
        private readonly IMapper _mapper;

        public ApproveTransportRequestCommandHandler(ITransportRequestRepository transportRequestRepository, IMapper mapper)
        {
            _transportRequestRepository = transportRequestRepository;
            _mapper = mapper;
        }

        public async Task<ApproveTransportRequestResponse> Handle(ApproveTransportRequestCommand request, CancellationToken cancellationToken)
        {
            TransportRequest? transportRequest = await _transportRequestRepository.GetAsync(
                e => e.Id == request.Id, 
                include: e => e.Include(e => e.Company).Include(e => e.Customer).Include(e => e.TransportType).Include(e => e.PaymentRequest)
            );
            if (transportRequest is null)
                throw new NotFoundException("Transport request not found");

            transportRequest.ApprovedByCompany = request.IsApproved;
            if (!request.IsApproved)
            {
                transportRequest.IsFinished = true;
                transportRequest.FinishDate = DateTime.UtcNow;
            }
            transportRequest.UpdatedDate = DateTime.UtcNow;

            await _transportRequestRepository.SaveChangesAsync();

            ApproveTransportRequestResponse response = _mapper.Map<ApproveTransportRequestResponse>(transportRequest);
            return response;
        }
    }
}

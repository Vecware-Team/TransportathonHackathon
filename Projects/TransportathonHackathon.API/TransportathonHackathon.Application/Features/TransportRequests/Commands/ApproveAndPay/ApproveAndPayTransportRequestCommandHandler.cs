using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions.ExceptionTypes;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TransportathonHackathon.Application.Repositories;
using TransportathonHackathon.Application.Services;
using TransportathonHackathon.Domain.Entities;

namespace TransportathonHackathon.Application.Features.TransportRequests.Commands.ApproveAndPay
{
    public class ApproveAndPayTransportRequestCommandHandler : IRequestHandler<ApproveAndPayTransportRequestCommand, ApproveAndPayTransportRequestResponse>
    {
        private readonly ITransportRequestRepository _transportRequestRepository;
        private readonly IPaymentService _paymentService;
        private readonly IMapper _mapper;

        public ApproveAndPayTransportRequestCommandHandler(ITransportRequestRepository transportRequestRepository, IPaymentService paymentService, IMapper mapper)
        {
            _transportRequestRepository = transportRequestRepository;
            _paymentService = paymentService;
            _mapper = mapper;
        }

        public async Task<ApproveAndPayTransportRequestResponse> Handle(ApproveAndPayTransportRequestCommand request, CancellationToken cancellationToken)
        {
            TransportRequest? transportRequest = await _transportRequestRepository.GetAsync(
                e => e.Id == request.Id,
                include: e => e.Include(e => e.Company).Include(e => e.Customer).Include(e => e.TransportType).Include(e => e.PaymentRequest)
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
                return _mapper.Map<ApproveAndPayTransportRequestResponse>(transportRequest);
            }

            request.PaymentRequest.Price = transportRequest.PaymentRequest.Price;
            if (!await _paymentService.Payment(request.PaymentRequest))
                throw new BusinessException("Payment failed");

            transportRequest.PaymentRequest.IsPaid = true;

            await _transportRequestRepository.SaveChangesAsync();

            ApproveAndPayTransportRequestResponse response = _mapper.Map<ApproveAndPayTransportRequestResponse>(transportRequest);
            return response;
        }
    }
}

using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions.ExceptionTypes;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TransportathonHackathon.Application.Repositories;
using TransportathonHackathon.Domain.Entities;

namespace TransportathonHackathon.Application.Features.TransportRequests.Commands.Delete
{
    public class DeleteTransportRequestCommandHandler : IRequestHandler<DeleteTransportRequestCommand, DeletedTransportRequestResponse>
    {
        private readonly ITransportRequestRepository _transportRequestRepository;
        private readonly IMapper _mapper;

        public DeleteTransportRequestCommandHandler(ITransportRequestRepository transportRequestRepository, IMapper mapper)
        {
            _transportRequestRepository = transportRequestRepository;
            _mapper = mapper;
        }

        public async Task<DeletedTransportRequestResponse> Handle(DeleteTransportRequestCommand request, CancellationToken cancellationToken)
        {
            TransportRequest? transportRequest = await _transportRequestRepository.GetAsync(
                e => e.Id == request.Id, 
                include: e => e.Include(e => e.Company).Include(e => e.Customer).Include(e => e.TransportType)
            );
            if (transportRequest is null)
                throw new NotFoundException("Transport request not found");

            Company company = _mapper.Map<Company>(transportRequest.Company);
            Customer customer = _mapper.Map<Customer>(transportRequest.Customer);
            TransportType transportType = _mapper.Map<TransportType>(transportRequest.TransportType);

            await _transportRequestRepository.DeleteAsync(transportRequest, true);

            transportRequest.Customer = customer;
            transportRequest.Company = company;
            transportRequest.TransportType = transportType;

            DeletedTransportRequestResponse response = _mapper.Map<DeletedTransportRequestResponse>(transportRequest);
            return response;
        }
    }
}

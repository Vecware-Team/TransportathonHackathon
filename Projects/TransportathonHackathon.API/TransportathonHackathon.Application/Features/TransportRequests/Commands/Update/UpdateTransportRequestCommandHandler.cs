using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions.ExceptionTypes;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TransportathonHackathon.Application.Repositories;
using TransportathonHackathon.Domain.Entities;

namespace TransportathonHackathon.Application.Features.TransportRequests.Commands.Update
{
    public class UpdateTransportRequestCommandHandler : IRequestHandler<UpdateTransportRequestCommand, UpdatedTransportRequestResponse>
    {
        private readonly ITransportRequestRepository _transportRequestRepository;
        private readonly IMapper _mapper;

        public UpdateTransportRequestCommandHandler(ITransportRequestRepository transportRequestRepository, IMapper mapper)
        {
            _transportRequestRepository = transportRequestRepository;
            _mapper = mapper;
        }

        public async Task<UpdatedTransportRequestResponse> Handle(UpdateTransportRequestCommand request, CancellationToken cancellationToken)
        {
            TransportRequest? transportRequest = await _transportRequestRepository.GetAsync(e => e.Id == request.Id, include: e => e.Include(e => e.Company).Include(e => e.Customer));
            if (transportRequest is null)
                throw new NotFoundException("Transport request not found");

            transportRequest.CompanyId = request.CompanyId;
            transportRequest.CustomerId = request.CustomerId;
            transportRequest.CountryFrom = request.CountryFrom;
            transportRequest.CountryTo = request.CountryTo;
            transportRequest.CityFrom = request.CityFrom;
            transportRequest.CityTo = request.CityTo;
            transportRequest.IsOfficce = request.IsOfficce;
            transportRequest.PlaceSize = request.PlaceSize;
            transportRequest.StartDate = request.StartDate;
            transportRequest.FinishDate = request.FinishDate;
            transportRequest.UpdatedDate = DateTime.UtcNow;

            await _transportRequestRepository.SaveChangesAsync();

            transportRequest = await _transportRequestRepository.GetAsync(e => e.Id == request.Id, include: e => e.Include(e => e.Company).Include(e => e.Customer));
            UpdatedTransportRequestResponse response = _mapper.Map<UpdatedTransportRequestResponse>(transportRequest);
            return response;
        }
    }
}

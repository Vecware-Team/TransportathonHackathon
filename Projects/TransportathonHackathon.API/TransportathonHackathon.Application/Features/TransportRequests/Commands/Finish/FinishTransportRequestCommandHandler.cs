﻿using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions.ExceptionTypes;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TransportathonHackathon.Application.Repositories;
using TransportathonHackathon.Domain.Entities;

namespace TransportathonHackathon.Application.Features.TransportRequests.Commands.Finish
{
    public class FinishTransportRequestCommandHandler : IRequestHandler<FinishTransportRequestCommand, FinishedTransportRequestResponse>
    {
        private readonly ITransportRequestRepository _transportRequestRepository;
        private readonly IMapper _mapper;

        public FinishTransportRequestCommandHandler(ITransportRequestRepository transportRequestRepository, IMapper mapper)
        {
            _transportRequestRepository = transportRequestRepository;
            _mapper = mapper;
        }

        public async Task<FinishedTransportRequestResponse> Handle(FinishTransportRequestCommand request, CancellationToken cancellationToken)
        {
            TransportRequest? transportRequest = await _transportRequestRepository.GetAsync(
               e => e.Id == request.Id,
               include: e => e.Include(e => e.Company).Include(e => e.Customer).Include(e => e.TransportType)
            );
            if (transportRequest is null)
                throw new NotFoundException("Transport request not found");

            if (!transportRequest.PaymentRequest.IsPaid)
                throw new BusinessException("You must pay first");
            
            transportRequest.IsFinished = true;

            await _transportRequestRepository.SaveChangesAsync();

            FinishedTransportRequestResponse response = _mapper.Map<FinishedTransportRequestResponse>(transportRequest);
            return response;
        }
    }

}
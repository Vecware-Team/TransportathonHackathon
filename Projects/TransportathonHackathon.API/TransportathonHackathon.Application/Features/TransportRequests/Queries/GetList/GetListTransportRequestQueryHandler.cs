using AutoMapper;
using Core.Persistence.Pagination;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TransportathonHackathon.Application.Repositories;
using TransportathonHackathon.Domain.Entities;

namespace TransportathonHackathon.Application.Features.TransportRequests.Queries.GetList
{
    public class GetListTransportRequestQueryHandler : IRequestHandler<GetListTransportRequestQuery, Paginate<GetListTransportRequestResponse>>
    {
        private readonly ITransportRequestRepository _transportRequestRepository;
        private readonly IMapper _mapper;

        public GetListTransportRequestQueryHandler(ITransportRequestRepository transportRequestRepository, IMapper mapper)
        {
            _transportRequestRepository = transportRequestRepository;
            _mapper = mapper;
        }

        public async Task<Paginate<GetListTransportRequestResponse>> Handle(GetListTransportRequestQuery request, CancellationToken cancellationToken)
        {
            IPaginate<TransportRequest> transportRequests = await _transportRequestRepository.GetListPagedAsync(
                index: request.PageRequest.Index,
                size: request.PageRequest.Size,
                include: e => e.Include(e => e.Company).Include(e => e.Customer).Include(e => e.TransportType).Include(e => e.PaymentRequest)
            );

            transportRequests.Items.ToList().ForEach(e =>
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
            Paginate<GetListTransportRequestResponse> response = _mapper.Map<Paginate<GetListTransportRequestResponse>>(transportRequests);
            return response;
        }
    }
}

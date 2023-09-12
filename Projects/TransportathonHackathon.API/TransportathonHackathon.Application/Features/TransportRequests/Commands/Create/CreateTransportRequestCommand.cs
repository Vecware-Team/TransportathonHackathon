﻿using MediatR;

namespace TransportathonHackathon.Application.Features.TransportRequests.Commands.Create
{
    public class CreateTransportRequestCommand : IRequest<CreatedTransportRequestResponse>
    {
        public Guid CustomerId { get; set; }
        public Guid CompanyId { get; set; }
        public string CountryFrom { get; set; }
        public string CountryTo { get; set; }
        public string CityFrom { get; set; }
        public string CityTo { get; set; }
        public bool IsOfficce { get; set; }
        public string PlaceSize { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? FinishDate { get; set; }
    }
}
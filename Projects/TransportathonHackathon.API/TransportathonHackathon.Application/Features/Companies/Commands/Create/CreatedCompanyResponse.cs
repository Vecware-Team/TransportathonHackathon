﻿namespace TransportathonHackathon.Application.Features.Companies.Commands.Create
{
    public class CreatedCompanyResponse
    {
        public Guid AppUserId { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string CompanyName { get; set; }
    }
}

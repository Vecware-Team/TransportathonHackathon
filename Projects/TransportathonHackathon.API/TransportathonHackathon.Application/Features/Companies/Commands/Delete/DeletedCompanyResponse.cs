﻿namespace TransportathonHackathon.Application.Features.Companies.Commands.Delete
{
    public class DeletedCompanyResponse
    {
        public Guid AppUserId { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string CompanyName { get; set; }
    }
}

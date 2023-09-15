﻿using TransportathonHackathon.Application.Requests;
using TransportathonHackathon.Application.Services;

namespace TransportathonHackathon.Infrastructure.DriverLicenseVerifiers.FakeDriverLicenseVerifier
{
    public class FakeDriverLicenseVerifierService : IDriverLicenseVerifierService
    {
        public async Task<bool> Verify(DriverLicenseRequest driverLicenseRequest)
        {
            return true;
        }
    }
}

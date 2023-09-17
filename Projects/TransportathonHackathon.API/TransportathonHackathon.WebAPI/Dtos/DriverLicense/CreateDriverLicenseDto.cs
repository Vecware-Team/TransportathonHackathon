namespace TransportathonHackathon.WebAPI.Dtos.DriverLicense
{
    public class CreateDriverLicenseDto
    {
        public Guid DriverId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Classes { get; set; }
        public bool IsNew { get; set; }
        public DateTime LicenseGetDate { get; set; }
    }
}

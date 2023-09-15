namespace TransportathonHackathon.Application.Requests
{
    public class DriverLicenseRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Classes { get; set; }
        public bool IsNew { get; set; }
        public DateTime LicenseGetDate { get; set; }
    }
}

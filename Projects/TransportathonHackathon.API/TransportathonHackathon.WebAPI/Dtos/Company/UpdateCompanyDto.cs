namespace TransportathonHackathon.WebAPI.Dtos.Company
{
    public class UpdateCompanyDto
    {
        public Guid AppUserId { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string CompanyName { get; set; }
    }
}

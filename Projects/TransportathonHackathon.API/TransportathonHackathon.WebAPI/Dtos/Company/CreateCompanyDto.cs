namespace TransportathonHackathon.WebAPI.Dtos.Company
{
    public class CreateCompanyDto
    {
        public string Email { get; set; }
        public string UserName { get; set; }
        public string CompanyName { get; set; }
        public string Password { get; set; }
    }
}

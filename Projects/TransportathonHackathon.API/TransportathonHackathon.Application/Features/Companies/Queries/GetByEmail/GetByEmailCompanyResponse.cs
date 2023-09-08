namespace TransportathonHackathon.Application.Features.Companies.Queries.GetByEmail
{
    public class GetByEmailCompanyResponse
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string CompanyName { get; set; }
    }
}

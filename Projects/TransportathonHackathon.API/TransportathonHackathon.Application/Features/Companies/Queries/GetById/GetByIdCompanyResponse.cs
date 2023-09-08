namespace TransportathonHackathon.Application.Features.Companies.Queries.GetById
{
    public class GetByIdCompanyResponse
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string UserName{ get; set; }
        public string CompanyName{ get; set; }
    }
}

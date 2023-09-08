namespace TransportathonHackathon.Application.Features.Companies.Queries.GetList
{
    public class GetListCompanyResponse
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string CompanyName { get; set; }
    }
}

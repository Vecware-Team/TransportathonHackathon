namespace TransportathonHackathon.Application.Features.Customers.Queries.GetById
{
    public class GetByIdCustomerResponse
    {
        public Guid AppUserId { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}

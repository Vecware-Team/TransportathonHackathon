namespace TransportathonHackathon.Application.Features.Customers.Queries.GetList
{
    public class GetListCustomerResponse
    {
        public Guid AppUserId { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}

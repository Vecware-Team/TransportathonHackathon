namespace TransportathonHackathon.Application.Features.Customers.Commands.Create
{
    public class CreatedCustomerResponse
    {
        public Guid AppUserId { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}

namespace TransportathonHackathon.Application.Features.Drivers.Dtos
{
    public class UpdatedDriverDto
    {
        public Guid EmployeeId { get; set; }
        public bool IsTransitNow { get; set; }
        public string UserName { get; set; }
    }
}

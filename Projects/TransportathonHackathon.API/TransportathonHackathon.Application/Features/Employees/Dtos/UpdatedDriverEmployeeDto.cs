namespace TransportathonHackathon.Application.Features.Employees.Dtos
{
    public class UpdatedDriverEmployeeDto
    {
        public Guid EmployeeId { get; set; }
        public bool IsTransitNow { get; set; }
        public string UserName { get; set; }
    }
}

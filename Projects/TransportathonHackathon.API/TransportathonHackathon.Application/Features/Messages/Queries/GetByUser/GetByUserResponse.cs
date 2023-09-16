namespace TransportathonHackathon.Application.Features.Messages.Queries.GetByUser
{
    public class GetByUserResponse
    {
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public string LastMessage { get; set; }
        public DateTime SendDate { get; set; }
    }
}

namespace TransportathonHackathon.WebAPI.Dtos.Comment
{
    public class CreateCommentDto
    {
        public Guid TransportRequestId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; } = string.Empty;
        public int Point { get; set; }
    }
}

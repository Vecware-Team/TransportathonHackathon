namespace TransportathonHackathon.WebAPI.Dtos.Comment
{
    public class UpdateCommentDto
    {
        public Guid TransportRequestId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Point { get; set; }
    }
}

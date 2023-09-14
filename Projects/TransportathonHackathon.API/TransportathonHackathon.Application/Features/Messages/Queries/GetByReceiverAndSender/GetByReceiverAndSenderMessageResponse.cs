namespace TransportathonHackathon.Application.Features.Messages.Queries.GetByReceiverAndSender
{
    public class GetByReceiverAndSenderMessageResponse
    {
        public Guid Id { get; set; }
        public Guid SenderId { get; set; }
        public Guid ReceiverId { get; set; }
        public string MessageText { get; set; }
        public DateTime SendDate { get; set; }
        public bool IsRead { get; set; }
        public string SenderUserName { get; set; }
        public string ReceiverUserName { get; set; }
    }
}

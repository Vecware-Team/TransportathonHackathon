namespace TransportathonHackathon.Infrastructure.SignalR
{
    public interface IMessageClient
    {
        Task ReceiveMessage(string message);
        Task Clients(List<SignalRClient> clients);
        Task UserJoined(SignalRClient client);
        Task UserLeaved(SignalRClient client);
    }
}

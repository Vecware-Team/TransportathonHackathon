using TransportathonHackathon.Domain.Entities;

namespace TransportathonHackathon.Infrastructure.SignalR
{
    public interface IMessageClient
    {
        Task ReceiveMessage(Message message);
        Task MessageSended(Message message);
        Task Clients(List<SignalRClient> clients);
        Task UserJoined(SignalRClient client);
        Task UserLeaved(SignalRClient client);
    }
}

using Core.CrossCuttingConcerns.Exceptions.ExceptionTypes;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using Microsoft.IdentityModel.Tokens;
using TransportathonHackathon.Application.Services;
using TransportathonHackathon.Domain.Entities;
using TransportathonHackathon.Domain.Entities.Identity;

namespace TransportathonHackathon.Infrastructure.SignalR
{
    public class MessageHub : Hub<IMessageClient>
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IMessageService _messageService;

        private static readonly List<SignalRClient> clients = new List<SignalRClient>();

        public MessageHub(UserManager<AppUser> userManager, IMessageService messageService)
        {
            _userManager = userManager;
            _messageService = messageService;
        }

        public async Task SendMessageAsync(string message)
        {
            await Clients.All.ReceiveMessage(message);
        }

        public override async Task OnConnectedAsync()
        {
            AppUser? user = await _userManager.GetUserAsync(Context.User);
            if (user is null)
                throw new UnauthorizedException();

            SignalRClient client = new() { ConnectionId = Context.ConnectionId, UserId = user.Id.ToString() };
            clients.Add(client);

            await Clients.All.UserJoined(client);

            // Kaldırılacak
            await Clients.All.Clients(clients);
        }

        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            AppUser? user = await _userManager.GetUserAsync(Context.User);
            if (user is null)
                throw new UnauthorizedException();

            SignalRClient? client = clients.SingleOrDefault(c => c.ConnectionId == Context.ConnectionId.ToString());

            if (client is not null)
            {
                clients.Remove(client);
                await Clients.All.UserLeaved(client);
            }

            // Kaldırılacak
            await Clients.All.Clients(clients);
        }

        public async Task SendMessage(Guid receiverId, string message)
        {
            AppUser? receiverUser = await _userManager.FindByIdAsync(receiverId.ToString());
            AppUser? senderUser = await _userManager.GetUserAsync(Context.User);
            if (receiverUser is null || senderUser is null)
                throw new Exception();

            if (receiverUser.Id == senderUser.Id)
                throw new BusinessException("Users was same");

            if (message.IsNullOrEmpty() || message.All(e => e == ' ') || message.All(e => e == '\n') || message.All(e => e == ' ' || e == '\n'))
                return;

            Message sendingMessage = new()
            {
                SenderId = senderUser.Id,
                ReceiverId = receiverUser.Id,
                MessageText = message,
                SendDate = DateTime.UtcNow,
                IsRead = false,
            };

            List<SignalRClient> receiverClients = clients.Where(c => c.UserId == receiverUser.Id.ToString()).ToList();
            if (receiverClients is not null && receiverClients?.Count > 0)
                foreach (SignalRClient client in receiverClients)
                    await Clients.Client(client.ConnectionId).ReceiveMessage(message);

            List<SignalRClient> senderClients = clients.Where(c => c.UserId == senderUser.Id.ToString()).ToList(); 
            if (senderClients is not null && senderClients?.Count > 0)
                foreach (SignalRClient client in senderClients)
                    await Clients.Client(client.ConnectionId).MessageSended(message);

            await _messageService.SaveMessage(sendingMessage);
        }

        public async Task ReadMessage(Guid receiverId, Guid messageId)
        {
            AppUser? receiverUser = await _userManager.FindByIdAsync(receiverId.ToString());
            AppUser? senderUser = await _userManager.GetUserAsync(Context.User);
            if (receiverUser is null || senderUser is null)
                throw new Exception();

            Message? message = await _messageService.GetById(messageId);
            await _messageService.MarkAsRead(message);
        }
    }
}

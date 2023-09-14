using Core.CrossCuttingConcerns.Exceptions.ExceptionTypes;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
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

            SignalRClient? client = clients.SingleOrDefault(c => c.UserId == user.Id.ToString());

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

            Message sendingMessage = new()
            {
                SenderId = senderUser.Id,
                ReceiverId = receiverUser.Id,
                MessageText = message,
                SendDate = DateTime.UtcNow,
                IsRead = false,
            };

            SignalRClient receiverClient = clients.SingleOrDefault(c => c.UserId == receiverUser.Id.ToString());
            if (receiverClient is not null)
                await Clients.Client(receiverClient.ConnectionId).ReceiveMessage(message);

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

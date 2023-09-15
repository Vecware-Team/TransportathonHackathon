using Core.Persistence.Repositories;
using TransportathonHackathon.Domain.Entities;

namespace TransportathonHackathon.Application.Repositories
{
    public interface IPaymentRequestRepository : IAsyncRepository<PaymentRequest>, IRepository<PaymentRequest>
    {
    }
}

using Core.Persistence.Repositories;
using TransportathonHackathon.Application.Repositories;
using TransportathonHackathon.Domain.Entities;
using TransportathonHackathon.Persistence.Contexts;

namespace TransportathonHackathon.Persistence.Repositories
{
    public class PaymentRequestRepository : EfRepositoryBase<PaymentRequest, ProjectDbContext>, IPaymentRequestRepository
    {
        public PaymentRequestRepository(ProjectDbContext context) : base(context)
        {
        }
    }
}

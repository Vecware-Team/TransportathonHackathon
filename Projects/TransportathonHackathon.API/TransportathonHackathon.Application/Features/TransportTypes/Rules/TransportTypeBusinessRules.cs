using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.ExceptionTypes;
using TransportathonHackathon.Application.Repositories;
using TransportathonHackathon.Domain.Entities;

namespace TransportathonHackathon.Application.Features.TransportTypes.Rules
{
    public class TransportTypeBusinessRules : BaseBusinessRules
    {
        private readonly ITransportTypeRepository _transportTypeRepository;

        public TransportTypeBusinessRules(ITransportTypeRepository transportTypeRepository)
        {
            _transportTypeRepository = transportTypeRepository;
        }

        public async Task TypeCannotBeDuplicatedWhenInsertingOrUpdating(string type)
        {
           TransportType? transportType = await _transportTypeRepository.GetAsync(e => e.Type.ToLower() == type.ToLower());
            if (transportType is not null)
                throw new BusinessException("Transport type already exists");
        }
    }
}

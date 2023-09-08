using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TransportathonHackathon.Application.Repositories;
using TransportathonHackathon.Domain.Entities;

namespace TransportathonHackathon.Application.Features.Companies.Queries.GetByEmail
{
    public class GetByEmailCompanyQueryHandler : IRequestHandler<GetByEmailCompanyQuery, GetByEmailCompanyResponse>
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IMapper _mapper;

        public GetByEmailCompanyQueryHandler(ICompanyRepository companyRepository, IMapper mapper)
        {
            _companyRepository = companyRepository;
            _mapper = mapper;
        }

        public async Task<GetByEmailCompanyResponse> Handle(GetByEmailCompanyQuery request, CancellationToken cancellationToken)
        {
            Company? company = await _companyRepository.GetAsync(e => e.AppUser.Email == request.Email, include: e => e.Include(e => e.AppUser));
            if (company is null)
                throw new Exception();

            GetByEmailCompanyResponse response = _mapper.Map<GetByEmailCompanyResponse>(company);
            return response;
        }
    }
}

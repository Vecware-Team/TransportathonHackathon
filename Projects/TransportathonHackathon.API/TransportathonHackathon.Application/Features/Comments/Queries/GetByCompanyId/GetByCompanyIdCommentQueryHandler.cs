using AutoMapper;
using Core.Persistence.Pagination;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TransportathonHackathon.Application.Repositories;
using TransportathonHackathon.Domain.Entities;

namespace TransportathonHackathon.Application.Features.Comments.Queries.GetByCompanyId
{
    public class GetByCompanyIdCommentQueryHandler : IRequestHandler<GetByCompanyIdCommentQuery, Paginate<GetByCompanyIdCommentResponse>>
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IMapper _mapper;

        public GetByCompanyIdCommentQueryHandler(ICommentRepository commentRepository, IMapper mapper)
        {
            _commentRepository = commentRepository;
            _mapper = mapper;
        }

        public async Task<Paginate<GetByCompanyIdCommentResponse>> Handle(GetByCompanyIdCommentQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Comment> comments = await _commentRepository.GetListPagedAsync(
                e => e.TransportRequest.CompanyId == request.CompanyId,
                index: request.PageRequest.Index,
                size: request.PageRequest.Size,
                include: e => e.Include(e => e.TransportRequest).Include(e => e.TransportRequest.Company).Include(e => e.TransportRequest.Customer)
            );

            comments.Items.ToList().ForEach(e =>
            {
                e.TransportRequest.Comment = null;
                e.TransportRequest.Company.TransportRequests = null;
                e.TransportRequest.Customer.TransportRequests = null;
            });

            Paginate<GetByCompanyIdCommentResponse> response = _mapper.Map<Paginate<GetByCompanyIdCommentResponse>>(comments);
            return response;
        }
    }
}

using AutoMapper;
using Core.Persistence.Pagination;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TransportathonHackathon.Application.Repositories;
using TransportathonHackathon.Domain.Entities;

namespace TransportathonHackathon.Application.Features.Comments.Queries.GetList
{
    public class GetListCommentQueryHandler : IRequestHandler<GetListCommentQuery, Paginate<GetListCommentResponse>>
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IMapper _mapper;

        public GetListCommentQueryHandler(ICommentRepository commentRepository, IMapper mapper)
        {
            _commentRepository = commentRepository;
            _mapper = mapper;
        }

        public async Task<Paginate<GetListCommentResponse>> Handle(GetListCommentQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Comment> comments = await _commentRepository.GetListPagedAsync(
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

            Paginate<GetListCommentResponse> response = _mapper.Map<Paginate<GetListCommentResponse>>(comments);
            return response;
        }
    }
}

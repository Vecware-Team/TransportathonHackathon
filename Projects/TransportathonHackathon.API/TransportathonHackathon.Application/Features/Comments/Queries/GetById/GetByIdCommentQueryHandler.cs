using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions.ExceptionTypes;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TransportathonHackathon.Application.Repositories;
using TransportathonHackathon.Domain.Entities;

namespace TransportathonHackathon.Application.Features.Comments.Queries.GetById
{
    public class GetByIdCommentQueryHandler : IRequestHandler<GetByIdCommentQuery, GetByIdCommentResponse>
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IMapper _mapper;

        public GetByIdCommentQueryHandler(ICommentRepository commentRepository, IMapper mapper)
        {
            _commentRepository = commentRepository;
            _mapper = mapper;
        }

        public async Task<GetByIdCommentResponse> Handle(GetByIdCommentQuery request, CancellationToken cancellationToken)
        {
            Comment? comment = await _commentRepository.GetAsync(
                e => e.TransportRequestId == request.TransportRequestId,
                include: e => e.Include(e => e.TransportRequest).Include(e => e.TransportRequest.Company).Include(e => e.TransportRequest.Customer)
            );
            if (comment is null)
                throw new NotFoundException("Comment not found");

            comment.TransportRequest.Comment = null;
            comment.TransportRequest.Company.TransportRequests = null;
            comment.TransportRequest.Customer.TransportRequests = null;
            GetByIdCommentResponse response = _mapper.Map<GetByIdCommentResponse>(comment);
            return response;
        }
    }
}

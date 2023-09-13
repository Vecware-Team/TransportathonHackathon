using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TransportathonHackathon.Application.Repositories;
using TransportathonHackathon.Domain.Entities;

namespace TransportathonHackathon.Application.Features.Comments.Commands.Create
{
    public class CreateCommentCommandHandler : IRequestHandler<CreateCommentCommand, CreatedCommentResponse>
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IMapper _mapper;

        public CreateCommentCommandHandler(ICommentRepository commentRepository, IMapper mapper)
        {
            _commentRepository = commentRepository;
            _mapper = mapper;
        }

        public async Task<CreatedCommentResponse> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
        {
            Comment comment = _mapper.Map<Comment>(request);
            await _commentRepository.AddAsync(comment);

            comment = await _commentRepository.GetAsync(
                e => e.TransportRequestId == comment.TransportRequestId, 
                include: e => e.Include(e => e.TransportRequest).Include(e => e.TransportRequest.Company).Include(e => e.TransportRequest.Customer)
            );

            comment.TransportRequest.Comment = null;
            comment.TransportRequest.Company.TransportRequests = null;
            comment.TransportRequest.Customer.TransportRequests = null;

            CreatedCommentResponse response = _mapper.Map<CreatedCommentResponse>(comment);
            return response;
        }
    }
}

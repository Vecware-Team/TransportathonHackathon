using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions.ExceptionTypes;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TransportathonHackathon.Application.Repositories;
using TransportathonHackathon.Domain.Entities;

namespace TransportathonHackathon.Application.Features.Comments.Commands.Delete
{
    public class DeleteCommentCommandHandler : IRequestHandler<DeleteCommentCommand, DeletedCommentResponse>
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IMapper _mapper;

        public DeleteCommentCommandHandler(ICommentRepository commentRepository, IMapper mapper)
        {
            _commentRepository = commentRepository;
            _mapper = mapper;
        }

        public async Task<DeletedCommentResponse> Handle(DeleteCommentCommand request, CancellationToken cancellationToken)
        {
            Comment? comment = await _commentRepository.GetAsync(
                e => e.TransportRequestId == request.TransportRequestId,
                include: e => e.Include(e => e.TransportRequest).Include(e => e.TransportRequest.Company).Include(e => e.TransportRequest.Customer)
            );
            if (comment is null)
                throw new NotFoundException("Comment not found");

            TransportRequest transportRequest = _mapper.Map<TransportRequest>(comment.TransportRequest);
            await _commentRepository.DeleteAsync(comment, true);

            comment.TransportRequest = transportRequest;
            comment.TransportRequest.Comment = null;
            comment.TransportRequest.Company.TransportRequests = null;
            comment.TransportRequest.Customer.TransportRequests = null;
            
            DeletedCommentResponse response = _mapper.Map<DeletedCommentResponse>(transportRequest);
            throw new NotImplementedException();
        }
    }
}

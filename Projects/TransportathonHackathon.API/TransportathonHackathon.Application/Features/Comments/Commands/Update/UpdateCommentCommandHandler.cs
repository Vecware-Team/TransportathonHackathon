using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions.ExceptionTypes;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TransportathonHackathon.Application.Repositories;
using TransportathonHackathon.Domain.Entities;

namespace TransportathonHackathon.Application.Features.Comments.Commands.Update
{
    public class UpdateCommentCommandHandler : IRequestHandler<UpdateCommentCommand, UpdatedCommentResponse>
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IMapper _mapper;

        public UpdateCommentCommandHandler(ICommentRepository commentRepository, IMapper mapper)
        {
            _commentRepository = commentRepository;
            _mapper = mapper;
        }

        public async Task<UpdatedCommentResponse> Handle(UpdateCommentCommand request, CancellationToken cancellationToken)
        {
            Comment? comment = await _commentRepository.GetAsync(
                e => e.TransportRequestId == request.TransportRequestId,
                include: e => e.Include(e => e.TransportRequest).Include(e => e.TransportRequest.Company).Include(e => e.TransportRequest.Customer)
            );
            if (comment is null)
                throw new NotFoundException("Comment not found");

            comment.Title = request.Title;
            comment.Description = request.Description;
            comment.Point = request.Point;
            comment.UpdatedDate = DateTime.UtcNow;

            await _commentRepository.SaveChangesAsync();

            comment.TransportRequest.Comment = null;
            comment.TransportRequest.Company.TransportRequests = null;
            comment.TransportRequest.Customer.TransportRequests = null;

            UpdatedCommentResponse response = _mapper.Map<UpdatedCommentResponse>(comment);
            return response;
        }
    }
}

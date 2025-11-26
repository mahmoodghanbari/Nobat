using AutoMapper;
using MediatR;

namespace Nobat.Backend.Application.Features.Queues.Commands.CreateQueue
{
    public class CreateQueueCommandHandler : IRequestHandler<CreateQueueCommand, int>
    {
        private readonly IMapper _mapper;

        public CreateQueueCommandHandler(IMapper mapper)
        {
            _mapper = mapper;
        }

        public Task<int> Handle(CreateQueueCommand request, CancellationToken cancellationToken)
        {
            // var queue = _mapper.Map<Queue>(request);
            // add to the database and save changes
            return Task.FromResult(0); // return the new queue ID
        }
    }
}

using MediatR;

namespace Nobat.Backend.Application.Features.Queues.Commands.CreateQueue
{
    public class CreateQueueCommand : IRequest<int>
    {
        public string Name { get; set; } = string.Empty;

        public string? Description { get; set; }

        public bool IsActive { get; set; } = true;
    }
}

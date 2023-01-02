using MediatR;

namespace Scharff.Application.Commands.Client.EnableClient
{
    public class EnableClientCommand : IRequest<int>
    {
        public int IdClient { get; set; }
    }
}

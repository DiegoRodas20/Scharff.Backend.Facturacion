using MediatR;

namespace Scharff.Application.Commands.Client.DisableClient
{
    public class DisableClientCommand :IRequest<int>
    {
        public int IdClient { get; set; }
    }
}

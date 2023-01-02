using MediatR;
using Scharff.Infrastructure.Repositories.Client.DisableClient;

namespace Scharff.Application.Commands.Client.DisableClient
{
    public class DisableClientCommandHandler : IRequestHandler<DisableClientCommand, int>
    {
        private readonly IDisableClientRepository _disableClientRepository;
        public DisableClientCommandHandler(IDisableClientRepository disableClientRepository)
        {
            _disableClientRepository = disableClientRepository;
        }

        public async Task<int> Handle(DisableClientCommand request, CancellationToken cancellationToken)
        {
            var result = await _disableClientRepository.DisableClient(request.IdClient);
            return result;
        }
    }
}

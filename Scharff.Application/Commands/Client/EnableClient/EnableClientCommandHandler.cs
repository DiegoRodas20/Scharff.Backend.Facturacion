using MediatR;
using Scharff.Infrastructure.Repositories.Client.DisableClient;
using Scharff.Infrastructure.Repositories.Client.EnableClient;

namespace Scharff.Application.Commands.Client.EnableClient
{
    public class EnableClientCommandHandler : IRequestHandler<EnableClientCommand, int>
    {
        private readonly IEnableClientRepository _enableClientRepository;
        public EnableClientCommandHandler(IEnableClientRepository enableClientRepository)
        {
            _enableClientRepository = enableClientRepository;
        }

        public async Task<int> Handle(EnableClientCommand request, CancellationToken cancellationToken)
        {
            var result = await _enableClientRepository.EnableClient(request.IdClient);
            return result;
        }
    }
}

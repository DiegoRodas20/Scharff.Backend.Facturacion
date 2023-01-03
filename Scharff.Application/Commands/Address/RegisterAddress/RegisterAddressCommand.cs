using MediatR;

namespace Scharff.Application.Commands.Direction.RegisterDirection
{
    public class RegisterAddressCommand : IRequest<int>
    {
        public int client_id { get; set; }
        public int type_param { get; set; }
        public string? address { get; set; }

    }
}

using MediatR;

namespace Scharff.Application.Commands.Direction.RegisterDirection
{
    public class RegisterAddressCommand : IRequest<int>
    {
        public int id { get; set; }
        public int idCliente { get; set; }
        public int tipoDireccion_parametro { get; set; }
        public string? direccion { get; set; }

    }
}

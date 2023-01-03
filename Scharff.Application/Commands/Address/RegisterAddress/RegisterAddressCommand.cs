using MediatR;

namespace Scharff.Application.Commands.Direction.RegisterDirection
{
    public class RegisterAddressCommand : IRequest<int>
    {
        public int client_id { get; set; }
        public int type_param { get; set; }
        public int unit_id { get; set; }
        public string? address { get; set; }
        public bool? status { get; set; }
        public DateTime? creation_date { get; set; }
        public int? creation_author { get; set; }

    }
}

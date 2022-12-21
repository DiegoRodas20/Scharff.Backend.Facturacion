using MediatR;
using Scharff.Domain.Entities;

namespace Scharff.Application.Commands.Client.RegisterClient
{
    public class RegisterClientCommand : IRequest<ResponseModel>
    {
        public int TypeDocumentIdenty { get; set; }
        public string? IdentificationNumber { get; set; }
        public string? BusinessName { get; set; }
        public string? Phone { get; set; }
        public string? TradeName { get; set; }
        public int TypeCurrency { get; set; }
        public int BusinessGroup { get; set; }
        public int EconomicSector { get; set; }
        public int Holding { get; set; }
        public int Segmentation { get; set; }
    }
}

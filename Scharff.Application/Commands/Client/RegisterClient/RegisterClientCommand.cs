using MediatR;
using Scharff.Domain.Entities;

namespace Scharff.Application.Commands.Client.RegisterClient
{
    public class RegisterClientCommand : IRequest<int>
    {
        public int TypeDocumentIdentity { get; set; }
        public string? NumberDocumentIdentity { get; set; }
        public string? CompanyName { get; set; }
        public string? Phone { get; set; }
        public string? TradeName { get; set; }
        public int? TypeCurrency { get; set; }
        public int? BusinessGroup { get; set; }
        public int? CodeEconomicSector { get; set; }
        public int? Holding { get; set; }
        public int? CodeSegmentation { get; set; }
        public bool? AccountAuthorizeFedex { get; set; }
        public bool? MigrateSap { get; set; }
        public bool? StatusClient { get; set; }
        public int? AccountFedex { get; set; }
    }
}

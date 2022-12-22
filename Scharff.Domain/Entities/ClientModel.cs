using System.Net.Sockets;
using System.Numerics;

namespace Scharff.Domain.Entities
{
    public class ClientModel
    {
        public int IdClient { get; set; }
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

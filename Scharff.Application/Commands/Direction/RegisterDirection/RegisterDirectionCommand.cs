using MediatR;
using Scharff.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scharff.Application.Commands.Direction.RegisterDirection
{
    public class RegisterDirectionCommand : IRequest<ResponseModel>
    {
        public int Id { get; set; }
        public Boolean? Status { get; set; }
        public int TypeDirectionParameter { get; set; }
        public int IdClient { get; set; }
        public int IdUbigeo { get; set; }
        public string Direction { get; set; }
        public string PostalCode { get; set; }
        public DateTime? CreationDate { get; set; }
        public int AuthorCreation { get; set; }
        public DateTime? DateUpdate { get; set; }
        public int AuthorUpdate { get; set; }

    }
}

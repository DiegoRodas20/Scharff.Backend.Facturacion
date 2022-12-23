using MediatR;
using Scharff.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scharff.Application.Commands.Contact.UpdateContact
{
    public class UpdateContactCommand : IRequest<ResponseModel>
    {
        public int Id { get; set; }
        public Boolean? Status { get; set; }
        public int IdClient { get; set; }
        public int TypeContactParameter { get; set; }
        public int AreaContactParameter { get; set; }
        public string FullName { get; set; }
        public string Commentary { get; set; }
        public DateTime? CreationDate { get; set; }
        public int AuthorCreation { get; set; }
        public DateTime? DateUpdate { get; set; }
        public int AuthorUpdate { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}

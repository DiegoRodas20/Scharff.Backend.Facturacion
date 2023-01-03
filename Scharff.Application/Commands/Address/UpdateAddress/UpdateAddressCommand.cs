using MediatR;
using Scharff.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scharff.Application.Commands.Direction.UpdateDirection
{
    public class UpdateAddressCommand :IRequest<ResponseModel>
    {
        public int id { get; set; }
        public Boolean? status { get; set; }
        public int type_param { get; set; }
        public int client_id { get; set; }
        public int ubigeo_id { get; set; }
        public int unit_id { get; set; }
        public string address { get; set; }
        public string postal_code { get; set; }
     
        public DateTime? modification_date { get; set; }
        public int modification_author { get; set; }

    }
}

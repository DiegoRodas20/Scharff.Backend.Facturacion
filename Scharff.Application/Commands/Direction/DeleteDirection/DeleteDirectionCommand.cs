using MediatR;
using Scharff.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scharff.Application.Commands.Direction.DeleteDirection
{
    public class DeleteDirectionCommand : IRequest<ResponseModel>
    {
        public int Id { get; set; }

    }
}

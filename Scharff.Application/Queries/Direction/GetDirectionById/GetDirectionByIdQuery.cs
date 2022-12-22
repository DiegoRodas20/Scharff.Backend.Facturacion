using MediatR;
using Scharff.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scharff.Application.Queries.Direction.GetDirectionById
{
    public class GetDirectionByIdQuery : IRequest<DirectionModel>
    {
        public int Id { get; set; }

    }
}

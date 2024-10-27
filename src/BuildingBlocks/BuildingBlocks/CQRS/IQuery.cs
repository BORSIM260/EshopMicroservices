using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Per le operazioni di LETTURA sul db
namespace BuildingBlocks.CQRS
{
    //Deve restituire una risposta che nn sia null
    public interface IQuery<out TResponse> : IRequest<TResponse>
                                             where TResponse : notnull
    {
    }
}

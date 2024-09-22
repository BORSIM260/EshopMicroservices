using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingBlocks.CQRS
{
    //Unit rappresenta un void come tipo di ritorno, fa parte del pacchetto MediatR
    //Non restituisce nessuna risposta
    public interface ICommand : ICommand<Unit>
    {
    }

    //Restituisce una risposta. TResponde è il generics
    public interface ICommand<out TResponse> : IRequest<TResponse>
    {
    }
}

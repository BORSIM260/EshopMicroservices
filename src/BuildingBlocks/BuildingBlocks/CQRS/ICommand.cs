using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Per le operazioni di MODIFICA 
namespace BuildingBlocks.CQRS
{
    //Unit rappresenta un void come tipo di ritorno, fa parte del pacchetto MediatR
    //Non restituisce nessuna risposta
    public interface ICommand : ICommand<Unit>
    {
    }

    //Restituisce una risposta. TResponse è il generics. (TResponse e IRequest fan parte di MediatR)
    public interface ICommand<out TResponse> : IRequest<TResponse>
    {
    }
}

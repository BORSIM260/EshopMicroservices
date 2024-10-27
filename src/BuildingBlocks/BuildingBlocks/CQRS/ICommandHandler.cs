using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Interfacce specifiche per la gestione delle query di modifica da parte degli handler
namespace BuildingBlocks.CQRS
{
    //Non restituisce un risultato
    public interface ICommandHandler<in TCommand>
                         : ICommandHandler<TCommand, Unit>
                            where TCommand : ICommand<Unit>
    {
    }

    //IRequestHandler è di MediatR. Restituisce un risultato
    //Se il command restituirà un risultato useremo questa interfaccia, altrimenti l'altra
    public interface ICommandHandler<in TCommand, TResponse>
                                : IRequestHandler<TCommand, TResponse>
                                            where TCommand : ICommand<TResponse>
                                            where TResponse : notnull
    {
    }
}

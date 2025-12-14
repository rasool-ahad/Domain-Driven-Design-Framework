using DDD.Core.Contracts.ApplicationServices.Commands;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace DDD.Core.ApplicationServices.Commands;

public class CommandDispatcher : ICommandDispatcher
{
    #region Fields
    private readonly IServiceProvider _serviceProvider;
    private readonly ILogger<CommandDispatcher> _logger;
    #endregion

    #region Constructors
    public CommandDispatcher(IServiceProvider serviceProvider, ILogger<CommandDispatcher> logger)
    {
        _serviceProvider = serviceProvider;
        _logger = logger;
    }
    #endregion

    #region Send Commands
    public async Task<CommandResult> Send<TCommand>(TCommand command) where TCommand : class, ICommand
    {
        try
        {
            _logger.LogDebug("Routing command of type {CommandType} With value {Command}  Start at {StartDateTime}", command.GetType(), command, DateTime.Now);
            var handler = _serviceProvider.GetRequiredService<ICommandHandler<TCommand>>();
            return await handler.Handle(command);
        }
        catch (InvalidOperationException ex)
        {
            _logger.LogError(ex, "There is not suitable handler for {CommandType} Routing failed at {StartDateTime}.", command.GetType(), DateTime.Now);
            throw;
        }

    }

    public async Task<CommandResult<TData>> Send<TCommand, TData>(TCommand command) where TCommand : class, ICommand<TData>
    {
        try
        {
            _logger.LogDebug("Routing command of type {CommandType} With value {Command}  Start at {StartDateTime}", command.GetType(), command, DateTime.Now);
            var handler = _serviceProvider.GetRequiredService<ICommandHandler<TCommand, TData>>();
            return await handler.Handle(command);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "There is not suitable handler for {CommandType} Routing failed at {StartDateTime}.", command.GetType(), DateTime.Now);
            throw;
        }
    }

    #endregion
}
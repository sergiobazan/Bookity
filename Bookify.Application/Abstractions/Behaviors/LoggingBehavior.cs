using Bookify.Application.Abstractions.Messaging;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Bookify.Application.Abstractions.Behaviors;

public class LoggingBehavior<TRequest, TResponse> 
    : IPipelineBehavior<TRequest, TResponse>    
    where TRequest : ICommandBase
{
    private readonly ILogger<TRequest> _logger;

    public LoggingBehavior(ILogger<TRequest> logger)
    {
        _logger = logger;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        var name = request.GetType().Name;

       try
       {
           _logger.LogInformation("Start handling {command} at {date}", name, DateTime.UtcNow);

           var result = await next();
           
           _logger.LogInformation("Command {command} processed successfully at {date}", name, DateTime.UtcNow);

           return result;
       }
       catch (Exception e)
       {
           _logger.LogError(
               "Error handling {command} at {date} with error {error}",
               name,
               DateTime.UtcNow,
               e.Message);

           throw;
       }
       
    }
}
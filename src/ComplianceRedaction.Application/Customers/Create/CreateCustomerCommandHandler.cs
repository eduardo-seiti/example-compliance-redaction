using MediatR;
using Microsoft.Extensions.Logging;

namespace ComplianceRedaction.Application.Customers.Create;

internal class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, Guid>
{
    private readonly ILogger<CreateCustomerCommandHandler> _logger;

    public CreateCustomerCommandHandler(ILogger<CreateCustomerCommandHandler> logger)
    {
        _logger = logger;
    }

    public async Task<Guid> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Log without redaction {0}", request);
        _logger.LogCustomerCreated(request);

        return Guid.Empty;
    }
}

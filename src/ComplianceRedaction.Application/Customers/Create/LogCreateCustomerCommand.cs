using Microsoft.Extensions.Logging;

namespace ComplianceRedaction.Application.Customers.Create;

public static partial class LogCreateCustomerCommand
{
    [LoggerMessage(LogLevel.Information, "Log customer with redaction")]
    public static partial void LogCustomerCreated(
                            this ILogger logger,
                            [LogProperties] CreateCustomerCommand customer);
}

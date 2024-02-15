using ComplianceRedaction.Application.Logging;
using MediatR;

namespace ComplianceRedaction.Application.Customers.Create;

public record CreateCustomerCommand(
    string Name,
    [PiiData] string Email,
    string City,
    string Country,
    [SensitiveData] string HealthProblems) : IRequest<Guid>;

using Muflone.Core;

namespace BrewUp.Sales.SharedKernel.DomainIds;

public sealed class SalesOrderId(Guid value) : DomainId(value);
using Muflone.Core;
using Muflone.Messages.Events;

namespace BrewUp.Sales.Messages.Events;

public sealed class SalesOrderAlreadyCompleted(IDomainId aggregateId) : DomainEvent(aggregateId);
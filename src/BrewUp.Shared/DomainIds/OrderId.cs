using Muflone.Core;

namespace BrewUp.Shared.DomainIds;

public sealed class OrderId(Guid value) : DomainId(value);
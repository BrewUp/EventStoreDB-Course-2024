using System;
using Muflone.Core;

namespace BrewUp.Shared.DomainIds;

public sealed class ProductionOrderId(Guid value) : DomainId(value);
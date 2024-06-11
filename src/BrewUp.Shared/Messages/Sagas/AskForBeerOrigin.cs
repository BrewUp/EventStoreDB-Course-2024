using BrewUp.Shared.DomainIds;
using Muflone.Messages.Commands;

namespace BrewUp.Shared.Messages.Sagas;

public sealed class AskForBeerOrigin(BeerId aggregateId, Guid commitId) : Command(aggregateId, commitId)
{
    public BeerId BeerId = aggregateId;
}
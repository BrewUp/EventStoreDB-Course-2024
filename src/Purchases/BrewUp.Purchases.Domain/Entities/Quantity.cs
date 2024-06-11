using Muflone.Core;

namespace Brewup.Purchases.Domain.Entities;

public class Quantity(double value, string unitOfMeasure) : ValueObject
{
	public double Value { get; } = value;
	public string UnitOfMeasure { get; } = unitOfMeasure;

	protected override IEnumerable<object> GetEqualityComponents()
	{
		yield return Value;
		yield return UnitOfMeasure;
	}
}
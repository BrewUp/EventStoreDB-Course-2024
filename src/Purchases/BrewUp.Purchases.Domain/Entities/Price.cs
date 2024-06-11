using Muflone.Core;

namespace Brewup.Purchases.Domain.Entities;

public class Cost(double value, string currency) : ValueObject
{
	public double Value { get; } = value;
	public string Currency { get; } = currency;

	protected override IEnumerable<object> GetEqualityComponents()
	{
		yield return Value;
		yield return Currency;
	}
}
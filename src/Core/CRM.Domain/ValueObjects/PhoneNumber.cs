using System.Text.RegularExpressions;

namespace CRM.Domain.ValueObjects;
public record PhoneNumber
{
	private const string PhoneNumberRegex = @"^\+?[1-9]\d{1,14}$"; // E.164 format (e.g., +1234567890)
	private readonly string _value;
	private PhoneNumber(string value)
	{
		_value = value;
	}
	public string Value => _value;
	public static PhoneNumber Create(string phoneNumber)
	{
		if (string.IsNullOrWhiteSpace(phoneNumber))
		{
			throw new ArgumentException("Phone number cannot be null or empty.", nameof(phoneNumber));
		}

		var normalized = phoneNumber.Replace(" ", "").Replace("-", "");

		if (!Regex.IsMatch(normalized, PhoneNumberRegex))
		{
			throw new ArgumentException("Invalid phone number format. Must follow E.164 format (e.g., +1234567890).", nameof(phoneNumber));
		}

		return new PhoneNumber(normalized);
	}
	public override string ToString() => _value;
	// Ensure compatibility with JSON serialization (e.g., for APIs)
	public static implicit operator string(PhoneNumber phoneNumber) => phoneNumber._value;
}
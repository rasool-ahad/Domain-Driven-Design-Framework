using DDD.Core.Domain.Exceptions;
using DDD.Core.Domain.Models.ValueObjects;
using System.Text.RegularExpressions;

namespace DDD.Core.Domain.ToolKits.ValueObjects;

public class PhoneNumber : BaseValueObject<Description>
{
    #region Properties
    public string Value { get; private set; }
    #endregion

    #region Constructors and Factories
    private PhoneNumber(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new InvalidValueObjectStateException($"{value} cannot be null");

        var isPhoneNumber = Regex.IsMatch(value, @"[+]\d{1,6}_\d{5,12}", RegexOptions.IgnoreCase);

        if (!isPhoneNumber)
            throw new InvalidValueObjectStateException($"{value} is not a valid phone number");

        Value = value;
    }

    private PhoneNumber()
    {
    }

    public static PhoneNumber FromString(string value) => new(value);
    #endregion

    #region Equality Check
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
    #endregion

    #region Operator Overloading
    public static explicit operator string(PhoneNumber description) => description.Value;

    public static implicit operator PhoneNumber(string value) => new(value);
    #endregion

}
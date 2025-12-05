using DDD.Core.Domain.Exceptions;
using DDD.Core.Domain.Models.ValueObjects;
using System.Text.RegularExpressions;

namespace DDD.Core.Domain.ToolKits.ValueObjects;

public class Email : BaseValueObject<Email>
{
    #region Properties
    public string Value { get; private set; }
    #endregion

    #region Constructors and Factories
    private Email(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new InvalidValueObjectStateException($"{value} cannot be null");

        bool isEmail = Regex.IsMatch(value, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z",
            RegexOptions.IgnoreCase);

        if (!isEmail)
            throw new InvalidValueObjectStateException($"{value} is not a valid email");

        Value = value;
    }

    private Email()
    {
    }

    public static Email FromString(string value) => new(value);
    #endregion

    #region Equality Check
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
    #endregion

    #region Operator Overloading
    public static explicit operator string(Email email) => email.Value;

    public static implicit operator Email(string value) => new(value);
    #endregion
}
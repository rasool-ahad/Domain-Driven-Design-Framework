using DDD.Core.Domain.Models.ValueObjects;

namespace DDD.Core.Domain.ToolKits.ValueObjects;


public class Locale : BaseValueObject<Locale>
{
    #region Properties
    public string Code { get; private set; }
    #endregion

    #region Constructors and Factories
    private Locale(string code)
    {
        Code = code;
    }

    private Locale()
    {
    }

    public static Locale FromString(string code) => new(code);
    #endregion

    #region Equality Check
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Code;
    }
    #endregion

    #region Operator Overloading
    public static explicit operator string(Locale locale) => locale.Code;

    public static implicit operator Locale(string code) => new(code);
    #endregion
}
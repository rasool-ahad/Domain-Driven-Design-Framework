using DDD.Core.Domain.Exceptions;
using DDD.Core.Domain.Models.ValueObjects;

namespace DDD.Core.Domain.ToolKits.ValueObjects;

public class IranLegalNationalId : BaseValueObject<IranLegalNationalId>
{
    #region Properties
    public string Value { get; private set; }
    #endregion

    #region Constructors and Factories
    public static IranLegalNationalId FromString(string value) => new(value);
    private IranLegalNationalId(string value)
    {
        if (!IsLegalNationalIdValid(value))
        {
            throw new InvalidValueObjectStateException("ValidationErrorStringFormat", nameof(IranLegalNationalId));
        }

        Value = value;
    }
    private IranLegalNationalId()
    {

    }

    #endregion

    #region Equality Check

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    #endregion

    #region Operator Overloading
    public static explicit operator string(IranLegalNationalId title) => title.Value;
    public static implicit operator IranLegalNationalId(string value) => new(value);
    #endregion
    #region Methods
    public override string ToString() => Value;

    #endregion

    private static bool IsLegalNationalIdValid(string nationalId)
    {
        if (string.IsNullOrWhiteSpace(nationalId) || !(nationalId.Length == 11))
            return false;

        if (!IsFormat1Validate(nationalId))
            return false;

        if (!IsFormat2Validate(nationalId))
            return false;
        return true;

        static bool IsFormat1Validate(string nationalId)
        {
            var allDigitEqual = new[] { "00000000000", "11111111111", "22222222222", "33333333333", "44444444444", "55555555555", "66666666666", "77777777777", "88888888888", "99999999999" };
            if (!allDigitEqual.Contains(nationalId))
                return true;
            return false;
        }

        static bool IsFormat2Validate(string nationalId)
        {
            var chArray = nationalId.ToCharArray();
            var controlCode = Convert.ToInt32(nationalId[10].ToString());
            var factor = Convert.ToInt32(nationalId[9].ToString()) + 2;
            var sum = 0;
            sum += (factor + Convert.ToInt32(chArray[0].ToString())) * 29;
            sum += (factor + Convert.ToInt32(chArray[1].ToString())) * 27;
            sum += (factor + Convert.ToInt32(chArray[2].ToString())) * 23;
            sum += (factor + Convert.ToInt32(chArray[3].ToString())) * 19;
            sum += (factor + Convert.ToInt32(chArray[4].ToString())) * 17;
            sum += (factor + Convert.ToInt32(chArray[5].ToString())) * 29;
            sum += (factor + Convert.ToInt32(chArray[6].ToString())) * 27;
            sum += (factor + Convert.ToInt32(chArray[7].ToString())) * 23;
            sum += (factor + Convert.ToInt32(chArray[8].ToString())) * 19;
            sum += (factor + Convert.ToInt32(chArray[9].ToString())) * 17;
            var remaining = sum % 11;
            if (remaining == 10)
                remaining = 0;
            return remaining == controlCode;
        }
    }

}


using DDD.Core.Domain.Exceptions;
using DDD.Core.Domain.Models.ValueObjects;

namespace DDD.Core.Domain.ToolKits.ValueObjects;

public class IranNationalCode : BaseValueObject<IranNationalCode>
{
    #region Properties
    public string Value { get; private set; }
    #endregion

    #region Constructors and Factories
    public static IranNationalCode FromString(string value) => new(value);
    public IranNationalCode(string value)
    {
        if (!IsNationalCode(value))
        {
            throw new InvalidValueObjectStateException("ValidationErrorStringFormat", nameof(IranNationalCode));
        }

        Value = value;
    }
    private IranNationalCode()
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

    public static explicit operator string(IranNationalCode title) => title.Value;
    public static implicit operator IranNationalCode(string value) => new(value);
    #endregion

    #region Methods
    public override string ToString() => Value;

    public static bool IsNationalCode(string nationalCode)
    {
        if (string.IsNullOrWhiteSpace(nationalCode) || !(nationalCode.Length <= 12 && nationalCode.Length >= 8))
            return false;

        nationalCode = nationalCode.PadLeft(10, '0');

        if (!IsFormat1Validate(nationalCode))
            return false;

        if (!IsFormat2Validate(nationalCode))
            return false;
        return true;

        static bool IsFormat1Validate(string nationalCode)
        {
            var allDigitEqual = new[] { "0000000000", "1111111111", "2222222222", "3333333333", "4444444444", "5555555555", "6666666666", "7777777777", "8888888888", "9999999999" };
            if (!allDigitEqual.Contains(nationalCode))
                return true;
            return false;
        }

        static bool IsFormat2Validate(string nationalCode)
        {
            var chArray = nationalCode.ToCharArray();
            var num0 = Convert.ToInt32(chArray[0].ToString()) * 10;
            var num2 = Convert.ToInt32(chArray[1].ToString()) * 9;
            var num3 = Convert.ToInt32(chArray[2].ToString()) * 8;
            var num4 = Convert.ToInt32(chArray[3].ToString()) * 7;
            var num5 = Convert.ToInt32(chArray[4].ToString()) * 6;
            var num6 = Convert.ToInt32(chArray[5].ToString()) * 5;
            var num7 = Convert.ToInt32(chArray[6].ToString()) * 4;
            var num8 = Convert.ToInt32(chArray[7].ToString()) * 3;
            var num9 = Convert.ToInt32(chArray[8].ToString()) * 2;
            var a = Convert.ToInt32(chArray[9].ToString());

            var b = num0 + num2 + num3 + num4 + num5 + num6 + num7 + num8 + num9;
            var c = b % 11;

            var result = c < 2 && a == c || c >= 2 && 11 - c == a;
            if (result)
                return true;
            return false;
        }
    }
        #endregion
    }


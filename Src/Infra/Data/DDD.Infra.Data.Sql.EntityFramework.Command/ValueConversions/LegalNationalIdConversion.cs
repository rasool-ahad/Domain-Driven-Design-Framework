using DDD.Core.Domain.ToolKits.ValueObjects;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DDD.Infra.Data.Sql.EntityFramework.Commands.ValueConversions;

public class LegalNationalIdConversion : ValueConverter<IranLegalNationalId, string>
{
    public LegalNationalIdConversion() : base(c => c.Value, c => IranLegalNationalId.FromString(c))
    {

    }
}

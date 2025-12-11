using DDD.Core.Domain.Abstractions.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DDD.Core.Domain.Models.Entities;

public abstract class Entity<TPrimaryKey> : IEntity<TPrimaryKey>, IEquatable<Entity<TPrimaryKey>>
        where TPrimaryKey : struct,
        IComparable,
        IComparable<TPrimaryKey>,
        IConvertible,
        IEquatable<TPrimaryKey>,
        IFormattable
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public TPrimaryKey Id { get; protected set; }

    protected Entity()
    {
    }

    protected Entity(TPrimaryKey id)
    {
        if (Equals(id, default(TPrimaryKey)))
            throw new ArgumentException("The Id cannot be the default value.", "id");

        Id = id;
    }

    #region Equality Check

    public bool Equals(Entity<TPrimaryKey>? other) => this == other;
    public override bool Equals(object? obj) =>
         obj is Entity<TPrimaryKey> otherObject && Id.Equals(otherObject.Id);

    public override int GetHashCode() => Id.GetHashCode();
    public static bool operator ==(Entity<TPrimaryKey> left, Entity<TPrimaryKey> right)
    {
        if (left is null && right is null)
            return true;

        if (left is null || right is null)
            return false;

        return left.Equals((object)right);
    }

    public static bool operator !=(Entity<TPrimaryKey> left, Entity<TPrimaryKey> right)
        => !(right == left);

    #endregion
}

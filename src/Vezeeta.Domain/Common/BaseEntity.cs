namespace Vezeeta.Domain.Common;

/// <summary>
/// Represents an Entity that should be the base for all entities
/// </summary>
/// <typeparam name="T">Data type of ID</typeparam>
public abstract class BaseEntity<T> where T : notnull
{
    public T ID { get; set; } = default!;
}

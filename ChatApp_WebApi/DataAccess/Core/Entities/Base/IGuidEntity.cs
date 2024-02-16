namespace DataAccess.Core.Entities.Base;

/// <summary>
///     Represent the base interface that all entity classes
///     use <see cref="Guid"/> as the data-type for their Id.
/// </summary>
public interface IGuidEntity : IBaseEntity
{
    Guid Id { get; set; }
}

namespace Presentation.DTOs.Base;

/// <summary>
///     This class contains methods to implement the mapping on DTO object.
/// </summary>
/// <typeparam name="TMapEntity">
///     The target entity class this DTO will map to.
/// </typeparam>
public interface IDtoMapping<TMapEntity>
    where TMapEntity : class
{
    TMapEntity MapTo();
}

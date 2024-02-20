using DataAccess.Core.Entities;
using DataAccess.Specifications.Entities.Base.Generics;

namespace DataAccess.Specifications.Entities.Implementation.ChatMessages.Base
{
    public interface IChatMessageSelectSpecification : 
        IGenericSpecification<ChatMessageEntity>
    {
        /// <summary>
        ///     This specification is used to select required 
        ///     properties/fields that need to display in a list.
        /// </summary>
        IChatMessageSelectSpecification ForListDisplay();
    }
}

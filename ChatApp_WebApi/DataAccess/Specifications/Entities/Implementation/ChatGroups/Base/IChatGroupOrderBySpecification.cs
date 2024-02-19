using DataAccess.Core.Entities;
using DataAccess.Specifications.Entities.Base.Generics;

namespace DataAccess.Specifications.Entities.Implementation.ChatGroups.Base
{
    public interface IChatGroupOrderBySpecification 
        : IGenericSpecification<ChatGroupEntity>
    {
        /// <summary>
        ///     Order the list by the datetime when this chat-group was created.
        /// </summary>
        /// <param name="isAscending">
        ///     Default is true.
        /// </param>
        /// <returns></returns>
        IChatGroupOrderBySpecification ByCreatedAt(bool isAscending);

        /// <summary>
        ///     Order the list by the creatorId.
        /// </summary>
        /// <param name="isAscending">
        ///     Default is true.
        /// </param>
        /// <returns></returns>
        IChatGroupOrderBySpecification ByCreatedBy(bool isAscending);
    }
}

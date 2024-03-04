using DataAccess.Core.Entities;
using DataAccess.Specifications.Entities.Base.Generics;

namespace DataAccess.Specifications.Entities.Implementation.ChatGroupMembers.Base
{
    public interface IChatGroupMemberSelectSpecification :
        IGenericSpecification<ChatGroupMemberEntity>
    {
        /// <summary>
        ///     This specification is used to select required 
        ///     properties/fields that need to display in a list.
        /// </summary>
        IChatGroupMemberSelectSpecification ForListDisplay();

        IChatGroupMemberSelectSpecification ForGetAllJoinedGroups();
    }
}

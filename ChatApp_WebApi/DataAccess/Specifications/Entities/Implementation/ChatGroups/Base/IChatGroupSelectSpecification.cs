using DataAccess.Core.Entities;
using DataAccess.Specifications.Entities.Base.Generics;

namespace DataAccess.Specifications.Entities.Implementation.ChatGroups.Base
{
    public interface IChatGroupSelectSpecification :
        IGenericSpecification<ChatGroupEntity>
    {
        /// <summary>
        ///     This specification is used to select required 
        ///     properties/fields that need to display detail information.
        /// </summary>
        public IChatGroupSelectSpecification ForDetailDisplay();

        /// <summary>
        ///     This specification is used to select required 
        ///     properties/fields that need to display in a list.
        /// </summary>
        public IChatGroupSelectSpecification ForListDisplay();
    }
}

using DataAccess.Core.Entities;
using DataAccess.Specifications.Entities.Base.Generics;
using DataAccess.Specifications.Entities.Implementation.ChatGroupMembers;
using DataAccess.Specifications.Entities.Implementation.ChatGroupMembers.Base;
using DataAccess.Specifications.Managers.Entities.Base;

namespace DataAccess.Specifications.Managers.Entities.Implementation
{
    internal class ChatGroupMemberSpecificationManager :
        IChatGroupMemberSpecificationManager
    {
        // Backing fields.
        private IChatGroupMemberWhereSpecification _whereSpecification;
        private IChatGroupMemberSelectSpecification _selectSpecification;
        private GenericAsNoTrackingSpecification<ChatGroupMemberEntity> _asNoTrackingSpecification;
        private GenericAsSplitQuerySpecification<ChatGroupMemberEntity> _asSplitQuerySpecification;

        public IChatGroupMemberWhereSpecification Where
        {
            get
            {
                _whereSpecification ??= new ChatGroupMemberWhereSpecification();

                return _whereSpecification;
            }
        }

        public IChatGroupMemberSelectSpecification Select
        {
            get
            {
                _selectSpecification ??= new ChatGroupMemberSelectSpecification();

                return _selectSpecification;
            }
        }

        public GenericAsNoTrackingSpecification<ChatGroupMemberEntity> AsNoTracking
        {
            get
            {
                _asNoTrackingSpecification ??= new GenericAsNoTrackingSpecification<ChatGroupMemberEntity>();

                return _asNoTrackingSpecification;
            }
        }

        public GenericAsSplitQuerySpecification<ChatGroupMemberEntity> AsSplitQuery
        {
            get
            {
                _asSplitQuerySpecification ??= new GenericAsSplitQuerySpecification<ChatGroupMemberEntity>();

                return _asSplitQuerySpecification;
            }
        }

    }
}

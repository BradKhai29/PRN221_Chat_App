using DataAccess.Core.Entities;
using DataAccess.Specifications.Entities.Base.Generics;
using DataAccess.Specifications.Entities.Implementation.ChatGroups;
using DataAccess.Specifications.Entities.Implementation.ChatGroups.Base;
using DataAccess.Specifications.Managers.Entities.Base;

namespace DataAccess.Specifications.Managers.Entities.Implementation
{
    internal class ChatGroupSpecificationManager
        : IChatGroupSpecificationManager
    {
        // Backing fields.
        private IChatGroupWhereSpecification _whereSpecification;
        private IChatGroupSelectSpecification _selectSpecification;
        private IChatGroupOrderBySpecification _orderBySpecification;
        private GenericAsNoTrackingSpecification<ChatGroupEntity> _asNoTrackingSpecification;
        private GenericAsSplitQuerySpecification<ChatGroupEntity> _asSplitQuerySpecification;

        public IChatGroupWhereSpecification Where
        {
            get
            {
                _whereSpecification ??= new ChatGroupWhereSpecification();

                return _whereSpecification;
            }
        }

        public IChatGroupSelectSpecification Select
        {
            get
            {
                _selectSpecification ??= new ChatGroupSelectSpecification();

                return _selectSpecification;
            }
        }

        public IChatGroupOrderBySpecification OrderBy
        {
            get
            {
                _orderBySpecification ??= new ChatGroupOrderBySpecification();

                return _orderBySpecification;
            }
        }

        public GenericPaginationSpecification<ChatGroupEntity> Pagination(
            int skipNumber,
            int takeNumber)
        {
            return new GenericPaginationSpecification<ChatGroupEntity>(skipNumber, takeNumber);
        }

        public GenericAsNoTrackingSpecification<ChatGroupEntity> AsNoTracking
        {
            get
            {
                _asNoTrackingSpecification ??= new GenericAsNoTrackingSpecification<ChatGroupEntity>();

                return _asNoTrackingSpecification;
            }
        }

        public GenericAsSplitQuerySpecification<ChatGroupEntity> AsSplitQuery
        {
            get
            {
                _asSplitQuerySpecification ??= new GenericAsSplitQuerySpecification<ChatGroupEntity>();

                return _asSplitQuerySpecification;
            }
        }
    }
}

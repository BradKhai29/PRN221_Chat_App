using DataAccess.Core.Entities;
using DataAccess.Specifications.Entities.Base.Generics;
using DataAccess.Specifications.Entities.Implementation.ChatMessages;
using DataAccess.Specifications.Entities.Implementation.ChatMessages.Base;
using DataAccess.Specifications.Managers.Entities.Base;

namespace DataAccess.Specifications.Managers.Entities.Implementation
{
    internal class ChatMessageSpecificationManager :
        IChatMessageSpecificationManager
    {
        // Backing fields.
        private IChatMessageWhereSpecification _whereSpecification;
        private IChatMessageSelectSpecification _selectSpecification;
        private IChatMessageOrderBySpecification _orderBySpecification;
        private GenericAsNoTrackingSpecification<ChatMessageEntity> _asNoTrackingSpecification;
        private GenericAsSplitQuerySpecification<ChatMessageEntity> _asSplitQuerySpecification;

        public IChatMessageWhereSpecification Where
        {
            get
            {
                _whereSpecification ??= new ChatMessageWhereSpecification();

                return _whereSpecification;
            }
        }

        public IChatMessageSelectSpecification Select
        {
            get
            {
                _selectSpecification ??= new ChatMessageSelectSpecification();

                return _selectSpecification;
            }
        }

        public IChatMessageOrderBySpecification OrderBy
        {
            get
            {
                _orderBySpecification ??= new ChatMessageOrderBySpecification();

                return _orderBySpecification;
            }
        }

        public GenericAsNoTrackingSpecification<ChatMessageEntity> AsNoTracking
        {
            get
            {
                _asNoTrackingSpecification ??= new GenericAsNoTrackingSpecification<ChatMessageEntity>();

                return _asNoTrackingSpecification;
            }
        }

        public GenericAsSplitQuerySpecification<ChatMessageEntity> AsSplitQuery
        {
            get
            {
                _asSplitQuerySpecification ??= new GenericAsSplitQuerySpecification<ChatMessageEntity>();

                return _asSplitQuerySpecification;
            }
        }

        public GenericPaginationSpecification<ChatMessageEntity> Pagination(int skipNumber, int takeNumber)
        {
            return new GenericPaginationSpecification<ChatMessageEntity>(
                skipNumber: skipNumber,
                takeNumber: takeNumber);
        }
    }
}

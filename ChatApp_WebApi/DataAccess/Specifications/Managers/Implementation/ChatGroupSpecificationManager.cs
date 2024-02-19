using DataAccess.Core.Entities;
using DataAccess.Specifications.Entities.Base.Generics;
using DataAccess.Specifications.Entities.Implementation.ChatGroups.Base;
using DataAccess.Specifications.Managers.Base;

namespace DataAccess.Specifications.Managers.Implementation
{
    internal class ChatGroupSpecificationManager 
        : IChatGroupSpecificationManager
    {
        // Backing fields.
        private IChatGroupWhereSpecification whereSpecification;


        public IChatGroupWhereSpecification WhereSpecification => throw new NotImplementedException();

        public IChatGroupSelectSpecification SelectSpecification => throw new NotImplementedException();

        public IChatGroupOrderBySpecification OrderBySpecification => throw new NotImplementedException();

        public GenericPaginationSpecification<ChatGroupEntity> PaginationSpecification => throw new NotImplementedException();

        public GenericAsNoTrackingSpecification<ChatGroupEntity> AsNoTrackingSpecification => throw new NotImplementedException();

        public GenericAsSplitQuerySpecification<ChatGroupEntity> AsSplitQuerySpecification => throw new NotImplementedException();
    }
}

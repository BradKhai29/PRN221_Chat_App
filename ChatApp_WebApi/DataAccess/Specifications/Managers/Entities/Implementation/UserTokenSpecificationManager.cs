using DataAccess.Core.Entities;
using DataAccess.Specifications.Entities.Base.Generics;
using DataAccess.Specifications.Entities.Implementation.UserTokens;
using DataAccess.Specifications.Entities.Implementation.UserTokens.Base;
using DataAccess.Specifications.Managers.Entities.Base;

namespace DataAccess.Specifications.Managers.Entities.Implementation
{
    internal class UserTokenSpecificationManager :
        IUserTokenSpecificationManager
    {
        // Backing fields.
        private IUserTokenWhereSpecification _whereSpecification;
        private IUserTokenSelectSpecification _selectSpecification;
        private GenericAsNoTrackingSpecification<UserTokenEntity> _asNoTrackingSpecification;
        private GenericAsSplitQuerySpecification<UserTokenEntity> _asSplitQuerySpecification;

        public IUserTokenWhereSpecification Where
        {
            get
            {
                _whereSpecification ??= new UserTokenWhereSpecification();

                return _whereSpecification;
            }
        }

        public IUserTokenSelectSpecification Select
        {
            get
            {
                _selectSpecification ??= new UserTokenSelectSpecification();

                return _selectSpecification;
            }
        }

        public GenericAsNoTrackingSpecification<UserTokenEntity> AsNoTracking
        {
            get
            {
                _asNoTrackingSpecification ??= new GenericAsNoTrackingSpecification<UserTokenEntity>();

                return _asNoTrackingSpecification;
            }
        }

        public GenericAsSplitQuerySpecification<UserTokenEntity> AsSplitQuery
        {
            get
            {
                _asSplitQuerySpecification ??= new GenericAsSplitQuerySpecification<UserTokenEntity>();

                return _asSplitQuerySpecification;
            }
        }
    }
}

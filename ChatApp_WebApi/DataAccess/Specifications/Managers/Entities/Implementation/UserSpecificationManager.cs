using DataAccess.Core.Entities;
using DataAccess.Specifications.Entities.Base.Generics;
using DataAccess.Specifications.Entities.Implementation.Users;
using DataAccess.Specifications.Entities.Implementation.Users.Base;
using DataAccess.Specifications.Managers.Entities.Base;

namespace DataAccess.Specifications.Managers.Entities.Implementation
{
    internal class UserSpecificationManager : IUserSpecificationManager
    {
        // Backing fields.
        private IUserWhereSpecification _whereSpecification;
        private IUserSelectSpecification _selectSpecification;
        private GenericAsNoTrackingSpecification<UserEntity> _asNoTrackingSpecification;
        private GenericAsSplitQuerySpecification<UserEntity> _asSplitQuerySpecification;

        public IUserWhereSpecification Where
        {
            get
            {
                _whereSpecification ??= new UserWhereSpecification();

                return _whereSpecification;
            }
        }

        public IUserSelectSpecification Select
        {
            get
            {
                _selectSpecification ??= new UserSelectSpecification();

                return _selectSpecification;
            }
        }

        public GenericAsNoTrackingSpecification<UserEntity> AsNoTracking
        {
            get
            {
                _asNoTrackingSpecification ??= new GenericAsNoTrackingSpecification<UserEntity>();

                return _asNoTrackingSpecification;
            }
        }

        public GenericAsSplitQuerySpecification<UserEntity> AsSplitQuery
        {
            get
            {
                _asSplitQuerySpecification ??= new GenericAsSplitQuerySpecification<UserEntity>();

                return _asSplitQuerySpecification;
            }
        }
    }
}

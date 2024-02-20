using DataAccess.Core.Entities;
using DataAccess.Specifications.Entities.Base.Generics;
using DataAccess.Specifications.Entities.Implementation.RefreshTokens;
using DataAccess.Specifications.Entities.Implementation.RefreshTokens.Base;
using DataAccess.Specifications.Managers.Entities.Base;

namespace DataAccess.Specifications.Managers.Entities.Implementation
{
    internal class RefreshTokenSpecificationManager :
        IRefreshTokenSpecificationManager
    {
        // Backing fields.
        private IRefreshTokenWhereSpecification _whereSpecification;
        private GenericAsNoTrackingSpecification<RefreshTokenEntity> _asNoTrackingSpecification;

        public IRefreshTokenWhereSpecification Where
        {
            get
            {
                _whereSpecification ??= new RefreshTokenWhereSpecification();

                return _whereSpecification;
            }
        }

        public GenericAsNoTrackingSpecification<RefreshTokenEntity> AsNoTracking
        {
            get
            {
                _asNoTrackingSpecification ??= new GenericAsNoTrackingSpecification<RefreshTokenEntity>();

                return _asNoTrackingSpecification;
            }
        }
    }
}

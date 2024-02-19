using DataAccess.Core.Entities.Base;

namespace DataAccess.Core.Entities
{
    public class AccountStatusEntity
        : GuidEntity
    {
        public string Name { get; set; }

        // Navigation Properties.
        public IEnumerable<UserEntity> Users { get; set; }

        #region MetaData
        public static class MetaData
        {
            public const string TableName = "AccountStatuses";
        }
        #endregion
    }
}

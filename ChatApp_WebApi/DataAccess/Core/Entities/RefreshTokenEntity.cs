using DataAccess.Core.Entities.Base;

namespace DataAccess.Core.Entities
{
    public class RefreshTokenEntity : GuidEntity
    {
        /// <summary>
        ///     Get or set the UserId of this RefreshToken.
        /// </summary>
        public Guid UserId { get; set; }

        /// <summary>
        ///     Get or set the RefreshToken value.
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        ///     Get or set the AccessTokenId that belonged
        ///     to this RefreshToken.
        /// </summary>
        public Guid AccessTokenId { get; set; }

        public DateTime CreatedAt { get; set; }

        /// <summary>
        ///     Get or set the expired datetime of this refresh token.
        /// </summary>
        public DateTime ExpiredAt { get; set; }

        // Navigation Properties
        public UserEntity User { get; set; }

        #region MetaData
        public static class MetaData
        {
            public const string TableName = "RefreshTokens";
        }
        #endregion
    }
}

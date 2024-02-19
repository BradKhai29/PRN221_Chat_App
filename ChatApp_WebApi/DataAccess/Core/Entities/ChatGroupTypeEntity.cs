using DataAccess.Core.Entities.Base;

namespace DataAccess.Core.Entities;

public class ChatGroupTypeEntity : GuidEntity
{
    public string Name { get; set; }

    // Navigation Properties
    public IEnumerable<ChatGroupEntity> ChatGroups { get; set; }

    #region MetaData
    public static class MetaData
    {
        public const string TableName = "ChatGroupTypes";
    }
    #endregion
}

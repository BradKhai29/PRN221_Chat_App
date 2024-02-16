using DataAccess.Core.Entities.Base;

namespace DataAccess.Core.Entities;

public class ChatGroupTypeEntity : GuidEntity
{
    public string Name { get; set; }

    // Navigation Properties
    public IList<ChatGroupEntity> ChatGroups { get; set; }
}

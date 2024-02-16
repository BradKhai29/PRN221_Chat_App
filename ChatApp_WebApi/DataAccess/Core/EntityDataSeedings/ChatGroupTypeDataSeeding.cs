using DataAccess.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Core.EntityDataSeedings;

public class ChatGroupTypeDataSeeding : IEntityTypeConfiguration<ChatGroupTypeEntity>
{
    public void Configure(EntityTypeBuilder<ChatGroupTypeEntity> builder)
    {
        
    }
}

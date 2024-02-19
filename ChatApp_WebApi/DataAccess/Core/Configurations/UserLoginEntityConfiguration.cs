using DataAccess.Core.Configurations.Base;
using DataAccess.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Core.Configurations
{
    internal class UserLoginEntityConfiguration :
        IEntityConfiguration<UserLoginEntity>
    {
        public void Configure(EntityTypeBuilder<UserLoginEntity> builder)
        {
            builder.ToTable(UserLoginEntity.MetaData.TableName);
        }
    }
}

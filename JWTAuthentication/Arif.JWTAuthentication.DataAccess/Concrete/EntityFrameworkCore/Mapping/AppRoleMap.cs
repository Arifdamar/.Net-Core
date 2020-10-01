using System;
using System.Collections.Generic;
using System.Text;
using Arif.JWTAuthentication.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Arif.JWTAuthentication.DataAccess.Concrete.EntityFrameworkCore.Mapping
{
    public class AppRoleMap : IEntityTypeConfiguration<AppRole>
    {
        public void Configure(EntityTypeBuilder<AppRole> builder)
        {
            builder.HasKey(I => I.Id);
            builder.Property(I => I.Id).UseIdentityColumn();

            builder.Property(I => I.Name).IsRequired().HasMaxLength(100);

            builder.HasMany(I => I.AppUserRoles).WithOne(I => I.AppRole).HasForeignKey(I => I.AppRoleId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}

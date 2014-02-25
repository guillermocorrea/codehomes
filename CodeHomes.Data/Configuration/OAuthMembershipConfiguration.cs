using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodedHomes.Models;

namespace CodedHomes.Data.Configuration
{
    public class OAuthMembershipConfiguration : EntityTypeConfiguration<OAuthMembership>
    {
        public OAuthMembershipConfiguration()
        {
            this.ToTable("webpages_OAuthMembership");
            this.HasKey(k => new { k.Provider, k.ProviderUserId });

            this.Property(p => p.Provider).IsRequired().HasMaxLength(30).HasColumnType("nvarchar");

            this.Property(p => p.ProviderUserId).IsRequired().HasMaxLength(100).HasColumnType("nvarchar");

            this.Property(p => p.UserId).IsRequired();
        }

    }
}

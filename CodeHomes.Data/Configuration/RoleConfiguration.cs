﻿using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodedHomes.Models;

namespace CodedHomes.Data.Configuration
{
    public class RoleConfiguration : EntityTypeConfiguration<Role>
    {
        public RoleConfiguration()
        {
            this.ToTable("webpages_Roles");
            this.Property(p => p.RoleName).IsRequired().HasMaxLength(256);
        }
    }
}

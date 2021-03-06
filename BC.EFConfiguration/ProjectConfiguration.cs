﻿using BC.Domain;
using BC.Contracts.Configuration;
using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;

namespace BC.EFConfiguration
{
    public class ProjectConfiguration : EntityTypeConfiguration<Project>, IConfiguration
    {
        public ProjectConfiguration()
        {
            ToTable("Project");
            HasKey(k => k.Id);
            Property(p => p.Id).HasColumnName("IdProject").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(p => p.Description).IsRequired().HasMaxLength(80);
            Property(p => p.IdDepartment).IsRequired();

            HasRequired(f => f.Department).WithMany().HasForeignKey(f => f.IdDepartment);
        }
    }
}

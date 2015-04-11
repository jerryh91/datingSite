using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using ContosoUniversity.Models;

namespace ContosoUniversity.DAL
{
    public class DatingSiteContext : DbContext
    {
        public DatingSiteContext() : base("SchoolContext") { }

        public DbSet<ProfileMeta> ProfileMetas { get; set; }
        public DbSet<ProfileDetail> ProfileDetails { get; set; }
        public DbSet<ConversationMeta> ConversationMetas { get; set; }
        public DbSet<MessageDetail> MessageDetails { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Disable/Remove pluralizing of table names
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
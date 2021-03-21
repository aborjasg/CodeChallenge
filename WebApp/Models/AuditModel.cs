using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace WebApp.Models
{
    public partial class AuditModel : DbContext
    {
        public AuditModel()
            : base("name=AuditModel")
        {
        }

        public virtual DbSet<EventLog> EventLogs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EventLog>()
                .Property(e => e.vAction)
                .IsUnicode(false);
        }
    }
}

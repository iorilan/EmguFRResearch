namespace EmguFR.Train.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class EmguFRContext : DbContext
    {
        public EmguFRContext()
            : base("name=FRDataContext")
        {
        }

        public virtual DbSet<UserFace> UserFaces { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}

using System.Data.Entity;

namespace EmguFR.Recognize.Models
{
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

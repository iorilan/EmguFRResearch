using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmguFR.Recognize.Models
{
    [Table("UserFace")]
    public partial class UserFace
    {
        public long Id { get; set; }

        [StringLength(50)]
        public string UserName { get; set; }

        [Column(TypeName = "image")]
        public byte[] Face { get; set; }
    }
}

namespace EmguFR.Train.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

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

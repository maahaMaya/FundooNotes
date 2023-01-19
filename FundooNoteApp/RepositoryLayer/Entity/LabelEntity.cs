using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RepositoryLayer.Entity
{
    public class LabelEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long LabelID { get; set; }
        public string LabelHeading { get; set; }

        [ForeignKey("User")]
        public long UserId { get; set; }
        public virtual UserEntity User { get; set; }

        [ForeignKey("Note")]
        public long NoteID { get; set; }
        public virtual NoteEntity Note { get; set; }
    }
}

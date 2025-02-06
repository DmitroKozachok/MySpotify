using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Data.Entities
{
    [Table("user_music_tbl")]
    public class UserMusicEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public UserEntity UserId { get; set; }

        [Required]
        public MusicEntity MusicId { get; set; }
    }
}

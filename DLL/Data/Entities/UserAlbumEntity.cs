using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Data.Entities
{
    [Table("user_album_tbl")]
    public class UserAlbumEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public UserEntity UserId { get; set; }

        [Required]
        public AlbumEntity AlbumId { get; set; }
    }
}

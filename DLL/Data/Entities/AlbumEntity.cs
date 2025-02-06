using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Data.Entities
{
    [Table("album_tbl")]
    public class AlbumEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(1000)]
        public string Picture { get; set; }

        [Required]
        [MaxLength(320)]
        public string Artist { get; set; }

        [Required]
        [MaxLength(320)]
        public string Name { get; set; }

        [Required]
        [MaxLength(320)]
        public string ReleaseDate { get; set; }

        [Required]
        [MaxLength(320)]
        public string TotalTracks { get; set; }
    }
}

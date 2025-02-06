using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Data.Entities
{
    [Table("music_tbl")]
    public class MusicEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(1000)]
        public string Picture { get; set; }

        [Required]
        [MaxLength(320)]
        public string Artists { get; set; }

        [Required]
        [MaxLength(320)]
        public string Album { get; set; }

        [Required]
        [MaxLength(320)]
        public string Name { get; set; }

        [Required]
        [MaxLength(320)]
        public string Duration { get; set; }
    }
}

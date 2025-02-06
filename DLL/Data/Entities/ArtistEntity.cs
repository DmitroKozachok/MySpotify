using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Data.Entities
{
    [Table("artist_tbl")]
    public class ArtistEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(1000)]
        public string Picture { get; set; }

        [Required]
        [MaxLength(320)]
        public string Name { get; set; }

        [Required]
        [MaxLength(500)]
        public string ListGenres { get; set; }

        [Required]
        [MaxLength(320)]
        public string NumberSubscribers { get; set; }
    }
}

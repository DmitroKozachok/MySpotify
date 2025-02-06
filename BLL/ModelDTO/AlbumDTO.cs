using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.ModelDTO
{
    public class AlbumDTO
    {
        public int Id { get; set; }
        public string Picture { get; set; }
        public string Artist { get; set; }
        public string Name { get; set; }
        public string ReleaseDate { get; set; }
        public string TotalTracks { get; set; }
    }
}

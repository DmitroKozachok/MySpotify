using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.ModelDTO
{
    public class ArtistDTO
    {
        public int Id { get; set; }
        public string Picture { get; set; }
        public string Name { get; set; }
        public string ListGenres { get; set; }
        public string NumberSubscribers { get; set; }
    }
}

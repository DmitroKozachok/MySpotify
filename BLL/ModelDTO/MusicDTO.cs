using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.ModelDTO
{
    public class MusicDTO
    {
        public int Id { get; set; }
        public string Picture { get; set; }
        public string Artists { get; set; }
        public string Album { get; set; }
        public string Name { get; set; }
        public string Duration { get; set; }
        //public string MusicId { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class Album
    {
        public Album()
        {
            Albumbaihat = new HashSet<Albumbaihat>();
        }

        public string MaAb { get; set; }
        public string TenAb { get; set; }
        public string GhiChu { get; set; }

        public virtual ICollection<Albumbaihat> Albumbaihat { get; set; }
    }
}

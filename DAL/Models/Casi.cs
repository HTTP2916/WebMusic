using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class Casi
    {
        public Casi()
        {
            Baihat = new HashSet<Baihat>();
        }

        public string MaCaSi { get; set; }
        public string TenCaSi { get; set; }
        public string GioiTinh { get; set; }
        public string QuocTich { get; set; }
        public string HinhAnh { get; set; }
        public string GhiChu { get; set; }

        public virtual ICollection<Baihat> Baihat { get; set; }
    }
}

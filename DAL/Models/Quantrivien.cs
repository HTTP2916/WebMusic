using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class Quantrivien
    {
        public Quantrivien()
        {
            Baihat = new HashSet<Baihat>();
        }

        public string MaQuanTri { get; set; }
        public string TenQtv { get; set; }
        public string NgaySinh { get; set; }
        public string GhiChu { get; set; }

        public virtual ICollection<Baihat> Baihat { get; set; }
    }
}

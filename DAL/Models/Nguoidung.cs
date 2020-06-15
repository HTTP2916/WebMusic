using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class Nguoidung
    {
        public Nguoidung()
        {
            Playlist = new HashSet<Playlist>();
        }

        public string MaUser { get; set; }
        public string TenUser { get; set; }
        public string MatKhau { get; set; }
        public string NgaySinh { get; set; }
        public string GioiTinh { get; set; }
        public string GhiChu { get; set; }

        public virtual ICollection<Playlist> Playlist { get; set; }
    }
}

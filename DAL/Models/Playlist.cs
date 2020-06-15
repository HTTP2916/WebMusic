using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class Playlist
    {
        public string MaPlayList { get; set; }
        public string TenPlaylist { get; set; }
        public string MaBaiHat { get; set; }
        public string MaUser { get; set; }
        public string GhiChu { get; set; }

        public virtual Baihat MaBaiHatNavigation { get; set; }
        public virtual Nguoidung MaUserNavigation { get; set; }
    }
}

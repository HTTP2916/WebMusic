using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class Baihat
    {
        public Baihat()
        {
            Albumbaihat = new HashSet<Albumbaihat>();
            Playlist = new HashSet<Playlist>();
        }

        public string MaBaiHat { get; set; }
        public string MaCaSi { get; set; }
        public string MaTheLoai { get; set; }
        public string TenBaiHat { get; set; }
        public string QuocGia { get; set; }
        public string FileLoiBaiHat { get; set; }
        public string LinkNhac { get; set; }
        public string NgayTao { get; set; }
        public string NguoiTao { get; set; }
        public string NgayChinhSua { get; set; }
        public string NguoiChinhSua { get; set; }
        public string GhiChu { get; set; }

        public virtual Casi MaCaSiNavigation { get; set; }
        public virtual Theloai MaTheLoaiNavigation { get; set; }
        public virtual Quantrivien NguoiTaoNavigation { get; set; }
        public virtual ICollection<Albumbaihat> Albumbaihat { get; set; }
        public virtual ICollection<Playlist> Playlist { get; set; }
    }
}

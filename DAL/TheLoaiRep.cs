using Common.DAL;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace DAL
{
    public class TheLoaiRep : GenericRep<DBMusicContext, Theloai>
    {
        public override Theloai Read(string MaTL)
        {
            var res = All.FirstOrDefault(p => p.MaTheLoai == MaTL);
            return res;
        }
        public string Remove(string MaTL)
        {
            var n = base.All.First(i => i.MaTheLoai == MaTL);
            n = base.Delete(n);
            return n.MaTheLoai;
        }
    }
}

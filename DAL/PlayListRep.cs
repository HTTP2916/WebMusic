using Common.DAL;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public class PlayListRep : GenericRep<DBMusicContext, Playlist>
    {
        public override Playlist Read(string MaPL)
        {
            var res = All.FirstOrDefault(p => p.MaPlayList == MaPL);
            return res;
        }
        public string Remove(string MaPL)
        {
            var n = base.All.First(i => i.MaPlayList == MaPL);
            n = base.Delete(n);
            return n.MaPlayList;
        }
    }
}

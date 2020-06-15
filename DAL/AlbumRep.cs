using Common.DAL;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public class AlbumRep: GenericRep<DBMusicContext, Album>
    {
        public override Album Read(string MaAB)
        {
            var res = All.FirstOrDefault(p => p.MaAb == MaAB);
            return res;
        }
        public string Remove(string MaAB)
        {
            var n = base.All.First(i => i.MaAb == MaAB);
            n = base.Delete(n);
            return n.MaAb;
        }

    }
}

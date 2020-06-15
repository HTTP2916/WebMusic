using System;
using System.Collections.Generic;
using System.Text;
using Common.DAL;
using System.Linq;

namespace DAL
{
    using Models;
    public class MusicRep: GenericRep<DBMusicContext,Baihat>
    {
        #region
        public override Baihat Read(string MaID)
        {
            var res = All.FirstOrDefault(p => p.MaBaiHat == MaID);
            return res;
        }
        public string Remove ( string MaID )
        {
            var n = base.All.First(i => i.MaBaiHat == MaID);
            n = base.Delete(n);
            return n.MaBaiHat;
        }
        #endregion
    }
}

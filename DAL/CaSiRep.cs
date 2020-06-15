using Common.DAL;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public class CaSiRep: GenericRep<DBMusicContext, Casi>
    {
        #region
        public override Casi Read(string MaCaSi)
        {
            var res = All.FirstOrDefault(p => p.MaCaSi == MaCaSi);
            return res;
        }
        public string Remove(string MaCaSi)
        {
            var n = base.All.First(i => i.MaCaSi == MaCaSi);
            n = base.Delete(n);
            return n.MaCaSi;
        }
        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using Common.Rsp;
using Common.BLL;
using System.Linq;
using DAL;
using DAL.Models;
using Common.Req;

namespace BLL
{
    public class CaSiSvc : GenericSvc<CaSiRep, Casi>
    {
        public override SingleRsp Read(string MaCaSi)
        {
            var res = new SingleRsp();
            var m = _rep.Read(MaCaSi);
            res.Data = m;
            return res;
        }

        public object SearchCaSi(string keyword, int page, int size)
        {
            var CS = All.Where(x => x.TenCaSi.Contains(keyword));
            var offset = (page - 1) * size;
            var total = CS.Count();
            int totalPage = (total % size) == 0 ? (int)(total / size) : (int)((total / size) + 1);
            var data = CS.OrderBy(x => x.TenCaSi).Skip(offset).Take(size).ToList();
            var res = new
            {
                Data = data,
                totalRecord = total,
                TotalPage = totalPage,
                page = page,
                size = size
            };
            return res;
        }

        // Remove 
        public SingleRsp DeleteCasi(string Ma)
        {
            var res = new SingleRsp();
            try
            {
                res.Data = _rep.Remove(Ma);
            }
            catch (Exception ex)
            {
                res.SetError(ex.StackTrace);
            }
            return res;
        }

        public SingleRsp CreateCasi(CasiReq singer)
        {
            var res = new SingleRsp();
            Casi casi = new Casi();
            casi.MaCaSi = singer.MaCaSi;
            casi.TenCaSi = singer.TenCaSi;
            casi.GioiTinh = singer.GioiTinh;
            casi.QuocTich = singer.QuocTich;
            casi.HinhAnh = singer.HinhAnh;
            casi.GhiChu = singer.GhiChu;
            res = _rep.CreateCasi(casi);
            return res;
        }

        public SingleRsp UpdateCasi(CasiReq singer)
        {
            var res = new SingleRsp();
            Casi casi = new Casi();
            casi.MaCaSi = singer.MaCaSi;
            casi.TenCaSi = singer.TenCaSi;
            casi.GioiTinh = singer.GioiTinh;
            casi.QuocTich = singer.QuocTich;
            casi.HinhAnh = singer.HinhAnh;
            casi.GhiChu = singer.GhiChu;
            res = _rep.UpdateCasi(casi);
            return res;
        }
    }
}

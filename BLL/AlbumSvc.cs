using Common.BLL;
using Common.Req;
using Common.Rsp;
using DAL;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public class AlbumSvc : GenericSvc<AlbumRep, Album>
    {
        public override SingleRsp Read(string MaAB)
        {
            var res = new SingleRsp();
            var m = _rep.Read(MaAB);
            res.Data = m;
            return res;
        }
        public object SearchAlbum(string keyword, int page, int size)
        {
            var AL = All.Where(x => x.TenAb.Contains(keyword));
            var offset = (page - 1) * size;
            var total = AL.Count();
            int totalPage = (total % size) == 0 ? (int)(total / size) : (int)((total / size) + 1);
            var data = AL.OrderBy(x => x.TenAb).Skip(offset).Take(size).ToList();
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
        public SingleRsp DeleteAlbum(string Ma)
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

        public SingleRsp CreateAlbum(AlbumReq alb)
        {
            var res = new SingleRsp();
            Album album = new Album();
            album.MaAb = alb.MaAb;
            album.TenAb = alb.TenAb;
            album.GhiChu = alb.GhiChu;
            res = _rep.CreateAlbum(album);
            return res;
        }

        public SingleRsp UpdateAlbum(AlbumReq alb)
        {
            var res = new SingleRsp();
            Album album = new Album();
            album.MaAb = alb.MaAb;
            album.TenAb = alb.TenAb;
            album.GhiChu = alb.GhiChu;
            res = _rep.UpdateAlbum(album);
            return res;
        }

    }
}

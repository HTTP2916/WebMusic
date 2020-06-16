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
    public class PlayListSvc : GenericSvc<PlayListRep, Playlist>
    {
        public override SingleRsp Read(string MaPL)
        {
            var res = new SingleRsp();
            var m = _rep.Read(MaPL);
            res.Data = m;
            return res;
        }
        public object SearchPlayList(string keyword, int page, int size)
        {
            var AL = All.Where(x => x.TenPlaylist.Contains(keyword));
            var offset = (page - 1) * size;
            var total = AL.Count();
            int totalPage = (total % size) == 0 ? (int)(total / size) : (int)((total / size) + 1);
            var data = AL.OrderBy(x => x.TenPlaylist).Skip(offset).Take(size).ToList();
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
        public SingleRsp DeletePlaylist(string Ma)
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

        public object DeletePlayList(string maPlayList)
        {
            throw new NotImplementedException();
        }

        public SingleRsp CreatePlaylist(PlaylistReq pl)
        {
            var res = new SingleRsp();
            Playlist playlist = new Playlist();
            playlist.MaPlayList = pl.MaPlayList;
            playlist.TenPlaylist = pl.TenPlaylist;
            playlist.MaBaiHat = pl.MaBaiHat;
            playlist.MaUser = pl.MaUser;
            playlist.GhiChu = pl.GhiChu;
            res = _rep.CreatePlaylist(playlist);
            return res;
        }
        public SingleRsp UpdatePlaylist(PlaylistReq pl)
        {
            var res = new SingleRsp();
            Playlist playlist = new Playlist();
            playlist.MaPlayList = pl.MaPlayList;
            playlist.TenPlaylist = pl.TenPlaylist;
            playlist.MaBaiHat = pl.MaBaiHat;
            playlist.MaUser = pl.MaUser;
            playlist.GhiChu = pl.GhiChu;
            res = _rep.UpdatePlaylist(playlist);
            return res;
        }
    }
}

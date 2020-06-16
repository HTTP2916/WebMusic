using System;
using System.Collections.Generic;
using System.Text;
using Common.Rsp;
using Common.BLL;
using System.Linq;

namespace BLL
{
    using Common.Req;
    using DAL;
    using DAL.Models;
    

    public class MusicSvc: GenericSvc<MusicRep,Baihat>
    {
        public override SingleRsp Read(string MaID)
        {
            var res = new SingleRsp();
            var m = _rep.Read(MaID);
            res.Data = m;
            return res;
        }
        //public override SingleRsp 
        //Search BaiHat
        public object SearchBaiHat ( string keyword, int page, int size )
        {
            var BH = All.Where(x => x.TenBaiHat.Contains(keyword));
            var offset = (page - 1) * size;
            var total = BH.Count();
            int totalPage = (total % size) == 0 ? (int)(total / size) : (int)((total / size) + 1);
            var data = BH.OrderBy(x => x.TenBaiHat).Skip(offset).Take(size).ToList();
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
        public SingleRsp DeleteBaiHat(string Ma)
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

        public SingleRsp CreateBaihat(BaihatReq song)
        {
            var res = new SingleRsp();
            Baihat baihat = new Baihat();
            baihat.MaBaiHat = song.MaBaiHat;
            baihat.MaCaSi = song.MaCaSi;
            baihat.MaTheLoai = song.MaTheLoai;
            baihat.TenBaiHat = song.TenBaiHat;
            baihat.QuocGia = song.QuocGia;
            baihat.FileLoiBaiHat = song.FileLoiBaiHat;
            baihat.LinkNhac = song.LinkNhac;
            baihat.NgayTao = song.NgayTao;
            baihat.NguoiTao = song.NguoiTao;
            baihat.NgayChinhSua = song.NgayChinhSua;
            baihat.NguoiChinhSua = song.NguoiChinhSua;
            baihat.GhiChu = song.GhiChu;
            res = _rep.CreateBaihat(baihat);
            return res;
        }

        public SingleRsp UpdateBaihat(BaihatReq song)
        {
            var res = new SingleRsp();
            Baihat baihat = new Baihat();
            baihat.MaBaiHat = song.MaBaiHat;
            baihat.MaCaSi = song.MaCaSi;
            baihat.MaTheLoai = song.MaTheLoai;
            baihat.TenBaiHat = song.TenBaiHat;
            baihat.QuocGia = song.QuocGia;
            baihat.FileLoiBaiHat = song.FileLoiBaiHat;
            baihat.LinkNhac = song.LinkNhac;
            baihat.NgayTao = song.NgayTao;
            baihat.NguoiTao = song.NguoiTao;
            baihat.NgayChinhSua = song.NgayChinhSua;
            baihat.NguoiChinhSua = song.NguoiChinhSua;
            baihat.GhiChu = song.GhiChu;
            res = _rep.UpdateBaihat(baihat);
            return res;
        }

    }
}

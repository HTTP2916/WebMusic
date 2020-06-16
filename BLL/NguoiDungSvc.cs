using System;
using System.Collections.Generic;
using System.Text;
using Common.Rsp;
using Common.BLL;
using DAL;
using DAL.Models;
using Common.Req;

namespace Music.BLL
{

    public class NguoiDungSvc : GenericSvc<NguoiDungRep, NguoidungSvc>
    {
        public override SingleRsp Read(string Ma)
        {
            var res = new SingleRsp();
            var m = _rep.Read(Ma);
            res.Data = m;
            return res;
        }
        //public override SingleRsp 

        // Remove 
        public SingleRsp DeleteNguoiDung(string Ma)
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

        public SingleRsp CreateNguoidung(NguoidungReq user)
        {
            var res = new SingleRsp();
            NguoidungSvc nguoidung = new NguoidungSvc();
            nguoidung.MaUser = user.MaUser;
            nguoidung.TenUser = user.TenUser;
            nguoidung.MatKhau = user.MatKhau;
            nguoidung.NgaySinh = user.NgaySinh;
            nguoidung.GioiTinh = user.GioiTinh;
            nguoidung.GhiChu = user.GhiChu;
            res = _rep.CreateNguoidung(nguoidung);
            return res;
        }
        public SingleRsp UpdateNguoidung(NguoidungReq user)
        {
            var res = new SingleRsp();
            NguoidungSvc nguoidung = new NguoidungSvc();
            nguoidung.MaUser = user.MaUser;
            nguoidung.TenUser = user.TenUser;
            nguoidung.MatKhau = user.MatKhau;
            nguoidung.NgaySinh = user.NgaySinh;
            nguoidung.GioiTinh = user.GioiTinh;
            nguoidung.GhiChu = user.GhiChu;
            res = _rep.UpdateNguoidung(nguoidung);
            return res;
        }
    }
}
﻿using Common.BLL;
using Common.Rsp;
using DAL;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public class TheLoaiSvc : GenericSvc<TheLoaiRep, Theloai>
    {
        public override SingleRsp Read(string MaTL)
        {
            var res = new SingleRsp();
            var m = _rep.Read(MaTL);
            res.Data = m;
            return res;
        }
        public object SearchTheLoai(string keyword, int page, int size)
        {
            var AL = All.Where(x => x.TenTheLoai.Contains(keyword));
            var offset = (page - 1) * size;
            var total = AL.Count();
            int totalPage = (total % size) == 0 ? (int)(total / size) : (int)((total / size) + 1);
            var data = AL.OrderBy(x => x.TenTheLoai).Skip(offset).Take(size).ToList();
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
    }
}

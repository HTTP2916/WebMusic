using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Music.Controllers
{
    using BLL;
    using DAL.Models;
    using Common.Req;
    using Common.Rsp;
    [Route("api/[controller]")]
    [ApiController]
    public class TheLoaiController: ControllerBase
    {
        public TheLoaiController()
        {
            _svc = new TheLoaiSvc();
        }

        [HttpPost("get-by-MaTheLoai")]
        public IActionResult getMusicByMaTheLoai([FromBody]SimpleReq req)
        {
            var res = new SingleRsp();
            res = _svc.Read(req.Keyword);
            return Ok(res);
        }

        [HttpPost("SearchTheLoai")]
        public IActionResult SearchTheLoai([FromBody]TheLoaiSearchReq req)
        {
            var res = new SingleRsp();
            var pros = _svc.SearchTheLoai(req.Keyword, req.Page, req.Size);
            res.Data = pros;
            return Ok(res);
        }

        private readonly TheLoaiSvc _svc;
    }
}

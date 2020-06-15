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
    public class MusicController : ControllerBase
    {
        public MusicController()
        {
            _svc = new MusicSvc();
        }
        [HttpPost("get-by-MaBaiHat")]
        public IActionResult getMusicByMaBaiHat ([FromBody]SimpleReq req)
        {
            var res = new SingleRsp();
            res = _svc.Read(req.Keyword);
            return Ok(res);
        }

        [HttpPost("SearchBaiHat")]
        public IActionResult SearchBaiHat([FromBody]BaiHatSearchReq req)
        {
            var res = new SingleRsp();
            var pros = _svc.SearchBaiHat(req.Keyword, req.Page, req.Size);
            res.Data = pros;
            return Ok(res);
        }

        private readonly MusicSvc _svc;
    }
}
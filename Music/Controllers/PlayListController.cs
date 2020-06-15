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
    public class PlayListController: ControllerBase
    {
        public PlayListController()
        {
            _svc = new PlayListSvc();
        }
        [HttpPost("get-by-MaPlayList")]
        public IActionResult getMusicByMaPlayList([FromBody]SimpleReq req)
        {
            var res = new SingleRsp();
            res = _svc.Read(req.Keyword);
            return Ok(res);
        }

        [HttpPost("SearchPlayList")]
        public IActionResult SearchPlayList([FromBody]PlayListSearchReq req)
        {
            var res = new SingleRsp();
            var pros = _svc.SearchPlayList(req.Keyword, req.Page, req.Size);
            res.Data = pros;
            return Ok(res);
        }

        private readonly PlayListSvc _svc;
    }
}

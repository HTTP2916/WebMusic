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
    public class AlbumController: ControllerBase
    {
        public AlbumController()
        {
            _svc = new AlbumSvc();
        }

        [HttpPost("get-by-MaAlbum")]
        public IActionResult getMusicByMaAlbum([FromBody]SimpleReq req)
        {
            var res = new SingleRsp();
            res = _svc.Read(req.Keyword);
            return Ok(res);
        }

        [HttpPost("SearchAlbum")]
        public IActionResult SearchAlbum([FromBody]AlbumSearchReq req)
        {
            var res = new SingleRsp();
            var pros = _svc.SearchAlbum(req.Keyword, req.Page, req.Size);
            res.Data = pros;
            return Ok(res);
        }

        private readonly AlbumSvc _svc;
    }
}

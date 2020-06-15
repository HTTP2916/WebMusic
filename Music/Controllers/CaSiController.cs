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
    public class CaSiController: ControllerBase
    {
        public CaSiController()
    {
        _svc = new CaSiSvc();
    }
    [HttpPost("get-by-MaCaSi")]
    public IActionResult getMusicByMaCaSi([FromBody]SimpleReq req)
    {
        var res = new SingleRsp();
        res = _svc.Read(req.Keyword);
        return Ok(res);
    }

    [HttpPost("SearchCaSi")]
    public IActionResult SearchCaSi([FromBody]CaSiSearchReq req)
    {
        var res = new SingleRsp();
        var pros = _svc.SearchCaSi(req.Keyword, req.Page, req.Size);
        res.Data = pros;
        return Ok(res);
    }

    private readonly CaSiSvc _svc;
}
}

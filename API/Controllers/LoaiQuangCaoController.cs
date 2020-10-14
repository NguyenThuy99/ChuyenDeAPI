using System;
using Model;
using BLL;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoaiQuangCaoController : ControllerBase
    {
        private ILoaiQuangCaoBusiness _itemGroupBusiness;
        public LoaiQuangCaoController(ILoaiQuangCaoBusiness itemGroupBusiness)
        {
            _itemGroupBusiness = itemGroupBusiness;
        }
        [Route("get-all-loaiquangcao")]
        [HttpGet]
        public IEnumerable<LoaiQuangCao> GetDatabAll()
        {
            return _itemGroupBusiness.GetDataAll();
        }

    }
}

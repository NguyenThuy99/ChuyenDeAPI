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
    public class LoaiChuDeController : ControllerBase
    {
        private ILoaiChuDeBusiness _itemGroupBusiness;
        public LoaiChuDeController(ILoaiChuDeBusiness itemGroupBusiness)
        {
            _itemGroupBusiness = itemGroupBusiness;
        }
        [Route("get-all-loaichude")]
        [HttpGet]
        public IEnumerable<LoaiChuDe> GetDatabAll()
        {
            return _itemGroupBusiness.GetDataAll();
        }
    }
}

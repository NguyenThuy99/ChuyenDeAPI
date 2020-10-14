using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Model;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TKBController : ControllerBase
    {
        private ITKBBusiness _itemBusiness;
        public TKBController(ITKBBusiness itemBusiness)
        {
            _itemBusiness = itemBusiness;
        }
        [Route("get-all")]
        [HttpGet]
        public IEnumerable<TKB> GetDatabAll()
        {
            return _itemBusiness.GetDataAll();
        }
    }
}

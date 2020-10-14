using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL;
using BLL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Model;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ThucDonController : ControllerBase
    {
        private IThucDonBusiness _itemBusiness;
        public ThucDonController(IThucDonBusiness itemBusiness)
        {
            _itemBusiness = itemBusiness;
        }
        [Route("get-all")]
        [HttpGet]
        public IEnumerable<ThucDon> GetDatabAll()
        {
            return _itemBusiness.GetDataAll();
        }
    }
}

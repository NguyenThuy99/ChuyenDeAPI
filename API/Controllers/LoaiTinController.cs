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
    public class LoaiTinController : ControllerBase
    {
        private ILoaiTinBusiness _itemGroupBusiness;
        public LoaiTinController(ILoaiTinBusiness itemGroupBusiness)
        {
            _itemGroupBusiness = itemGroupBusiness;
        }

        [Route("get-menu")]
        [HttpGet]
        public IEnumerable<LoaiTin> GetAllMenu()
        {
            return _itemGroupBusiness.GetData();
        }
    }
}

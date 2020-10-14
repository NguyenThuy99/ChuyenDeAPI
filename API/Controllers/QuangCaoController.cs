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
    public class QuangCaoController : ControllerBase
    {
        private IQuangCaoBusiness _itemBusiness;
        public QuangCaoController(IQuangCaoBusiness itemBusiness)
        {
            _itemBusiness = itemBusiness;
        }

        [Route("get-by-id/{id}")]
        [HttpGet]
        public QuangCao GetDatabyID(string id)
        {
            return _itemBusiness.GetDatabyID(id);
        }
        [Route("get-all-quangcao")]
        [HttpGet]
        public IEnumerable<QuangCao> GetDatabAll()
        {
            return _itemBusiness.GetDataAll();
        }
    }
}

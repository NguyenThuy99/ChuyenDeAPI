using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChuDeController : ControllerBase
    {
        private IChuDeBusiness _itemBusiness;
        public ChuDeController(IChuDeBusiness itemBusiness)
        {
            _itemBusiness = itemBusiness;
        }

        [Route("create-item")]
        [HttpPost]
        public ChuDe CreateItem([FromBody] ChuDe model)
        {
            _itemBusiness.Create(model);
            return model;
        }

        [Route("get-by-id/{id}")]
        [HttpGet]
        public ChuDe GetDatabyID(string id)
        {
            return _itemBusiness.GetDatabyID(id);
        }
        [Route("get-all-chude")]
        [HttpGet]
        public IEnumerable<ChuDe> GetDatabAll()
        {
            return _itemBusiness.GetDataAll();
        }
        [Route("delete-chude/{id}")]
        [HttpGet]
        public IActionResult DeleteUser(int id)
        {
            _itemBusiness.Delete(id);
            return Ok();
        }
        [Route("update-chude")]
        [HttpPost]
        public ChuDe UpdateUser([FromBody] ChuDe model)
        {

            _itemBusiness.Update(model);
            return model;
        }

    }
}

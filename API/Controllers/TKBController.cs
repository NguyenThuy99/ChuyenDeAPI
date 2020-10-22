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
        [Route("delete-tkb{id}")]
        [HttpGet]
        public IActionResult DeleteUser(int id)
        {


            _itemBusiness.Delete(id);
            return Ok();
        }

        [Route("create-tkb")]
        [HttpPost]
        public TKB CreateTintuc([FromBody] TKB model)
        {
            /* if (model.hinhanh != null)
             {
                 var arrData = model.hinhanh.Split(';');
                 if (arrData.Length == 3)
                 {
                     var savePath = $@"assets/images/{arrData[0]}";
                     model.hinhanh = $"{savePath}";
                     SaveFileFromBase64String(savePath, arrData[2]);
                 }
             }*/
            //model.id = Guid.NewGuid().ToString();
            _itemBusiness.Create(model);
            return model;
        }

        [Route("update-loaitintuc")]
        [HttpPost]
        public TKB UpdateUser([FromBody] TKB model)
        {

            _itemBusiness.Update(model);
            return model;
        }
    }
}

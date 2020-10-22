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
        [Route("delete-thucdon/{id}")]
        [HttpGet]
        public IActionResult DeleteUser(int id)
        {


            _itemBusiness.Delete(id);
            return Ok();
        }

        [Route("create-thucdon")]
        [HttpPost]
        public ThucDon CreateTintuc([FromBody] ThucDon model)
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

        [Route("update-thucdon")]
        [HttpPost]
        public ThucDon UpdateUser([FromBody] ThucDon model)
        {

            _itemBusiness.Update(model);
            return model;
        }
    }
}

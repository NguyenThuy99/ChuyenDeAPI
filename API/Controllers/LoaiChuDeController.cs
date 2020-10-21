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
        [Route("delete-tintuc/{id}")]
        [HttpGet]
        public IActionResult DeleteUser(int id)
        {


            _itemGroupBusiness.Delete(id);
            return Ok();
        }

        [Route("create-tintuc")]
        [HttpPost]
        public LoaiChuDe CreateTintuc([FromBody] LoaiChuDe model)
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
            _itemGroupBusiness.Create(model);
            return model;
        }

        [Route("update-tintuc")]
        [HttpPost]
    }
}

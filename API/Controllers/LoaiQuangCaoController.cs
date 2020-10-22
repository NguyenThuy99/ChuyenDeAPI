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
        [Route("delete-loaiquangcao/{id}")]
        [HttpGet]
        public IActionResult DeleteUser(int id)
        {


            _itemGroupBusiness.Delete(id);
            return Ok();
        }

        [Route("create-loaiquangcao")]
        [HttpPost]
        public LoaiQuangCao CreateTintuc([FromBody] LoaiQuangCao model)
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

        [Route("update-loaiquangcao")]
        [HttpPost]
        public LoaiQuangCao UpdateUser([FromBody] LoaiQuangCao model)
        {

            _itemGroupBusiness.Update(model);
            return model;
        }

    }
}

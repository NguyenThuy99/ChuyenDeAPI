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
        [Route("get-all-loai")]
        [HttpGet]
        public IEnumerable<LoaiTin> GetDatabAll()
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
        public LoaiTin CreateTintuc([FromBody] LoaiTin model)
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
        public LoaiTin UpdateUser([FromBody] LoaiTin model)
        {

            _itemGroupBusiness.Update(model);
            return model;
        }
        /* [Route("get-menu")]
         [HttpGet]*/
        /*  public IEnumerable<LoaiTin> GetAllMenu()
          {
              return _itemGroupBusiness.GetData();
          }*/
    }
}

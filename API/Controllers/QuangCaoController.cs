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
        [Route("get-tin-theo-loai/{id}")]
        [HttpGet]
        public List<QuangCao> GetQuangCaoTheoLoai(int id)
        {
            return _itemBusiness.GetQuangCaoTheoLoai(id);
        }
        [Route("delete-quangcao/{id}")]
        [HttpGet]
        public IActionResult DeleteUser(int id)
        {


            _itemBusiness.Delete(id);
            return Ok();
        }

        [Route("create-quangcao")]
        [HttpPost]
        public QuangCao CreateTintuc([FromBody] QuangCao model)
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

        [Route("update-quangcao")]
        [HttpPost]
        public QuangCao UpdateUser([FromBody] QuangCao model)
        {

            _itemBusiness.Update(model);
            return model;
        }

    }
}

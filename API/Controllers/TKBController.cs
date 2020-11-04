using System;
using System.Collections.Generic;
using System.IO;
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
        private string _path;
        public TKBController(ITKBBusiness itemBusiness, IConfiguration configuration)
        {
            _itemBusiness = itemBusiness;
            _path = configuration["AppSettings:PATH"];
        }
        public string SaveFileFromBase64String(string RelativePathFileName, string dataFromBase64String)
        {
            if (dataFromBase64String.Contains("base64,"))
            {
                dataFromBase64String = dataFromBase64String.Substring(dataFromBase64String.IndexOf("base64,", 0) + 7);
            }
            return WriteFileToAuthAccessFolder(RelativePathFileName, dataFromBase64String);
        }
        public string WriteFileToAuthAccessFolder(string RelativePathFileName, string base64StringData)
        {
            try
            {
                string result = "";
                string serverRootPathFolder = _path;
                string fullPathFile = $@"{serverRootPathFolder}\{RelativePathFileName}";
                string fullPathFolder = System.IO.Path.GetDirectoryName(fullPathFile);
                if (!Directory.Exists(fullPathFolder))
                    Directory.CreateDirectory(fullPathFolder);
                System.IO.File.WriteAllBytes(fullPathFile, Convert.FromBase64String(base64StringData));
                return result;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        [Route("get-all")]
        [HttpGet]
        public IEnumerable<TKB> GetDatabAll()
        {
            return _itemBusiness.GetDataAll();
        }
        [Route("delete-tkb/{id}")]
        [HttpGet]
        public IActionResult DeleteUser(int id)
        {
            _itemBusiness.Delete(id);
            return Ok();
        }

        [Route("create-tkb")]
        [HttpPost]
        public IActionResult CreateTintuc([FromBody] Dictionary<string, object> formData)
        {
            var model = new TKB();
            model.ten = formData["ten"].ToString();
            model.hinhanh = formData["hinhanh"].ToString();
            if (model.hinhanh != null)
            {
                var arrData = model.hinhanh.Split(';');
                if (arrData.Length == 3)
                {
                    var savePath = $@"assets/images/{arrData[0]}";
                    model.hinhanh = $"{savePath}";
                    SaveFileFromBase64String(savePath, arrData[2]);
                }
            }
            //model.id = Guid.NewGuid().ToString();
            _itemBusiness.Create(model);
            return Ok(model);
        }

        [Route("update-tkb")]
        [HttpPost]
        public IActionResult UpdateUser([FromBody] Dictionary<string, object> formData)
        {
            var model = new TKB();
            model.id = int.Parse(formData["id"].ToString());
            model.ten = formData["ten"].ToString();
            var hinhanh = formData["hinhanh"];
            if (hinhanh != null)
            {
                var arrData = hinhanh.ToString().Split(';');
                if (arrData.Length == 3)
                {
                    var savePath = $@"assets/images/{arrData[0]}";
                    model.hinhanh = $"{savePath}";
                    SaveFileFromBase64String(savePath, arrData[2]);
                }
            }
            else
            {
                var tkb = _itemBusiness.GetDatabyID("" + model.id);
                model.hinhanh = tkb.hinhanh;
            }
            var kq = _itemBusiness.Update(model);
            return Ok(kq);
        }

        [Route("get-by-id/{id}")]
        [HttpGet]
        public TKB GetDatabyID(string id)
        {
            return _itemBusiness.GetDatabyID(id);
        }
    }
}

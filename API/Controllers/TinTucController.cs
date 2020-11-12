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
    public class TinTucController : ControllerBase
    {
        private ITinTucBusiness _itemBusiness;
        private string _path;

        public TinTucController(ITinTucBusiness itemBusiness, IConfiguration configuration)
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
        [Route("delete-tintuc/{id}")]
        [HttpGet]
        public IActionResult DeleteUser(int id)
        {                   
            _itemBusiness.Delete(id);
            return Ok();
        }

        [Route("create-tintuc")]
        [HttpPost]
        public IActionResult CreateTintuc([FromBody] Dictionary<string, object> formData)
        {
            var model = new TinTuc();
            model.tieude = formData["tieude"].ToString();
            model.idloai = int.Parse(formData["idloai"].ToString());
            model.mota = formData["mota"].ToString();
            model.hinhanh = formData["hinhanh"].ToString();
            model.noidung = formData["noidung"].ToString();

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

        [Route("update-tintuc")]
        [HttpPost]
        public IActionResult UpdateUser([FromBody] Dictionary<string, object> formData)
        {
            var model = new TinTuc();
            model.id = int.Parse(formData["id"].ToString());
            model.tieude = formData["tieude"].ToString();
            model.idloai = int.Parse(formData["idloai"].ToString());
            model.mota = formData["mota"].ToString();
            var hinhanh = formData["hinhanh"];
            model.noidung = formData["noidung"].ToString();

            if (hinhanh != null)
            {
                var arrData = hinhanh.ToString().Split(';');
                if (arrData.Length == 3)
                {
                    var savePath = $@"assets/images/{arrData[0]}";
                    model.hinhanh = $"{savePath}";
                    SaveFileFromBase64String(savePath, arrData[2]);
                }
            } else
            {
                var tintuc = _itemBusiness.GetDatabyID("" + model.id);
                model.hinhanh = tintuc.hinhanh;
            }
            var kq = _itemBusiness.Update(model);
            return Ok(kq);
        }
    

        [Route("get-by-id/{id}")]
        [HttpGet]
        public TinTuc GetDatabyID(string id)
        {
            return _itemBusiness.GetDatabyID(id);
        }

        [Route("get-tin-theo-loai/{id}")]
        [HttpGet]
        public List<TinTuc> GetTinTheoLoai(int id)
        {
            return _itemBusiness.GetTinTheoLoai(id);
        }

        [Route("get-all")]
        [HttpGet]
        public IEnumerable<TinTuc> GetDatabAll()
        {
            return _itemBusiness.GetDataAll();
        }

        [Route("search")]
        [HttpPost]
        public ResponseModel Search([FromBody] Dictionary<string, object> formData)
        {
            var response = new ResponseModel();
            try
            {
                var page = int.Parse(formData["page"].ToString());
                var pageSize = int.Parse(formData["pageSize"].ToString());
                string tieude = "";
                if (formData.Keys.Contains("tieude") && !string.IsNullOrEmpty(Convert.ToString(formData["tieude"]))) { tieude = Convert.ToString(formData["tieude"]); }              
                long total = 0;
                var data = _itemBusiness.Search(page, pageSize, out total, tieude);
                response.TotalItems = total;
                response.Data = data;
                response.Page = page;
                response.PageSize = pageSize;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return response;
        }
    }
}

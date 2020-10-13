using DAL.Helper;
using Model;
using DAL.Interfaces;
using Microsoft.TeamFoundation.SourceControl.WebApi;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DAL
{
    public partial class TinTucRepository : Interfaces.ITinTucRepository
    {
        private IDatabaseHelper _dbHelper;
        
        public TinTucRepository(IDatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }
        public bool Create(TinTuc model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_tintuc_all",
                "@id", model.id,
                "@idloai", model.idloai,
                "@tieude", model.tieude,
                "@hinhanh", model.hinhanh,
                "@mota", model.mota,
                "@ngaydang", model.ngaydang,
                "@noidung", model.noidung);
                if ((result != null && !string.IsNullOrEmpty(result.ToString())) || !string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(Convert.ToString(result) + msgError);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<TinTuc> GetDataAll()
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_get_tintuc");
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<TinTuc>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

       public List<TinTuc> GetTinTheoLoai(int idloai)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_get_tintuc_theoloai","@loaitin" , idloai);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<TinTuc>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public TinTuc GetDatabyID(string id)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "tintuc_id",
                     "@id", id);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<TinTuc>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

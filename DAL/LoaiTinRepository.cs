using DAL.Helper;
using DAL.Interfaces;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public partial class LoaiTinRepository : ILoaiTinRepository
    {
        private IDatabaseHelper _dbHelper;

        public LoaiTinRepository(IDatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }
        public List<LoaiTin> GetDataAll()
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_get_loaitin");
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<LoaiTin>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<TinTuc> Search(int pageIndex, int pageSize, out long total, string idloai)
        {
            string msgError = "";
            total = 0;
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_item_search",
                    "@page_index", pageIndex,
                    "@page_size", pageSize,
                    "@item_group_id", idloai);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                if (dt.Rows.Count > 0) total = (long)dt.Rows[0]["RecordCount"];
                return dt.ConvertTo<TinTuc>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //public List<LoaiTin> GetData()
        //{
        //    string msgError = "";
        //    try
        //    {
        //        var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_item_group_get_data");
        //        if (!string.IsNullOrEmpty(msgError))
        //            throw new Exception(msgError);
        //        return dt.ConvertTo<LoaiTin>().ToList();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

    }
}

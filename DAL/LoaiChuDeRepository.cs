using DAL.Helper;
using DAL.Interfaces;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public partial class LoaiChuDeRepository : ILoaiChuDeRepository
    {
        private IDatabaseHelper _dbHelper;
        public LoaiChuDeRepository(IDatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }
        public List<LoaiChuDe> GetDataAll()
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "getloaichude");
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<LoaiChuDe>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

      
    }
}

using DAL.Helper;
using DAL.Interfaces;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public partial class LoaiQuangCaoRepository : ILoaiQuangCaoRepository
    {
        private IDatabaseHelper _dbHelper;

        public LoaiQuangCaoRepository(IDatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }
        public List<LoaiQuangCao> GetDataAll()
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "get_loaiquangcao");
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<LoaiQuangCao>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

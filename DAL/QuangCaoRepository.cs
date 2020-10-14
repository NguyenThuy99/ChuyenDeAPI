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
    public partial class QuangCaoRepository : IQuangCaoRepository
    {
        private IDatabaseHelper _dbHelper;
        public QuangCaoRepository(IDatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }
        public List<QuangCao> GetDataAll()
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "get_quangcao");
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<QuangCao>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public QuangCao GetDatabyID(string id)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "quangcao_id",
                     "@id", id);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<QuangCao>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

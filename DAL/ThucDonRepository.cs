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
    public partial class ThucDonRepository : IThucDonRepository
    {
        private IDatabaseHelper _dbHelper;

        public ThucDonRepository(IDatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }
        public List<ThucDon> GetDataAll()
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "getthucdon");
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<ThucDon>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

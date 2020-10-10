using DAL.Helper;
using Model;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
  public partial class LoaiTinRepository: ILoaiTinRepository
    {
        private IDatabaseHelper _dbHelper;

        public LoaiTinRepository(IDatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }
        public bool Create(LoaiTin model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_item_create",
                "@id", model.id,
                "@tenloai", model.tenloai);
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

    }
}

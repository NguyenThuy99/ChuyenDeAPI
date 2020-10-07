using DAL.Helper;
using DAL.Interfaces;
using Microsoft.TeamFoundation.SourceControl.WebApi;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public partial interface IITinTucRepository : ITinTucRepository
    {
        private IDatabaseHelper _dbHelper;
        
        public IITinTucRepository(IDatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }
        public bool Create(ItemModel model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_item_create",
                "@item_id", model.item_id,
                "@item_group_id", model.item_group_id,
                "@item_image", model.item_image,
                "@item_name", model.item_name,
                "@item_price", model.item_price);
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

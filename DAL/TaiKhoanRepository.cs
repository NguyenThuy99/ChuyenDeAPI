using DAL.Helper;
using Model;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System;
using DAL.Interfaces;

namespace DAL
{
    public partial class TaiKhoanRepository:ITaiKhoanRepository
    {
        private IDatabaseHelper _dbHelper;
        public TaiKhoanRepository(IDatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }
        public bool Create(TaiKhoan model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_taikhoan_create",
                "@id", model.id,
                "@usename", model.usename,
                "@password", model.password,
                "@role", model.role,
                "@hoten", model.hoten,
                "@ngaysinh", model.ngaysinh,
                "@gioitinh", model.gioitinh,
                "@email", model.email,
                "@diachi", model.diachi);
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

        public bool Delete(string id)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_taikhoan_delete",
                "@user_id", id);
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
        public bool Update(TaiKhoan model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_taikhoan_update",
                 "@id", model.id,
                "@usename", model.usename,
                "@password", model.password,
                "@role", model.role,
                "@hoten", model.hoten,
                "@ngaysinh", model.ngaysinh,
                "@gioitinh", model.gioitinh,
                "@email", model.email,
                "@diachi", model.diachi);
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
        public TaiKhoan GetUser(string usename, string password)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_user_get_by_username_password",
                     "@usename", usename,
                     "@password", password);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<TaiKhoan>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public TaiKhoan GetDatabyID(string id)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_user_get_by_id",
                     "@user_id", id);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<TaiKhoan>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<TaiKhoan> Search(int pageIndex, int pageSize, out long total, string hoten, string usename)
        {
            string msgError = "";
            total = 0;
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_taikhoan_search",
                    "@page_index", pageIndex,
                    "@page_size", pageSize,
                    "@hoten", hoten,
                    "@usename", usename);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                if (dt.Rows.Count > 0) total = (long)dt.Rows[0]["RecordCount"];
                return dt.ConvertTo<TaiKhoan>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

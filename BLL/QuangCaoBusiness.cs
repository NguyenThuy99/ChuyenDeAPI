﻿using BLL.Interfaces;
using DAL;
using DAL.Interfaces;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public partial class QuangCaoBusiness : IQuangCaoBusiness
    {
        private IQuangCaoRepository _res;
        public QuangCaoBusiness(IQuangCaoRepository QuangCaoGroupRes)
        {
            _res = QuangCaoGroupRes;
        }
   /*     public bool Create(TinTuc model)
        {
            return _res.Create(model);
        }*/
        public QuangCao GetDatabyID(string id)
        {
            return _res.GetDatabyID(id);
        }
        public List<QuangCao> GetDataAll()
        {
            return _res.GetDataAll();
        }
        public List<QuangCao> GetQuangCaoTheoLoai(int id)
        {
            return _res.GetQuangCaoTheoLoai(id);
        }
        public bool Delete(int id)
        {
            return _res.Delete(id);
        }
        public bool Update(QuangCao model)
        {
            return _res.Update(model);
        }
        public bool Create(QuangCao model)
        {
            return _res.Create(model);
        }
    }
}

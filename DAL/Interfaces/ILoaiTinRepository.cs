﻿using System;
using Model;
using System.Collections.Generic;
using System.Text;

namespace DAL.Interfaces
{
    public partial interface ILoaiTinRepository
    {
        List<LoaiTin> GetData();
    }
}

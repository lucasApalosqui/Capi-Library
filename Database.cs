﻿using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapiLibrary
{
    public static class Database
    {
        public static SqlConnection Connection { get; set; }
    }
}

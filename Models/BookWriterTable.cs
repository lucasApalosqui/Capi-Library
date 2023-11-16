using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapiLibrary.Models
{
    [Table("BookWriter_Table")]
    public class BookWriterTable
    {
        public int IdBook { get; set; }
        public int IdWriter { get; set; }
    }
}

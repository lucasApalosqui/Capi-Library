using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapiLibrary.Models
{
    [Table("Writer_Table")]
    public class WriterTable
    {
        public WriterTable()
            => Books = new List<BookTable>();

        public int Id { get; set; }
        public string Name { get; set; }

        [Write(false)]
        public List<BookTable> Books { get; set; }
    }
}

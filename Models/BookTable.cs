using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapiLibrary.Models
{
    [Table("Book_Table")]
    public class BookTable
    {
        public BookTable()
            => Categories = new List<CategoryTable>();

        public int Id { get; set; }
        public string Title { get; set; }
        public string Synopsis { get; set; }
        public int Pages { get; set; }
        public string GeneralAud { get; set; }


        [Write(false)]
        public List<CategoryTable> Categories { get; set; }

    }
}

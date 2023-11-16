using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapiLibrary.Models
{
    [Table("BookCategory_Table")]
    public class BookCategoryTable
    {
        public int IdBook { get; set; }
        public int IdCategory { get; set; }
    }
}

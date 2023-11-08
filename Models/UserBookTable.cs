using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapiLibrary.Models
{
    [Table("UserBook_Table")]
    public class UserBookTable
    {
        public int IdUser { get; set; }
        public int IdBook { get; set; }
        public DateTime GetDate { get; set; }
        public DateTime ReturnDate { get; set; }


    }
}

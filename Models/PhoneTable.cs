using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapiLibrary.Models
{
    [Table("Phone_Table")]
    public class PhoneTable
    {
        public int Id { get; set; }
        public string Phone { get; set; }
        public int UserId { get; set; }

    }
}

using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapiLibrary.Models
{
    [Table("Address_Table")]
    public class AddressTable
    {
        public int Id { get; set; }
        public string Street { get; set; }
        public string District { get; set; }
        public string State { get; set; }
        public int Number { get; set; }
        public string Complement { get; set; }

    }
}

using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapiLibrary.Models
{
    [Table("Category_Table")]
    public class CategoryTable
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}

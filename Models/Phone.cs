using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapiLibrary.Models
{
    [Table("Phone_Table")]
    public class Phone
    {
        public int Id { get; set; }

        [Column("Phone")]
        public string phone { get; set; }
   
    }
}

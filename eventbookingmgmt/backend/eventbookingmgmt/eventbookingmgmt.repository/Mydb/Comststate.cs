using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eventbookingmgmt.repository.Mydb
{
    public class Comststate
    {
        [Key]
        public Int64 rid { get; set; }
        public string statecode { get; set; } = "";
        public string statename { get; set; } = "";
        public string stateremark1 { get; set; } = "";
        public string stateremark2 { get; set; } = "";
    }
}

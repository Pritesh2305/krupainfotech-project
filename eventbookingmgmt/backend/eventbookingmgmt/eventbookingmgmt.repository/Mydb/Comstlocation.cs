using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eventbookingmgmt.repository.Mydb
{
    public class Comstlocation
    {
        [Key]
        public Int64 rid { get; set; }
        public string? loccode { get; set; } = "";
        public string? locname { get; set; } = "";
        public string? locremark1 { get; set; } = "";
        public string? locremark2 { get; set; } = "";
    }
}

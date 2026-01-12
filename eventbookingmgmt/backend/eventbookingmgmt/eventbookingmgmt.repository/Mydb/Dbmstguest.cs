using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace eventbookingmgmt.repository.Mydb
{
    [Table("mstguest")]
    public class Dbmstguest
    {
        [Key]
        public Int64? rid { get; set; }
        public string? gcode { get; set; } = "";
        public string? gname { get; set; } = "";
        public string?  gmobno { get; set; } = "";
        public string? gwano { get; set; } = "";
        public string? gemail { get; set; } = "";
        public string? gadd1 { get; set; } = "";
        public string? gadd2 { get; set; } = "";
        public string? gadd3 { get; set; } = "";

        public Int64? gcityrid = 0;

        public Int64? gstaterid = 0;

        public Int64? gcountryrid = 0;
        public string? gremark1 { get; set; } = "";
        public string? gremark2 { get; set; } = "";
        public Int64? arid { get; set; }
        public DateTime? adatetime { get; set; }
        public Int64? erid { get; set; }
        public DateTime? edatetime { get; set; }
        public Int64? drid { get; set; }
        public DateTime? ddatetime { get; set; }
        public bool? delflg { get; set; }
    }
}
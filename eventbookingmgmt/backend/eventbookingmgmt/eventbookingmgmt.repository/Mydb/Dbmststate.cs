using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eventbookingmgmt.repository.Mydb
{
    [Table("mststate")]
    public class Dbmststate
    {
        [Key]
        public Int64 rid { get; set; }
        public string? statecode { get; set; } = "";
        public string? statename { get; set; } = "";
        public string? stateremark1 { get; set; } = "";
        public string? stateremark2 { get; set; } = "";
        public Int64? arid { get; set; }
        public DateTime? adatetime { get; set; }
        public Int64? erid { get; set; }
        public DateTime? edatetime { get; set; }
        public Int64? drid { get; set; }
        public DateTime? ddatetime { get; set; }
        public bool? delflg { get; set; }
    }
}

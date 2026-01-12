using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eventbookingmgmt.repository.Mydb
{
    [Table("mstcity")]
    public class Dbmstcity
    {
        [Key]
        public Int64 rid { get; set; }
        public string? citycode { get; set; } = "";
        public string? cityname { get; set; } = "";
        public string? cityremark1 { get; set; } = "";
        public string? cityremark2 { get; set; } = "";
        public Int64? arid { get; set; }
        public DateTime? adatetime { get; set; }
        public Int64? erid { get; set; }
        public DateTime? edatetime { get; set; }
        public Int64? drid { get; set; }
        public DateTime? ddatetime { get; set; }
        public bool? delflg { get; set; }
    }
}

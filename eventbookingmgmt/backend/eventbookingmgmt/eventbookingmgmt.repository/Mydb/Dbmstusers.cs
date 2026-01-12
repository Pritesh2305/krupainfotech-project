using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eventbookingmgmt.repository.Mydb
{
    [Table("mstusers")]
    public class Dbmstusers
    {
        [Key]
        public Int64 rid { get; set; }
        public string? usercode { get; set; } = "";
        public string? firstname { get; set; } = "";
        public string? lastname { get; set; } = "";
        public string? username { get; set; } = "";
        public string? userpassword { get; set; } = "";
        public Int64? usertyperid { get; set; }
        public Int64? arid { get; set; }
        public DateTime? adatetime { get; set; }
        public Int64? erid { get; set; }
        public DateTime? edatetime { get; set; }
        public Int64? drid { get; set; }
        public DateTime? ddatetime { get; set; }
        public bool? delflg { get; set; }
    }
}

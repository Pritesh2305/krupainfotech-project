using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eventbookingmgmt.entities.ResponseDto.mstlocation
{
    public class DbmstlocationResponse
    {
        public Int64 rid { get; set; }
        public string? locationcode { get; set; } = "";
        public string? locationname { get; set; } = "";
        public string? locationremark1 { get; set; } = "";
        public string? locationremark2 { get; set; } = "";
        public Int64? arid { get; set; }
        public DateTime? adatetime { get; set; }
        public Int64? erid { get; set; }
        public DateTime? edatetime { get; set; }
        public Int64? drid { get; set; }
        public DateTime? ddatetime { get; set; }
        public bool? delflg { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eventbookingmgmt.entities.ResponseDto.mstcountry
{
    public class DbmstcountryResponse
    {
        public Int64 rid { get; set; }
        public string? countrycode { get; set; } = "";
        public string? countryname { get; set; } = "";
        public string? countryremark1 { get; set; } = "";
        public string? countryremark2 { get; set; } = "";
        public Int64? arid { get; set; }
        public DateTime? adatetime { get; set; }
        public Int64? erid { get; set; }
        public DateTime? edatetime { get; set; }
        public Int64? drid { get; set; }
        public DateTime? ddatetime { get; set; }
        public bool? delflg { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eventbookingmgmt.entities.RequestDto
{
    public class mstcityRequest
    {
        public Int64 rid { get; set; }
        public string? citycode { get; set; } = "";
        public string? cityname { get; set; } = "";
        public string? cityremark1 { get; set; } = "";
        public string? cityremark2 { get; set; } = "";
        public Int64 urid { get; set; }
    }
}

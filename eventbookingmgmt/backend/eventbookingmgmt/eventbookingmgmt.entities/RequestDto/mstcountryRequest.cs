using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eventbookingmgmt.entities.RequestDto
{
    public class mstcountryRequest
    {
        public Int64 rid { get; set; }
        public string? countrycode { get; set; } = "";
        public string? countryname { get; set; } = "";
        public string? countryremark1 { get; set; } = "";
        public string? countryremark2 { get; set; } = "";
        public Int64 urid { get; set; }
    }
}

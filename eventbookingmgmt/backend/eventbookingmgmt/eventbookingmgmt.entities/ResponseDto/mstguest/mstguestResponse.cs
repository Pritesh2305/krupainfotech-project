using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eventbookingmgmt.entities.ResponseDto.mstguest
{
    public class mstguestResponse
    {
        public Int64? rid { get; set; }
        public string? gcode { get; set; } = "";
        public string? gname { get; set; } = "";
        public string? gmobno { get; set; } = "";
        public string? gemail { get; set; } = "";
        public string? countryname { get; set; } = "";
        public string? statename { get; set; } = "";
        public string? cityname { get; set; } = "";
      
    }
}

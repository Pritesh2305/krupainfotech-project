using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eventbookingmgmt.entities.RequestDto
{
    public class mstguestRequest
    {
        public Int64 rid { get; set; }
        public string? gcode { get; set; } = "";
        public string? gname { get; set; } = "";
        public string? gmobno { get; set; } = "";
        public string? gwano { get; set; } = "";
        public string? gemail { get; set; } = "";
        public string? gadd1 { get; set; } = "";
        public string? gadd2 { get; set; } = "";
        public string? gadd3 { get; set; } = "";

        public Int64? gcityrid { get; set; } = 0;

        public Int64? gstaterid { get; set; } = 0;

        public Int64? gcountryrid { get; set; } = 0;
        public string? gremark1 { get; set; } = "";
        public string? gremark2 { get; set; } = "";
        public Int64? urid { get; set; }
    }
}

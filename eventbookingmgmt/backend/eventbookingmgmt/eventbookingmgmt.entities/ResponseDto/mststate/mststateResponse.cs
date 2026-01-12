using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eventbookingmgmt.entities.ResponseDto.mststate
{
    public class mststateResponse
    {
        public Int64? rid { get; set; }
        public string? statecode { get; set; } = "";
        public string? statename { get; set; } = "";
        public string? stateremark1 { get; set; } = "";
        public string? stateremark2 { get; set; } = "";

    }
}

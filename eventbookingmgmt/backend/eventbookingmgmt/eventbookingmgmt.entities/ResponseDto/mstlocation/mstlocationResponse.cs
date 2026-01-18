using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eventbookingmgmt.entities.ResponseDto.mstlocation
{
    public class mstlocationResponse
    {
        public Int64 rid { get; set; }
        public string? loccode { get; set; } = "";
        public string? locname { get; set; } = "";
        public string? locremark1 { get; set; } = "";
        public string? locremark2 { get; set; } = "";
    }
}

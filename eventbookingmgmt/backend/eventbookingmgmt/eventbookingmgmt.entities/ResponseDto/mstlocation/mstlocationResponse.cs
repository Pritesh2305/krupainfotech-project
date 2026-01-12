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
        public string? locationcode { get; set; } = "";
        public string? locationname { get; set; } = "";
        public string? locationremark1 { get; set; } = "";
        public string? locationremark2 { get; set; } = "";
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eventbookingmgmt.entities.ResponseDto
{
    public class mstusersResponse
    {
        public Int64 rid { get; set; }
        public string usercode { get; set; } = "";
        public string firstname { get; set; } = "";
        public string lastname { get; set; } = "";
        public string username { get; set; } = "";
        public Int64? usertyperid { get; set; }
        public bool? delflg { get; set; }
    }
}

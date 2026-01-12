using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eventbookingmgmt.entities.ResponseDto
{
    public class LoginResponse
    {
        public Int64 rid { get; set; }
        public string? clientcode { get; set; } = "";
        public string? usercode { get; set; } = "";
        public string? firstname { get; set; } = "";
        public string? lastname { get; set; } = "";
        public string? username { get; set; } = "";
        public Int64? usertyperid { get; set; }
        public string? usertype { get; set; } = "";
        public string? token { get; set; } = "";
    }
}

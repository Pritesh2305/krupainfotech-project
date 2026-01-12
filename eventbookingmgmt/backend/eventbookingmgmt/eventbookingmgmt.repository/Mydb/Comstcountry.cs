using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eventbookingmgmt.repository.Mydb
{
    public class Comstcountry
    {
        [Key]
        public Int64 rid { get; set; }
        public string countrycode { get; set; } = "";
        public string countryname { get; set; } = "";
        public string countryremark1 { get; set; } = "";
        public string countryremark2 { get; set; } = "";
    }
}

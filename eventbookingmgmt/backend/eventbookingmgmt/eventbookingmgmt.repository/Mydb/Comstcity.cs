using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eventbookingmgmt.repository.Mydb
{
    public class Comstcity
    {
        [Key]
        public Int64 rid { get; set; }
        public string citycode { get; set; } = "";
        public string cityname { get; set; } = "";
        public string cityremark1 { get; set; } = "";
        public string cityremark2 { get; set; } = "";       
    }
}

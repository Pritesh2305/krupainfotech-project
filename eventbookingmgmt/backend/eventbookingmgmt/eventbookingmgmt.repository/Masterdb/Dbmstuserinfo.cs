
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace eventbookingmgmt.repository.masterdb
{
    [Table("mstuserinfo")]
    public class Dbmstuserinfo
    {
        [Key]
        public Int64 rid { get; set; }
        public string clientcode { get; set; } = "";
        public string connservernm { get; set; } = "";
        public string conndbnm { get; set; } = "";
        public string conndbuid { get; set; } = "";
        public string conndbupass { get; set; } = "";
        public string connstr { get; set; } = "";
    }
}

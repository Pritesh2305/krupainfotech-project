using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eventbookingmgmt.entities.Common
{
    public class ResultDto<T>
    {
        public bool ISuccess { get; set; }
        public T? Data { get; set; }
        public List<string>? Errors { get; set; }
    }
}

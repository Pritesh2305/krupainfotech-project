using eventbookingmgmt.entities.Common;
using eventbookingmgmt.entities.RequestDto;
using eventbookingmgmt.repository.Mydb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eventbookingmgmt.repository.Interface
{
    public interface ImstusersRepository
    {
        CoUserLogin? Login(LoginRequest model);
        ResultDto<Dbmstusers?> GetById(Int64 Id);
        ResultDto<IEnumerable<Dbmstusers?>> GetAll();
    }
}

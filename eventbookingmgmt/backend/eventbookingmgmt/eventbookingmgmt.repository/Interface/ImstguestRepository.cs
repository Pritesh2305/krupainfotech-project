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
    public interface ImstguestRepository
    {
        ResultDto<RidResponse> Insert(mstguestRequest viewModel);
        ResultDto<RidResponse> Update(mstguestRequest viewModel);
        ResultDto<RidResponse> Delete(DelRequest viewModel);
        ResultDto<IEnumerable<Dbmstguest?>> GetAllDetails();
        ResultDto<IEnumerable<Comstguest?>> GetList();
        ResultDto<Dbmstguest?> GetById(Int64 Id);
    }
}

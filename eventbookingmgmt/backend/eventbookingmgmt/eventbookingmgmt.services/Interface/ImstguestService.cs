using eventbookingmgmt.entities.Common;
using eventbookingmgmt.entities.RequestDto;
using eventbookingmgmt.entities.ResponseDto.mstcountry;
using eventbookingmgmt.entities.ResponseDto.mstguest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eventbookingmgmt.services.Interface
{
    public interface ImstguestService
    {
        ResultDto<RidResponse> Insert(mstguestRequest viewModel);
        ResultDto<RidResponse> Update(mstguestRequest viewModel);
        ResultDto<RidResponse> Delete(DelRequest viewModel);
        ResultDto<IEnumerable<DbmstguestResponse?>> GetAllDetails();
        ResultDto<IEnumerable<mstguestResponse?>> GetList();
        ResultDto<DbmstguestResponse> GetById(Int64 Id);
    }
}

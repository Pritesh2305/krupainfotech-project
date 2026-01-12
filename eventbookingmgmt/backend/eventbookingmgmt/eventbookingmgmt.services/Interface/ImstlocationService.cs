using eventbookingmgmt.entities.Common;
using eventbookingmgmt.entities.RequestDto;
using eventbookingmgmt.entities.ResponseDto.mstcountry;
using eventbookingmgmt.entities.ResponseDto.mstlocation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eventbookingmgmt.services.Interface
{
    public interface ImstlocationService
    {
        ResultDto<RidResponse> Insert(mstlocationRequest viewModel);
        ResultDto<RidResponse> Update(mstlocationRequest viewModel);
        ResultDto<RidResponse> Delete(DelRequest viewModel);
        ResultDto<IEnumerable<DbmstlocationResponse?>> GetAllDetails();
        ResultDto<IEnumerable<mstlocationResponse?>> GetList();
        ResultDto<mstlocationResponse> GetById(Int64 Id);
    }
}

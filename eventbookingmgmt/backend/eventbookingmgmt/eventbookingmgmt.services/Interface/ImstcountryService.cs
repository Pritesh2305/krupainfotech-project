using eventbookingmgmt.entities.Common;
using eventbookingmgmt.entities.RequestDto;
using eventbookingmgmt.entities.ResponseDto.mstcountry;
using eventbookingmgmt.entities.ResponseDto.mststate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eventbookingmgmt.services.Interface
{
    public interface ImstcountryService
    {
        ResultDto<RidResponse> Insert(mstcountryRequest viewModel);
        ResultDto<RidResponse> Update(mstcountryRequest viewModel);
        ResultDto<RidResponse> Delete(DelRequest viewModel);
        ResultDto<IEnumerable<DbmstcountryResponse?>> GetAllDetails();
        ResultDto<IEnumerable<mstcountryResponse?>> GetList();
        ResultDto<mstcountryResponse> GetById(Int64 Id);
    }
}

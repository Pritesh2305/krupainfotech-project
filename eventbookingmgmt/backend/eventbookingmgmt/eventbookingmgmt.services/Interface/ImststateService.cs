using eventbookingmgmt.entities.Common;
using eventbookingmgmt.entities.RequestDto;
using eventbookingmgmt.entities.ResponseDto;
using eventbookingmgmt.entities.ResponseDto.mststate;
using eventbookingmgmt.repository.Mydb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eventbookingmgmt.services.Interface
{
    public interface ImststateService
    {
        ResultDto<RidResponse> Insert(mststateRequest viewModel);
        ResultDto<RidResponse> Update(mststateRequest viewModel);
        ResultDto<RidResponse> Delete(DelRequest viewModel);
        ResultDto<IEnumerable<DbmststateResponse?>> GetAllDetails();
        ResultDto<IEnumerable<mststateResponse?>> GetList();
        ResultDto<mststateResponse> GetById(Int64 Id);
       

    }
}

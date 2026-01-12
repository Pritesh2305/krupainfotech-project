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
    public interface ImstlocationRepository
    {
        ResultDto<RidResponse> Insert(mstlocationRequest viewModel);
        ResultDto<RidResponse> Update(mstlocationRequest viewModel);
        ResultDto<RidResponse> Delete(DelRequest viewModel);
        ResultDto<IEnumerable<Dbmstlocation?>> GetAllDetails();
        ResultDto<IEnumerable<Comstlocation?>> GetList();
        ResultDto<Dbmstlocation?> GetById(Int64 Id);
    }
}

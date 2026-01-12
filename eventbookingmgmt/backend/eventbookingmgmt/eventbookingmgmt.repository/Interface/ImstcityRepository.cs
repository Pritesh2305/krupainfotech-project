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
    public interface ImstcityRepository
    {
        ResultDto<RidResponse> Insert(mstcityRequest viewModel);
        ResultDto<RidResponse> Update(mstcityRequest viewModel);
        ResultDto<RidResponse> Delete(DelRequest viewModel);
        ResultDto<IEnumerable<Dbmstcity?>> GetlistDetails();
        ResultDto<IEnumerable<Dbmstcity?>> GetAllDetails();
        ResultDto<IEnumerable<Comstcity?>> Getlist();
        ResultDto<IEnumerable<Comstcity?>> GetAll();
        ResultDto<Comstcity?> GetById(Int64 Id);
    }
}

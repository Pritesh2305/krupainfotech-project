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
    public interface ImstcountryRepository
    {
        ResultDto<RidResponse> Insert(mstcountryRequest viewModel);
        ResultDto<RidResponse> Update(mstcountryRequest viewModel);
        ResultDto<RidResponse> Delete(DelRequest viewModel);
        ResultDto<IEnumerable<Dbmstcountry?>> GetAllDetails();
        ResultDto<IEnumerable<Comstcountry?>> GetList();
        ResultDto<Dbmstcountry?> GetById(Int64 Id);
    }
}

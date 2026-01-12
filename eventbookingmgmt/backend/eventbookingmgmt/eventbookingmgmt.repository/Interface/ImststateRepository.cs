using eventbookingmgmt.entities.Common;
using eventbookingmgmt.entities.RequestDto;
using eventbookingmgmt.entities.ResponseDto;
using eventbookingmgmt.repository.Mydb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eventbookingmgmt.repository.Interface
{
    public interface ImststateRepository
    {
        ResultDto<RidResponse> Insert(mststateRequest viewModel);
        ResultDto<RidResponse> Update(mststateRequest viewModel);
        ResultDto<RidResponse> Delete(DelRequest viewModel);
        ResultDto<IEnumerable<Dbmststate?>> GetAllDetails();
        ResultDto<IEnumerable<Comststate?>>GetList();
        ResultDto<Dbmststate?> GetById(Int64 Id);


    }
}

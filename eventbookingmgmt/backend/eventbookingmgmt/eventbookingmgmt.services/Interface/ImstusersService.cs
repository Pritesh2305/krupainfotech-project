using eventbookingmgmt.entities.Common;
using eventbookingmgmt.entities.RequestDto;
using eventbookingmgmt.entities.ResponseDto;


namespace eventbookingmgmt.services.Interface
{
    public interface ImstusersService
    {
        ResultDto<LoginResponse> Login(LoginRequest model);
        ResultDto<mstusersResponse> GetById(Int64 Id);
        ResultDto<IEnumerable<mstusersResponse>> GetAll();

    }
}

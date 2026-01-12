using eventbookingmgmt.entities.Common;
using eventbookingmgmt.entities.RequestDto;
using eventbookingmgmt.entities.ResponseDto;
using eventbookingmgmt.repository.Implementation;
using eventbookingmgmt.repository.Interface;
using eventbookingmgmt.repository.Mydb;
using eventbookingmgmt.services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eventbookingmgmt.services.Implementation
{
    public class mstusersService : ImstusersService
    {
        private readonly ImstusersRepository _imstusersRepository;
        public mstusersService(ImstusersRepository imstusersRepository)
        {
            _imstusersRepository = imstusersRepository;
        }
        public ResultDto<LoginResponse> Login(LoginRequest model)
        {
            LoginResponse obj = new LoginResponse();
            var resp = new ResultDto<LoginResponse>()
            {
                ISuccess = false,
                Data = null,
                Errors = new List<string>()
            };
            try
            {
                var response = _imstusersRepository.Login(model);
                if (response == null)
                {
                    resp.ISuccess = false;
                    resp.Data = null;
                    resp.Errors.Add("Please Check, Invalid Username or Password.");
                }
                else
                {
                    resp.ISuccess = true;
                    obj.rid = response.rid;
                    obj.usercode = response.usercode;
                    obj.firstname = response.firstname;
                    obj.username = response.username;
                    obj.token = response.token;
                    obj.usertype = response.usertype;
                    obj.usertyperid = response.usertyperid;
                    obj.lastname = response.lastname;
                    resp.Data = obj;
                }

                return resp;
            }
            catch (Exception ex)
            {
                resp.ISuccess = false;
                resp.Data = null;
                resp.Errors.Add(ex.Message.ToString() + "");
                return resp;
            }
        }

        public ResultDto<mstusersResponse> GetById(Int64 Id)
        {
            var res = new ResultDto<mstusersResponse>
            {
                ISuccess = false,
                Data = null,
                Errors = new List<string>()
            };
            try
            {
                var response = _imstusersRepository.GetById(Id);
                if (response.ISuccess)
                {
                    mstusersResponse obj = new mstusersResponse();
                    res.ISuccess = true;
                    if (response.Data != null)
                    {
                        obj.rid = response.Data.rid;
                        obj.usercode = response.Data.usercode + "".Trim();
                        obj.firstname = response.Data.firstname + "".Trim();
                        obj.lastname = response.Data.lastname + "".Trim();
                        obj.username = response.Data.username + "".Trim();
                        obj.usertyperid = response.Data.usertyperid;
                        obj.delflg = response.Data.delflg;
                    }
                    res.Data = obj;
                }
                else
                {
                    res.Errors = response.Errors;
                }

                return res;
            }
            catch (Exception ex)
            {
                res.ISuccess = false;
                res.Data = null;
                res.Errors?.Add($"Error Occured in GetById Services :  ${ex.Message.ToString()}");
                return res;
            }

        }
        public ResultDto<IEnumerable<mstusersResponse>> GetAll()
        {
            var res = new ResultDto<IEnumerable<mstusersResponse>>
            {
                ISuccess = false,
                Data = null,
                Errors = new List<string>()
            };
            try
            {
                var response = _imstusersRepository.GetAll();
                if (response.ISuccess)
                {
                    List<mstusersResponse> list = new List<mstusersResponse>();
                    mstusersResponse obj = new mstusersResponse();
                    res.ISuccess = true;

                    foreach (var item in response.Data)
                    {
                        if (item != null)
                        {
                            mstusersResponse obj1 = new mstusersResponse();
                            obj1.rid = item.rid;
                            obj1.usercode = item.usercode + "";
                            obj1.firstname = item.firstname + "";
                            obj1.lastname = item.lastname + "";
                            obj1.username = item.username + "";
                            obj1.usertyperid = item.usertyperid;
                            obj1.delflg = item.delflg;
                            list.Add(obj1);
                        }
                    }
                    res.Data = list;
                }
                return res;
            }
            catch (Exception ex)
            {
                res.ISuccess = false;
                res.Data = null;
                res.Errors?.Add($"Error Occured in GetAll Services :  ${ex.Message.ToString()}");
                return res;
            }
        }
    }
}

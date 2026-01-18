using eventbookingmgmt.entities.Common;
using eventbookingmgmt.entities.RequestDto;
using eventbookingmgmt.entities.ResponseDto;
using eventbookingmgmt.entities.ResponseDto.mststate;
using eventbookingmgmt.repository.Implementation;
using eventbookingmgmt.repository.Interface;
using eventbookingmgmt.repository.Mydb;
using eventbookingmgmt.services.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eventbookingmgmt.services.Implementation
{
    public class mststateService : ImststateService
    {
        private readonly ImststateRepository _imststateRepository;
        public mststateService(ImststateRepository repository)
        {
            _imststateRepository = repository;
        }
        public ResultDto<RidResponse> Insert(mststateRequest viewModel)
        {
            RidResponse crudres = new RidResponse { Rid = 0 };

            var res = new ResultDto<RidResponse>
            {
                ISuccess = false,
                Data = crudres,
                Errors = new List<string>()
            };
            try
            {
                var response = _imststateRepository.Insert(viewModel);

                if (response.ISuccess)
                {
                    res.ISuccess = true;
                    res.Data = response.Data;
                }
                else
                {
                    res.ISuccess = false;
                    res.Errors = response.Errors;
                }
                return res;
            }
            catch (Exception ex)
            {
                res.ISuccess = false;
                res.Errors.Add($"Error Occures in Add Services : {ex.Message.ToString()}");
                return res;

            }

        }
        public ResultDto<RidResponse> Update(mststateRequest viewModel)
        {
            RidResponse crudres = new RidResponse { Rid = 0 };

            var res = new ResultDto<RidResponse>
            {
                ISuccess = false,
                Data = crudres,
                Errors = new List<string>()
            };
            try
            {
                var response = _imststateRepository.Update(viewModel);

                if (response.ISuccess)
                {
                    res.ISuccess = true;
                    res.Data = response.Data;
                }
                else
                {
                    res.ISuccess = false;
                    res.Errors = response.Errors;
                }
                return res;
            }
            catch (Exception ex)
            {
                res.ISuccess = false;
                res.Errors?.Add($"Error Occures in Update Services : {ex.Message.ToString()}");
                return res;

            }

        }
        public ResultDto<RidResponse> Delete(DelRequest viewModel)
        {
            RidResponse crudres = new RidResponse { Rid = 0 };

            var res = new ResultDto<RidResponse>
            {
                ISuccess = false,
                Data = crudres,
                Errors = new List<string>()
            };
            try
            {
                var response = _imststateRepository.Delete(viewModel);

                if (response.ISuccess)
                {
                    res.ISuccess = true;
                    res.Data = response.Data;
                }
                else
                {
                    res.ISuccess = false;
                    res.Errors = response.Errors;
                }
                return res;
            }
            catch (Exception ex)
            {
                res.ISuccess = false;
                res.Errors?.Add($"Error Occures in Delete Services : {ex.Message.ToString()}");
                return res;

            }

        }
        public ResultDto<IEnumerable<DbmststateResponse?>> GetAllDetails()
        {
            var res = new ResultDto<IEnumerable<DbmststateResponse?>>
            {
                ISuccess = false,
                Data = null,
                Errors = new List<string>()
            };
            try
            {
                var response = _imststateRepository.GetAllDetails();
                if (response.ISuccess)
                {
                    List<DbmststateResponse> list = new List<DbmststateResponse>();                    
                    res.ISuccess = true;
                    if (response.Data != null)
                    {
                        foreach (var item in response.Data)
                        {
                            if (item != null)
                            {
                                DbmststateResponse obj1 = new DbmststateResponse();
                                obj1.rid = item.rid;
                                obj1.statecode = item.statecode + "".Trim();
                                obj1.statename = item.statename + "".Trim();
                                obj1.stateremark1 = item.stateremark1 + "".Trim();
                                obj1.stateremark2 = item.stateremark2 + "".Trim();
                                obj1.arid=item.arid;
                                obj1.adatetime = item.adatetime;
                                obj1.erid = item.erid;
                                obj1.edatetime = item.edatetime;
                                obj1.drid = item.drid;
                                obj1.ddatetime = item.ddatetime;
                                obj1.delflg = item.delflg;
                                list.Add(obj1);
                            }
                        }
                        res.Data = list;
                    }
                }
                return res;
            }
            catch (Exception ex)
            {
                res.ISuccess = false;
                res.Data = null;
                res.Errors?.Add($"Error Occured in GetAllDetails Services :  ${ex.Message.ToString()}");
                return res;
            }
        }
        public ResultDto<IEnumerable<mststateResponse?>> GetList()
        {
            var res = new ResultDto<IEnumerable<mststateResponse?>>
            {
                ISuccess = false,
                Data = null,
                Errors = new List<string>()
            };
            try
            {
                var response = _imststateRepository.GetList();
                if (response.ISuccess)
                {
                    List<mststateResponse> list = new List<mststateResponse>();
                    res.ISuccess = true;
                    if (response.Data != null)
                    {
                        foreach (var item in response.Data)
                        {
                            if (item != null)
                            {
                                mststateResponse obj1 = new mststateResponse();
                                obj1.rid = item.rid;
                                obj1.statecode = item.statecode + "".Trim();
                                obj1.statename = item.statename + "".Trim();
                                obj1.stateremark1 = item.stateremark1 + "".Trim();
                                obj1.stateremark2 = item.stateremark2 + "".Trim();                               
                                list.Add(obj1);
                            }
                        }
                        res.Data = list;
                    }
                }
                return res;
            }
            catch (Exception ex)
            {
                res.ISuccess = false;
                res.Data = null;
                res.Errors?.Add($"Error Occured in GetList Services :  ${ex.Message.ToString()}");
                return res;
            }
        }
        public ResultDto<mststateResponse> GetById(Int64 Id)
        {
            var res = new ResultDto<mststateResponse>
            {
                ISuccess = false,
                Data = null,
                Errors = new List<string>()
            };
            try
            {
                var response = _imststateRepository.GetById(Id);
                if (response.ISuccess)
                {
                    mststateResponse obj = new mststateResponse();
                    res.ISuccess = true;
                    if (response.Data != null)
                    {
                        obj.rid = response.Data.rid;
                        obj.statecode = response.Data.statecode + "".Trim();
                        obj.statename = response.Data.statename + "".Trim();
                        obj.stateremark1 = response.Data.stateremark1 + "".Trim();
                        obj.stateremark2 = response.Data.stateremark2 + "".Trim();    
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
    }
}

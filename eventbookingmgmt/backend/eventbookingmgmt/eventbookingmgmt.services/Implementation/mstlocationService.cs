using eventbookingmgmt.entities.Common;
using eventbookingmgmt.entities.RequestDto;
using eventbookingmgmt.entities.ResponseDto.mstlocation;
using eventbookingmgmt.repository.Interface;
using eventbookingmgmt.services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eventbookingmgmt.services.Implementation
{
    public class mstlocationService : ImstlocationService
    {
        private readonly ImstlocationRepository _imstlocationRepository;
        public mstlocationService(ImstlocationRepository repository)
        {
            _imstlocationRepository = repository;
        }
        public ResultDto<RidResponse> Insert(mstlocationRequest viewModel)
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
                var response = _imstlocationRepository.Insert(viewModel);

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
                res.Errors?.Add($"Error Occures in Add Services : {ex.Message.ToString()}");
                return res;

            }

        }
        public ResultDto<RidResponse> Update(mstlocationRequest viewModel)
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
                var response = _imstlocationRepository.Update(viewModel);

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
                var response = _imstlocationRepository.Delete(viewModel);

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
        public ResultDto<IEnumerable<DbmstlocationResponse?>> GetAllDetails()
        {
            var res = new ResultDto<IEnumerable<DbmstlocationResponse?>>
            {
                ISuccess = false,
                Data = null,
                Errors = new List<string>()
            };
            try
            {
                var response = _imstlocationRepository.GetAllDetails();
                if (response.ISuccess)
                {
                    List<DbmstlocationResponse> list = new List<DbmstlocationResponse>();
                    res.ISuccess = true;
                    if (response.Data != null)
                    {
                        foreach (var item in response.Data)
                        {
                            if (item != null)
                            {
                                DbmstlocationResponse obj1 = new DbmstlocationResponse();
                                obj1.rid = item.rid;
                                obj1.loccode = item.loccode + "".Trim();
                                obj1.locname = item.locname + "".Trim();
                                obj1.locremark1 = item.locremark1 + "".Trim();
                                obj1.locremark2 = item.locremark2 + "".Trim();
                                obj1.arid = item.arid;
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
        public ResultDto<IEnumerable<mstlocationResponse?>> GetList()
        {
            var res = new ResultDto<IEnumerable<mstlocationResponse?>>
            {
                ISuccess = false,
                Data = null,
                Errors = new List<string>()
            };
            try
            {
                var response = _imstlocationRepository.GetList();
                if (response.ISuccess)
                {
                    List<mstlocationResponse> list = new List<mstlocationResponse>();
                    res.ISuccess = true;
                    if (response.Data != null)
                    {
                        foreach (var item in response.Data)
                        {
                            if (item != null)
                            {
                                mstlocationResponse obj1 = new mstlocationResponse();
                                obj1.rid = item.rid;
                                obj1.loccode = item.loccode + "".Trim();
                                obj1.locname = item.locname + "".Trim();
                                obj1.locremark1 = item.locremark1 + "".Trim();
                                obj1.locremark2 = item.locremark2 + "".Trim();
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
        public ResultDto<mstlocationResponse> GetById(Int64 Id)
        {
            var res = new ResultDto<mstlocationResponse>
            {
                ISuccess = false,
                Data = null,
                Errors = new List<string>()
            };
            try
            {
                var response = _imstlocationRepository.GetById(Id);
                if (response.ISuccess)
                {
                    mstlocationResponse obj = new mstlocationResponse();
                    res.ISuccess = true;
                    if (response.Data != null)
                    {
                        obj.rid = response.Data.rid;
                        obj.loccode = response.Data.loccode + "".Trim();
                        obj.locname = response.Data.locname + "".Trim();
                        obj.locremark1 = response.Data.locremark1 + "".Trim();
                        obj.locremark2 = response.Data.locremark2 + "".Trim();
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

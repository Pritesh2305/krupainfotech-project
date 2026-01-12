using eventbookingmgmt.entities.Common;
using eventbookingmgmt.entities.RequestDto;
using eventbookingmgmt.entities.ResponseDto.mstcountry;
using eventbookingmgmt.entities.ResponseDto.mststate;
using eventbookingmgmt.repository.Interface;
using eventbookingmgmt.services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eventbookingmgmt.services.Implementation
{
    public class mstcountryService : ImstcountryService
    {
        private readonly ImstcountryRepository _imstcountryRepository;
        public mstcountryService(ImstcountryRepository repository)
        {
            _imstcountryRepository = repository;
        }
        public ResultDto<RidResponse> Insert(mstcountryRequest viewModel)
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
                var response = _imstcountryRepository.Insert(viewModel);

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
        public ResultDto<RidResponse> Update(mstcountryRequest viewModel)
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
                var response = _imstcountryRepository.Update(viewModel);

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
                res.Errors.Add($"Error Occures in Update Services : {ex.Message.ToString()}");
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
                var response = _imstcountryRepository.Delete(viewModel);

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
                res.Errors.Add($"Error Occures in Delete Services : {ex.Message.ToString()}");
                return res;

            }

        }
        public ResultDto<IEnumerable<DbmstcountryResponse?>> GetAllDetails()
        {
            var res = new ResultDto<IEnumerable<DbmstcountryResponse>>
            {
                ISuccess = false,
                Data = null,
                Errors = new List<string>()
            };
            try
            {
                var response = _imstcountryRepository.GetAllDetails();
                if (response.ISuccess)
                {
                    List<DbmstcountryResponse> list = new List<DbmstcountryResponse>();
                    res.ISuccess = true;
                    if (response.Data != null)
                    {
                        foreach (var item in response.Data)
                        {
                            if (item != null)
                            {
                                DbmstcountryResponse obj1 = new DbmstcountryResponse();
                                obj1.rid = item.rid;
                                obj1.countrycode = item.countrycode + "".Trim();
                                obj1.countryname = item.countryname + "".Trim();
                                obj1.countryremark1 = item.countryremark1 + "".Trim();
                                obj1.countryremark2 = item.countryremark2 + "".Trim();
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
        public ResultDto<IEnumerable<mstcountryResponse?>> GetList()
        {
            var res = new ResultDto<IEnumerable<mstcountryResponse>>
            {
                ISuccess = false,
                Data = null,
                Errors = new List<string>()
            };
            try
            {
                var response = _imstcountryRepository.GetList();
                if (response.ISuccess)
                {
                    List<mstcountryResponse> list = new List<mstcountryResponse>();
                    res.ISuccess = true;
                    if (response.Data != null)
                    {
                        foreach (var item in response.Data)
                        {
                            if (item != null)
                            {
                                mstcountryResponse obj1 = new mstcountryResponse();
                                obj1.rid = item.rid;
                                obj1.countrycode = item.countrycode + "".Trim();
                                obj1.countryname = item.countryname + "".Trim();
                                obj1.countryremark1 = item.countryremark1 + "".Trim();
                                obj1.countryremark2 = item.countryremark2 + "".Trim();
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
        public ResultDto<mstcountryResponse> GetById(Int64 Id)
        {
            var res = new ResultDto<mstcountryResponse>
            {
                ISuccess = false,
                Data = null,
                Errors = new List<string>()
            };
            try
            {
                var response = _imstcountryRepository.GetById(Id);
                if (response.ISuccess)
                {
                    mstcountryResponse obj = new mstcountryResponse();
                    res.ISuccess = true;
                    if (response.Data != null)
                    {
                        obj.rid = response.Data.rid;
                        obj.countrycode = response.Data.countrycode + "".Trim();
                        obj.countryname = response.Data.countryname + "".Trim();
                        obj.countryremark1 = response.Data.countryremark1 + "".Trim();
                        obj.countryremark2 = response.Data.countryremark2 + "".Trim();
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

using Azure;
using eventbookingmgmt.entities.Common;
using eventbookingmgmt.entities.RequestDto;
using eventbookingmgmt.entities.ResponseDto.mstcountry;
using eventbookingmgmt.entities.ResponseDto.mstguest;
using eventbookingmgmt.repository.Interface;
using eventbookingmgmt.services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eventbookingmgmt.services.Implementation
{
    public class mstguestService : ImstguestService
    {
        private readonly ImstguestRepository _imstguestRepository;
        public mstguestService(ImstguestRepository repository)
        {
            _imstguestRepository = repository;
        }
        public ResultDto<RidResponse> Insert(mstguestRequest viewModel)
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
                var response = _imstguestRepository.Insert(viewModel);

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
        public ResultDto<RidResponse> Update(mstguestRequest viewModel)
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
                var response = _imstguestRepository.Update(viewModel);

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
                var response = _imstguestRepository.Delete(viewModel);

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
        public ResultDto<IEnumerable<DbmstguestResponse?>> GetAllDetails()
        {
            var res = new ResultDto<IEnumerable<DbmstguestResponse>>
            {
                ISuccess = false,
                Data = null,
                Errors = new List<string>()
            };
            try
            {
                var response = _imstguestRepository.GetAllDetails();
                if (response.ISuccess)
                {
                    List<DbmstguestResponse> list = new List<DbmstguestResponse>();
                    res.ISuccess = true;
                    if (response.Data != null)
                    {
                        foreach (var item in response.Data)
                        {
                            if (item != null)
                            {
                                DbmstguestResponse obj1 = new DbmstguestResponse();
                                obj1.rid = item.rid;
                                obj1.gcode = item.gcode + "".Trim();
                                obj1.gname = item.gname + "".Trim();
                                obj1.gmobno = item.gmobno + "".Trim();
                                obj1.gwano = item.gwano + "".Trim();
                                obj1.gemail = item.gemail + "".Trim();
                                obj1.gadd1 = item.gadd1 + "".Trim();
                                obj1.gadd2 = item.gadd2 + "".Trim();
                                obj1.gadd3 = item.gadd3 + "".Trim();
                                obj1.gcityrid = item.gcityrid;
                                obj1.gstaterid = item.gstaterid;
                                obj1.gcountryrid = item.gcountryrid;
                                obj1.gremark1 = item.gremark1;
                                obj1.gremark2 = item.gremark2;
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
        public ResultDto<IEnumerable<mstguestResponse?>> GetList()
        {
            var res = new ResultDto<IEnumerable<mstguestResponse>>
            {
                ISuccess = false,
                Data = null,
                Errors = new List<string>()
            };
            try
            {
                var response = _imstguestRepository.GetList();
                if (response.ISuccess)
                {
                    List<mstguestResponse> list = new List<mstguestResponse>();
                    res.ISuccess = true;
                    if (response.Data != null)
                    {
                        foreach (var item in response.Data)
                        {
                            if (item != null)
                            {
                                mstguestResponse obj1 = new mstguestResponse();
                                obj1.rid = item.rid;
                                obj1.gcode = item.gcode + "".Trim();
                                obj1.gname = item.gname + "".Trim();
                                obj1.gemail = item.gemail+"".Trim();
                                obj1.gmobno = item.gmobno + "".Trim();
                                obj1.statename = item.statename + "".Trim();
                                obj1.cityname = item.cityname + "".Trim();
                                obj1.countryname = item.countryname + "".Trim();
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
        public ResultDto<DbmstguestResponse> GetById(Int64 Id)
        {
            var res = new ResultDto<DbmstguestResponse>
            {
                ISuccess = false,
                Data = null,
                Errors = new List<string>()
            };
            try
            {
                var response = _imstguestRepository.GetById(Id);
                if (response.ISuccess)
                {
                    DbmstguestResponse obj1 = new DbmstguestResponse();
                    res.ISuccess = true;
                    if (response.Data != null)
                    {
                        obj1.rid = response.Data.rid;
                        obj1.gcode = response.Data.gcode + "".Trim();
                        obj1.gname = response.Data.gname + "".Trim();
                        obj1.gmobno = response.Data.gmobno + "".Trim();
                        obj1.gwano = response.Data.gwano + "".Trim();
                        obj1.gemail = response.Data.gemail + "".Trim();
                        obj1.gadd1 = response.Data.gadd1 + "".Trim();
                        obj1.gadd2 = response.Data.gadd2 + "".Trim();
                        obj1.gadd3 = response.Data.gadd3 + "".Trim();
                        obj1.gcityrid = response.Data.gcityrid;
                        obj1.gstaterid = response.Data.gstaterid;
                        obj1.gcountryrid = response.Data.gcountryrid;
                        obj1.gremark1 = response.Data.gremark1;
                        obj1.gremark2 = response.Data.gremark2;
                        obj1.arid = response.Data.arid;
                        obj1.adatetime = response.Data.adatetime;
                        obj1.erid = response.Data.erid;
                        obj1.edatetime = response.Data.edatetime;
                        obj1.drid = response.Data.drid;
                        obj1.ddatetime = response.Data.ddatetime;
                        obj1.delflg = response.Data.delflg;

                    }
                    res.Data = obj1;
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

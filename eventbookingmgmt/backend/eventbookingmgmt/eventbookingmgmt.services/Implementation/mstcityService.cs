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
    public class mstcityService : ImstcityService
    {
        private readonly ImstcityRepository _imstcityRepository;
        public mstcityService(ImstcityRepository repository)
        {
            _imstcityRepository = repository;
        }
        public ResultDto<RidResponse> Insert(mstcityRequest viewModel)
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
                var response = _imstcityRepository.Insert(viewModel);

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
        public ResultDto<RidResponse> Update(mstcityRequest viewModel)
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
                var response = _imstcityRepository.Update(viewModel);

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
                var response = _imstcityRepository.Delete(viewModel);

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
        public ResultDto<IEnumerable<Dbmstcity?>> GetlistDetails()
        {
            var res = new ResultDto<IEnumerable<Dbmstcity>>
            {
                ISuccess = false,
                Data = null,
                Errors = new List<string>()
            };
            try
            {
                var response = _imstcityRepository.GetlistDetails();
                if (response.ISuccess)
                {
                    List<Dbmstcity> list = new List<Dbmstcity>();
                    Dbmstcity obj = new Dbmstcity();
                    res.ISuccess = true;

                    foreach (var item in response.Data)
                    {
                        if (response.Data != null)
                        {
                            if (item != null)
                            {
                                Dbmstcity obj1 = new Dbmstcity();
                                obj1.rid = item.rid;
                                obj1.citycode = item.citycode + "".Trim();
                                obj1.cityname = item.cityname + "".Trim();
                                obj1.cityremark1 = item.cityremark1 + "".Trim();
                                obj1.cityremark2 = item.cityremark2 + "".Trim();
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
                res.Errors?.Add($"Error Occured in GetlistDetails Services :  ${ex.Message.ToString()}");
                return res;
            }
        }

        public ResultDto<IEnumerable<Dbmstcity?>> GetAllDetails()
        {
            var res = new ResultDto<IEnumerable<Dbmstcity>>
            {
                ISuccess = false,
                Data = null,
                Errors = new List<string>()
            };
            try
            {
                var response = _imstcityRepository.GetAllDetails();
                if (response.ISuccess)
                {
                    List<Dbmstcity> list = new List<Dbmstcity>();
                    Dbmstcity obj = new Dbmstcity();
                    res.ISuccess = true;

                    if (response.Data != null)
                    {
                        foreach (var item in response.Data)
                        {
                            if (item != null)
                            {
                                Dbmstcity obj1 = new Dbmstcity();
                                obj1.rid = item.rid;
                                obj1.citycode = item.citycode + "".Trim();
                                obj1.cityname = item.cityname + "".Trim();
                                obj1.cityremark1 = item.cityremark1 + "".Trim();
                                obj1.cityremark2 = item.cityremark2 + "".Trim();
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

        public ResultDto<IEnumerable<Comstcity?>> Getlist()
        {
            var res = new ResultDto<IEnumerable<Comstcity>>
            {
                ISuccess = false,
                Data = null,
                Errors = new List<string>()
            };
            try
            {
                var response = _imstcityRepository.Getlist();
                if (response.ISuccess)
                {
                    List<Comstcity> list = new List<Comstcity>();
                    Comstcity obj = new Comstcity();
                    res.ISuccess = true;

                    if (response.Data != null)
                    {
                        foreach (var item in response.Data)
                        {
                            if (item != null)
                            {
                                Comstcity obj1 = new Comstcity();
                                obj1.rid = item.rid;
                                obj1.citycode = item.citycode + "".Trim(); 
                                obj1.cityname = item.cityname + "".Trim(); 
                                obj1.cityremark1 = item.cityremark1 + "";
                                obj1.cityremark2 = item.cityremark2 + "";
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
                res.Errors?.Add($"Error Occured in Getlist Services :  ${ex.Message.ToString()}");
                return res;
            }
        }

        public ResultDto<IEnumerable<Comstcity?>> GetAll()
        {
            var res = new ResultDto<IEnumerable<Comstcity>>
            {
                ISuccess = false,
                Data = null,
                Errors = new List<string>()
            };
            try
            {
                var response = _imstcityRepository.GetAll();
                if (response.ISuccess)
                {
                    List<Comstcity> list = new List<Comstcity>();
                    Comstcity obj = new Comstcity();
                    res.ISuccess = true;

                    if (response.Data != null)
                    {
                        foreach (var item in response.Data)
                        {
                            if (item != null)
                            {
                                Comstcity obj1 = new Comstcity();
                                obj1.rid = item.rid;
                                obj1.citycode = item.citycode + "".Trim();
                                obj1.cityname = item.cityname + "".Trim();
                                obj1.cityremark1 = item.cityremark1 + "".Trim();
                                obj1.cityremark2 = item.cityremark2 + "".Trim();
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
                res.Errors?.Add($"Error Occured in GetAll Services :  ${ex.Message.ToString()}");
                return res;
            }
        }

        public ResultDto<Comstcity?> GetById(Int64 Id)
        {
            var res = new ResultDto<Comstcity>
            {
                ISuccess = false,
                Data = null,
                Errors = new List<string>()
            };
            try
            {
                var response = _imstcityRepository.GetById(Id);
                if (response.ISuccess)
                {
                    Comstcity obj = new Comstcity();
                    res.ISuccess = true;
                    if (response.Data != null)
                    {
                        obj.rid = response.Data.rid;
                        obj.citycode = response.Data.citycode + "".Trim();
                        obj.cityname = response.Data.cityname + "".Trim();
                        obj.cityremark1 = response.Data.cityremark1 + "".Trim();
                        obj.cityremark2 = response.Data.cityremark2 + "".Trim();
                        res.Data = obj;
                    }
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

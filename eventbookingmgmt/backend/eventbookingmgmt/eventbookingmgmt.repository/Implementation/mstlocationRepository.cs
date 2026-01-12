using eventbookingmgmt.entities.Common;
using eventbookingmgmt.entities.RequestDto;
using eventbookingmgmt.repository.Common;
using eventbookingmgmt.repository.Interface;
using eventbookingmgmt.repository.Mydb;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eventbookingmgmt.repository.Implementation
{
    public class mstlocationRepository : ImstlocationRepository
    {
        private Mydbcontext _context;
        public mstlocationRepository(Mydbcontext context)
        {
            _context = context;
        }
        public ResultDto<RidResponse> Insert(mstlocationRequest viewModel)
        {
            Int64 retrid = 0;
            RidResponse rid_resp = new RidResponse { Rid = 0 };
            ResultDto<RidResponse> res = new ResultDto<RidResponse>()
            {
                ISuccess = false,
                Data = null,
                Errors = new List<string>()
            };
            try
            {
                string strjson1 = commonFunction.ConvertToJSON(viewModel);

                var in_para1 = new SqlParameter
                {
                    ParameterName = "@p_json",
                    SqlDbType = System.Data.SqlDbType.NVarChar,
                    Size = -1,
                    Direction = System.Data.ParameterDirection.Input,
                    Value = strjson1
                };
                var out_para1 = new SqlParameter
                {
                    ParameterName = "@p_retrid",
                    SqlDbType = System.Data.SqlDbType.BigInt,
                    Direction = System.Data.ParameterDirection.Output,
                };
                var out_para2 = new SqlParameter
                {
                    ParameterName = "@p_retval",
                    SqlDbType = System.Data.SqlDbType.BigInt,
                    Direction = System.Data.ParameterDirection.Output,
                };
                var out_para3 = new SqlParameter
                {
                    ParameterName = "@p_reterr",
                    SqlDbType = System.Data.SqlDbType.NVarChar,
                    Size = -1,
                    Direction = System.Data.ParameterDirection.Output,
                };

                var response = _context.Database.ExecuteSqlRaw("execute usp_mstlocation_add  @p_json," +
                                                                " @p_retrid OUTPUT,@p_retval OUTPUT,@p_reterr OUTPUT",
                                                                in_para1, out_para1, out_para2, out_para3);

                string out1 = out_para1.Value + "";
                string out2 = out_para2.Value + "";
                string out3 = out_para3.Value + "";
                byte ret_out2; bool bool_out2;
                Int64.TryParse(out1, out retrid);
                byte.TryParse(out2, out ret_out2);
                bool.TryParse(Convert.ToBoolean(ret_out2) + "", out bool_out2);
                rid_resp.Rid = retrid;

                if (bool_out2)
                {
                    res.ISuccess = true;
                    res.Data = rid_resp;
                    res.Errors.Add(out3);
                }
                else
                {
                    res.ISuccess = false;
                    res.Data = rid_resp;
                    res.Errors.Add(out3);
                }
                return res;
            }
            catch (Exception ex)
            {
                res.ISuccess = false;
                res.Data = rid_resp;
                res.Errors.Add($"Error Occured In Insert Repository : {ex.Message.ToString()}");
                return res;
            }
        }
        public ResultDto<RidResponse> Update(mstlocationRequest viewModel)
        {
            Int64 retrid = 0;
            RidResponse rid_resp = new RidResponse { Rid = 0 };
            ResultDto<RidResponse> res = new ResultDto<RidResponse>()
            {
                ISuccess = false,
                Data = null,
                Errors = new List<string>()
            };
            try
            {
                string strjson1 = commonFunction.ConvertToJSON(viewModel);

                var in_para1 = new SqlParameter
                {
                    ParameterName = "@p_json",
                    SqlDbType = System.Data.SqlDbType.NVarChar,
                    Size = -1,
                    Direction = System.Data.ParameterDirection.Input,
                    Value = strjson1
                };
                var out_para1 = new SqlParameter
                {
                    ParameterName = "@p_retrid",
                    SqlDbType = System.Data.SqlDbType.BigInt,
                    Direction = System.Data.ParameterDirection.Output,
                };
                var out_para2 = new SqlParameter
                {
                    ParameterName = "@p_retval",
                    SqlDbType = System.Data.SqlDbType.BigInt,
                    Direction = System.Data.ParameterDirection.Output,
                };
                var out_para3 = new SqlParameter
                {
                    ParameterName = "@p_reterr",
                    SqlDbType = System.Data.SqlDbType.NVarChar,
                    Size = -1,
                    Direction = System.Data.ParameterDirection.Output,
                };

                var response = _context.Database.ExecuteSqlRaw("execute usp_mstlocation_update @p_json," +
                                                                " @p_retrid OUTPUT,@p_retval OUTPUT,@p_reterr OUTPUT",
                                                                in_para1, out_para1, out_para2, out_para3);

                string out1 = out_para1.Value + "";
                string out2 = out_para2.Value + "";
                string out3 = out_para3.Value + "";
                byte ret_out2; bool bool_out2;
                Int64.TryParse(out1, out retrid);
                byte.TryParse(out2, out ret_out2);
                bool.TryParse(Convert.ToBoolean(ret_out2) + "", out bool_out2);
                rid_resp.Rid = retrid;

                if (bool_out2)
                {
                    res.ISuccess = true;
                    res.Data = rid_resp;
                    res.Errors.Add(out3);
                }
                else
                {
                    res.ISuccess = false;
                    res.Data = rid_resp;
                    res.Errors.Add(out3);
                }
                return res;
            }
            catch (Exception ex)
            {
                res.ISuccess = false;
                res.Data = rid_resp;
                res.Errors.Add($"Error Occured In Update Repository : {ex.Message.ToString()}");
                return res;
            }
        }
        public ResultDto<RidResponse> Delete(DelRequest viewModel)
        {
            Int64 retrid = 0;
            RidResponse rid_resp = new RidResponse { Rid = 0 };
            ResultDto<RidResponse> res = new ResultDto<RidResponse>()
            {
                ISuccess = false,
                Data = null,
                Errors = new List<string>()
            };
            try
            {
                string strjson1 = commonFunction.ConvertToJSON(viewModel);

                var in_para1 = new SqlParameter
                {
                    ParameterName = "@p_json",
                    SqlDbType = System.Data.SqlDbType.NVarChar,
                    Size = -1,
                    Direction = System.Data.ParameterDirection.Input,
                    Value = strjson1
                };
                var out_para1 = new SqlParameter
                {
                    ParameterName = "@p_retrid",
                    SqlDbType = System.Data.SqlDbType.BigInt,
                    Direction = System.Data.ParameterDirection.Output,
                };
                var out_para2 = new SqlParameter
                {
                    ParameterName = "@p_retval",
                    SqlDbType = System.Data.SqlDbType.BigInt,
                    Direction = System.Data.ParameterDirection.Output,
                };
                var out_para3 = new SqlParameter
                {
                    ParameterName = "@p_reterr",
                    SqlDbType = System.Data.SqlDbType.NVarChar,
                    Size = -1,
                    Direction = System.Data.ParameterDirection.Output,
                };

                var response = _context.Database.ExecuteSqlRaw("execute usp_mstlocation_delete @p_json," +
                                                                " @p_retrid OUTPUT,@p_retval OUTPUT,@p_reterr OUTPUT",
                                                                in_para1, out_para1, out_para2, out_para3);

                string out1 = out_para1.Value + "";
                string out2 = out_para2.Value + "";
                string out3 = out_para3.Value + "";
                byte ret_out2; bool bool_out2;
                Int64.TryParse(out1, out retrid);
                byte.TryParse(out2, out ret_out2);
                bool.TryParse(Convert.ToBoolean(ret_out2) + "", out bool_out2);
                rid_resp.Rid = retrid;

                if (bool_out2)
                {
                    res.ISuccess = true;
                    res.Data = rid_resp;
                    res.Errors.Add(out3);
                }
                else
                {
                    res.ISuccess = false;
                    res.Data = rid_resp;
                    res.Errors.Add(out3);
                }
                return res;
            }
            catch (Exception ex)
            {
                res.ISuccess = false;
                res.Data = rid_resp;
                res.Errors.Add($"Error Occured In Delete Repository : {ex.Message.ToString()}");
                return res;
            }
        }
        public ResultDto<IEnumerable<Dbmstlocation?>> GetAllDetails()
        {
            var resp = new ResultDto<IEnumerable<Dbmstlocation?>>()
            {
                ISuccess = false,
                Data = null,
                Errors = new List<string>()
            };
            try
            {
                IEnumerable<Dbmstlocation?> response = _context.mstlocation.FromSqlRaw("execute usp_mstlocation_getalldetails");
                resp.ISuccess = true;
                if (response.Count() > 0) resp.Data = response;
                return resp;
            }
            catch (Exception ex)
            {
                resp.Errors.Add($"Error Occured in GetAllDetails : {ex.Message.ToString()}");
                return resp;
            }
        }
        public ResultDto<IEnumerable<Comstlocation?>> GetList()
        {
            var resp = new ResultDto<IEnumerable<Comstlocation?>>()
            {
                ISuccess = false,
                Data = null,
                Errors = new List<string>()
            };
            try
            {
                IEnumerable<Comstlocation?> response = _context.comstlocation.FromSqlRaw("execute usp_mstlocation_getlist");
                resp.ISuccess = true;
                if (response.Count() > 0) resp.Data = response;
                return resp;
            }
            catch (Exception ex)
            {
                resp.Errors.Add($"Error Occured in GetList : {ex.Message.ToString()}");
                return resp;
            }
        }
        public ResultDto<Dbmstlocation?> GetById(Int64 Id)
        {
            var resp = new ResultDto<Dbmstlocation?>()
            {
                ISuccess = false,
                Data = null,
                Errors = new List<string>()
            };
            try
            {
                Dbmstlocation? response = _context.mstlocation.FromSqlRaw("execute usp_mstlocation_getbyid @p_rid", new SqlParameter("@p_rid", Id)).AsEnumerable().FirstOrDefault();
                resp.ISuccess = true;
                resp.Data = response;
                return resp;
            }
            catch (Exception ex)
            {
                resp.Errors.Add($"Error Occured in GetById : {ex.Message.ToString()}");
                return resp;
            }
        }
    }
}

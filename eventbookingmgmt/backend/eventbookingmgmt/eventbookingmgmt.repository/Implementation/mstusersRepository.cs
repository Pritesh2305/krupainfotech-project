using eventbookingmgmt.entities.Common;
using eventbookingmgmt.entities.RequestDto;
using eventbookingmgmt.entities.ResponseDto;
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
    public class mstusersRepository : ImstusersRepository
    {
        private Mydbcontext _context;
        public mstusersRepository(Mydbcontext context)
        {
            _context = context;
        }
        public CoUserLogin? Login(LoginRequest model)
        {
            CoUserLogin? response = null;
            try
            {
                return response = _context.couserlogin.FromSqlRaw("execute usp_getlogininfo @p_username,@p_userpassword",
                                                            new SqlParameter("@p_username", model.username),
                                                            new SqlParameter("@p_userpassword", model.password))
                                                            .AsEnumerable().FirstOrDefault();
            }
            catch (Exception)
            {
                return response;
            }

        }
        public ResultDto<IEnumerable<Dbmstusers?>> GetAll()
        {
            var resp = new ResultDto<IEnumerable<Dbmstusers?>>()
            {
                ISuccess = false,
                Data = null,
                Errors = new List<string>()
            };
            try
            {
                IEnumerable<Dbmstusers?> response = _context.mstusers.FromSqlRaw("execute usp_mstuserslist");
                resp.ISuccess = true;
                if (response.Count() > 0) resp.Data = response;
                return resp;
            }
            catch (Exception ex)
            {
                resp.Errors.Add($"Error Occured in GetAll : {ex.Message.ToString()}");
                return resp;
            }
        }
        public ResultDto<Dbmstusers?> GetById(Int64 Id)
        {
            var resp = new ResultDto<Dbmstusers?>()
            {
                ISuccess = false,
                Data = null,
                Errors = new List<string>()
            };
            try
            {
                Dbmstusers? response = _context.mstusers.FromSqlRaw("execute usp_get_mstuser @p_rid", new SqlParameter("@p_rid", Id)).AsEnumerable().FirstOrDefault();
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

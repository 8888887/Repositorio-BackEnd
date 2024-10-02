using Dapper;
using DecideTuCancha.DBContext.Base;
using DecideTuCancha.DBContext.Interface;
using DecideTuCancha.DBEntity.Base;
using DecideTuCancha.DBEntity.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace DecideTuCancha.DBContext.Repository
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        public EntityBaseResponse Login(EntityLogin login)
        {
            var response = new EntityBaseResponse();
            try
            {
                using (var db = GetSqlConnection())
                {
                    var user = new EntityLoginResponse();

                    const string sql = "usp_user_login";
                    var p = new DynamicParameters();
                    p.Add(name: "@LOGINUSUARIO", value: login.uid, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add(name: "@PASSWORDUSUARIO", value: login.pwd, dbType: DbType.String, direction: ParameterDirection.Input);

                    user = db.Query<EntityLoginResponse>(
                            sql: sql,
                            param: p,
                            commandType: CommandType.StoredProcedure
                        ).FirstOrDefault();

                    if (user != null)
                    {
                        response.IsSuccess = true;
                        response.ErrorCode = "0000";
                        response.ErrorMessage = string.Empty;
                        response.Data = user;
                    }
                    else
                    {
                        response.IsSuccess = false;
                        response.ErrorCode = "0000";
                        response.ErrorMessage = string.Empty;
                        response.Data = null;
                    }
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.ErrorCode = "0001";
                response.ErrorMessage = ex.Message;
                response.Data = null;
            }
            return response;
        }
    }
}

using Dapper;
using DecideTuCancha.DBEntity.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using DecideTuCancha.DBContext.Interface;
using DecideTuCancha.DBContext.Base;
using DecideTuCancha.DBEntity.Base;

namespace DecideTuCancha.DBContext.Repository
{
    public class TipoCanchaRepository : BaseRepository, ITipoCanchaRepository
    {
        public EntityBaseResponse GetTipoCancha(int id)
        {
            var response = new EntityBaseResponse();
            try
            {
                using (var db = GetSqlConnection())
                {
                    const string sql = "usp_ObtenerTipoCancha";
                    var p = new DynamicParameters();
                    p.Add(name: "@IDTipoCancha", value: id, dbType: DbType.Int32, direction: ParameterDirection.Input);

                    var tipoCancha = db.Query<EntityTipoCancha>(sql: sql, param: p, commandType: CommandType.StoredProcedure).FirstOrDefault();

                    if (tipoCancha != null)
                    {
                        response.IsSuccess = true;
                        response.ErrorCode = "0000";
                        response.ErrorMessage = string.Empty;
                        response.Data = tipoCancha;
                    }
                    else
                    {
                        response.IsSuccess = false;
                        response.ErrorCode = "0000";
                        response.ErrorMessage = "Tipo de cancha no encontrado.";
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

        public EntityBaseResponse GetTiposCancha()
        {
            var response = new EntityBaseResponse();
            try
            {
                using (var db = GetSqlConnection())
                {
                    const string sql = "usp_ListarTiposCancha";
                    var tiposCancha = db.Query<EntityTipoCancha>(sql: sql, commandType: CommandType.StoredProcedure).ToList();

                    if (tiposCancha.Count > 0)
                    {
                        response.IsSuccess = true;
                        response.ErrorCode = "0000";
                        response.ErrorMessage = string.Empty;
                        response.Data = tiposCancha;
                    }
                    else
                    {
                        response.IsSuccess = false;
                        response.ErrorCode = "0000";
                        response.ErrorMessage = "No se encontraron tipos de cancha.";
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

        public EntityBaseResponse InsertTipoCancha(EntityTipoCancha tipoCancha)
        {
            var response = new EntityBaseResponse();
            try
            {
                using (var db = GetSqlConnection())
                {
                    const string sql = "usp_InsertarTipoCancha";
                    var p = new DynamicParameters();
                    p.Add(name: "@NOMBRE", value: tipoCancha.Nombre, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add(name: "@PRECIO", value: tipoCancha.Precio, dbType: DbType.Decimal, direction: ParameterDirection.Input);
                    p.Add(name: "@USUARIOCREA", value: tipoCancha.UsuarioCrea, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add(name: "@USUARIOMODIFICA", value: tipoCancha.UsuarioModifica, dbType: DbType.Int32, direction: ParameterDirection.Input);

                    var id = db.ExecuteScalar<int>(sql: sql, param: p, commandType: CommandType.StoredProcedure);

                    response.IsSuccess = true;
                    response.ErrorCode = "0000";
                    response.ErrorMessage = string.Empty;
                    response.Data = id; // Devuelve el ID del nuevo tipo de cancha insertado
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

        public EntityBaseResponse UpdateTipoCancha(EntityTipoCancha tipoCancha)
        {
            var response = new EntityBaseResponse();
            try
            {
                using (var db = GetSqlConnection())
                {
                    const string sql = "usp_ActualizarTipoCancha";
                    var p = new DynamicParameters();
                    p.Add(name: "@IDTipoCancha", value: tipoCancha.IdTipoCancha, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add(name: "@NOMBRE", value: tipoCancha.Nombre, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add(name: "@PRECIO", value: tipoCancha.Precio, dbType: DbType.Decimal, direction: ParameterDirection.Input);
                    p.Add(name: "@USUARIOMODIFICA", value: tipoCancha.UsuarioModifica, dbType: DbType.Int32, direction: ParameterDirection.Input);

                    var rowsAffected = db.Execute(sql: sql, param: p, commandType: CommandType.StoredProcedure);

                    response.IsSuccess = rowsAffected > 0;
                    response.ErrorCode = rowsAffected > 0 ? "0000" : "0002";
                    response.ErrorMessage = rowsAffected > 0 ? string.Empty : "No se actualizó ningún tipo de cancha.";
                    response.Data = null;
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

        public EntityBaseResponse DeleteTipoCancha(int id)
        {
            var response = new EntityBaseResponse();
            try
            {
                using (var db = GetSqlConnection())
                {
                    const string sql = "usp_EliminarTipoCancha";
                    var p = new DynamicParameters();
                    p.Add(name: "@IDTipoCancha", value: id, dbType: DbType.Int32, direction: ParameterDirection.Input);

                    var rowsAffected = db.Execute(sql: sql, param: p, commandType: CommandType.StoredProcedure);

                    response.IsSuccess = rowsAffected > 0;
                    response.ErrorCode = rowsAffected > 0 ? "0000" : "0002";
                    response.ErrorMessage = rowsAffected > 0 ? string.Empty : "No se eliminó ningún tipo de cancha.";
                    response.Data = null;
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

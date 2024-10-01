using Dapper;
using DecideTuCancha.DBEntity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using DecideTuCancha.DBContext.Interface;
using DecideTuCancha.DBContext.Base;
using DecideTuCancha.DBEntity.Base;
using DecideTuCancha.DBEntity.Model;

namespace DecideTuCancha.DBContext.Repository
{
    public class SedeRepository : BaseRepository, ISedeRepository
    {
        public EntityBaseResponse GetSede(int id)
        {
            var response = new EntityBaseResponse();
            try
            {
                using (var db = GetSqlConnection())
                {
                    const string sql = "usp_ObtenerSede";
                    var p = new DynamicParameters();
                    p.Add(name: "@IDSede", value: id, dbType: DbType.Int32, direction: ParameterDirection.Input);

                    var sede = db.Query<EntitySede>(sql: sql, param: p, commandType: CommandType.StoredProcedure).FirstOrDefault();

                    if (sede != null)
                    {
                        response.IsSuccess = true;
                        response.ErrorCode = "0000";
                        response.ErrorMessage = string.Empty;
                        response.Data = sede;
                    }
                    else
                    {
                        response.IsSuccess = false;
                        response.ErrorCode = "0000";
                        response.ErrorMessage = "Sede no encontrada.";
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

        public EntityBaseResponse GetSedes()
        {
            var response = new EntityBaseResponse();
            try
            {
                using (var db = GetSqlConnection())
                {
                    const string sql = "usp_ListarSedes";
                    var sedes = db.Query<EntitySede>(sql: sql, commandType: CommandType.StoredProcedure).ToList();

                    if (sedes.Count > 0)
                    {
                        response.IsSuccess = true;
                        response.ErrorCode = "0000";
                        response.ErrorMessage = string.Empty;
                        response.Data = sedes;
                    }
                    else
                    {
                        response.IsSuccess = false;
                        response.ErrorCode = "0000";
                        response.ErrorMessage = "No se encontraron sedes.";
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

        public EntityBaseResponse InsertSede(EntitySede sede)
        {
            var response = new EntityBaseResponse();
            try
            {
                using (var db = GetSqlConnection())
                {
                    const string sql = "usp_InsertarSede";
                    var p = new DynamicParameters();
                    p.Add(name: "@IDComplejo", value: sede.IdComplejo, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add(name: "@NOMBRE", value: sede.Nombre, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add(name: "@HABILITADO", value: sede.Habilitado, dbType: DbType.Boolean, direction: ParameterDirection.Input);
                    p.Add(name: "@USUARIOCREA", value: sede.UsuarioCrea, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add(name: "@USUARIOMODIFICA", value: sede.UsuarioModifica, dbType: DbType.Int32, direction: ParameterDirection.Input);

                    var id = db.ExecuteScalar<int>(sql: sql, param: p, commandType: CommandType.StoredProcedure);

                    response.IsSuccess = true;
                    response.ErrorCode = "0000";
                    response.ErrorMessage = string.Empty;
                    response.Data = id; // Devuelve el ID de la nueva sede insertada
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

        public EntityBaseResponse UpdateSede(EntitySede sede)
        {
            var response = new EntityBaseResponse();
            try
            {
                using (var db = GetSqlConnection())
                {
                    const string sql = "usp_ActualizarSede";
                    var p = new DynamicParameters();
                    p.Add(name: "@IDSede", value: sede.IdSede, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add(name: "@IDComplejo", value: sede.IdComplejo, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add(name: "@NOMBRE", value: sede.Nombre, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add(name: "@HABILITADO", value: sede.Habilitado, dbType: DbType.Boolean, direction: ParameterDirection.Input);
                    p.Add(name: "@USUARIOMODIFICA", value: sede.UsuarioModifica, dbType: DbType.Int32, direction: ParameterDirection.Input);

                    var rowsAffected = db.Execute(sql: sql, param: p, commandType: CommandType.StoredProcedure);

                    response.IsSuccess = rowsAffected > 0;
                    response.ErrorCode = rowsAffected > 0 ? "0000" : "0002";
                    response.ErrorMessage = rowsAffected > 0 ? string.Empty : "No se actualizó ninguna sede.";
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

        public EntityBaseResponse DeleteSede(int id)
        {
            var response = new EntityBaseResponse();
            try
            {
                using (var db = GetSqlConnection())
                {
                    const string sql = "usp_EliminarSede";
                    var p = new DynamicParameters();
                    p.Add(name: "@IDSede", value: id, dbType: DbType.Int32, direction: ParameterDirection.Input);

                    var rowsAffected = db.Execute(sql: sql, param: p, commandType: CommandType.StoredProcedure);

                    response.IsSuccess = rowsAffected > 0;
                    response.ErrorCode = rowsAffected > 0 ? "0000" : "0002";
                    response.ErrorMessage = rowsAffected > 0 ? string.Empty : "No se eliminó ninguna sede.";
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

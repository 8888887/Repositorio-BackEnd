using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DecideTuCancha.DBContext.Interface;
using DecideTuCancha.DBContext.Base;
using DecideTuCancha.DBEntity.Base;
using DecideTuCancha.DBEntity.Model;

namespace DecideTuCancha.DBContext.Repository
{
    public class ComplejoRepository : BaseRepository, IComplejoRepository
    {
        public EntityBaseResponse GetComplejo(int id)
        {
            var response = new EntityBaseResponse();
            try
            {
                using (var db = GetSqlConnection())
                {
                    const string sql = "usp_ObtenerComplejo";
                    var p = new DynamicParameters();
                    p.Add(name: "@IDCOMPLEJO", value: id, dbType: DbType.Int32, direction: ParameterDirection.Input);

                    var complejo = db.Query<EntityComplejo>(sql: sql, param: p, commandType: CommandType.StoredProcedure).FirstOrDefault();

                    if (complejo != null)
                    {
                        response.IsSuccess = true;
                        response.ErrorCode = "0000";
                        response.ErrorMessage = string.Empty;
                        response.Data = complejo;
                    }
                    else
                    {
                        response.IsSuccess = false;
                        response.ErrorCode = "0000";
                        response.ErrorMessage = "Complejo no encontrado.";
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

        public EntityBaseResponse GetComplejos()
        {
            var response = new EntityBaseResponse();
            try
            {
                using (var db = GetSqlConnection())
                {
                    const string sql = "usp_ListarComplejos";
                    var complejos = db.Query<EntityComplejo>(sql: sql, commandType: CommandType.StoredProcedure).ToList();

                    if (complejos.Count > 0)
                    {
                        response.IsSuccess = true;
                        response.ErrorCode = "0000";
                        response.ErrorMessage = string.Empty;
                        response.Data = complejos;
                    }
                    else
                    {
                        response.IsSuccess = false;
                        response.ErrorCode = "0000";
                        response.ErrorMessage = "No se encontraron complejos.";
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

        public EntityBaseResponse InsertComplejo(EntityComplejo complejo)
        {
            var response = new EntityBaseResponse();
            try
            {
                using (var db = GetSqlConnection())
                {
                    const string sql = "usp_InsertarComplejo";
                    var p = new DynamicParameters();
                    p.Add(name: "@NOMBRE", value: complejo.Nombre, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add(name: "@DIRECCION", value: complejo.Direccion, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add(name: "@URL_IMAGEN", value: complejo.UrlImagen, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add(name: "@HABILITADO", value: complejo.Habilitado, dbType: DbType.Boolean, direction: ParameterDirection.Input);
                    p.Add(name: "@USUARIOCREA", value: complejo.UsuarioCrea, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add(name: "@USUARIOMODIFICA", value: complejo.UsuarioModifica, dbType: DbType.Int32, direction: ParameterDirection.Input);

                    var id = db.ExecuteScalar<int>(sql: sql, param: p, commandType: CommandType.StoredProcedure);

                    response.IsSuccess = true;
                    response.ErrorCode = "0000";
                    response.ErrorMessage = string.Empty;
                    response.Data = id; // Devuelve el ID del nuevo complejo insertado
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

        public EntityBaseResponse UpdateComplejo(EntityComplejo complejo)
        {
            var response = new EntityBaseResponse();
            try
            {
                using (var db = GetSqlConnection())
                {
                    const string sql = "usp_ActualizarComplejo";
                    var p = new DynamicParameters();
                    p.Add(name: "@IDCOMPLEJO", value: complejo.IdComplejo, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add(name: "@NOMBRE", value: complejo.Nombre, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add(name: "@DIRECCION", value: complejo.Direccion, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add(name: "@URL_IMAGEN", value: complejo.UrlImagen, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add(name: "@HABILITADO", value: complejo.Habilitado, dbType: DbType.Boolean, direction: ParameterDirection.Input);
                    p.Add(name: "@USUARIOMODIFICA", value: complejo.UsuarioModifica, dbType: DbType.Int32, direction: ParameterDirection.Input);

                    var rowsAffected = db.Execute(sql: sql, param: p, commandType: CommandType.StoredProcedure);

                    response.IsSuccess = rowsAffected > 0;
                    response.ErrorCode = rowsAffected > 0 ? "0000" : "0002";
                    response.ErrorMessage = rowsAffected > 0 ? string.Empty : "No se actualizó ningún complejo.";
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

        public EntityBaseResponse DeleteComplejo(int id)
        {
            var response = new EntityBaseResponse();
            try
            {
                using (var db = GetSqlConnection())
                {
                    const string sql = "usp_EliminarComplejo";
                    var p = new DynamicParameters();
                    p.Add(name: "@IDCOMPLEJO", value: id, dbType: DbType.Int32, direction: ParameterDirection.Input);

                    var rowsAffected = db.Execute(sql: sql, param: p, commandType: CommandType.StoredProcedure);

                    response.IsSuccess = rowsAffected > 0;
                    response.ErrorCode = rowsAffected > 0 ? "0000" : "0002";
                    response.ErrorMessage = rowsAffected > 0 ? string.Empty : "No se eliminó ningún complejo.";
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
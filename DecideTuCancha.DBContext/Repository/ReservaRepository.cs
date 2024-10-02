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
    public class ReservaRepository : BaseRepository, IReservaRepository
    {
        public EntityBaseResponse GetReserva(int id)
        {
            var response = new EntityBaseResponse();
            try
            {
                using (var db = GetSqlConnection())
                {
                    const string sql = "usp_ObtenerReserva";
                    var p = new DynamicParameters();
                    p.Add(name: "@IDReserva", value: id, dbType: DbType.Int32, direction: ParameterDirection.Input);

                    var reserva = db.Query<EntityReserva>(sql: sql, param: p, commandType: CommandType.StoredProcedure).FirstOrDefault();

                    if (reserva != null)
                    {
                        response.IsSuccess = true;
                        response.ErrorCode = "0000";
                        response.ErrorMessage = string.Empty;
                        response.Data = reserva;
                    }
                    else
                    {
                        response.IsSuccess = false;
                        response.ErrorCode = "0000";
                        response.ErrorMessage = "Reserva no encontrada.";
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

        public EntityBaseResponse GetReservas()
        {
            var response = new EntityBaseResponse();
            try
            {
                using (var db = GetSqlConnection())
                {
                    const string sql = "usp_ListarReservas";
                    var reservas = db.Query<EntityReserva>(sql: sql, commandType: CommandType.StoredProcedure).ToList();

                    if (reservas.Count > 0)
                    {
                        response.IsSuccess = true;
                        response.ErrorCode = "0000";
                        response.ErrorMessage = string.Empty;
                        response.Data = reservas;
                    }
                    else
                    {
                        response.IsSuccess = false;
                        response.ErrorCode = "0000";
                        response.ErrorMessage = "No se encontraron reservas.";
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

        public EntityBaseResponse InsertReserva(EntityReserva reserva)
        {
            var response = new EntityBaseResponse();
            try
            {
                using (var db = GetSqlConnection())
                {
                    const string sql = "usp_InsertarReserva";
                    var p = new DynamicParameters();
                    p.Add(name: "@IDCancha", value: reserva.IdCancha, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add(name: "@IDUsuario", value: reserva.IdUsuario, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add(name: "@FechaReserva", value: reserva.FechaReserva, dbType: DbType.DateTime, direction: ParameterDirection.Input);
                    p.Add(name: "@HoraInicio", value: reserva.HoraInicio, dbType: DbType.DateTime, direction: ParameterDirection.Input);
                    p.Add(name: "@HoraFin", value: reserva.HoraFin, dbType: DbType.DateTime, direction: ParameterDirection.Input);
                    p.Add(name: "@USUARIOCREA", value: reserva.UsuarioCrea, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add(name: "@USUARIOMODIFICA", value: reserva.UsuarioModifica, dbType: DbType.Int32, direction: ParameterDirection.Input);

                    var id = db.ExecuteScalar<int>(sql: sql, param: p, commandType: CommandType.StoredProcedure);

                    response.IsSuccess = true;
                    response.ErrorCode = "0000";
                    response.ErrorMessage = string.Empty;
                    response.Data = id; // Devuelve el ID de la nueva reserva insertada
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

        public EntityBaseResponse UpdateReserva(EntityReserva reserva)
        {
            var response = new EntityBaseResponse();
            try
            {
                using (var db = GetSqlConnection())
                {
                    const string sql = "usp_ActualizarReserva";
                    var p = new DynamicParameters();
                    p.Add(name: "@IDReserva", value: reserva.IdReserva, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add(name: "@IDCancha", value: reserva.IdCancha, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add(name: "@IDUsuario", value: reserva.IdUsuario, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add(name: "@FechaReserva", value: reserva.FechaReserva, dbType: DbType.DateTime, direction: ParameterDirection.Input);
                    p.Add(name: "@HoraInicio", value: reserva.HoraInicio, dbType: DbType.DateTime, direction: ParameterDirection.Input);
                    p.Add(name: "@HoraFin", value: reserva.HoraFin, dbType: DbType.DateTime, direction: ParameterDirection.Input);
                    p.Add(name: "@USUARIOMODIFICA", value: reserva.UsuarioModifica, dbType: DbType.Int32, direction: ParameterDirection.Input);

                    var rowsAffected = db.Execute(sql: sql, param: p, commandType: CommandType.StoredProcedure);

                    response.IsSuccess = rowsAffected > 0;
                    response.ErrorCode = rowsAffected > 0 ? "0000" : "0002";
                    response.ErrorMessage = rowsAffected > 0 ? string.Empty : "No se actualizó ninguna reserva.";
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

        public EntityBaseResponse DeleteReserva(int id)
        {
            var response = new EntityBaseResponse();
            try
            {
                using (var db = GetSqlConnection())
                {
                    const string sql = "usp_EliminarReserva";
                    var p = new DynamicParameters();
                    p.Add(name: "@IDReserva", value: id, dbType: DbType.Int32, direction: ParameterDirection.Input);

                    var rowsAffected = db.Execute(sql: sql, param: p, commandType: CommandType.StoredProcedure);

                    response.IsSuccess = rowsAffected > 0;
                    response.ErrorCode = rowsAffected > 0 ? "0000" : "0002";
                    response.ErrorMessage = rowsAffected > 0 ? string.Empty : "No se eliminó ninguna reserva.";
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

        public EntityBaseResponse GetReservasByCancha(int idCancha)
        {
            var response = new EntityBaseResponse();
            try
            {
                using (var db = GetSqlConnection())
                {
                    const string sql = "usp_ListarReservasPorCancha";
                    var p = new DynamicParameters();
                    p.Add(name: "@IDCancha", value: idCancha, dbType: DbType.Int32, direction: ParameterDirection.Input);

                    var reservas = db.Query<EntityReserva>(sql: sql, param: p, commandType: CommandType.StoredProcedure).ToList();

                    if (reservas.Count > 0)
                    {
                        response.IsSuccess = true;
                        response.ErrorCode = "0000";
                        response.ErrorMessage = string.Empty;
                        response.Data = reservas;
                    }
                    else
                    {
                        response.IsSuccess = false;
                        response.ErrorCode = "0000";
                        response.ErrorMessage = "No se encontraron reservas para la cancha especificada.";
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

        public EntityBaseResponse GetReservasByUsuario(int idUsuario)
        {
            var response = new EntityBaseResponse();
            try
            {
                using (var db = GetSqlConnection())
                {
                    const string sql = "usp_ListarReservasPorUsuario";
                    var p = new DynamicParameters();
                    p.Add(name: "@IDUsuario", value: idUsuario, dbType: DbType.Int32, direction: ParameterDirection.Input);

                    var reservas = db.Query<EntityReserva>(sql: sql, param: p, commandType: CommandType.StoredProcedure).ToList();

                    if (reservas.Count > 0)
                    {
                        response.IsSuccess = true;
                        response.ErrorCode = "0000";
                        response.ErrorMessage = string.Empty;
                        response.Data = reservas;
                    }
                    else
                    {
                        response.IsSuccess = false;
                        response.ErrorCode = "0000";
                        response.ErrorMessage = "No se encontraron reservas para el usuario especificado.";
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

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
    public class UsuarioRepository : BaseRepository, IUsuarioRepository
    {
        public EntityBaseResponse GetUsuario(int id)
        {
            var response = new EntityBaseResponse();
            try
            {
                using (var db = GetSqlConnection())
                {
                    const string sql = "usp_ObtenerUsuario";
                    var p = new DynamicParameters();
                    p.Add(name: "@IDUsuario", value: id, dbType: DbType.Int32, direction: ParameterDirection.Input);

                    var usuario = db.Query<EntityUsuario>(sql: sql, param: p, commandType: CommandType.StoredProcedure).FirstOrDefault();

                    if (usuario != null)
                    {
                        response.IsSuccess = true;
                        response.ErrorCode = "0000";
                        response.ErrorMessage = string.Empty;
                        response.Data = usuario;
                    }
                    else
                    {
                        response.IsSuccess = false;
                        response.ErrorCode = "0000";
                        response.ErrorMessage = "Usuario no encontrado.";
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

        public EntityBaseResponse GetUsuarios()
        {
            var response = new EntityBaseResponse();
            try
            {
                using (var db = GetSqlConnection())
                {
                    const string sql = "usp_ListarUsuarios";
                    var usuarios = db.Query<EntityUsuario>(sql: sql, commandType: CommandType.StoredProcedure).ToList();

                    if (usuarios.Count > 0)
                    {
                        response.IsSuccess = true;
                        response.ErrorCode = "0000";
                        response.ErrorMessage = string.Empty;
                        response.Data = usuarios;
                    }
                    else
                    {
                        response.IsSuccess = false;
                        response.ErrorCode = "0000";
                        response.ErrorMessage = "No se encontraron usuarios.";
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

        public EntityBaseResponse InsertUsuario(EntityUsuario usuario)
        {
            var response = new EntityBaseResponse();
            try
            {
                using (var db = GetSqlConnection())
                {
                    const string sql = "usp_InsertarUsuario";
                    var p = new DynamicParameters();
                    p.Add(name: "@NOMBRE", value: usuario.Nombre, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add(name: "@EMAIL", value: usuario.Email, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add(name: "@CONTRASENA", value: usuario.Contrasena, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add(name: "@USUARIOCREA", value: usuario.UsuarioCrea, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add(name: "@USUARIOMODIFICA", value: usuario.UsuarioModifica, dbType: DbType.Int32, direction: ParameterDirection.Input);

                    var id = db.ExecuteScalar<int>(sql: sql, param: p, commandType: CommandType.StoredProcedure);

                    response.IsSuccess = true;
                    response.ErrorCode = "0000";
                    response.ErrorMessage = string.Empty;
                    response.Data = id; // Devuelve el ID del nuevo usuario insertado
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

        public EntityBaseResponse UpdateUsuario(EntityUsuario usuario)
        {
            var response = new EntityBaseResponse();
            try
            {
                using (var db = GetSqlConnection())
                {
                    const string sql = "usp_ActualizarUsuario";
                    var p = new DynamicParameters();
                    p.Add(name: "@IDUsuario", value: usuario.IdUsuario, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add(name: "@NOMBRE", value: usuario.Nombre, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add(name: "@EMAIL", value: usuario.Email, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add(name: "@CONTRASENA", value: usuario.Contrasena, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add(name: "@USUARIOMODIFICA", value: usuario.UsuarioModifica, dbType: DbType.Int32, direction: ParameterDirection.Input);

                    var rowsAffected = db.Execute(sql: sql, param: p, commandType: CommandType.StoredProcedure);

                    response.IsSuccess = rowsAffected > 0;
                    response.ErrorCode = rowsAffected > 0 ? "0000" : "0002";
                    response.ErrorMessage = rowsAffected > 0 ? string.Empty : "No se actualizó ningún usuario.";
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

        public EntityBaseResponse DeleteUsuario(int id)
        {
            var response = new EntityBaseResponse();
            try
            {
                using (var db = GetSqlConnection())
                {
                    const string sql = "usp_EliminarUsuario";
                    var p = new DynamicParameters();
                    p.Add(name: "@IDUsuario", value: id, dbType: DbType.Int32, direction: ParameterDirection.Input);

                    var rowsAffected = db.Execute(sql: sql, param: p, commandType: CommandType.StoredProcedure);

                    response.IsSuccess = rowsAffected > 0;
                    response.ErrorCode = rowsAffected > 0 ? "0000" : "0002";
                    response.ErrorMessage = rowsAffected > 0 ? string.Empty : "No se eliminó ningún usuario.";
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

        public EntityBaseResponse Authenticate(string email, string contrasena)
        {
            var response = new EntityBaseResponse();
            try
            {
                using (var db = GetSqlConnection())
                {
                    const string sql = "usp_AutenticarUsuario";
                    var p = new DynamicParameters();
                    p.Add(name: "@EMAIL", value: email, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add(name: "@CONTRASENA", value: contrasena, dbType: DbType.String, direction: ParameterDirection.Input);

                    var usuario = db.Query<EntityUsuario>(sql: sql, param: p, commandType: CommandType.StoredProcedure).FirstOrDefault();

                    if (usuario != null)
                    {
                        response.IsSuccess = true;
                        response.ErrorCode = "0000";
                        response.ErrorMessage = string.Empty;
                        response.Data = usuario;
                    }
                    else
                    {
                        response.IsSuccess = false;
                        response.ErrorCode = "0000";
                        response.ErrorMessage = "Credenciales inválidas.";
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

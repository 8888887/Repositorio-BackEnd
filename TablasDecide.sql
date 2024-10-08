CREATE TABLE [dbo].[COMPLEJO](
    [IDCOMPLEJO] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    [NOMBRE] VARCHAR(50) NOT NULL,
    [DIRECCION] VARCHAR(100) NOT NULL,
    [URLIMAGEN] VARCHAR(255) NULL,
    [HABILITADO] BIT NOT NULL,
    [USUARIOCREA] INT NOT NULL,
    [USUARIOMODIFICA] INT NOT NULL,
    [FECHACREA] DATETIME NOT NULL DEFAULT GETDATE(),
    [FECHAMODIFICA] DATETIME NOT NULL DEFAULT GETDATE()
);


CREATE TABLE [dbo].[SEDE](
    [IDSEDE] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    [IDCOMPLEJO] INT NOT NULL,
    [NOMBRE] VARCHAR(30) NOT NULL,
    [HABILITADO] BIT NOT NULL,
    [USUARIOCREA] INT NOT NULL,
    [USUARIOMODIFICA] INT NOT NULL,
    [FECHACREA] DATETIME NOT NULL DEFAULT GETDATE(),
    [FECHAMODIFICA] DATETIME NOT NULL DEFAULT GETDATE(),
    FOREIGN KEY (IDCOMPLEJO) REFERENCES COMPLEJO(IDCOMPLEJO) ON DELETE CASCADE
);



CREATE TABLE [dbo].[TIPOCANCHA](
    [IDTIPOCANCHA] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    [NOMBRE] VARCHAR(20) NOT NULL,
    [PRECIO] DECIMAL(10, 2) NOT NULL,
    [HABILITADO] BIT NOT NULL,
    [USUARIOCREA] INT NOT NULL,
    [USUARIOMODIFICA] INT NOT NULL,
    [FECHACREA] DATETIME NOT NULL DEFAULT GETDATE(),
    [FECHAMODIFICA] DATETIME NOT NULL DEFAULT GETDATE()
);


CREATE TABLE [dbo].[USUARIO](
    [IDUSUARIO] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    [NOMBRE] VARCHAR(50) NOT NULL,
    [EMAIL] VARCHAR(100) NOT NULL UNIQUE,
    [CONTRASENA] VARCHAR(255) NOT NULL,  -- Encriptar la contrase�a
    [HABILITADO] BIT NOT NULL,
    [USUARIOCREA] INT NOT NULL,
    [USUARIOMODIFICA] INT NOT NULL,
    [FECHACREA] DATETIME NOT NULL DEFAULT GETDATE(),
    [FECHAMODIFICA] DATETIME NOT NULL DEFAULT GETDATE()
);

CREATE TABLE [dbo].[CANCHA](
    [IDCANCHA] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    [IDSEDE] INT NOT NULL,
    [NOMBRE] VARCHAR(20) NOT NULL,
    [IDTIPOCANCHA] INT NOT NULL,  -- Tipo de cancha (f�tbol, voley, etc.)
    [HABILITADO] BIT NOT NULL,
    [USUARIOCREA] INT NOT NULL,
    [USUARIOMODIFICA] INT NOT NULL,
    [FECHACREA] DATETIME NOT NULL DEFAULT GETDATE(),
    [FECHAMODIFICA] DATETIME NOT NULL DEFAULT GETDATE(),
    FOREIGN KEY (IDSEDE) REFERENCES SEDE(IDSEDE) ON DELETE CASCADE,
    FOREIGN KEY (IDTIPOCANCHA) REFERENCES TIPOCANCHA(IDTIPOCANCHA) ON DELETE NO ACTION
);


CREATE TABLE [dbo].[RESERVA](
    [IDRESERVA] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    [IDCANCHA] INT NOT NULL,
    [IDUSUARIO] INT NOT NULL,
    [FECHARESERVA] DATETIME NOT NULL,
    [HORAINICIO] DATETIME NOT NULL,
    [HORAFIN] DATETIME NOT NULL,
    [HABILITADO] BIT NOT NULL,
    [USUARIOCREA] INT NOT NULL,
    [USUARIOMODIFICA] INT NOT NULL,
    [FECHACREA] DATETIME NOT NULL DEFAULT GETDATE(),
    [FECHAMODIFICA] DATETIME NOT NULL DEFAULT GETDATE(),
    FOREIGN KEY (IDCANCHA) REFERENCES CANCHA(IDCANCHA) ON DELETE CASCADE,
    FOREIGN KEY (IDUSUARIO) REFERENCES USUARIO(IDUSUARIO) ON DELETE NO ACTION
);

GO

--------------------------------------------
-- PROCEDIMIENTOS
--------------------------------------------


CREATE PROCEDURE usp_ObtenerComplejo
    @IDCOMPLEJO INT
AS
BEGIN
    SET NOCOUNT ON;
    SELECT * FROM COMPLEJO WHERE IDCOMPLEJO = @IDCOMPLEJO;
END
go

CREATE PROCEDURE usp_ListarComplejos
AS
BEGIN
    SET NOCOUNT ON;
    SELECT * FROM COMPLEJO;
END
go

CREATE PROCEDURE usp_InsertarComplejo
    @NOMBRE VARCHAR(50),
    @DIRECCION VARCHAR(100),
    @URLIMAGEN VARCHAR(255),
    @HABILITADO BIT,
    @USUARIOCREA INT,
    @USUARIOMODIFICA INT
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO COMPLEJO (NOMBRE, DIRECCION, URLIMAGEN, HABILITADO, USUARIOCREA, USUARIOMODIFICA)
    VALUES (@NOMBRE, @DIRECCION, @URLIMAGEN, @HABILITADO, @USUARIOCREA, @USUARIOMODIFICA);
    SELECT SCOPE_IDENTITY();
END
go

CREATE PROCEDURE usp_ActualizarComplejo
    @IDCOMPLEJO INT,
    @NOMBRE VARCHAR(50),
    @DIRECCION VARCHAR(100),
    @URLIMAGEN VARCHAR(255),
    @HABILITADO BIT,
    @USUARIOMODIFICA INT
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE COMPLEJO
    SET NOMBRE = @NOMBRE,
        DIRECCION = @DIRECCION,
        URLIMAGEN = @URLIMAGEN,
        HABILITADO = @HABILITADO,
        USUARIOMODIFICA = @USUARIOMODIFICA
    WHERE IDCOMPLEJO = @IDCOMPLEJO;
END
go

CREATE PROCEDURE usp_EliminarComplejo
    @IDCOMPLEJO INT
AS
BEGIN
    SET NOCOUNT ON;
    DELETE FROM COMPLEJO WHERE IDCOMPLEJO = @IDCOMPLEJO;
END
go





CREATE PROCEDURE usp_ObtenerSede
    @IDSede INT
AS
BEGIN
    SET NOCOUNT ON;
    SELECT * FROM SEDE WHERE IdSede = @IDSede;
END
go

CREATE PROCEDURE usp_ListarSedes
AS
BEGIN
    SET NOCOUNT ON;
    SELECT * FROM SEDE;
END
go

CREATE PROCEDURE usp_InsertarSede
    @IDComplejo INT,
    @NOMBRE VARCHAR(50),
    @HABILITADO BIT,
    @USUARIOCREA INT,
    @USUARIOMODIFICA INT
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO SEDE (IdComplejo, NOMBRE, HABILITADO, USUARIOCREA, USUARIOMODIFICA)
    VALUES (@IDComplejo, @NOMBRE, @HABILITADO, @USUARIOCREA, @USUARIOMODIFICA);
    SELECT SCOPE_IDENTITY();
END
go

CREATE PROCEDURE usp_ActualizarSede
    @IDSede INT,
    @IDComplejo INT,
    @NOMBRE VARCHAR(50),
    @HABILITADO BIT,
    @USUARIOMODIFICA INT
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE SEDE
    SET IdComplejo = @IDComplejo,
        NOMBRE = @NOMBRE,
        HABILITADO = @HABILITADO,
        USUARIOMODIFICA = @USUARIOMODIFICA
    WHERE IdSede = @IDSede;
END
go

CREATE PROCEDURE usp_EliminarSede
    @IDSede INT
AS
BEGIN
    SET NOCOUNT ON;
    DELETE FROM SEDE WHERE IdSede = @IDSede;
END
go




CREATE PROCEDURE usp_ObtenerCancha
    @IDCancha INT
AS
BEGIN
    SET NOCOUNT ON;
    SELECT * FROM CANCHA WHERE IdCancha = @IDCancha;
END
go

CREATE PROCEDURE usp_ListarCanchas
AS
BEGIN
    SET NOCOUNT ON;
    SELECT * FROM CANCHA;
END
go

CREATE PROCEDURE usp_InsertarCancha
    @IDSede INT,
    @NOMBRE VARCHAR(50),
    @IDTIPOCANCHA INT,
    @USUARIOCREA INT,
    @USUARIOMODIFICA INT
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO CANCHA (IdSede, Nombre, IdTipoCancha, UsuarioCrea, UsuarioModifica)
    VALUES (@IDSede, @NOMBRE, @IDTIPOCANCHA, @USUARIOCREA, @USUARIOMODIFICA);
    SELECT SCOPE_IDENTITY();
END
go


CREATE PROCEDURE usp_ActualizarCancha
    @IDCancha INT,
    @IDSede INT,
    @NOMBRE VARCHAR(50),
    @IDTIPOCANCHA INT,
    @USUARIOMODIFICA INT
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE CANCHA
    SET IdSede = @IDSede,
        Nombre = @NOMBRE,
        IdTipoCancha = @IDTIPOCANCHA,
        UsuarioModifica = @USUARIOMODIFICA
    WHERE IdCancha = @IDCancha;
END
go

CREATE PROCEDURE usp_EliminarCancha
    @IDCancha INT
AS
BEGIN
    SET NOCOUNT ON;
    DELETE FROM CANCHA WHERE IdCancha = @IDCancha;
END
go





CREATE PROCEDURE usp_ObtenerTipoCancha
    @IDTipoCancha INT
AS
BEGIN
    SET NOCOUNT ON;
    SELECT * FROM TIPOCANCHA WHERE IdTipoCancha = @IDTipoCancha;
END
go

CREATE PROCEDURE usp_ListarTiposCancha
AS
BEGIN
    SET NOCOUNT ON;
    SELECT * FROM TIPOCANCHA;
END
go

CREATE PROCEDURE usp_InsertarTipoCancha
    @NOMBRE VARCHAR(50),
    @PRECIO DECIMAL(18, 2),
    @USUARIOCREA INT,
    @USUARIOMODIFICA INT
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO TIPOCANCHA (Nombre, Precio, UsuarioCrea, UsuarioModifica)
    VALUES (@NOMBRE, @PRECIO, @USUARIOCREA, @USUARIOMODIFICA);
    SELECT SCOPE_IDENTITY();
END
go


CREATE PROCEDURE usp_ActualizarTipoCancha
    @IDTipoCancha INT,
    @NOMBRE VARCHAR(50),
    @PRECIO DECIMAL(18, 2),
    @USUARIOMODIFICA INT
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE TIPOCANCHA
    SET Nombre = @NOMBRE,
        Precio = @PRECIO,
        UsuarioModifica = @USUARIOMODIFICA
    WHERE IdTipoCancha = @IDTipoCancha;
END
go


CREATE PROCEDURE usp_EliminarTipoCancha
    @IDTipoCancha INT
AS
BEGIN
    SET NOCOUNT ON;
    DELETE FROM TIPOCANCHA WHERE IdTipoCancha = @IDTipoCancha;
END
go



CREATE PROCEDURE usp_ObtenerUsuario
    @IDUsuario INT
AS
BEGIN
    SET NOCOUNT ON;
    SELECT * FROM USUARIO WHERE IdUsuario = @IDUsuario;
END
go

CREATE PROCEDURE usp_ListarUsuarios
AS
BEGIN
    SET NOCOUNT ON;
    SELECT * FROM USUARIO;
END
go

CREATE PROCEDURE usp_InsertarUsuario
    @NOMBRE VARCHAR(50),
    @EMAIL VARCHAR(100),
    @CONTRASENA VARCHAR(100),
    @USUARIOCREA INT,
    @USUARIOMODIFICA INT
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO USUARIO (Nombre, Email, Contrasena, UsuarioCrea, UsuarioModifica)
    VALUES (@NOMBRE, @EMAIL, @CONTRASENA, @USUARIOCREA, @USUARIOMODIFICA);
    SELECT SCOPE_IDENTITY();
END
go

CREATE PROCEDURE usp_ActualizarUsuario
    @IDUsuario INT,
    @NOMBRE VARCHAR(50),
    @EMAIL VARCHAR(100),
    @CONTRASENA VARCHAR(100),
    @USUARIOMODIFICA INT
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE USUARIO
    SET Nombre = @NOMBRE,
        Email = @EMAIL,
        Contrasena = @CONTRASENA,
        UsuarioModifica = @USUARIOMODIFICA
    WHERE IdUsuario = @IDUsuario;
END
go

CREATE PROCEDURE usp_EliminarUsuario
    @IDUsuario INT
AS
BEGIN
    SET NOCOUNT ON;
    DELETE FROM USUARIO WHERE IdUsuario = @IDUsuario;
END
go

CREATE PROCEDURE usp_AutenticarUsuario
    @EMAIL VARCHAR(100),
    @CONTRASENA VARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;
    SELECT * FROM USUARIO 
    WHERE Email = @EMAIL AND Contrasena = @CONTRASENA;
END
go






CREATE PROCEDURE usp_InsertarReserva
    @IDCancha INT,
    @IDUsuario INT,
    @FechaReserva DATETIME,
    @HoraInicio DATETIME,
    @HoraFin DATETIME,
    @USUARIOCREA INT,
    @USUARIOMODIFICA INT
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO RESERVA (IdCancha, IdUsuario, FechaReserva, HoraInicio, HoraFin, UsuarioCrea, UsuarioModifica)
    VALUES (@IDCancha, @IDUsuario, @FechaReserva, @HoraInicio, @HoraFin, @USUARIOCREA, @USUARIOMODIFICA);
    SELECT SCOPE_IDENTITY();
END
go

CREATE PROCEDURE usp_ActualizarReserva
    @IDReserva INT,
    @IDCancha INT,
    @IDUsuario INT,
    @FechaReserva DATETIME,
    @HoraInicio DATETIME,
    @HoraFin DATETIME,
    @USUARIOMODIFICA INT
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE RESERVA
    SET IdCancha = @IDCancha,
        IdUsuario = @IDUsuario,
        FechaReserva = @FechaReserva,
        HoraInicio = @HoraInicio,
        HoraFin = @HoraFin,
        UsuarioModifica = @USUARIOMODIFICA
    WHERE IdReserva = @IDReserva;
END
go

CREATE PROCEDURE usp_EliminarReserva
    @IDReserva INT
AS
BEGIN
    SET NOCOUNT ON;
    DELETE FROM RESERVA WHERE IdReserva = @IDReserva;
END
go

CREATE PROCEDURE usp_ObtenerReserva
    @IDReserva INT
AS
BEGIN
    SET NOCOUNT ON;
    SELECT * FROM RESERVA WHERE IdReserva = @IDReserva;
END
go

CREATE PROCEDURE usp_ListarReservas
AS
BEGIN
    SET NOCOUNT ON;
    SELECT * FROM RESERVA;
END
go

CREATE PROCEDURE usp_ListarReservasPorCancha
    @IDCancha INT
AS
BEGIN
    SET NOCOUNT ON;
    SELECT * FROM RESERVA WHERE IdCancha = @IDCancha;
END
go

CREATE PROCEDURE usp_ListarReservasPorUsuario
    @IDUsuario INT
AS
BEGIN
    SET NOCOUNT ON;
    SELECT * FROM RESERVA WHERE IdUsuario = @IDUsuario;
END
go



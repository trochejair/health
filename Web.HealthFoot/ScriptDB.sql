USE HEALTHFOOT
GO
USE HEALTHFOOT
GO
CREATE TABLE CATEGORIA
(
    ID         INT      NOT NULL IDENTITY,
    NOMBRE     NVARCHAR(50),
    ACTIVO     INT,
    CREATED_AT DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
    PRIMARY KEY (ID)
)
GO
CREATE TABLE PRODUCTO
(
    ID           INT      NOT NULL IDENTITY,
    NOMBRE       NVARCHAR(100),
    CANTIDAD     INT,
    PRECIO       FLOAT,
    DESCRIPCION  TEXT,
    FK_CATEGORIA INT      NOT NULL,
    ACTIVO       INT,
    CREATED_AT   DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
    PRIMARY KEY (ID),
    FOREIGN KEY (FK_CATEGORIA) REFERENCES CATEGORIA (ID)
)
GO

CREATE TABLE IMAGEN_PRODUCTO
(
    ID          INT NOT NULL IDENTITY,
    IMAGEN      NVARCHAR(255),
    FK_PRODUCTO INT NOT NULL,
    PRIMARY KEY (ID),
    FOREIGN KEY (FK_PRODUCTO) REFERENCES PRODUCTO (ID)
)
GO
CREATE TABLE DIRECCION
(
    ID         INT      NOT NULL IDENTITY,
    ESTADO     NVARCHAR(50),
    CIUDAD     NVARCHAR(50),
    MUNICIPIO  NVARCHAR(50),
    COLONIA    NVARCHAR(100),
    CALLE      NVARCHAR(100),
    CP         NVARCHAR(8),
    NUMERO     NVARCHAR(10),
    ACTIVO     INT,
    CREATED_AT DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
    PRIMARY KEY (ID)
)
GO


CREATE TABLE PROVEEDOR
(
    ID           INT      NOT NULL IDENTITY,
    NOMBRE       NVARCHAR(100),
    TELEFONO     NVARCHAR(15),
    CORREO       NVARCHAR(50),
    RFC          NVARCHAR(20),
    FK_DIRECCION INT      NOT NULL,
    ACTIVO       INT,
    CREATED_AT   DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
    PRIMARY KEY (ID),
    FOREIGN KEY (FK_DIRECCION) REFERENCES DIRECCION (ID)
)
GO

CREATE TABLE ORDEN_PROVEEDOR
(
    ID           INT      NOT NULL IDENTITY,
    FK_PROVEEDOR INT      NOT NULL,
    FECHA        DATE,
    CREATED_AT   DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
    PRIMARY KEY (ID),
    FOREIGN KEY (FK_PROVEEDOR) REFERENCES PROVEEDOR (ID)
)
GO
CREATE TABLE INSUMO
(
    ID            INT      NOT NULL IDENTITY,
    NOMBRE        NVARCHAR(100),
    CANTIDAD      INT,
    ACTIVO        INT,
    CREATED_AT    DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
    PRIMARY KEY (ID),
)
GO

CREATE TABLE INSUMO_ORDEN
(
    ID            INT      NOT NULL IDENTITY,
    CANTIDAD      INT,
    PRECIO        FLOAT,
    UNIDAD_MEDIDA NVARCHAR(50),
    ACTIVO        INT,
    CREATED_AT    DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
    FK_ORDEN_PROVEEDOR INT NOT NULL,
    FK_INSUMO INT NOT NULL,
    PRIMARY KEY (ID),
    FOREIGN KEY (FK_ORDEN_PROVEEDOR) REFERENCES ORDEN_PROVEEDOR (ID),
    FOREIGN KEY (FK_INSUMO) REFERENCES INSUMO (ID)
)
GO

CREATE TABLE FORMULA
(
    ID          INT      NOT NULL IDENTITY,
    FK_PRODUCTO INT      NOT NULL,
    FK_INSUMO_ORDEN   INT      NOT NULL,
    UNIDAD_MEDIDA NVARCHAR(50),
    CANTIDAD    INT,
    CREATED_AT  DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
    PRIMARY KEY (ID),
    FOREIGN KEY (FK_PRODUCTO) REFERENCES PRODUCTO (ID),
    FOREIGN KEY (FK_INSUMO_ORDEN) REFERENCES INSUMO_ORDEN (ID)
)
GO


CREATE TABLE CLIENTE
(
    ID               INT      NOT NULL IDENTITY,
    NOMBRE           NVARCHAR(50),
    APELLIDOS NVARCHAR(50),
    EMAIL NVARCHAR(255),
    FK_DIRECCION     INT      NOT NULL,
    ACTIVO           INT,
	ROL INT,
    CREATED_AT       DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
    PRIMARY KEY (ID),
    FOREIGN KEY (FK_DIRECCION) REFERENCES DIRECCION (ID)
)
GO

CREATE TABLE ORDEN
(
    ID         INT      NOT NULL IDENTITY,
    FECHA      DATE,
    FK_CLIENTE INT      NOT NULL,
	ESTATUS NVARCHAR(50),
    ACTIVO     INT,
    CREATED_AT DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
    PRIMARY KEY (ID),
    FOREIGN KEY (FK_CLIENTE) REFERENCES CLIENTE (ID)
)
GO

CREATE TABLE DETALLE_ORDEN
(
    ID          INT NOT NULL IDENTITY,
    FK_ORDEN    INT NOT NULL,
    FK_PRODUCTO INT NOT NULL,
    CANTIDAD    INT,
    SUBTOTAL    FLOAT,
    PRIMARY KEY (ID),
    FOREIGN KEY (FK_PRODUCTO) REFERENCES PRODUCTO (ID),
    FOREIGN KEY (FK_ORDEN) REFERENCES ORDEN (ID)
)
GO

CREATE TABLE VENTA
(
    ID           INT NOT NULL IDENTITY,
    FK_ORDEN     INT NOT NULL,
    FECHA        DATE,
    FK_DIRECCION INT NOT NULL,
	CREATED_AT   DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
    PRIMARY KEY (ID),
    FOREIGN KEY (FK_ORDEN) REFERENCES ORDEN (ID),
    FOREIGN KEY (FK_DIRECCION) REFERENCES DIRECCION (ID)
)
GO

CREATE TABLE VEHICULO(
ID INT NOT NULL IDENTITY,
NOMBRE NVARCHAR(50),
MARCA NVARCHAR(50),
MODELO NVARCHAR(50),
CAPACIDAD NVARCHAR(50),
PESO NVARCHAR(50),
CILINDROS INT,
ACTIVO INT,
CREATED_AT DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
PRIMARY KEY(ID))
GO

CREATE TABLE RUTA(
ID INT NOT NULL IDENTITY,
INICIO NVARCHAR(50),
FIN NVARCHAR(50),
DISTANCIA INT,
ACTIVO INT,
CREATED_AT DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
PRIMARY KEY(ID))
GO

CREATE TABLE EMBARQUE(
ID INT NOT NULL IDENTITY,
ID_RUTA INT NOT NULL,
ID_VEHICULO INT NOT NULL,
FECHA DATE,
ACTIVO INT,
CREATED_AT DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
PRIMARY KEY(ID),
FOREIGN KEY(ID_RUTA) REFERENCES RUTA(ID),
FOREIGN KEY(ID_VEHICULO) REFERENCES VEHICULO(ID),
)
GO

CREATE TABLE ENTREGA(
ID INT NOT NULL IDENTITY,
ID_VENTA INT NOT NULL,
ID_EMBARQUE INT NOT NULL,
PRIMARY KEY(ID),
FOREIGN KEY(ID_EMBARQUE) REFERENCES EMBARQUE(ID),
FOREIGN KEY(ID_VENTA) REFERENCES VENTA(ID)
)
GO

CREATE TABLE EMPLEADO(
     ID int  NOT NULL IDENTITY,
     EMAIL Nvarchar(100) unique,
     APELIDO_PATERNO Nvarchar(50),
     APELLIDO_MATERNO Nvarchar(50),
     ROL INT,
	 CREATED_AT DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
	 ACTIVO INT,
	 PRIMARY KEY(ID)
);
go
/****** Object:  StoredProcedure [dbo].[spEMBARQUECt]    Script Date: 27/11/2019 10:20:32 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[spEMBARQUECt]
----------------------------------------------------------------------------------
-- Procedimiento encargado de seleccionar todos los registros sobre la tabla 
-- EMBARQUE
-- Creado por: Jair Troche
-- Fecha: 17/07/2019
----------------------------------------------------------------------------------
--Resumen de actualizaciones
--| Actualizado por |  Fecha  | Descripcion de la actualizacion
----------------------------------------------------------------------------------
----------------------------------------------------------------------------------
as
SET NOCOUNT ON 
	   SELECT E.ID,E.FECHA, V.NOMBRE AS VEHICULO, CONCAT(R.INICIO,'-',R.FIN) AS RUTA
	   FROM EMBARQUE E WITH(NOLOCK)
	   INNER JOIN VEHICULO V WITH(NOLOCK) ON  E.ID_VEHICULO=V.ID
	   INNER JOIN RUTA R WITH(NOLOCK) ON E.ID_RUTA=R.ID
	   ;
GO
/****** Object:  StoredProcedure [dbo].[spEmbarqueEl]    Script Date: 27/11/2019 10:20:32 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[spEmbarqueEl]
@IDEM INT
----------------------------------------------------------------------------------
-- Procedimiento encargado de eliminar sobre la tabla 
-- EMBARQUE
-- Creado por: Jair Troche
-- Fecha: 26/11/2019
----------------------------------------------------------------------------------
--Resumen de actualizaciones
--| Actualizado por |  Fecha  | Descripcion de la actualizacion
----------------------------------------------------------------------------------
----------------------------------------------------------------------------------
as
SET NOCOUNT ON 
BEGIN TRY
       BEGIN TRAN
BEGIN
	   UPDATE EMBARQUE SET ACTIVO=0
	   WHERE ID=@IDEM;
END

COMMIT
       
END TRY
BEGIN CATCH
       
       IF @@TRANCOUNT > 0
             ROLLBACK 
       --print error_line()       
       DECLARE @ErrorMessage NVARCHAR(4000);
       DECLARE @ErrorSeverity bigINT;
       DECLARE @ErrorState bigINT;
       SELECT @ErrorMessage = ERROR_MESSAGE(),
       @ErrorSeverity = ERROR_SEVERITY(),
       @ErrorState = ERROR_STATE();
       IF @ErrorState = 0
             SET @ErrorState = 1 
       RAISERROR (@ErrorMessage, @ErrorSeverity, @ErrorState);
       
END CATCH

GO
/****** Object:  StoredProcedure [dbo].[spEmbarqueIn]    Script Date: 27/11/2019 10:20:32 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[spEmbarqueIn]
@IDEM INT OUT,
@IDR INT,
@IDV INT,
@FECHA DATE
----------------------------------------------------------------------------------
-- Procedimiento encargado de actualizar sobre la tabla 
-- EMBARQUE
-- Creado por: Jair Troche
-- Fecha: 26/11/2019
----------------------------------------------------------------------------------
--Resumen de actualizaciones
--| Actualizado por |  Fecha  | Descripcion de la actualizacion
----------------------------------------------------------------------------------
----------------------------------------------------------------------------------
as
SET NOCOUNT ON 
BEGIN TRY
       BEGIN TRAN
BEGIN
	   INSERT INTO EMBARQUE(ID_RUTA,ID_VEHICULO,FECHA,ACTIVO) VALUES(@IDR,@IDV,@FECHA,1);
	   SET @IDEM = SCOPE_IDENTITY();
END

COMMIT
       
END TRY
BEGIN CATCH
       
       IF @@TRANCOUNT > 0
             ROLLBACK 
       --print error_line()       
       DECLARE @ErrorMessage NVARCHAR(4000);
       DECLARE @ErrorSeverity bigINT;
       DECLARE @ErrorState bigINT;
       SELECT @ErrorMessage = ERROR_MESSAGE(),
       @ErrorSeverity = ERROR_SEVERITY(),
       @ErrorState = ERROR_STATE();
       IF @ErrorState = 0
             SET @ErrorState = 1 
       RAISERROR (@ErrorMessage, @ErrorSeverity, @ErrorState);
       
END CATCH

GO
/****** Object:  StoredProcedure [dbo].[spEmbarqueUp]    Script Date: 27/11/2019 10:20:32 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[spEmbarqueUp]
@IDEM INT,
@IDR INT,
@IDV INT,
@FECHA DATE
----------------------------------------------------------------------------------
-- Procedimiento encargado de actualizar sobre la tabla 
-- EMBARQUE
-- Creado por: Jair Troche
-- Fecha: 26/11/2019
----------------------------------------------------------------------------------
--Resumen de actualizaciones
--| Actualizado por |  Fecha  | Descripcion de la actualizacion
----------------------------------------------------------------------------------
----------------------------------------------------------------------------------
as
SET NOCOUNT ON 
BEGIN TRY
       BEGIN TRAN
BEGIN
	   UPDATE EMBARQUE SET ID_RUTA=@IDR,ID_VEHICULO=@IDV,FECHA=@FECHA 
	   WHERE ID=@IDEM
END

COMMIT
       
END TRY
BEGIN CATCH
       
       IF @@TRANCOUNT > 0
             ROLLBACK 
       --print error_line()       
       DECLARE @ErrorMessage NVARCHAR(4000);
       DECLARE @ErrorSeverity bigINT;
       DECLARE @ErrorState bigINT;
       SELECT @ErrorMessage = ERROR_MESSAGE(),
       @ErrorSeverity = ERROR_SEVERITY(),
       @ErrorState = ERROR_STATE();
       IF @ErrorState = 0
             SET @ErrorState = 1 
       RAISERROR (@ErrorMessage, @ErrorSeverity, @ErrorState);
       
END CATCH

GO
/****** Object:  StoredProcedure [dbo].[spENTREGAEl]    Script Date: 27/11/2019 10:20:32 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[spENTREGAEl]
@IDE INT
--------------------------------------------------------------------
-- Procedimiento encargado de eliminar sobre la tabla 
-- ENTREGA
-- Creado por: Jair Troche
-- Fecha: 26/11/2019
----------------------------------------------------------------------------------
--Resumen de actualizaciones
--| Actualizado por |  Fecha  | Descripcion de la actualizacion
----------------------------------------------------------------------------------
----------------------------------------------------------------------------------
as
SET NOCOUNT ON 
BEGIN TRY
       BEGIN TRAN
BEGIN
	   DELETE FROM ENTREGA WHERE ID=@IDE;
END

COMMIT
       
END TRY
BEGIN CATCH
       
       IF @@TRANCOUNT > 0
             ROLLBACK 
       --print error_line()       
       DECLARE @ErrorMessage NVARCHAR(4000);
       DECLARE @ErrorSeverity bigINT;
       DECLARE @ErrorState bigINT;
       SELECT @ErrorMessage = ERROR_MESSAGE(),
       @ErrorSeverity = ERROR_SEVERITY(),
       @ErrorState = ERROR_STATE();
       IF @ErrorState = 0
             SET @ErrorState = 1 
       RAISERROR (@ErrorMessage, @ErrorSeverity, @ErrorState);
       
END CATCH

GO
/****** Object:  StoredProcedure [dbo].[spRUTAEd]    Script Date: 27/11/2019 10:20:32 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[spRUTAEd]
@IDRUTA INT,
@INICIO NVARCHAR(50),
@FIN NVARCHAR(50),
@DISTANCIA INT
----------------------------------------------------------------------------------
-- Procedimiento encargado de actualizar sobre la tabla 
-- RUTA
-- Creado por: Jair Troche
-- Fecha: 17/07/2019
----------------------------------------------------------------------------------
--Resumen de actualizaciones
--| Actualizado por |  Fecha  | Descripcion de la actualizacion
----------------------------------------------------------------------------------
----------------------------------------------------------------------------------
as
SET NOCOUNT ON 
BEGIN TRY
       BEGIN TRAN

BEGIN
	   UPDATE RUTA 
	   SET INICIO=@INICIO,
	   FIN=@FIN,
	   DISTANCIA=@DISTANCIA
	   WHERE ID=@IDRUTA;
END


COMMIT
       
END TRY
BEGIN CATCH
       
       IF @@TRANCOUNT > 0
             ROLLBACK 
       --print error_line()       
       DECLARE @ErrorMessage NVARCHAR(4000);
       DECLARE @ErrorSeverity bigINT;
       DECLARE @ErrorState bigINT;
       SELECT @ErrorMessage = ERROR_MESSAGE(),
       @ErrorSeverity = ERROR_SEVERITY(),
       @ErrorState = ERROR_STATE();
       IF @ErrorState = 0
             SET @ErrorState = 1 
       RAISERROR (@ErrorMessage, @ErrorSeverity, @ErrorState);
       
END CATCH
GO
/****** Object:  StoredProcedure [dbo].[spRUTAEl]    Script Date: 27/11/2019 10:20:32 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[spRUTAEl]
@IDE INT
----------------------------------------------------------------------------------
-- Procedimiento encargado de eliminar sobre la tabla 
-- ruta
-- Creado por: Jair Troche
-- Fecha: 26/11/2019
----------------------------------------------------------------------------------
--Resumen de actualizaciones
--| Actualizado por |  Fecha  | Descripcion de la actualizacion
----------------------------------------------------------------------------------
----------------------------------------------------------------------------------
as
SET NOCOUNT ON 
BEGIN TRY
       BEGIN TRAN
BEGIN
	   UPDATE RUTA SET ACTIVO=0
	   WHERE ID=@IDE ;
END

COMMIT
       
END TRY
BEGIN CATCH
       
       IF @@TRANCOUNT > 0
             ROLLBACK 
       --print error_line()       
       DECLARE @ErrorMessage NVARCHAR(4000);
       DECLARE @ErrorSeverity bigINT;
       DECLARE @ErrorState bigINT;
       SELECT @ErrorMessage = ERROR_MESSAGE(),
       @ErrorSeverity = ERROR_SEVERITY(),
       @ErrorState = ERROR_STATE();
       IF @ErrorState = 0
             SET @ErrorState = 1 
       RAISERROR (@ErrorMessage, @ErrorSeverity, @ErrorState);
       
END CATCH
GO
/****** Object:  StoredProcedure [dbo].[spRUTAIn]    Script Date: 27/11/2019 10:20:32 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[spRUTAIn]
@IDR INT OUT,
@INICIO NVARCHAR(50),
@FIN NVARCHAR(50),
@DISTANCIA INT
----------------------------------------------------------------------------------
-- Procedimiento encargado de insertar sobre la tabla 
-- EMBARQUES
-- Creado por: Jair Troche
-- Fecha: 26/11/2019
----------------------------------------------------------------------------------
--Resumen de actualizaciones
--| Actualizado por |  Fecha  | Descripcion de la actualizacion
----------------------------------------------------------------------------------
----------------------------------------------------------------------------------
as
SET NOCOUNT ON 
BEGIN TRY
       BEGIN TRAN
BEGIN
	   INSERT INTO RUTA(INICIO,FIN,DISTANCIA,ACTIVO) VALUES(@INICIO,@FIN,@DISTANCIA,1);
	   SET @IDR = SCOPE_IDENTITY();
END

COMMIT
       
END TRY
BEGIN CATCH
       
       IF @@TRANCOUNT > 0
             ROLLBACK 
       --print error_line()       
       DECLARE @ErrorMessage NVARCHAR(4000);
       DECLARE @ErrorSeverity bigINT;
       DECLARE @ErrorState bigINT;
       SELECT @ErrorMessage = ERROR_MESSAGE(),
       @ErrorSeverity = ERROR_SEVERITY(),
       @ErrorState = ERROR_STATE();
       IF @ErrorState = 0
             SET @ErrorState = 1 
       RAISERROR (@ErrorMessage, @ErrorSeverity, @ErrorState);
       
END CATCH
GO
/****** Object:  StoredProcedure [dbo].[spVehiculoCt]    Script Date: 27/11/2019 10:20:32 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[spVehiculoCt]
@ID INT
----------------------------------------------------------------------------------
-- Procedimiento encargado de seleccionar todos un registro sobre la tabla 
-- VEHICULO
-- Creado por: Jair Troche
-- Fecha: 23/11/2019
----------------------------------------------------------------------------------
--Resumen de actualizaciones
--| Actualizado por |  Fecha  | Descripcion de la actualizacion
----------------------------------------------------------------------------------
----------------------------------------------------------------------------------
as
SET NOCOUNT ON 
	   SELECT ID,NOMBRE, MARCA,MODELO,CAPACIDAD,PESO,CILINDROS,ACTIVO
	   FROM VEHICULO WITH(NOLOCK)
	   WHERE ID=@ID;
GO
/****** Object:  StoredProcedure [dbo].[spVEHICULOEd]    Script Date: 27/11/2019 10:20:32 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[spVEHICULOEd]
@IDV INT,
@NOMBRE NVARCHAR(50),
@MARCA NVARCHAR(50),
@MODELO NVARCHAR(50),
@CAPACIDAD NVARCHAR(50),
@PESO NVARCHAR(50),
@CILINDROS INT
----------------------------------------------------------------------------------
-- Procedimiento encargado de insertar sobre la tabla 
-- VEHICULO
-- Creado por: Jair Troche
-- Fecha: 26/11/2019
----------------------------------------------------------------------------------
--Resumen de actualizaciones
--| Actualizado por |  Fecha  | Descripcion de la actualizacion
----------------------------------------------------------------------------------
----------------------------------------------------------------------------------
as
SET NOCOUNT ON 
BEGIN TRY
       BEGIN TRAN
BEGIN
	   UPDATE VEHICULO SET NOMBRE=@NOMBRE,MARCA=@MARCA,MODELO=@MODELO,CAPACIDAD=@CAPACIDAD,PESO=@PESO,CILINDROS=@CILINDROS
	   WHERE ID=@IDV
END

COMMIT
       
END TRY
BEGIN CATCH
       
       IF @@TRANCOUNT > 0
             ROLLBACK 
       --print error_line()       
       DECLARE @ErrorMessage NVARCHAR(4000);
       DECLARE @ErrorSeverity bigINT;
       DECLARE @ErrorState bigINT;
       SELECT @ErrorMessage = ERROR_MESSAGE(),
       @ErrorSeverity = ERROR_SEVERITY(),
       @ErrorState = ERROR_STATE();
       IF @ErrorState = 0
             SET @ErrorState = 1 
       RAISERROR (@ErrorMessage, @ErrorSeverity, @ErrorState);
       
END CATCH
GO
/****** Object:  StoredProcedure [dbo].[spVEHICULOEl]    Script Date: 27/11/2019 10:20:32 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[spVEHICULOEl]
@IDV INT

----------------------------------------------------------------------------------
-- Procedimiento encargado de eliminar sobre la tabla 
-- VEHICULO
-- Creado por: Jair Troche
-- Fecha: 26/11/2019
----------------------------------------------------------------------------------
--Resumen de actualizaciones
--| Actualizado por |  Fecha  | Descripcion de la actualizacion
----------------------------------------------------------------------------------
----------------------------------------------------------------------------------
as
SET NOCOUNT ON 
BEGIN TRY
       BEGIN TRAN
BEGIN
	   UPDATE VEHICULO SET ACTIVO=0
	   WHERE ID=@IDV
END

COMMIT
       
END TRY
BEGIN CATCH
       
       IF @@TRANCOUNT > 0
             ROLLBACK 
       --print error_line()       
       DECLARE @ErrorMessage NVARCHAR(4000);
       DECLARE @ErrorSeverity bigINT;
       DECLARE @ErrorState bigINT;
       SELECT @ErrorMessage = ERROR_MESSAGE(),
       @ErrorSeverity = ERROR_SEVERITY(),
       @ErrorState = ERROR_STATE();
       IF @ErrorState = 0
             SET @ErrorState = 1 
       RAISERROR (@ErrorMessage, @ErrorSeverity, @ErrorState);
       
END CATCH
GO
/****** Object:  StoredProcedure [dbo].[spVEHICULOIn]    Script Date: 27/11/2019 10:20:32 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[spVEHICULOIn]
@IDV INT OUT,
@NOMBRE NVARCHAR(50),
@MARCA NVARCHAR(50),
@MODELO NVARCHAR(50),
@CAPACIDAD NVARCHAR(50),
@PESO NVARCHAR(50),
@CILINDROS INT
----------------------------------------------------------------------------------
-- Procedimiento encargado de insertar sobre la tabla 
-- VEHICULO
-- Creado por: Jair Troche
-- Fecha: 26/11/2019
----------------------------------------------------------------------------------
--Resumen de actualizaciones
--| Actualizado por |  Fecha  | Descripcion de la actualizacion
----------------------------------------------------------------------------------
----------------------------------------------------------------------------------
as
SET NOCOUNT ON 
BEGIN TRY
       BEGIN TRAN
BEGIN
	   INSERT INTO VEHICULO(NOMBRE,MARCA,MODELO,CAPACIDAD,PESO,CILINDROS,ACTIVO)VALUES(@NOMBRE,@MARCA,@MODELO,@CAPACIDAD,@PESO,@CILINDROS,1);
	   SET @IDV = SCOPE_IDENTITY();
END

COMMIT
       
END TRY
BEGIN CATCH
       
       IF @@TRANCOUNT > 0
             ROLLBACK 
       --print error_line()       
       DECLARE @ErrorMessage NVARCHAR(4000);
       DECLARE @ErrorSeverity bigINT;
       DECLARE @ErrorState bigINT;
       SELECT @ErrorMessage = ERROR_MESSAGE(),
       @ErrorSeverity = ERROR_SEVERITY(),
       @ErrorState = ERROR_STATE();
       IF @ErrorState = 0
             SET @ErrorState = 1 
       RAISERROR (@ErrorMessage, @ErrorSeverity, @ErrorState);
       
END CATCH
GO

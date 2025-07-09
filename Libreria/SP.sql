--ACEITE LUBRICANTE
CREATE  PROCEDURE [dbo].[SP_ACEITE_LUBRICANTE_Q1]
AS
BEGIN
	SELECT [identity], name         
	FROM ACEITE_LUBRICANTE;
END 

 -- COMPONENTES
CREATE PROCEDURE [dbo].[SP_COMPONENTE_Q1]
    @group VARCHAR(10) = NULL,
    @Equipos VARCHAR(10) = NULL
AS
BEGIN
    SELECT 
        [identity], 
        equipo, 
        descripcion, 
        nivel_servicio, 
        aceite
    FROM COMPONENTE
    WHERE 
        (
            @group IS NULL
            OR GROUP_ID = @group
        )
        AND (
            @Equipos IS NULL
            OR EQUIPO = @Equipos
        )
		AND
		REMOVEFLAG = 'F'
    ORDER BY [identity];
END

--EQUIPO
CREATE PROCEDURE [dbo].[SP_Equipo_Q1]
@ListFlota VARCHAR(10)=NULL
AS
BEGIN
	SELECT 
		P.phrase_text AS nome_equipo,
		E.[identity],
		E.estado,
		E.tipo_equipo,
		E.codigo_interno,
		E.flota
	FROM 
		equipo E
	JOIN 
		phrase P ON P.phrase_id = E.tipo_equipo AND P.phrase_type = 'TIPO_EQUIP'
	WHERE 
		E.removeflag = 'F'
		AND E.flota = @ListFlota
	ORDER BY 
		E.[identity];
END

--FLOTA
CREATE PROCEDURE [dbo].[SP_FLOTA_AREA_Q1]
    @group_id VARCHAR(10) = NULL,
    @id_customer VARCHAR(10) = NULL
AS
BEGIN
    SET NOCOUNT ON;
	if @group_id IS  NULL
	BEGIN
		select [identity], id_customer, nombre_flota FROM FLOTA_AREA 
                                    WHERE  id_customer = @id_customer;
	END
	ELSE
	BEGIN
		select [identity], id_customer, nombre_flota FROM FLOTA_AREA 
                                    WHERE  group_id = @group_id AND id_customer = @id_customer;
	END
END

--NIVEL SERVICIOS
CREATE PROCEDURE [dbo].[SP_NivelServicio_Q1]
    @CUSTOMER NVARCHAR(10)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        p.phrase_text AS nome_nivel_servicio,
        c1.[identity],
        c1.customer,
        c1.nivel_servicio
    FROM CLIENT_SERVICIO c1
    INNER JOIN phrase p
        ON p.phrase_id = c1.nivel_servicio
        AND p.phrase_type = 'niv_serv'
    WHERE c1.customer = @CUSTOMER;
END
--
CREATE PROCEDURE [dbo].[SP_GROUPLINK_Q1]
@UserLogin VARCHAR(10)
AS
BEGIN
    SET NOCOUNT ON;
    SELECT 
        GROUP_ID
    FROM 
        GROUPLINK GR
    WHERE 
        OPERATOR_ID = @UserLogin;
END

--
CREATE PROCEDURE [dbo].[SP_JOB_HEADER_Q1]
    @jobName NVARCHAR(20) = NULL
AS
BEGIN
    SET NOCOUNT ON;
    
    SELECT JOB_NAME, JOB_STATUS, CLIENT_FACTURA 
    FROM JOB_HEADER 
    WHERE @jobName IS NULL OR job_name = @jobName;
END

--
CREATE PROCEDURE [dbo].[SP_ROLE_ASSIGNMENT_Q1]
    @UserLogin VARCHAR(10)
AS
BEGIN
    SET NOCOUNT ON;
    
    -- Verificar si el usuario tiene el rol SECURITY_OVERRIDE
    SELECT 
        *
    FROM 
        ROLE_ASSIGNMENT RA
    WHERE 
        RA.ROLE_ID = 'SECURITY_OVERRIDE' 
        AND RA.OPERATOR_ID = @UserLogin;
END
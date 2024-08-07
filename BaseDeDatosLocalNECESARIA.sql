/*==============================================================*/
/* DBMS name:      Microsoft SQL Server 2008                    */
/* Created on:     2/25/2024 8:43:58 PM                         */
/*==============================================================*/
USE MASTER
GO

IF EXISTS (SELECT 1 FROM sys.databases WHERE name = 'REQUERIMIENTOS')
BEGIN
    DECLARE @DatabaseName nvarchar(50)
	SET @DatabaseName = 'REQUERIMIENTOS'

	DECLARE @SQL varchar(max)

	SELECT @SQL = COALESCE(@SQL,'') + 'Kill ' + Convert(varchar, SPId) + ';'
	FROM MASTER..SysProcesses
	WHERE DBId = DB_ID(@DatabaseName) AND SPId <> @@SPId

	--SELECT @SQL 
	EXEC(@SQL)
END
ELSE
	CREATE DATABASE REQUERIMIENTOS;

USE REQUERIMIENTOS
GO

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('EXAMENES') and o.name = 'FK_EXAMENES_RELATIONS_TIPOSEXA')
alter table EXAMENES
   drop constraint FK_EXAMENES_RELATIONS_TIPOSEXA
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('EXAMENES') and o.name = 'FK_EXAMENES_RELATIONS_PEDIDOS')
alter table EXAMENES
   drop constraint FK_EXAMENES_RELATIONS_PEDIDOS
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('EXAMEN_PARAMETRO') and o.name = 'FK_EXAMEN_P_EXAMEN_PA_PARAMETR')
alter table EXAMEN_PARAMETRO
   drop constraint FK_EXAMEN_P_EXAMEN_PA_PARAMETR
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('EXAMEN_PARAMETRO') and o.name = 'FK_EXAMEN_P_EXAMEN_PA_EXAMENES')
alter table EXAMEN_PARAMETRO
   drop constraint FK_EXAMEN_P_EXAMEN_PA_EXAMENES
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('FACTURA') and o.name = 'FK_FACTURA_RELATIONS_VENTAS')
alter table FACTURA
   drop constraint FK_FACTURA_RELATIONS_VENTAS
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('INFORMESRESULTADO') and o.name = 'FK_INFORMES_RELATIONS_PACIENTE')
alter table INFORMESRESULTADO
   drop constraint FK_INFORMES_RELATIONS_PACIENTE
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('INFORMESRESULTADO') and o.name = 'FK_INFORMES_RELATIONS_EXAMENES')
alter table INFORMESRESULTADO
   drop constraint FK_INFORMES_RELATIONS_EXAMENES
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('PEDIDOS') and o.name = 'FK_PEDIDOS_RELATIONS_PACIENTE')
alter table PEDIDOS
   drop constraint FK_PEDIDOS_RELATIONS_PACIENTE
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('TIPOEXAMEN_PARAMETRO') and o.name = 'FK_TIPOEXAM_TIPOEXAME_TIPOSEXA')
alter table TIPOEXAMEN_PARAMETRO
   drop constraint FK_TIPOEXAM_TIPOEXAME_TIPOSEXA
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('TIPOEXAMEN_PARAMETRO') and o.name = 'FK_TIPOEXAM_TIPOEXAME_PARAMETR')
alter table TIPOEXAMEN_PARAMETRO
   drop constraint FK_TIPOEXAM_TIPOEXAME_PARAMETR
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('VENTAS') and o.name = 'FK_VENTAS_RELATIONS_PEDIDOS')
alter table VENTAS
   drop constraint FK_VENTAS_RELATIONS_PEDIDOS
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('VENTAS') and o.name = 'FK_VENTAS_RELATIONS_PACIENTE')
alter table VENTAS
   drop constraint FK_VENTAS_RELATIONS_PACIENTE
go

if exists (select 1
            from  sysobjects
           where  id = object_id('EXAMENES')
            and   type = 'U')
   drop table EXAMENES
go

if exists (select 1
            from  sysobjects
           where  id = object_id('EXAMEN_PARAMETRO')
            and   type = 'U')
   drop table EXAMEN_PARAMETRO
go

if exists (select 1
            from  sysobjects
           where  id = object_id('FACTURA')
            and   type = 'U')
   drop table FACTURA
go

if exists (select 1
            from  sysobjects
           where  id = object_id('INFORMESRESULTADO')
            and   type = 'U')
   drop table INFORMESRESULTADO
go

if exists (select 1
            from  sysobjects
           where  id = object_id('INSTRUMENTOS')
            and   type = 'U')
   drop table INSTRUMENTOS
go

if exists (select 1
            from  sysobjects
           where  id = object_id('PACIENTES')
            and   type = 'U')
   drop table PACIENTES
go

if exists (select 1
            from  sysobjects
           where  id = object_id('PARAMETROSTIPOEXAMEN')
            and   type = 'U')
   drop table PARAMETROSTIPOEXAMEN
go

if exists (select 1
            from  sysobjects
           where  id = object_id('PEDIDOS')
            and   type = 'U')
   drop table PEDIDOS
go

if exists (select 1
            from  sysobjects
           where  id = object_id('REACTIVOS')
            and   type = 'U')
   drop table REACTIVOS
go

if exists (select 1
            from  sysobjects
           where  id = object_id('TIPOEXAMEN_PARAMETRO')
            and   type = 'U')
   drop table TIPOEXAMEN_PARAMETRO
go

if exists (select 1
            from  sysobjects
           where  id = object_id('TIPOSEXAMEN')
            and   type = 'U')
   drop table TIPOSEXAMEN
go

if exists (select 1
            from  sysobjects
           where  id = object_id('USERS')
            and   type = 'U')
   drop table USERS
go

if exists (select 1
            from  sysobjects
           where  id = object_id('VENTAS')
            and   type = 'U')
   drop table VENTAS
go

if exists (select 1
            from  sysobjects
           where  id = object_id('IVA')
            and   type = 'U')
   drop table IVA
go

/*==============================================================*/
/* Table: IVA                                              */
/*==============================================================*/
create table IVA (
   IDIVA             int              identity,
   VALORIVA         int              not null,
   FECHAIVA             date              not null,
   constraint PK_IVA primary key nonclustered (IDIVA)
)
go


/*==============================================================*/
/* Table: EXAMENES                                              */
/*==============================================================*/
create table EXAMENES (
   IDEXAMEN             int              identity,
   IDTIPOEXAMEN         int              not null,
   IDPEDIDO             int              not null,
   ESTADOEXAMEN         varchar(10)            default 'Pendiente',
   constraint PK_EXAMENES primary key nonclustered (IDEXAMEN)
)
go

/*==============================================================*/
/* Table: EXAMEN_PARAMETRO                                      */
/*==============================================================*/
create table EXAMEN_PARAMETRO (
   IDEXAMEN             int              not null,
   IDPARAMETRO          int              not null,
   RESULTADOPARAMETRO   varchar(15)          not null,
   constraint PK_EXAMEN_PARAMETRO primary key nonclustered (IDEXAMEN, IDPARAMETRO)
)
go

/*==============================================================*/
/* Table: FACTURA                                               */
/*==============================================================*/
create table FACTURA (
   IDFACTURA            int              identity,
   IDVENTA              int              not null,
   constraint PK_FACTURA primary key nonclustered (IDFACTURA)
)
go

/*==============================================================*/
/* Table: INFORMESRESULTADO                                     */
/*==============================================================*/
create table INFORMESRESULTADO (
   IDINFORME            int              identity,
   CIPACIENTE           char(10)             not null,
   IDEXAMEN             int              not null,
   ARCHIVOINFORME       varbinary(8000)      not null,
   FECHAINFORME         datetime             not null,
   constraint PK_INFORMESRESULTADO primary key nonclustered (IDINFORME)
)
go

/*==============================================================*/
/* Table: INSTRUMENTOS                                          */
/*==============================================================*/
create table INSTRUMENTOS (
   IDINSTRUMENTO        int              identity,
   NOMBREINSTRUMENTO    varchar(30)          not null,
   CANTIDADINSTRUMENTO  int                  not null,
   constraint PK_INSTRUMENTOS primary key nonclustered (IDINSTRUMENTO)
)
go

/*==============================================================*/
/* Table: PACIENTES                                             */
/*==============================================================*/
create table PACIENTES (
   CIPACIENTE           char(10)             not null,
   NOMBRESPACIENTE      varchar(30)          not null,
   APELLIDOSPACIENTE    varchar(30)          not null,
   TELEFONOPACIENTE     char(10)             not null,
   CORREOPACIENTE       varchar(129)            not null,
   DIRECCIONPACIENTE    varchar(120)         not null,
   FECHANACPACIENTE		date				 not null,
   constraint PK_PACIENTES primary key nonclustered (CIPACIENTE)
)
go

/*==============================================================*/
/* Table: PARAMETROSTIPOEXAMEN                                  */
/*==============================================================*/
create table PARAMETROSTIPOEXAMEN (
   IDPARAMETRO          int              identity,
   NOMBREPARAMETRO      varchar(30)          not null,
   MINPARAMETRO         float(6)             null,
   MAXPARAMETRO         float(6)             null,
   UNIDADPARAMETRO      varchar(10)          null,
   constraint PK_PARAMETROSTIPOEXAMEN primary key nonclustered (IDPARAMETRO)
)
go

/*==============================================================*/
/* Table: PEDIDOS                                               */
/*==============================================================*/
create table PEDIDOS (
   IDPEDIDO             int					identity,
   CIPACIENTE           char(10)             not null,
   ESTADOPEDIDO         varchar(10)            default 'Pendiente',
   DOCTORPEDIDO			varchar(20)				default 'N/A',
   constraint PK_PEDIDOS primary key nonclustered (IDPEDIDO)
)
go

/*==============================================================*/
/* Table: REACTIVOS                                             */
/*==============================================================*/
create table REACTIVOS (
   IDREACTIVO           int              identity,
   NOMBREREACTIVO       varchar(30)          not null,
   CANTIDADREACTIVO     int                  null,
   FECHACADUCIDAD       datetime             null,
   constraint PK_REACTIVOS primary key nonclustered (IDREACTIVO)
)
go

/*==============================================================*/
/* Table: TIPOEXAMEN_PARAMETRO                                  */
/*==============================================================*/
create table TIPOEXAMEN_PARAMETRO (
   IDTIPOEXAMEN         int              not null,
   IDPARAMETRO          int              not null,
   constraint PK_TIPOEXAMEN_PARAMETRO primary key nonclustered (IDTIPOEXAMEN, IDPARAMETRO)
)
go

/*==============================================================*/
/* Table: TIPOSEXAMEN                                           */
/*==============================================================*/
create table TIPOSEXAMEN (
   IDTIPOEXAMEN         int              identity,
   NOMBRETIPOEXAMEN     varchar(30)          not null,
   COSTOTIPOEXAMEN		money				not null,
   constraint PK_TIPOSEXAMEN primary key nonclustered (IDTIPOEXAMEN)
)
go

/*==============================================================*/
/* Table: USERS                                                 */
/*==============================================================*/
create table USERS (
   IDUSER               int              identity,
   NOMBREUSER           varchar(15)          not null,
   CLAVEUSER            varchar(15)          not null,
   TIPOUSER             varchar(24)            not null,
   constraint PK_USERS primary key nonclustered (IDUSER)
)
go

/*==============================================================*/
/* Table: VENTAS                                                */
/*==============================================================*/
create table VENTAS (
   IDVENTA              int              identity,
   IDPEDIDO             int              not null,
   CIPACIENTE           char(10)             not null,
   PRECIOTOTALVENTA		money				not null,
   PRECIOFINALVENTA     money                not null,
   FECHAVENTA			date			default CONVERT(DATE, GETDATE()),
   constraint PK_VENTAS primary key nonclustered (IDVENTA)
)
go

alter table EXAMENES
   add constraint FK_EXAMENES_RELATIONS_TIPOSEXA foreign key (IDTIPOEXAMEN)
      references TIPOSEXAMEN (IDTIPOEXAMEN)
go

alter table EXAMENES
   add constraint FK_EXAMENES_RELATIONS_PEDIDOS foreign key (IDPEDIDO)
      references PEDIDOS (IDPEDIDO)
go

alter table EXAMEN_PARAMETRO
   add constraint FK_EXAMEN_P_EXAMEN_PA_PARAMETR foreign key (IDPARAMETRO)
      references PARAMETROSTIPOEXAMEN (IDPARAMETRO)
go

alter table EXAMEN_PARAMETRO
   add constraint FK_EXAMEN_P_EXAMEN_PA_EXAMENES foreign key (IDEXAMEN)
      references EXAMENES (IDEXAMEN)
go

alter table FACTURA
   add constraint FK_FACTURA_RELATIONS_VENTAS foreign key (IDVENTA)
      references VENTAS (IDVENTA)
go

alter table INFORMESRESULTADO
   add constraint FK_INFORMES_RELATIONS_PACIENTE foreign key (CIPACIENTE)
      references PACIENTES (CIPACIENTE)
go

alter table INFORMESRESULTADO
   add constraint FK_INFORMES_RELATIONS_EXAMENES foreign key (IDEXAMEN)
      references EXAMENES (IDEXAMEN)
go

alter table PEDIDOS
   add constraint FK_PEDIDOS_RELATIONS_PACIENTE foreign key (CIPACIENTE)
      references PACIENTES (CIPACIENTE)
go

alter table TIPOEXAMEN_PARAMETRO
   add constraint FK_TIPOEXAM_TIPOEXAME_TIPOSEXA foreign key (IDTIPOEXAMEN)
      references TIPOSEXAMEN (IDTIPOEXAMEN)
go

alter table TIPOEXAMEN_PARAMETRO
   add constraint FK_TIPOEXAM_TIPOEXAME_PARAMETR foreign key (IDPARAMETRO)
      references PARAMETROSTIPOEXAMEN (IDPARAMETRO)
go

alter table VENTAS
   add constraint FK_VENTAS_RELATIONS_PEDIDOS foreign key (IDPEDIDO)
      references PEDIDOS (IDPEDIDO)
go

alter table VENTAS
   add constraint FK_VENTAS_RELATIONS_PACIENTE foreign key (CIPACIENTE)
      references PACIENTES (CIPACIENTE)
go

delete from USERS


use Requerimientos
insert into USERS (NOMBREUSER, CLAVEUSER, TIPOUSER)
values ('admin', 'admin', 'Jefe de laboratorio')

select * from USERS

insert into IVA (VALORIVA, FECHAIVA)
values (12, CONVERT(DATE, GETDATE()))

SELECT * FROM IVA

insert into TIPOSEXAMEN(NOMBRETIPOEXAMEN, COSTOTIPOEXAMEN)
VALUES ('Analisis de Orina', 5)
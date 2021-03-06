USE [master]
GO
/****** Object:  Database [BDBill]    Script Date: 15/11/2018 12:20:27 ******/
CREATE DATABASE [BDBill]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'BDBill', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.BDBILL\MSSQL\DATA\BDBill.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'BDBill_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.BDBILL\MSSQL\DATA\BDBill_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [BDBill] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BDBill].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BDBill] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BDBill] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BDBill] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BDBill] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BDBill] SET ARITHABORT OFF 
GO
ALTER DATABASE [BDBill] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [BDBill] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BDBill] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BDBill] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BDBill] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [BDBill] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BDBill] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BDBill] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BDBill] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BDBill] SET  DISABLE_BROKER 
GO
ALTER DATABASE [BDBill] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BDBill] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [BDBill] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [BDBill] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [BDBill] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BDBill] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [BDBill] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [BDBill] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [BDBill] SET  MULTI_USER 
GO
ALTER DATABASE [BDBill] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [BDBill] SET DB_CHAINING OFF 
GO
ALTER DATABASE [BDBill] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [BDBill] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [BDBill] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [BDBill] SET QUERY_STORE = OFF
GO
USE [BDBill]
GO
ALTER DATABASE SCOPED CONFIGURATION SET IDENTITY_CACHE = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
USE [BDBill]
GO
/****** Object:  Table [dbo].[Asistentes]    Script Date: 15/11/2018 12:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Asistentes](
	[id_asis] [int] NOT NULL,
	[nombre_asis] [nvarchar](200) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Infante]    Script Date: 15/11/2018 12:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Infante](
	[num_hist_cli_bb] [nvarchar](30) NOT NULL,
	[nom_bb] [nvarchar](150) NOT NULL,
	[ape_bb] [nvarchar](150) NOT NULL,
	[fec_bb] [date] NOT NULL,
	[hora_bb] [time](7) NOT NULL,
	[sexo_bb] [nvarchar](1) NOT NULL,
	[lugar_bb] [nvarchar](200) NOT NULL,
	[id_exa_gen] [int] NULL,
	[id_exa_fis] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Madre]    Script Date: 15/11/2018 12:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Madre](
	[id_mad] [int] NULL,
	[nom_mad] [nvarchar](150) NOT NULL,
	[ape_mad] [nvarchar](150) NOT NULL,
	[edad_mad] [int] NOT NULL,
	[sangre_mad] [nvarchar](20) NOT NULL,
	[factor_mad] [nvarchar](300) NOT NULL,
	[enf_mad] [nvarchar](200) NULL,
	[id_exa_mad] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Persona]    Script Date: 15/11/2018 12:20:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Persona](
	[id_per] [int] NOT NULL,
	[nom_per] [nvarchar](150) NOT NULL,
	[ape_per] [nvarchar](150) NOT NULL,
	[email_per] [nvarchar](200) NULL,
	[fec_per] [date] NULL,
	[sex_per] [nvarchar](1) NULL,
	[cel_per] [int] NULL,
	[log_per] [nvarchar](100) NULL,
	[pas_per] [nvarchar](124) NULL,
	[id_tipo_per] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Salida]    Script Date: 15/11/2018 12:20:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Salida](
	[id_salida] [int] NOT NULL,
	[obs_concl_salida] [nvarchar](500) NULL,
	[destino_salida] [nvarchar](150) NOT NULL,
	[num_cnv_salida] [nvarchar](50) NOT NULL,
	[fec_salida] [date] NULL,
	[hora_salida] [time](7) NULL,
	[id_asis] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TipoPersona]    Script Date: 15/11/2018 12:20:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoPersona](
	[id_tipo_per] [int] NOT NULL,
	[desc_tipo_per] [nvarchar](100) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[AsistentesEliminar]    Script Date: 15/11/2018 12:20:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure[dbo].[AsistentesEliminar]
(
	@id_asis int
)
as
begin
	delete from Asistentes where id_asis=@id_asis
End
GO
/****** Object:  StoredProcedure [dbo].[AsistentesInsertar]    Script Date: 15/11/2018 12:20:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[AsistentesInsertar]
	@id_asis int,
	@nombre_asis nvarchar(200)
	as
	insert into Asistentes(id_asis, nombre_asis)
	values (@id_asis, @nombre_asis);
GO
/****** Object:  StoredProcedure [dbo].[AsistentesListar]    Script Date: 15/11/2018 12:20:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure[dbo].[AsistentesListar]
as
begin
select * from Asistentes
End
GO
/****** Object:  StoredProcedure [dbo].[InfanteEliminar]    Script Date: 15/11/2018 12:20:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure[dbo].[InfanteEliminar]
(
	@id_bb nvarchar(30)
)
as
begin
	delete from Infante where num_hist_cli_bb=@id_bb
End
GO
/****** Object:  StoredProcedure [dbo].[InfanteInsertar]    Script Date: 15/11/2018 12:20:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[InfanteInsertar]
	@num_hist_cli_bb nvarchar(30),
	@nom_bb nvarchar(150),
	@ape_bb nvarchar(150),
	@fec_bb date,
	@hora_bb time(7),
	@sexo_bb nvarchar(1),
	@lugar_bb nvarchar(200),
	@id_exa_gen int,
	@id_exa_fis int
	as
	insert into Infante(num_hist_cli_bb, nom_bb, ape_bb, fec_bb, hora_bb, sexo_bb, lugar_bb, id_exa_gen, id_exa_fis)
	values (@num_hist_cli_bb, @nom_bb, @ape_bb, @fec_bb, @hora_bb, @sexo_bb, @lugar_bb, @id_exa_gen ,@id_exa_fis);
GO
/****** Object:  StoredProcedure [dbo].[InfanteListar]    Script Date: 15/11/2018 12:20:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure[dbo].[InfanteListar]
as
begin
select * from Infante
End
GO
/****** Object:  StoredProcedure [dbo].[MadreEliminar]    Script Date: 15/11/2018 12:20:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure[dbo].[MadreEliminar]
(
	@id_mad int
)
as
begin
	delete from Madre where id_mad=@id_mad
End
GO
/****** Object:  StoredProcedure [dbo].[MadreInsertar]    Script Date: 15/11/2018 12:20:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[MadreInsertar]
	@id_mad int,
	@nom_mad nvarchar(150),
	@ape_mad nvarchar(150),
	@edad_mad int,
	@sangre_mad nvarchar(20),
	@factor_mad nvarchar(300),
	@enf_mad nvarchar(200),
	@id_exa_mad int
	as
	insert into Madre(id_mad, nom_mad, ape_mad, edad_mad, sangre_mad, factor_mad, enf_mad, id_exa_mad)
	values (@id_mad, @nom_mad, @ape_mad, @edad_mad, @sangre_mad, @factor_mad, @enf_mad, @id_exa_mad);
GO
/****** Object:  StoredProcedure [dbo].[MadreListar]    Script Date: 15/11/2018 12:20:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure[dbo].[MadreListar]
as
begin
select * from Madre
End
GO
/****** Object:  StoredProcedure [dbo].[PersonaEliminar]    Script Date: 15/11/2018 12:20:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure[dbo].[PersonaEliminar]
(
	@id_per int
)
as
begin
	delete from Persona where id_per=@id_per
End
GO
/****** Object:  StoredProcedure [dbo].[PersonaInsertar]    Script Date: 15/11/2018 12:20:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[PersonaInsertar]
	@id_per int,
	@nom_per nvarchar(150),
	@ape_per nvarchar(150),
	@email_per nvarchar(200),
	@fec_per date,
	@sex_per nvarchar(1),
	@cel_per int,
	@log_per nvarchar(100),
	@pas_per nvarchar(124),
	@id_tipo_per int
	as
	insert into Persona(id_per, nom_per, ape_per, email_per, fec_per, sex_per, cel_per, log_per, pas_per, id_tipo_per)
	values (@id_per, @nom_per, @ape_per, @email_per, @fec_per, @sex_per, @cel_per, @log_per, @pas_per, @id_tipo_per);
GO
/****** Object:  StoredProcedure [dbo].[PersonaListar]    Script Date: 15/11/2018 12:20:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure[dbo].[PersonaListar]
as
begin
select * from Persona
End
GO
/****** Object:  StoredProcedure [dbo].[SalidaEliminar]    Script Date: 15/11/2018 12:20:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure[dbo].[SalidaEliminar]
(
	@id_salida int
)
as
begin
	delete from Salida where id_salida=@id_salida
End
GO
/****** Object:  StoredProcedure [dbo].[SalidaListar]    Script Date: 15/11/2018 12:20:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure[dbo].[SalidaListar]
as
begin
select * from Salida
End
GO
/****** Object:  StoredProcedure [dbo].[TipoPersonaEliminar]    Script Date: 15/11/2018 12:20:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure[dbo].[TipoPersonaEliminar]
(
	@id_tipo_per int
)
as
begin
	delete from TipoPersona where id_tipo_per=@id_tipo_per
End
GO
/****** Object:  StoredProcedure [dbo].[TipoPersonaListar]    Script Date: 15/11/2018 12:20:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure[dbo].[TipoPersonaListar]
as
begin
select * from TipoPersona
End
GO
USE [master]
GO
ALTER DATABASE [BDBill] SET  READ_WRITE 
GO

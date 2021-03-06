USE [master]
GO
/****** Object:  Database [sistemaUsuarios]    Script Date: 13-10-2021 11:02:09 ******/
CREATE DATABASE [sistemaUsuarios]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'sistemaUsuarios', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\sistemaUsuarios.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'sistemaUsuarios_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\sistemaUsuarios_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [sistemaUsuarios] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [sistemaUsuarios].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [sistemaUsuarios] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [sistemaUsuarios] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [sistemaUsuarios] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [sistemaUsuarios] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [sistemaUsuarios] SET ARITHABORT OFF 
GO
ALTER DATABASE [sistemaUsuarios] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [sistemaUsuarios] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [sistemaUsuarios] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [sistemaUsuarios] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [sistemaUsuarios] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [sistemaUsuarios] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [sistemaUsuarios] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [sistemaUsuarios] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [sistemaUsuarios] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [sistemaUsuarios] SET  DISABLE_BROKER 
GO
ALTER DATABASE [sistemaUsuarios] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [sistemaUsuarios] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [sistemaUsuarios] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [sistemaUsuarios] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [sistemaUsuarios] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [sistemaUsuarios] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [sistemaUsuarios] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [sistemaUsuarios] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [sistemaUsuarios] SET  MULTI_USER 
GO
ALTER DATABASE [sistemaUsuarios] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [sistemaUsuarios] SET DB_CHAINING OFF 
GO
ALTER DATABASE [sistemaUsuarios] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [sistemaUsuarios] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [sistemaUsuarios] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [sistemaUsuarios] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [sistemaUsuarios] SET QUERY_STORE = OFF
GO
USE [sistemaUsuarios]
GO
/****** Object:  Table [dbo].[cuentas]    Script Date: 13-10-2021 11:02:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[cuentas](
	[codigoUsuario] [nvarchar](64) NOT NULL,
	[codigoCuenta] [nvarchar](64) NOT NULL,
	[descripcionCuenta] [nvarchar](64) NOT NULL,
 CONSTRAINT [PK_cuentas_1] PRIMARY KEY CLUSTERED 
(
	[codigoUsuario] ASC,
	[codigoCuenta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[logs]    Script Date: 13-10-2021 11:02:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[logs](
	[codigoUsuario] [nvarchar](64) NOT NULL,
	[codigoCuenta] [nvarchar](64) NOT NULL,
	[logID] [int] IDENTITY(1,1) NOT NULL,
	[fecha] [timestamp] NOT NULL,
	[mensaje] [text] NOT NULL,
 CONSTRAINT [PK_logs] PRIMARY KEY CLUSTERED 
(
	[codigoUsuario] ASC,
	[codigoCuenta] ASC,
	[logID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[transacciones]    Script Date: 13-10-2021 11:02:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[transacciones](
	[codigoUsuario] [nvarchar](64) NOT NULL,
	[codigoCuenta] [nvarchar](64) NOT NULL,
	[lineaTransaccion] [int] IDENTITY(1,1) NOT NULL,
	[monto] [float] NOT NULL,
 CONSTRAINT [PK_transacciones] PRIMARY KEY CLUSTERED 
(
	[codigoUsuario] ASC,
	[codigoCuenta] ASC,
	[lineaTransaccion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[usuarios]    Script Date: 13-10-2021 11:02:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[usuarios](
	[codigoUsuario] [nvarchar](64) NOT NULL,
	[email] [nvarchar](64) NOT NULL,
	[password] [nvarchar](64) NOT NULL,
	[Nombre] [nvarchar](64) NOT NULL,
	[Apellido] [nvarchar](64) NOT NULL,
 CONSTRAINT [PK_usuarios] PRIMARY KEY CLUSTERED 
(
	[codigoUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[cuentas] ([codigoUsuario], [codigoCuenta], [descripcionCuenta]) VALUES (N'12345678-9', N'12345678', N'Not Cuenta RUT')
GO
SET IDENTITY_INSERT [dbo].[transacciones] ON 

INSERT [dbo].[transacciones] ([codigoUsuario], [codigoCuenta], [lineaTransaccion], [monto]) VALUES (N'12345678-9', N'12345678', 1012, 10000)
INSERT [dbo].[transacciones] ([codigoUsuario], [codigoCuenta], [lineaTransaccion], [monto]) VALUES (N'12345678-9', N'12345678', 1013, 15000)
INSERT [dbo].[transacciones] ([codigoUsuario], [codigoCuenta], [lineaTransaccion], [monto]) VALUES (N'12345678-9', N'12345678', 1014, 2500)
INSERT [dbo].[transacciones] ([codigoUsuario], [codigoCuenta], [lineaTransaccion], [monto]) VALUES (N'12345678-9', N'12345678', 1015, -5000)
INSERT [dbo].[transacciones] ([codigoUsuario], [codigoCuenta], [lineaTransaccion], [monto]) VALUES (N'12345678-9', N'12345678', 1016, -7000)
INSERT [dbo].[transacciones] ([codigoUsuario], [codigoCuenta], [lineaTransaccion], [monto]) VALUES (N'12345678-9', N'12345678', 1017, 23000)
SET IDENTITY_INSERT [dbo].[transacciones] OFF
GO
INSERT [dbo].[usuarios] ([codigoUsuario], [email], [password], [Nombre], [Apellido]) VALUES (N'12345678-9', N'kyron.meza@outlok.com', N'asdf1234', N'Kyron', N'Meza')
GO
ALTER TABLE [dbo].[cuentas]  WITH CHECK ADD  CONSTRAINT [FK_cuentas_usuarios] FOREIGN KEY([codigoUsuario])
REFERENCES [dbo].[usuarios] ([codigoUsuario])
GO
ALTER TABLE [dbo].[cuentas] CHECK CONSTRAINT [FK_cuentas_usuarios]
GO
ALTER TABLE [dbo].[logs]  WITH CHECK ADD  CONSTRAINT [FK_logs_cuentas] FOREIGN KEY([codigoUsuario], [codigoCuenta])
REFERENCES [dbo].[cuentas] ([codigoUsuario], [codigoCuenta])
GO
ALTER TABLE [dbo].[logs] CHECK CONSTRAINT [FK_logs_cuentas]
GO
ALTER TABLE [dbo].[transacciones]  WITH CHECK ADD  CONSTRAINT [FK_transacciones_cuentas1] FOREIGN KEY([codigoUsuario], [codigoCuenta])
REFERENCES [dbo].[cuentas] ([codigoUsuario], [codigoCuenta])
GO
ALTER TABLE [dbo].[transacciones] CHECK CONSTRAINT [FK_transacciones_cuentas1]
GO
USE [master]
GO
ALTER DATABASE [sistemaUsuarios] SET  READ_WRITE 
GO

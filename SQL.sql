USE [master]
GO

/****** Object:  Database [mmcrawler]    Script Date: 12/09/2012 21:31:49 ******/
CREATE DATABASE [mmcrawler] ON  PRIMARY 
( NAME = N'mmcrawler', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL10.SQLEXPRESS\MSSQL\DATA\mmcrawler.mdf' , SIZE = 28672KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'mmcrawler_log', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL10.SQLEXPRESS\MSSQL\DATA\mmcrawler_log.ldf' , SIZE = 1280KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO

ALTER DATABASE [mmcrawler] SET COMPATIBILITY_LEVEL = 100
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [mmcrawler].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [mmcrawler] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [mmcrawler] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [mmcrawler] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [mmcrawler] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [mmcrawler] SET ARITHABORT OFF 
GO

ALTER DATABASE [mmcrawler] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [mmcrawler] SET AUTO_CREATE_STATISTICS ON 
GO

ALTER DATABASE [mmcrawler] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [mmcrawler] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [mmcrawler] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [mmcrawler] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [mmcrawler] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [mmcrawler] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [mmcrawler] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [mmcrawler] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [mmcrawler] SET  DISABLE_BROKER 
GO

ALTER DATABASE [mmcrawler] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [mmcrawler] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [mmcrawler] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [mmcrawler] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [mmcrawler] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [mmcrawler] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [mmcrawler] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [mmcrawler] SET  READ_WRITE 
GO

ALTER DATABASE [mmcrawler] SET RECOVERY SIMPLE 
GO

ALTER DATABASE [mmcrawler] SET  MULTI_USER 
GO

ALTER DATABASE [mmcrawler] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [mmcrawler] SET DB_CHAINING OFF 
GO


USE [mmcrawler]
/****** Object:  Table [dbo].[StoredLink]    Script Date: 12/05/2012 17:35:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

GO
CREATE TABLE [dbo].[StoredLink](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Value] [nvarchar](max) NULL,
	[ParentId] [int] NULL,
 CONSTRAINT [PK_StoredLink] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
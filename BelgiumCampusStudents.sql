USE [master]
GO
/****** Object:  Database [BelgiumCampusStudents]    Script Date: 2021/10/10 14:20:47 ******/
CREATE DATABASE [BelgiumCampusStudents]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'BelgiumCampusStudents', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\BelgiumCampusStudents.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'BelgiumCampusStudents_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\BelgiumCampusStudents_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [BelgiumCampusStudents] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BelgiumCampusStudents].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BelgiumCampusStudents] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BelgiumCampusStudents] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BelgiumCampusStudents] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BelgiumCampusStudents] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BelgiumCampusStudents] SET ARITHABORT OFF 
GO
ALTER DATABASE [BelgiumCampusStudents] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [BelgiumCampusStudents] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BelgiumCampusStudents] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BelgiumCampusStudents] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BelgiumCampusStudents] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [BelgiumCampusStudents] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BelgiumCampusStudents] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BelgiumCampusStudents] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BelgiumCampusStudents] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BelgiumCampusStudents] SET  DISABLE_BROKER 
GO
ALTER DATABASE [BelgiumCampusStudents] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BelgiumCampusStudents] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [BelgiumCampusStudents] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [BelgiumCampusStudents] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [BelgiumCampusStudents] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BelgiumCampusStudents] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [BelgiumCampusStudents] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [BelgiumCampusStudents] SET RECOVERY FULL 
GO
ALTER DATABASE [BelgiumCampusStudents] SET  MULTI_USER 
GO
ALTER DATABASE [BelgiumCampusStudents] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [BelgiumCampusStudents] SET DB_CHAINING OFF 
GO
ALTER DATABASE [BelgiumCampusStudents] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [BelgiumCampusStudents] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [BelgiumCampusStudents] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [BelgiumCampusStudents] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'BelgiumCampusStudents', N'ON'
GO
ALTER DATABASE [BelgiumCampusStudents] SET QUERY_STORE = OFF
GO
USE [BelgiumCampusStudents]
GO
/****** Object:  Table [dbo].[Students]    Script Date: 2021/10/10 14:20:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Students](
	[StudentNumber] [int] NULL,
	[StudentName] [varchar](20) NULL,
	[Surname] [varchar](20) NULL,
	[Picture] [image] NULL,
	[DateofBirth] [date] NULL,
	[Gender] [varchar](10) NULL,
	[Phone] [varchar](15) NULL,
	[StudentAddress] [varchar](50) NULL,
	[ModuleCode] [varchar](10) NULL,
	[ModuleName] [varchar](20) NULL,
	[ModuleDescription] [varchar](100) NULL,
	[OnlineResource] [varchar](50) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
USE [master]
GO
ALTER DATABASE [BelgiumCampusStudents] SET  READ_WRITE 
GO

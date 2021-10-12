USE [master]
GO
/****** Object:  Database [BelgiumCampusStudents]    Script Date: 2021/10/12 01:14:48 ******/
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
/****** Object:  Table [dbo].[Module]    Script Date: 2021/10/12 01:14:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Module](
	[ModuleCode] [varchar](6) NOT NULL,
	[ModuleName] [varchar](20) NULL,
	[ModuleDescription] [varchar](50) NULL,
	[OnlineLink] [varchar](60) NULL,
PRIMARY KEY CLUSTERED 
(
	[ModuleCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Picture]    Script Date: 2021/10/12 01:14:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Picture](
	[PictureNo] [int] IDENTITY(100,15) NOT NULL,
	[StudentImage] [image] NULL,
PRIMARY KEY CLUSTERED 
(
	[PictureNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Student]    Script Date: 2021/10/12 01:14:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Student](
	[StudentID] [int] NOT NULL,
	[sName] [varchar](20) NULL,
	[sSurname] [varchar](20) NULL,
	[DateOfBirth] [datetime] NULL,
	[Gender] [varchar](10) NULL,
	[Phone] [varchar](10) NULL,
	[sAddress] [varchar](50) NULL,
	[PictureNo] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[StudentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StudentModule]    Script Date: 2021/10/12 01:14:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StudentModule](
	[StudentID] [int] NOT NULL,
	[ModuleCode] [varchar](6) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[StudentID] ASC,
	[ModuleCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Student]  WITH CHECK ADD FOREIGN KEY([PictureNo])
REFERENCES [dbo].[Picture] ([PictureNo])
GO
ALTER TABLE [dbo].[StudentModule]  WITH CHECK ADD FOREIGN KEY([ModuleCode])
REFERENCES [dbo].[Module] ([ModuleCode])
GO
ALTER TABLE [dbo].[StudentModule]  WITH CHECK ADD FOREIGN KEY([StudentID])
REFERENCES [dbo].[Student] ([StudentID])
GO
/****** Object:  StoredProcedure [dbo].[spDeleteStudents]    Script Date: 2021/10/12 01:14:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spDeleteStudents]
(
	@Id INT
)
AS 
BEGIN
	DELETE FROM Student 
	WHERE StudentID = @Id
	DELETE FROM Picture 	
	WHERE PictureNo = (SELECT PictureNo FROM Student WHERE StudentID = @Id)
END
GO
/****** Object:  StoredProcedure [dbo].[spSearchStudents]    Script Date: 2021/10/12 01:14:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spSearchStudents]
(
	@Id INT
)
AS 
BEGIN
	SELECT * FROM Student
	WHERE StudentID = @Id
END
GO
/****** Object:  StoredProcedure [dbo].[spUpdateStudents]    Script Date: 2021/10/12 01:14:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spUpdateStudents]
(
	@StudentID INT,
	@Name VARCHAR(20),
	@Surname VARCHAR(20),
	@dob VARCHAR(20),
	@Gender VARCHAR(20),
	@Phone VARCHAR(10),
	@Address VARCHAR(50),
	@ModuleCode VARCHAR(10),
	@ModuleName VARCHAR(20),
	@ModDescription VARCHAR(100),
	@OnlineLink VARCHAR(50)
)
AS 
BEGIN
 UPDATE Student
 SET StudentID = @StudentID, sName = @Name, sSurname = @Surname, DateOfBirth = @dob, Gender = @Gender, Phone = @Phone,sAddress =  @Address
 WHERE StudentID = @StudentID
 UPDATE Module 
 SET ModuleCode = @ModuleCode, ModuleName = @ModuleName, ModuleDescription = @ModDescription, OnlineLink = @OnlineLink
 FROM Module m
 INNER JOIN StudentModule sm
 ON m.ModuleCode = sm.ModuleCode
 INNER JOIN Student s
 ON s.StudentID = sm.StudentID
END
GO
USE [master]
GO
ALTER DATABASE [BelgiumCampusStudents] SET  READ_WRITE 
GO

USE [master]
GO
/****** Object:  Database [BookStore]    Script Date: 06/12/2021 21:58:31 ******/
CREATE DATABASE [BookStore]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'BookStore', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\BookStore.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'BookStore_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\BookStore_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [BookStore] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BookStore].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BookStore] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BookStore] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BookStore] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BookStore] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BookStore] SET ARITHABORT OFF 
GO
ALTER DATABASE [BookStore] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [BookStore] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BookStore] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BookStore] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BookStore] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [BookStore] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BookStore] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BookStore] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BookStore] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BookStore] SET  DISABLE_BROKER 
GO
ALTER DATABASE [BookStore] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BookStore] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [BookStore] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [BookStore] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [BookStore] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BookStore] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [BookStore] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [BookStore] SET RECOVERY FULL 
GO
ALTER DATABASE [BookStore] SET  MULTI_USER 
GO
ALTER DATABASE [BookStore] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [BookStore] SET DB_CHAINING OFF 
GO
ALTER DATABASE [BookStore] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [BookStore] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [BookStore] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [BookStore] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'BookStore', N'ON'
GO
ALTER DATABASE [BookStore] SET QUERY_STORE = OFF
GO
USE [BookStore]
GO
/****** Object:  User [bookStoreUser]    Script Date: 06/12/2021 21:58:31 ******/
CREATE USER [bookStoreUser] FOR LOGIN [bookStoreUser] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [bookStoreUser]
GO
/****** Object:  Table [dbo].[Autor]    Script Date: 06/12/2021 21:58:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Autor](
	[AutorID] [int] IDENTITY(1,1) NOT NULL,
	[ImeAutora] [nvarchar](50) NOT NULL,
	[PrezimeAutora] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Autor] PRIMARY KEY CLUSTERED 
(
	[AutorID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Knjiga]    Script Date: 06/12/2021 21:58:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Knjiga](
	[KnjigaID] [int] IDENTITY(1,1) NOT NULL,
	[NazivKnjige] [nvarchar](50) NOT NULL,
	[CenaKnjige] [int] NOT NULL,
	[ZanrID] [int] NOT NULL,
	[AutorID] [int] NOT NULL,
 CONSTRAINT [PK_Knjiga] PRIMARY KEY CLUSTERED 
(
	[KnjigaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Zanr]    Script Date: 06/12/2021 21:58:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Zanr](
	[ZanrID] [int] IDENTITY(1,1) NOT NULL,
	[ZanrNaziv] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Zanr] PRIMARY KEY CLUSTERED 
(
	[ZanrID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Autor] ON 

INSERT [dbo].[Autor] ([AutorID], [ImeAutora], [PrezimeAutora]) VALUES (1, N'Adam', N'Adam')
INSERT [dbo].[Autor] ([AutorID], [ImeAutora], [PrezimeAutora]) VALUES (2, N'Pera', N'Peric')
INSERT [dbo].[Autor] ([AutorID], [ImeAutora], [PrezimeAutora]) VALUES (3, N'Spenser', N'Papic')
SET IDENTITY_INSERT [dbo].[Autor] OFF
GO
SET IDENTITY_INSERT [dbo].[Knjiga] ON 

INSERT [dbo].[Knjiga] ([KnjigaID], [NazivKnjige], [CenaKnjige], [ZanrID], [AutorID]) VALUES (1, N'Knjiga1', 2000, 2, 1)
INSERT [dbo].[Knjiga] ([KnjigaID], [NazivKnjige], [CenaKnjige], [ZanrID], [AutorID]) VALUES (2, N'Knjiga2', 1500, 2, 1)
INSERT [dbo].[Knjiga] ([KnjigaID], [NazivKnjige], [CenaKnjige], [ZanrID], [AutorID]) VALUES (3, N'Knjiga3', 1000, 1, 3)
INSERT [dbo].[Knjiga] ([KnjigaID], [NazivKnjige], [CenaKnjige], [ZanrID], [AutorID]) VALUES (4, N'Knjiga4', 3000, 3, 2)
INSERT [dbo].[Knjiga] ([KnjigaID], [NazivKnjige], [CenaKnjige], [ZanrID], [AutorID]) VALUES (5, N'Knjiga5', 5000, 3, 2)
INSERT [dbo].[Knjiga] ([KnjigaID], [NazivKnjige], [CenaKnjige], [ZanrID], [AutorID]) VALUES (7, N'MM', 2404, 2, 3)
SET IDENTITY_INSERT [dbo].[Knjiga] OFF
GO
SET IDENTITY_INSERT [dbo].[Zanr] ON 

INSERT [dbo].[Zanr] ([ZanrID], [ZanrNaziv]) VALUES (1, N'Drama')
INSERT [dbo].[Zanr] ([ZanrID], [ZanrNaziv]) VALUES (2, N'Ljubavni')
INSERT [dbo].[Zanr] ([ZanrID], [ZanrNaziv]) VALUES (3, N'Spenser')
SET IDENTITY_INSERT [dbo].[Zanr] OFF
GO
ALTER TABLE [dbo].[Knjiga]  WITH CHECK ADD  CONSTRAINT [FK_Knjiga_Autor] FOREIGN KEY([AutorID])
REFERENCES [dbo].[Autor] ([AutorID])
GO
ALTER TABLE [dbo].[Knjiga] CHECK CONSTRAINT [FK_Knjiga_Autor]
GO
ALTER TABLE [dbo].[Knjiga]  WITH CHECK ADD  CONSTRAINT [FK_Knjiga_Zanr] FOREIGN KEY([ZanrID])
REFERENCES [dbo].[Zanr] ([ZanrID])
GO
ALTER TABLE [dbo].[Knjiga] CHECK CONSTRAINT [FK_Knjiga_Zanr]
GO
USE [master]
GO
ALTER DATABASE [BookStore] SET  READ_WRITE 
GO

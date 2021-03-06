USE [master]
GO
/****** Object:  Database [BidMe]    Script Date: 4/17/2017 4:11:06 PM ******/
CREATE DATABASE [BidMe]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'BidMe', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\DATA\BidMe.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'BidMe_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\DATA\BidMe_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [BidMe] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BidMe].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BidMe] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BidMe] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BidMe] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BidMe] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BidMe] SET ARITHABORT OFF 
GO
ALTER DATABASE [BidMe] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [BidMe] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BidMe] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BidMe] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BidMe] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [BidMe] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BidMe] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BidMe] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BidMe] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BidMe] SET  ENABLE_BROKER 
GO
ALTER DATABASE [BidMe] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BidMe] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [BidMe] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [BidMe] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [BidMe] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BidMe] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [BidMe] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [BidMe] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [BidMe] SET  MULTI_USER 
GO
ALTER DATABASE [BidMe] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [BidMe] SET DB_CHAINING OFF 
GO
ALTER DATABASE [BidMe] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [BidMe] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [BidMe] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [BidMe] SET QUERY_STORE = OFF
GO
USE [BidMe]
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
USE [BidMe]
GO
/****** Object:  Table [dbo].[Bids]    Script Date: 4/17/2017 4:11:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bids](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[listingId] [int] NULL,
	[UserId] [int] NULL,
	[price] [int] NULL,
	[DateTime] [datetime] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Category]    Script Date: 4/17/2017 4:11:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](100) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Listings]    Script Date: 4/17/2017 4:11:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Listings](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[ListingCode] [int] NULL,
	[title] [varchar](100) NULL,
	[CategoryId] [int] NULL,
	[SellerId] [int] NULL,
	[description] [varchar](1000) NULL,
	[price] [int] NULL,
	[location] [varchar](100) NULL,
	[AddedDate] [datetime] NULL,
	[LastDate] [datetime] NULL,
	[ImageUrl] [varchar](100) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Users]    Script Date: 4/17/2017 4:11:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NULL,
	[Email] [varchar](100) NULL,
	[Password] [varchar](100) NULL,
	[Location] [varchar](100) NULL,
	[UserType] [int] NULL
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Bids] ON 

INSERT [dbo].[Bids] ([id], [listingId], [UserId], [price], [DateTime]) VALUES (8, 5, 1, 100000, CAST(N'2017-04-01T20:10:14.000' AS DateTime))
INSERT [dbo].[Bids] ([id], [listingId], [UserId], [price], [DateTime]) VALUES (2, 1, 2, 40000, CAST(N'2017-03-29T19:11:51.000' AS DateTime))
INSERT [dbo].[Bids] ([id], [listingId], [UserId], [price], [DateTime]) VALUES (9, 6, 2, 5, CAST(N'2017-04-01T20:19:30.000' AS DateTime))
INSERT [dbo].[Bids] ([id], [listingId], [UserId], [price], [DateTime]) VALUES (7, 2, 2, 50000, CAST(N'2017-03-29T23:00:16.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[Bids] OFF
SET IDENTITY_INSERT [dbo].[Category] ON 

INSERT [dbo].[Category] ([id], [name]) VALUES (1, N'Electronics')
INSERT [dbo].[Category] ([id], [name]) VALUES (2, N'Clothings')
INSERT [dbo].[Category] ([id], [name]) VALUES (3, N'Toys')
INSERT [dbo].[Category] ([id], [name]) VALUES (4, N'Sports')
SET IDENTITY_INSERT [dbo].[Category] OFF
SET IDENTITY_INSERT [dbo].[Listings] ON 

INSERT [dbo].[Listings] ([id], [ListingCode], [title], [CategoryId], [SellerId], [description], [price], [location], [AddedDate], [LastDate], [ImageUrl]) VALUES (1, 101, N'HP Proobook', 1, 1, N'Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry''s standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.

', 50000, NULL, CAST(N'2017-03-29T16:16:56.000' AS DateTime), CAST(N'2017-03-28T00:00:00.000' AS DateTime), N'101hp_laptop9.jpg')
INSERT [dbo].[Listings] ([id], [ListingCode], [title], [CategoryId], [SellerId], [description], [price], [location], [AddedDate], [LastDate], [ImageUrl]) VALUES (2, 102, N'Dell XPS 13', 1, 1, N'Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry''s standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.

', 110000, NULL, CAST(N'2017-03-29T17:09:02.000' AS DateTime), CAST(N'2017-03-28T00:00:00.000' AS DateTime), N'102dell-xps-13-rose-gold.png')
INSERT [dbo].[Listings] ([id], [ListingCode], [title], [CategoryId], [SellerId], [description], [price], [location], [AddedDate], [LastDate], [ImageUrl]) VALUES (5, 103, N'Macbook Pro', 1, 1, N'i7 6th Generation.
8GB Ram', 110000, N'London', CAST(N'2017-04-01T20:09:56.000' AS DateTime), CAST(N'2018-01-01T00:00:00.000' AS DateTime), N'103mbp13-silver-select-201610.jpg')
INSERT [dbo].[Listings] ([id], [ListingCode], [title], [CategoryId], [SellerId], [description], [price], [location], [AddedDate], [LastDate], [ImageUrl]) VALUES (6, 201, N'Jeans Shirt', 2, 1, N'Blue Denim', 10, N'London', CAST(N'2017-04-01T20:11:26.000' AS DateTime), CAST(N'2017-12-12T00:00:00.000' AS DateTime), N'201291357_main.jpg')
SET IDENTITY_INSERT [dbo].[Listings] OFF
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([id], [Name], [Email], [Password], [Location], [UserType]) VALUES (1, N'Fagun', N'mdabuzaforfagun@gmail.com', N'password', N'London', 1)
INSERT [dbo].[Users] ([id], [Name], [Email], [Password], [Location], [UserType]) VALUES (2, N'Rain', N'rain@gmail.com', N'pass', N'London', 0)
SET IDENTITY_INSERT [dbo].[Users] OFF
USE [master]
GO
ALTER DATABASE [BidMe] SET  READ_WRITE 
GO

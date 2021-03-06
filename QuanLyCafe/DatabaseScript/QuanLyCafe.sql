USE [master]
GO
/****** Object:  Database [QuanLyCafe]    Script Date: 28/04/2022 7:44:51 PM ******/
CREATE DATABASE [QuanLyCafe]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'QuanLyCafe', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\QuanLyCafe.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'QuanLyCafe_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\QuanLyCafe_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [QuanLyCafe] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [QuanLyCafe].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [QuanLyCafe] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [QuanLyCafe] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [QuanLyCafe] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [QuanLyCafe] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [QuanLyCafe] SET ARITHABORT OFF 
GO
ALTER DATABASE [QuanLyCafe] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [QuanLyCafe] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [QuanLyCafe] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [QuanLyCafe] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [QuanLyCafe] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [QuanLyCafe] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [QuanLyCafe] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [QuanLyCafe] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [QuanLyCafe] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [QuanLyCafe] SET  ENABLE_BROKER 
GO
ALTER DATABASE [QuanLyCafe] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [QuanLyCafe] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [QuanLyCafe] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [QuanLyCafe] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [QuanLyCafe] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [QuanLyCafe] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [QuanLyCafe] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [QuanLyCafe] SET RECOVERY FULL 
GO
ALTER DATABASE [QuanLyCafe] SET  MULTI_USER 
GO
ALTER DATABASE [QuanLyCafe] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [QuanLyCafe] SET DB_CHAINING OFF 
GO
ALTER DATABASE [QuanLyCafe] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [QuanLyCafe] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [QuanLyCafe] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [QuanLyCafe] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'QuanLyCafe', N'ON'
GO
ALTER DATABASE [QuanLyCafe] SET QUERY_STORE = OFF
GO
USE [QuanLyCafe]
GO
/****** Object:  Table [dbo].[Account]    Script Date: 28/04/2022 7:44:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Account](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[user_name] [varchar](100) NOT NULL,
	[display_name] [nvarchar](100) NOT NULL,
	[password] [varchar](100) NOT NULL,
	[type] [tinyint] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Bill]    Script Date: 28/04/2022 7:44:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bill](
	[id] [varchar](20) NOT NULL,
	[date_check_in] [datetime] NULL,
	[date_check_out] [datetime] NULL,
	[status] [tinyint] NOT NULL,
	[discount] [int] NULL,
	[id_table] [int] NOT NULL,
	[id_user] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BillInfo]    Script Date: 28/04/2022 7:44:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BillInfo](
	[id_bill] [varchar](20) NOT NULL,
	[id_food] [int] NOT NULL,
	[quantity] [int] NOT NULL,
	[price] [float] NOT NULL,
 CONSTRAINT [PK_billinfo] PRIMARY KEY CLUSTERED 
(
	[id_bill] ASC,
	[id_food] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Food]    Script Date: 28/04/2022 7:44:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Food](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](100) NOT NULL,
	[id_category] [int] NOT NULL,
	[price] [float] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FoodCategory]    Script Date: 28/04/2022 7:44:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FoodCategory](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TableFood]    Script Date: 28/04/2022 7:44:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TableFood](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](100) NOT NULL,
	[status] [tinyint] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Account] ON 

INSERT [dbo].[Account] ([id], [user_name], [display_name], [password], [type]) VALUES (1, N'Admin', N'Admin', N'xMpCOKC5I4INzFCab3WEmw==', 1)
INSERT [dbo].[Account] ([id], [user_name], [display_name], [password], [type]) VALUES (2, N'User', N'Nguyễn Thị A', N'xMpCOKC5I4INzFCab3WEmw==', 0)
INSERT [dbo].[Account] ([id], [user_name], [display_name], [password], [type]) VALUES (3, N'user', N'Nguyễn B', N'xMpCOKC5I4INzFCab3WEmw==', 0)
INSERT [dbo].[Account] ([id], [user_name], [display_name], [password], [type]) VALUES (4, N'user2', N'Nguyễn Thị A', N'xMpCOKC5I4INzFCab3WEmw==', 0)
INSERT [dbo].[Account] ([id], [user_name], [display_name], [password], [type]) VALUES (5, N'user3', N'Nguyễn Thị A', N'xMpCOKC5I4INzFCab3WEmw==', 0)
INSERT [dbo].[Account] ([id], [user_name], [display_name], [password], [type]) VALUES (6, N'user5', N'Nguyễn Thị C', N'xMpCOKC5I4INzFCab3WEmw==', 0)
INSERT [dbo].[Account] ([id], [user_name], [display_name], [password], [type]) VALUES (8, N'user7', N'Nguyễn Thị A', N'xMpCOKC5I4INzFCab3WEmw==', 0)
INSERT [dbo].[Account] ([id], [user_name], [display_name], [password], [type]) VALUES (11, N'user1', N'Lê Thị A', N'xMpCOKC5I4INzFCab3WEmw==', 0)
SET IDENTITY_INSERT [dbo].[Account] OFF
GO
INSERT [dbo].[Bill] ([id], [date_check_in], [date_check_out], [status], [discount], [id_table], [id_user]) VALUES (N'2022-03-0001', CAST(N'2022-03-30T00:00:00.000' AS DateTime), CAST(N'2022-03-30T00:00:00.000' AS DateTime), 1, 0, 13, 2)
INSERT [dbo].[Bill] ([id], [date_check_in], [date_check_out], [status], [discount], [id_table], [id_user]) VALUES (N'2022-03-0003', CAST(N'2022-03-30T00:00:00.000' AS DateTime), CAST(N'2022-03-30T00:00:00.000' AS DateTime), 1, 0, 1, 2)
INSERT [dbo].[Bill] ([id], [date_check_in], [date_check_out], [status], [discount], [id_table], [id_user]) VALUES (N'2022-03-0008', CAST(N'2022-03-30T00:00:00.000' AS DateTime), CAST(N'2022-03-30T00:00:00.000' AS DateTime), 1, 0, 9, 2)
INSERT [dbo].[Bill] ([id], [date_check_in], [date_check_out], [status], [discount], [id_table], [id_user]) VALUES (N'2022-03-0010', CAST(N'2022-03-30T00:00:00.000' AS DateTime), CAST(N'2022-03-30T00:00:00.000' AS DateTime), 1, 0, 13, 2)
INSERT [dbo].[Bill] ([id], [date_check_in], [date_check_out], [status], [discount], [id_table], [id_user]) VALUES (N'2022-03-0017', CAST(N'2022-03-31T00:00:00.000' AS DateTime), CAST(N'2022-03-31T00:00:00.000' AS DateTime), 1, 0, 20, 1)
INSERT [dbo].[Bill] ([id], [date_check_in], [date_check_out], [status], [discount], [id_table], [id_user]) VALUES (N'2022-03-0019', CAST(N'2022-03-31T00:00:00.000' AS DateTime), CAST(N'2022-03-31T00:00:00.000' AS DateTime), 1, 0, 15, 1)
INSERT [dbo].[Bill] ([id], [date_check_in], [date_check_out], [status], [discount], [id_table], [id_user]) VALUES (N'2022-03-0020', CAST(N'2022-03-31T00:00:00.000' AS DateTime), CAST(N'2022-04-02T00:00:00.000' AS DateTime), 1, 10, 1, 1)
INSERT [dbo].[Bill] ([id], [date_check_in], [date_check_out], [status], [discount], [id_table], [id_user]) VALUES (N'2022-03-0022', CAST(N'2022-03-31T00:00:00.000' AS DateTime), CAST(N'2022-04-03T00:00:00.000' AS DateTime), 1, 20, 10, 1)
INSERT [dbo].[Bill] ([id], [date_check_in], [date_check_out], [status], [discount], [id_table], [id_user]) VALUES (N'2022-04-0001', CAST(N'2022-04-01T00:00:00.000' AS DateTime), CAST(N'2022-04-01T00:00:00.000' AS DateTime), 1, 0, 38, 1)
INSERT [dbo].[Bill] ([id], [date_check_in], [date_check_out], [status], [discount], [id_table], [id_user]) VALUES (N'2022-04-0002', CAST(N'2022-04-01T00:00:00.000' AS DateTime), CAST(N'2022-04-03T00:00:00.000' AS DateTime), 1, 40, 15, 1)
INSERT [dbo].[Bill] ([id], [date_check_in], [date_check_out], [status], [discount], [id_table], [id_user]) VALUES (N'2022-04-0003', CAST(N'2022-04-02T00:00:00.000' AS DateTime), CAST(N'2022-04-03T00:00:00.000' AS DateTime), 1, 0, 29, 1)
INSERT [dbo].[Bill] ([id], [date_check_in], [date_check_out], [status], [discount], [id_table], [id_user]) VALUES (N'2022-04-0005', CAST(N'2022-04-02T00:00:00.000' AS DateTime), NULL, 0, 0, 12, 1)
INSERT [dbo].[Bill] ([id], [date_check_in], [date_check_out], [status], [discount], [id_table], [id_user]) VALUES (N'2022-04-0006', CAST(N'2022-04-02T00:00:00.000' AS DateTime), CAST(N'2022-04-03T00:00:00.000' AS DateTime), 1, 50, 13, 1)
INSERT [dbo].[Bill] ([id], [date_check_in], [date_check_out], [status], [discount], [id_table], [id_user]) VALUES (N'2022-04-0008', CAST(N'2022-04-03T00:00:00.000' AS DateTime), NULL, 0, 0, 35, 1)
INSERT [dbo].[Bill] ([id], [date_check_in], [date_check_out], [status], [discount], [id_table], [id_user]) VALUES (N'2022-04-0009', CAST(N'2022-04-03T17:29:37.967' AS DateTime), CAST(N'2022-04-03T17:29:41.077' AS DateTime), 1, 0, 2, 1)
INSERT [dbo].[Bill] ([id], [date_check_in], [date_check_out], [status], [discount], [id_table], [id_user]) VALUES (N'2022-04-0010', CAST(N'2022-04-03T17:33:38.377' AS DateTime), CAST(N'2022-04-03T17:33:58.420' AS DateTime), 1, 0, 9, 1)
INSERT [dbo].[Bill] ([id], [date_check_in], [date_check_out], [status], [discount], [id_table], [id_user]) VALUES (N'2022-04-0012', CAST(N'2022-04-03T17:34:02.937' AS DateTime), CAST(N'2022-04-03T17:39:09.470' AS DateTime), 1, 0, 32, 1)
INSERT [dbo].[Bill] ([id], [date_check_in], [date_check_out], [status], [discount], [id_table], [id_user]) VALUES (N'2022-04-0013', CAST(N'2022-04-03T17:34:06.460' AS DateTime), CAST(N'2022-04-04T01:33:41.047' AS DateTime), 1, 0, 38, 1)
INSERT [dbo].[Bill] ([id], [date_check_in], [date_check_out], [status], [discount], [id_table], [id_user]) VALUES (N'2022-04-0014', CAST(N'2022-04-03T17:34:08.670' AS DateTime), CAST(N'2022-04-03T17:39:14.000' AS DateTime), 1, 0, 15, 1)
INSERT [dbo].[Bill] ([id], [date_check_in], [date_check_out], [status], [discount], [id_table], [id_user]) VALUES (N'2022-04-0015', CAST(N'2022-04-03T17:34:11.820' AS DateTime), NULL, 0, 0, 18, 1)
INSERT [dbo].[Bill] ([id], [date_check_in], [date_check_out], [status], [discount], [id_table], [id_user]) VALUES (N'2022-04-0016', CAST(N'2022-04-03T17:34:18.383' AS DateTime), NULL, 0, 0, 24, 1)
INSERT [dbo].[Bill] ([id], [date_check_in], [date_check_out], [status], [discount], [id_table], [id_user]) VALUES (N'2022-04-0017', CAST(N'2022-04-04T14:27:48.493' AS DateTime), CAST(N'2022-04-04T14:27:50.027' AS DateTime), 1, 0, 20, 1)
INSERT [dbo].[Bill] ([id], [date_check_in], [date_check_out], [status], [discount], [id_table], [id_user]) VALUES (N'2022-04-0018', CAST(N'2022-04-04T14:27:54.393' AS DateTime), NULL, 0, 0, 1, 1)
GO
INSERT [dbo].[BillInfo] ([id_bill], [id_food], [quantity], [price]) VALUES (N'2022-03-0001', 3, 1, 10000)
INSERT [dbo].[BillInfo] ([id_bill], [id_food], [quantity], [price]) VALUES (N'2022-03-0001', 5, 1, 10000)
INSERT [dbo].[BillInfo] ([id_bill], [id_food], [quantity], [price]) VALUES (N'2022-03-0001', 7, 1, 5000)
INSERT [dbo].[BillInfo] ([id_bill], [id_food], [quantity], [price]) VALUES (N'2022-03-0001', 14, 5, 20000)
INSERT [dbo].[BillInfo] ([id_bill], [id_food], [quantity], [price]) VALUES (N'2022-03-0003', 1, 17, 10000)
INSERT [dbo].[BillInfo] ([id_bill], [id_food], [quantity], [price]) VALUES (N'2022-03-0003', 2, 1, 10000)
INSERT [dbo].[BillInfo] ([id_bill], [id_food], [quantity], [price]) VALUES (N'2022-03-0008', 1, 1, 10000)
INSERT [dbo].[BillInfo] ([id_bill], [id_food], [quantity], [price]) VALUES (N'2022-03-0008', 3, 2, 10000)
INSERT [dbo].[BillInfo] ([id_bill], [id_food], [quantity], [price]) VALUES (N'2022-03-0008', 10, 3, 15000)
INSERT [dbo].[BillInfo] ([id_bill], [id_food], [quantity], [price]) VALUES (N'2022-03-0010', 1, 1, 10000)
INSERT [dbo].[BillInfo] ([id_bill], [id_food], [quantity], [price]) VALUES (N'2022-03-0017', 1, 1, 10000)
INSERT [dbo].[BillInfo] ([id_bill], [id_food], [quantity], [price]) VALUES (N'2022-03-0019', 1, 45, 10000)
INSERT [dbo].[BillInfo] ([id_bill], [id_food], [quantity], [price]) VALUES (N'2022-03-0019', 11, 1, 15000)
INSERT [dbo].[BillInfo] ([id_bill], [id_food], [quantity], [price]) VALUES (N'2022-03-0020', 1, 3, 10000)
INSERT [dbo].[BillInfo] ([id_bill], [id_food], [quantity], [price]) VALUES (N'2022-03-0020', 3, 2, 10000)
INSERT [dbo].[BillInfo] ([id_bill], [id_food], [quantity], [price]) VALUES (N'2022-03-0020', 6, 1, 10000)
INSERT [dbo].[BillInfo] ([id_bill], [id_food], [quantity], [price]) VALUES (N'2022-03-0020', 10, 2, 15000)
INSERT [dbo].[BillInfo] ([id_bill], [id_food], [quantity], [price]) VALUES (N'2022-03-0020', 18, 1, 15000)
INSERT [dbo].[BillInfo] ([id_bill], [id_food], [quantity], [price]) VALUES (N'2022-03-0022', 10, 1, 15000)
INSERT [dbo].[BillInfo] ([id_bill], [id_food], [quantity], [price]) VALUES (N'2022-04-0001', 2, 1, 10000)
INSERT [dbo].[BillInfo] ([id_bill], [id_food], [quantity], [price]) VALUES (N'2022-04-0001', 3, 1, 10000)
INSERT [dbo].[BillInfo] ([id_bill], [id_food], [quantity], [price]) VALUES (N'2022-04-0001', 6, 1, 10000)
INSERT [dbo].[BillInfo] ([id_bill], [id_food], [quantity], [price]) VALUES (N'2022-04-0001', 8, 1, 10000)
INSERT [dbo].[BillInfo] ([id_bill], [id_food], [quantity], [price]) VALUES (N'2022-04-0001', 9, 5, 10000)
INSERT [dbo].[BillInfo] ([id_bill], [id_food], [quantity], [price]) VALUES (N'2022-04-0002', 2, 4, 10000)
INSERT [dbo].[BillInfo] ([id_bill], [id_food], [quantity], [price]) VALUES (N'2022-04-0002', 10, 1, 15000)
INSERT [dbo].[BillInfo] ([id_bill], [id_food], [quantity], [price]) VALUES (N'2022-04-0002', 29, 1, 50000)
INSERT [dbo].[BillInfo] ([id_bill], [id_food], [quantity], [price]) VALUES (N'2022-04-0003', 28, 1, 10000)
INSERT [dbo].[BillInfo] ([id_bill], [id_food], [quantity], [price]) VALUES (N'2022-04-0005', 28, 1, 10000)
INSERT [dbo].[BillInfo] ([id_bill], [id_food], [quantity], [price]) VALUES (N'2022-04-0006', 28, 1, 10000)
INSERT [dbo].[BillInfo] ([id_bill], [id_food], [quantity], [price]) VALUES (N'2022-04-0008', 7, 1, 10000)
INSERT [dbo].[BillInfo] ([id_bill], [id_food], [quantity], [price]) VALUES (N'2022-04-0008', 28, 5, 10000)
INSERT [dbo].[BillInfo] ([id_bill], [id_food], [quantity], [price]) VALUES (N'2022-04-0009', 28, 1, 10000)
INSERT [dbo].[BillInfo] ([id_bill], [id_food], [quantity], [price]) VALUES (N'2022-04-0010', 10, 1, 15000)
INSERT [dbo].[BillInfo] ([id_bill], [id_food], [quantity], [price]) VALUES (N'2022-04-0010', 28, 2, 10000)
INSERT [dbo].[BillInfo] ([id_bill], [id_food], [quantity], [price]) VALUES (N'2022-04-0012', 28, 1, 10000)
INSERT [dbo].[BillInfo] ([id_bill], [id_food], [quantity], [price]) VALUES (N'2022-04-0013', 35, 1, 15000)
INSERT [dbo].[BillInfo] ([id_bill], [id_food], [quantity], [price]) VALUES (N'2022-04-0014', 35, 1, 15000)
INSERT [dbo].[BillInfo] ([id_bill], [id_food], [quantity], [price]) VALUES (N'2022-04-0015', 3, 1, 10000)
INSERT [dbo].[BillInfo] ([id_bill], [id_food], [quantity], [price]) VALUES (N'2022-04-0015', 26, 1, 15000)
INSERT [dbo].[BillInfo] ([id_bill], [id_food], [quantity], [price]) VALUES (N'2022-04-0015', 35, 1, 15000)
INSERT [dbo].[BillInfo] ([id_bill], [id_food], [quantity], [price]) VALUES (N'2022-04-0015', 36, 1, 15000)
INSERT [dbo].[BillInfo] ([id_bill], [id_food], [quantity], [price]) VALUES (N'2022-04-0016', 6, 1, 10000)
INSERT [dbo].[BillInfo] ([id_bill], [id_food], [quantity], [price]) VALUES (N'2022-04-0016', 11, 1, 15000)
INSERT [dbo].[BillInfo] ([id_bill], [id_food], [quantity], [price]) VALUES (N'2022-04-0016', 13, 1, 15000)
INSERT [dbo].[BillInfo] ([id_bill], [id_food], [quantity], [price]) VALUES (N'2022-04-0017', 28, 1, 10000)
INSERT [dbo].[BillInfo] ([id_bill], [id_food], [quantity], [price]) VALUES (N'2022-04-0018', 28, 1, 10000)
GO
SET IDENTITY_INSERT [dbo].[Food] ON 

INSERT [dbo].[Food] ([id], [name], [id_category], [price]) VALUES (1, N'Cà phê sữa', 1, 10000)
INSERT [dbo].[Food] ([id], [name], [id_category], [price]) VALUES (2, N'Cà phê đen', 1, 10000)
INSERT [dbo].[Food] ([id], [name], [id_category], [price]) VALUES (3, N'Bạc xỉu', 1, 10000)
INSERT [dbo].[Food] ([id], [name], [id_category], [price]) VALUES (4, N'Cà phê latte', 1, 10000)
INSERT [dbo].[Food] ([id], [name], [id_category], [price]) VALUES (5, N'Cà phê sữa dừa', 1, 10000)
INSERT [dbo].[Food] ([id], [name], [id_category], [price]) VALUES (6, N'Cá viên', 2, 10000)
INSERT [dbo].[Food] ([id], [name], [id_category], [price]) VALUES (7, N'Bò viên', 2, 10000)
INSERT [dbo].[Food] ([id], [name], [id_category], [price]) VALUES (8, N'Xoài lắc', 2, 10000)
INSERT [dbo].[Food] ([id], [name], [id_category], [price]) VALUES (9, N'Bánh tráng trộn', 2, 10000)
INSERT [dbo].[Food] ([id], [name], [id_category], [price]) VALUES (10, N'Sting', 3, 15000)
INSERT [dbo].[Food] ([id], [name], [id_category], [price]) VALUES (11, N'C2', 3, 15000)
INSERT [dbo].[Food] ([id], [name], [id_category], [price]) VALUES (13, N'7 up', 3, 15000)
INSERT [dbo].[Food] ([id], [name], [id_category], [price]) VALUES (14, N'Trà sữa truyền thống', 4, 20000)
INSERT [dbo].[Food] ([id], [name], [id_category], [price]) VALUES (15, N'Trà sữa trái cây', 4, 20000)
INSERT [dbo].[Food] ([id], [name], [id_category], [price]) VALUES (16, N'Trà sữa đặc biệt', 4, 20000)
INSERT [dbo].[Food] ([id], [name], [id_category], [price]) VALUES (17, N'Hồng trà sữa', 4, 10000)
INSERT [dbo].[Food] ([id], [name], [id_category], [price]) VALUES (18, N'Sinh tố xoài', 5, 15000)
INSERT [dbo].[Food] ([id], [name], [id_category], [price]) VALUES (19, N'Sinh tố thơm', 5, 15000)
INSERT [dbo].[Food] ([id], [name], [id_category], [price]) VALUES (20, N'Sinh tố bơ', 5, 15000)
INSERT [dbo].[Food] ([id], [name], [id_category], [price]) VALUES (21, N'Sinh tố sapoche', 5, 15000)
INSERT [dbo].[Food] ([id], [name], [id_category], [price]) VALUES (23, N'Bạc xỉu nóng', 1, 10000)
INSERT [dbo].[Food] ([id], [name], [id_category], [price]) VALUES (24, N'Bạc xỉu đá', 1, 10000)
INSERT [dbo].[Food] ([id], [name], [id_category], [price]) VALUES (26, N'Bí đao', 3, 15000)
INSERT [dbo].[Food] ([id], [name], [id_category], [price]) VALUES (28, N'Bánh tráng nướng', 2, 10000)
INSERT [dbo].[Food] ([id], [name], [id_category], [price]) VALUES (29, N'Coca', 3, 50000)
INSERT [dbo].[Food] ([id], [name], [id_category], [price]) VALUES (31, N'Xoài mắm ruốc', 2, 10000)
INSERT [dbo].[Food] ([id], [name], [id_category], [price]) VALUES (32, N'Sinh tố cà rốt', 5, 20000)
INSERT [dbo].[Food] ([id], [name], [id_category], [price]) VALUES (33, N'Trà sữa thái', 4, 20000)
INSERT [dbo].[Food] ([id], [name], [id_category], [price]) VALUES (34, N'Trà sữa thái', 4, 15000)
INSERT [dbo].[Food] ([id], [name], [id_category], [price]) VALUES (35, N'Trứng cút', 2, 15000)
INSERT [dbo].[Food] ([id], [name], [id_category], [price]) VALUES (36, N'Nước dừa', 3, 15000)
SET IDENTITY_INSERT [dbo].[Food] OFF
GO
SET IDENTITY_INSERT [dbo].[FoodCategory] ON 

INSERT [dbo].[FoodCategory] ([id], [name]) VALUES (1, N'Cà phê')
INSERT [dbo].[FoodCategory] ([id], [name]) VALUES (2, N'Ăn vặt')
INSERT [dbo].[FoodCategory] ([id], [name]) VALUES (3, N'Nước giải khát')
INSERT [dbo].[FoodCategory] ([id], [name]) VALUES (4, N'Trà sữa')
INSERT [dbo].[FoodCategory] ([id], [name]) VALUES (5, N'Sinh tố')
SET IDENTITY_INSERT [dbo].[FoodCategory] OFF
GO
SET IDENTITY_INSERT [dbo].[TableFood] ON 

INSERT [dbo].[TableFood] ([id], [name], [status]) VALUES (1, N'Bàn 01', 1)
INSERT [dbo].[TableFood] ([id], [name], [status]) VALUES (2, N'Bàn 02', 0)
INSERT [dbo].[TableFood] ([id], [name], [status]) VALUES (9, N'Bàn 09', 0)
INSERT [dbo].[TableFood] ([id], [name], [status]) VALUES (10, N'Bàn 10', 0)
INSERT [dbo].[TableFood] ([id], [name], [status]) VALUES (12, N'Bàn 12', 1)
INSERT [dbo].[TableFood] ([id], [name], [status]) VALUES (13, N'Bàn 13', 0)
INSERT [dbo].[TableFood] ([id], [name], [status]) VALUES (15, N'Bàn 15', 0)
INSERT [dbo].[TableFood] ([id], [name], [status]) VALUES (18, N'Bàn 18', 1)
INSERT [dbo].[TableFood] ([id], [name], [status]) VALUES (20, N'Bàn 20', 0)
INSERT [dbo].[TableFood] ([id], [name], [status]) VALUES (24, N'Bàn 16', 1)
INSERT [dbo].[TableFood] ([id], [name], [status]) VALUES (27, N'Bàn 03', 0)
INSERT [dbo].[TableFood] ([id], [name], [status]) VALUES (28, N'Bàn 04', 0)
INSERT [dbo].[TableFood] ([id], [name], [status]) VALUES (29, N'Bàn 05', 0)
INSERT [dbo].[TableFood] ([id], [name], [status]) VALUES (30, N'Bàn 06', 0)
INSERT [dbo].[TableFood] ([id], [name], [status]) VALUES (31, N'Bàn 07', 0)
INSERT [dbo].[TableFood] ([id], [name], [status]) VALUES (32, N'Bàn 08', 0)
INSERT [dbo].[TableFood] ([id], [name], [status]) VALUES (35, N'Bàn 11', 1)
INSERT [dbo].[TableFood] ([id], [name], [status]) VALUES (38, N'Bàn 14', 0)
INSERT [dbo].[TableFood] ([id], [name], [status]) VALUES (41, N'Bàn 17', 0)
INSERT [dbo].[TableFood] ([id], [name], [status]) VALUES (43, N'Bàn 19', 0)
SET IDENTITY_INSERT [dbo].[TableFood] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UNIQUE_user]    Script Date: 28/04/2022 7:44:52 PM ******/
ALTER TABLE [dbo].[Account] ADD  CONSTRAINT [UNIQUE_user] UNIQUE NONCLUSTERED 
(
	[user_name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Account] ADD  DEFAULT (N'User') FOR [display_name]
GO
ALTER TABLE [dbo].[Account] ADD  DEFAULT ((0)) FOR [type]
GO
ALTER TABLE [dbo].[Bill] ADD  CONSTRAINT [DF_Bill_date_check_in]  DEFAULT (getdate()) FOR [date_check_in]
GO
ALTER TABLE [dbo].[Bill] ADD  DEFAULT ((0)) FOR [status]
GO
ALTER TABLE [dbo].[Bill] ADD  DEFAULT ((0)) FOR [discount]
GO
ALTER TABLE [dbo].[BillInfo] ADD  DEFAULT ((0)) FOR [quantity]
GO
ALTER TABLE [dbo].[BillInfo] ADD  DEFAULT ((0)) FOR [price]
GO
ALTER TABLE [dbo].[Food] ADD  DEFAULT (N'-') FOR [name]
GO
ALTER TABLE [dbo].[Food] ADD  DEFAULT ((0)) FOR [price]
GO
ALTER TABLE [dbo].[FoodCategory] ADD  DEFAULT (N'-') FOR [name]
GO
ALTER TABLE [dbo].[TableFood] ADD  DEFAULT (N'Bàn mới') FOR [name]
GO
ALTER TABLE [dbo].[TableFood] ADD  DEFAULT ((0)) FOR [status]
GO
ALTER TABLE [dbo].[Bill]  WITH CHECK ADD  CONSTRAINT [FK_bill_account] FOREIGN KEY([id_user])
REFERENCES [dbo].[Account] ([id])
GO
ALTER TABLE [dbo].[Bill] CHECK CONSTRAINT [FK_bill_account]
GO
ALTER TABLE [dbo].[Bill]  WITH CHECK ADD  CONSTRAINT [FK_bill_table] FOREIGN KEY([id_table])
REFERENCES [dbo].[TableFood] ([id])
GO
ALTER TABLE [dbo].[Bill] CHECK CONSTRAINT [FK_bill_table]
GO
ALTER TABLE [dbo].[BillInfo]  WITH CHECK ADD  CONSTRAINT [FK_billinfo_bill] FOREIGN KEY([id_bill])
REFERENCES [dbo].[Bill] ([id])
GO
ALTER TABLE [dbo].[BillInfo] CHECK CONSTRAINT [FK_billinfo_bill]
GO
ALTER TABLE [dbo].[BillInfo]  WITH CHECK ADD  CONSTRAINT [FK_billinfo_food] FOREIGN KEY([id_food])
REFERENCES [dbo].[Food] ([id])
GO
ALTER TABLE [dbo].[BillInfo] CHECK CONSTRAINT [FK_billinfo_food]
GO
ALTER TABLE [dbo].[Food]  WITH CHECK ADD  CONSTRAINT [FK_food_category] FOREIGN KEY([id_category])
REFERENCES [dbo].[FoodCategory] ([id])
GO
ALTER TABLE [dbo].[Food] CHECK CONSTRAINT [FK_food_category]
GO
/****** Object:  StoredProcedure [dbo].[USP_Bill_By_Date_In]    Script Date: 28/04/2022 7:44:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Danh sach Bill theo ngay vao
CREATE   PROC [dbo].[USP_Bill_By_Date_In]
	@from_date DATE, @to_date DATE
AS
BEGIN
	SELECT b.id, b.date_check_in, b.date_check_out, b.status, b.discount, b.id_table, b.id_user,
	    t.name as name_table, a.display_name,
		CASE
			WHEN b.discount > 0 THEN cast(b.discount as VARCHAR(10)) + '%'
			ELSE '-'
		END discount_percent, 
		(SELECT SUM(i.quantity * i.price) FROM BillInfo i WHERE i.id_bill = b.id) AS amount,
		(SELECT SUM(i.quantity * i.price) FROM BillInfo i WHERE i.id_bill = b.id) * (100 - b.discount)/100 AS total
	FROM Bill b
		INNER JOIN TableFood t on (t.id = b.id_table)
		INNER JOIN Account a on (a.id = b.id_user)
	WHERE b.status = 1 AND b.date_check_in >= @from_date AND b.date_check_in <= @to_date
END
GO
/****** Object:  StoredProcedure [dbo].[USP_Bill_By_Date_Out]    Script Date: 28/04/2022 7:44:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Danh sach Bill theo ngay ra
CREATE   PROC [dbo].[USP_Bill_By_Date_Out]
	@from_date DATE, @to_date DATE
AS
BEGIN
	SELECT b.id, b.date_check_in, b.date_check_out, b.status, b.discount, b.id_table, b.id_user,
	    t.name as name_table, a.display_name,
		CASE
			WHEN b.discount > 0 THEN cast(b.discount as VARCHAR(10)) + '%'
			ELSE '-'
		END discount_percent, 
		(SELECT SUM(i.quantity * i.price) FROM BillInfo i WHERE i.id_bill = b.id) AS amount,
		(SELECT SUM(i.quantity * i.price) FROM BillInfo i WHERE i.id_bill = b.id) * (100 - b.discount)/100 AS total
	FROM Bill b
		INNER JOIN TableFood t on (t.id = b.id_table)
		INNER JOIN Account a on (a.id = b.id_user)
	WHERE b.status = 1 AND b.date_check_out >= @from_date AND b.date_check_out <= @to_date
END
GO
/****** Object:  StoredProcedure [dbo].[USP_Bill_Info]    Script Date: 28/04/2022 7:44:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[USP_Bill_Info]
	@id_bill varchar(20)
AS
BEGIN
	SELECT i.id_bill, i.id_food, i.price, i.quantity, 
	      (i.price * i.quantity) amount, f.name name_food,
	       b.date_check_in, b.date_check_out, b.discount, b.id_table,
		   t.name name_table, a.display_name
	FROM BillInfo i
		INNER JOIN Bill b ON (b.id = i.id_bill)
		INNER JOIN Food f ON (f.id = i.id_food)
		INNER JOIN TableFood t ON (t.id = b.id_table)
		INNER JOIN Account a ON (a.id = b.id_user)
	WHERE i.id_bill = @id_bill
END
GO
/****** Object:  StoredProcedure [dbo].[USP_Bill_Info_Delete]    Script Date: 28/04/2022 7:44:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Xoa Bill Info -----------------------------------------------------------
CREATE   PROC [dbo].[USP_Bill_Info_Delete]
	@id_bill VARCHAR(20), @id_food INT
AS
BEGIN
	BEGIN TRAN
	BEGIN TRY
		DELETE FROM BillInfo
		WHERE id_bill = @id_bill AND id_food = @id_food

		IF NOT EXISTS (SELECT TOP 1 * 
		               FROM BillInfo 
		               WHERE id_bill = @id_bill)
		BEGIN
			DECLARE @id_table INT 
			SELECT @id_table = id_table
			FROM Bill 
			WHERE id = @id_bill

			DELETE FROM Bill 
			WHERE id = @id_bill
		
			UPDATE TableFood
			SET status = 0
			WHERE id = @id_table
		END

		COMMIT TRAN
	END TRY
	BEGIN CATCH
		ROLLBACK TRAN
	END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[USP_FoodCategory_Delete]    Script Date: 28/04/2022 7:44:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Xoa FoodCategory -----------------------------------------
CREATE   PROC [dbo].[USP_FoodCategory_Delete]
	@id INT
AS
BEGIN
	DECLARE @result TINYINT = 0	
	
	BEGIN TRAN
	BEGIN TRY
		-- Kiem tra Food trong Category da co Bill nao chua
		DECLARE @id_food INT
		SELECT TOP 1 @id_food = i.id_food
		FROM BillInfo i
			INNER JOIN Food f ON (i.id_food = f.id)
		WHERE f.id_category = @id

		IF(@id_food IS NULL) -- Chua co trong Bill
		BEGIN
			-- Xoa Food truoc
			DELETE FROM Food WHERE id_category = @id
			-- Xoa Category
			DELETE FROM FoodCategory WHERE id = @id
			
			SET @result = 1 -- Xoa thanh cong
		END
		ELSE
		BEGIN			
			SET @result = -1 -- Dang su dung				
		END	
		
		COMMIT TRAN
	END TRY
	BEGIN CATCH		
		SET @result = 0 -- Loi		
		ROLLBACK TRAN
	END CATCH		

	SELECT @result AS Result
END
GO
/****** Object:  StoredProcedure [dbo].[USP_FoodCategory_InsertOrUpdate]    Script Date: 28/04/2022 7:44:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Them/Sua FoodCategory -----------------------------------------
CREATE   PROC [dbo].[USP_FoodCategory_InsertOrUpdate]
	@id INT, @name NVARCHAR(100)
AS
BEGIN
	DECLARE @id_new INT = -1

	BEGIN TRAN
	BEGIN TRY
		IF (@id = 0) 
		BEGIN
			INSERT INTO FoodCategory (name)
			VALUES (@name)

			SET @id_new = SCOPE_IDENTITY()
		END
		ELSE
		BEGIN
			UPDATE FoodCategory
			SET name = @name
			WHERE id = @id

			SET @id_new = @id
		END

		COMMIT TRAN
	END TRY
	BEGIN CATCH
		SET @id_new = -1
		ROLLBACK TRAN
	END CATCH

	SELECT @id_new AS Id	
END
GO
/****** Object:  StoredProcedure [dbo].[USP_Table_Add_Bill_Info]    Script Date: 28/04/2022 7:44:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Them Bill, Bill Info -------------------------------------------------------------
CREATE   PROC [dbo].[USP_Table_Add_Bill_Info]
	@id_table INT, @id_food INT, @quantity INT, @id_user INT
AS
BEGIN
	BEGIN TRANSACTION;
	BEGIN TRY		
		DECLARE @month_str NVARCHAR(3) = RIGHT( CAST( (MONTH(GETDATE()) + 100)  AS NVARCHAR(3)) , 2)
		DECLARE @year_str NVARCHAR(4) = CAST(YEAR(GETDATE()) AS NVARCHAR(4))	
		DECLARE @pre_str NVARCHAR(7) =  @year_str + '-' + @month_str

		-- Tim bill chua thanh toan cua ban
		DECLARE @id_bill VARCHAR(20);
		SELECT @id_bill = b.id
		FROM Bill b
		WHERE b.id_table = @id_table AND b.status = 0			

		IF(@id_bill IS NULL) -- Ban chua co bill
		BEGIN
			-- Tao id_bill
			DECLARE @max_bill VARCHAR(20)
			SELECT @max_bill = MAX(b.id)
			FROM Bill b
			WHERE b.id LIKE @pre_str + '%'			

			IF (@max_bill IS NULL)
				SET @id_bill = @pre_str + '-0001'
			ELSE
			BEGIN
				DECLARE @id_gen VARCHAR(4)
				SET @id_gen = CAST( RIGHT ( CAST( RIGHT(@max_bill, 4)  AS INT ) + 10001 , 4) AS VARCHAR(4) )
				SET @id_bill = @pre_str + '-' + @id_gen
			END

			-- Them bill moi
			INSERT INTO Bill(id, status, id_table, id_user)
			VALUES(@id_bill, 0, @id_table, @id_user)
		END			

		-- Them BillInfo
		DECLARE @price FLOAT
		SELECT @price = price
		FROM Food
		WHERE id = @id_food		

		IF EXISTS (SELECT b.id_food
				   FROM BillInfo b
				   WHERE b.id_bill = @id_bill AND b.id_food = @id_food )
		BEGIN
			-- So luong dang co trong bill
			DECLARE @quantity_old INT
			SELECT @quantity_old = b.quantity
			FROM BillInfo b
			WHERE b.id_bill = @id_bill AND b.id_food = @id_food

			-- Neu so luong dang co + so luong can them > 0 thi cap nhat nguoc lai thi xoa
			IF(@quantity_old + @quantity > 0) 
			BEGIN
				UPDATE BillInfo
				SET quantity = BillInfo.quantity + @quantity,
					price = @price
				WHERE id_bill = @id_bill AND id_food = @id_food
			END
			ELSE
			BEGIN
				DELETE FROM BillInfo
				WHERE id_bill = @id_bill AND id_food = @id_food

				-- Kiem tra trong bill con food nao ko
				IF NOT EXISTS (SELECT TOP 1 id_food FROM BillInfo WHERE id_bill = @id_bill)
				BEGIN
					-- neu ko con food nao thi xoa bill
					DELETE FROM Bill WHERE id = @id_bill

					-- Cap nhat table thanh trong
					UPDATE TableFood
					SET status = 0
					WHERE id = @id_table
				END
			END
		END
		ELSE
		BEGIN		
			IF (@quantity > 0)
			BEGIN
				INSERT INTO BillInfo(id_bill, id_food, quantity, price)
				VALUES (@id_bill, @id_food, @quantity, @price)

				-- Cap nhat table thanh co nguoi
				UPDATE TableFood
				SET status = 1
				WHERE id = @id_table
			END
		END			

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH

		ROLLBACK TRANSACTION;
	END CATCH;	
END
GO
/****** Object:  StoredProcedure [dbo].[USP_Table_Cancel_Bill]    Script Date: 28/04/2022 7:44:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Huy ban -------------------------------------------------------------
CREATE   PROC [dbo].[USP_Table_Cancel_Bill]
	@id_table INT
AS
BEGIN
	BEGIN TRAN
	BEGIN TRY
		DECLARE @id_bill VARCHAR(20)
		SELECT @id_bill = b.id
		FROM Bill b
		WHERE b.id_table = @id_table

		IF (@id_bill IS NOT NULL)
		BEGIN
			DELETE FROM BillInfo 
			WHERE id_bill = @id_bill

			DELETE FROM Bill 
			WHERE id = @id_bill
		END

		UPDATE TableFood 
		SET status = 0
		WHERE id = @id_table

		COMMIT TRAN
	END TRY
	BEGIN CATCH
		ROLLBACK TRAN
	END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[USP_Table_Change_Bill]    Script Date: 28/04/2022 7:44:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Chuyen ban -------------------------------------------------------------
CREATE   PROC [dbo].[USP_Table_Change_Bill]
	@id_table_from INT, @id_table_to INT
AS
BEGIN
	BEGIN TRAN
	BEGIN TRY
		-- Bill chua thanh toan
		DECLARE @id_bill_from NVARCHAR(20)
		SELECT @id_bill_from = id
		FROM Bill 
		WHERE id_table = @id_table_from and status = 0

		DECLARE @id_bill_to NVARCHAR(20)
		SELECT @id_bill_to = id
		FROM Bill 
		WHERE id_table = @id_table_to and status = 0

		-- Chuyen Bill
		IF (@id_bill_from IS NOT NULL)
		BEGIN
			UPDATE Bill
			SET id_table = @id_table_to
			WHERE id = @id_bill_from
		END

		IF (@id_bill_to IS NOT NULL)
		BEGIN
			UPDATE Bill
			SET id_table = @id_table_from
			WHERE id = @id_bill_to
		END

		-- Trang thai ban
		DECLARE @status_from INT
		SELECT @status_from = status
		FROM TableFood	
		WHERE id = @id_table_from

		DECLARE @status_to INT
		SELECT @status_to = status
		FROM TableFood	
		WHERE id = @id_table_to

		-- Chuyen tinh trang
		UPDATE TableFood
		SET status = @status_to
		WHERE id = @id_table_from

		UPDATE TableFood
		SET status = @status_from
		WHERE id = @id_table_to

		COMMIT TRAN
	END TRY
	BEGIN CATCH
		ROLLBACK TRAN
	END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[USP_Table_Delete]    Script Date: 28/04/2022 7:44:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Xoa Table -----------------------------------------------------------
CREATE   PROC [dbo].[USP_Table_Delete]
	@id_table INT
AS
BEGIN
	DECLARE @result INT = 0
	BEGIN TRAN
	BEGIN TRY
		DECLARE @id_bill INT
		SELECT TOP 1 @id_bill = id
		FROM Bill
		WHERE id_table = @id_table			

		IF (@id_bill IS NULL) -- Chua co hoa don
		BEGIN
			DELETE FROM TableFood
			WHERE id = @id_table

			SET @result = 1 -- thanh cong
		END
		ELSE
		BEGIN
			SET @result = -1 -- dang su dung
		END

		COMMIT TRAN
	END TRY
	BEGIN CATCH
		SET @result = 0 -- loi
		ROLLBACK TRAN
	END CATCH
	SELECT @result AS Result
END
GO
/****** Object:  StoredProcedure [dbo].[USP_Table_Get_Bill_Info]    Script Date: 28/04/2022 7:44:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- LayBill Info theo Table -------------------------------------------------------------
CREATE   PROC [dbo].[USP_Table_Get_Bill_Info]
	@id_table INT
AS
BEGIN
	-- Tim bill chua thanh toan cua ban
	DECLARE @id_bill VARCHAR(20);
	SELECT @id_bill = b.id
	FROM Bill b
	WHERE b.id_table = @id_table AND b.status = 0	
	
	SELECT b.id_bill, b.id_food, b.price, b.quantity, f.name as name_food
	FROM BillInfo b
		INNER JOIN Food f ON (f.id = b.id_food)
	WHERE b.id_bill = @id_bill
END
GO
/****** Object:  StoredProcedure [dbo].[USP_Table_InsertOrUpdate]    Script Date: 28/04/2022 7:44:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Them/Sua Table -----------------------------------------------------------
CREATE   PROC [dbo].[USP_Table_InsertOrUpdate]
	@id INT, @name NVARCHAR(100)
AS
BEGIN
	DECLARE @id_new INT = -1

	BEGIN TRAN 
	BEGIN TRY
		IF (@id = 0) -- Them
		BEGIN
			INSERT INTO TableFood(name)
			VALUES (@name)
			SET @id_new = SCOPE_IDENTITY()
		END
		ELSE
		BEGIN
			UPDATE TableFood
			SET name = @name
			WHERE id = @id

			SET @id_new = @id
		END

		COMMIT TRAN
	END TRY
	BEGIN CATCH 
		SET @id_new = -1
		ROLLBACK TRAN
	END CATCH

	SELECT @id_new AS Id
END
GO
/****** Object:  StoredProcedure [dbo].[USP_Table_Merge_Bill]    Script Date: 28/04/2022 7:44:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Gop ban -----------------------------------------------------------
CREATE   PROC [dbo].[USP_Table_Merge_Bill]
	@id_table_from INT, @id_table_to INT, @id_user INT
AS
BEGIN
	BEGIN TRAN 
	BEGIN TRY
		-- Bill chua thanh toan
		DECLARE @id_bill_from NVARCHAR(20)
		SELECT @id_bill_from = id
		FROM Bill 
		WHERE id_table = @id_table_from and status = 0

		-- Chuyen Bill
		IF (@id_bill_from IS NOT NULL)
		BEGIN
			DECLARE @id_food_min INT
			SELECT  @id_food_min = MIN(id_food)
			FROM BillInfo
			WHERE id_bill = @id_bill_from			
			
			WHILE (@id_food_min IS NOT NULL)
			BEGIN
				DECLARE @quantity INT
				SELECT @quantity = quantity
				FROM BillInfo 
				WHERE id_bill = @id_bill_from AND  id_food = @id_food_min

				-- Them vao ban moi
				EXEC USP_Table_Add_Bill_Info @id_table_to, @id_food_min, @quantity, @id_user

				SELECT @id_food_min = MIN(id_food)
				FROM BillInfo 
				WHERE id_bill = @id_bill_from AND  id_food > @id_food_min
			END

			-- Xoa Bill
			DELETE FROM BillInfo WHERE id_bill = @id_bill_from
			DELETE FROM Bill WHERE id = @id_bill_from
		END

		-- Chuyen tinh trang
		UPDATE TableFood
		SET status = 0
		WHERE id = @id_table_from

		UPDATE TableFood
		SET status = 1
		WHERE id = @id_table_to

		COMMIT TRAN 
	END TRY
	BEGIN CATCH
		 IF @@TRANCOUNT > 0 ROLLBACK TRAN
	END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[USP_Table_Payment_Bill]    Script Date: 28/04/2022 7:44:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--Thanh toan -----------------------------------------------------------
CREATE   PROC [dbo].[USP_Table_Payment_Bill]
	@id_table INT
AS
BEGIN
	-- Tim bill chua thanh toan cua table
	DECLARE @id_bill VARCHAR(20)
	SELECT @id_bill = id
	FROM Bill
	WHERE id_table = @id_table and status = 0

	if (@id_bill IS NOT NULL)
	BEGIN
		-- Cap nhat tinh trang bill sang da thanh toan
		UPDATE Bill 
		SET status = 1,
		    date_check_out = GETDATE()
		WHERE id = @id_bill

		-- Cap nhat trinh trang table ve trong
		UPDATE TableFood
		SET status = 0
		WHERE id = @id_table
	END
END
GO
/****** Object:  StoredProcedure [dbo].[USP_User_Login]    Script Date: 28/04/2022 7:44:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Login
CREATE   PROC [dbo].[USP_User_Login]
	@user_name VARCHAR(100), @password NVARCHAR(100)
AS
BEGIN
	SELECT user_name, password
	FROM Account 
	WHERE user_name = @user_name AND password = @password;
END
GO
USE [master]
GO
ALTER DATABASE [QuanLyCafe] SET  READ_WRITE 
GO

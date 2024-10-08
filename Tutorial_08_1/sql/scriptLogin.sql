USE [master]
GO
/****** Object:  Database [CustomerDb]    Script Date: 9/30/2024 4:33:09 PM ******/
CREATE DATABASE [CustomerDb]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'CustomerDb', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESSTESTER\MSSQL\DATA\CustomerDb.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'CustomerDb_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESSTESTER\MSSQL\DATA\CustomerDb_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [CustomerDb] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CustomerDb].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CustomerDb] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [CustomerDb] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [CustomerDb] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [CustomerDb] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [CustomerDb] SET ARITHABORT OFF 
GO
ALTER DATABASE [CustomerDb] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [CustomerDb] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [CustomerDb] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [CustomerDb] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [CustomerDb] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [CustomerDb] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [CustomerDb] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [CustomerDb] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [CustomerDb] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [CustomerDb] SET  DISABLE_BROKER 
GO
ALTER DATABASE [CustomerDb] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [CustomerDb] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [CustomerDb] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [CustomerDb] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [CustomerDb] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [CustomerDb] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [CustomerDb] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [CustomerDb] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [CustomerDb] SET  MULTI_USER 
GO
ALTER DATABASE [CustomerDb] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [CustomerDb] SET DB_CHAINING OFF 
GO
ALTER DATABASE [CustomerDb] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [CustomerDb] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [CustomerDb] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [CustomerDb] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [CustomerDb] SET QUERY_STORE = ON
GO
ALTER DATABASE [CustomerDb] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [CustomerDb]
GO
/****** Object:  Table [dbo].[Customers]    Script Date: 9/30/2024 4:33:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customers](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[customer_id] [nvarchar](50) NOT NULL,
	[customer_name] [nvarchar](100) NOT NULL,
	[nrc_number] [nvarchar](100) NOT NULL,
	[dob] [date] NULL,
	[member_card] [smallint] NOT NULL,
	[email] [nvarchar](100) NOT NULL,
	[gender] [smallint] NOT NULL,
	[phone_no_1] [nvarchar](50) NOT NULL,
	[phone_no_2] [nvarchar](50) NULL,
	[photo] [nvarchar](200) NULL,
	[address] [nvarchar](500) NULL,
	[created_user_id] [int] NOT NULL,
	[created_datetime] [datetime] NOT NULL,
	[updated_user_id] [int] NULL,
	[updated_datetime] [datetime] NULL,
	[is_deleted] [smallint] NOT NULL,
	[deleted_user_id] [int] NULL,
	[deleted_datetime] [datetime] NULL,
	[password] [nvarchar](255) NOT NULL,
 CONSTRAINT [PK__Customer__3213E83F70CB1904] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Customers] ON 

INSERT [dbo].[Customers] ([id], [customer_id], [customer_name], [nrc_number], [dob], [member_card], [email], [gender], [phone_no_1], [phone_no_2], [photo], [address], [created_user_id], [created_datetime], [updated_user_id], [updated_datetime], [is_deleted], [deleted_user_id], [deleted_datetime], [password]) VALUES (1, N'C-0001', N'yeyint', N'12/LaThar(N)330445', CAST(N'1999-01-01' AS Date), 2, N'yeyint@gmail.com', 1, N'09333444', N'09434324234', NULL, N'Burma', 1, CAST(N'2024-09-29T22:20:45.743' AS DateTime), 0, CAST(N'2024-09-29T23:17:46.127' AS DateTime), 0, 0, NULL, N'48d275e4dbf972f57c9a326e7cbf3a2a')
INSERT [dbo].[Customers] ([id], [customer_id], [customer_name], [nrc_number], [dob], [member_card], [email], [gender], [phone_no_1], [phone_no_2], [photo], [address], [created_user_id], [created_datetime], [updated_user_id], [updated_datetime], [is_deleted], [deleted_user_id], [deleted_datetime], [password]) VALUES (2, N'C-0002', N'Ye Aung', N'12/LaThar(N)330445', CAST(N'1999-01-01' AS Date), 1, N'yeyint@gmail.com', 1, N'09333444', N'09434324234', NULL, N'Burma', 1, CAST(N'2024-09-29T22:20:54.733' AS DateTime), 0, CAST(N'2024-09-29T22:27:50.620' AS DateTime), 0, 0, NULL, N'48d275e4dbf972f57c9a326e7cbf3a2a')
INSERT [dbo].[Customers] ([id], [customer_id], [customer_name], [nrc_number], [dob], [member_card], [email], [gender], [phone_no_1], [phone_no_2], [photo], [address], [created_user_id], [created_datetime], [updated_user_id], [updated_datetime], [is_deleted], [deleted_user_id], [deleted_datetime], [password]) VALUES (3, N'C-0003', N'Ye Thway', N'12/LaThar(N)330445', CAST(N'1999-01-01' AS Date), 1, N'yeyint@gmail.com', 1, N'09333444', N'09434324234', N'C:\Users\yyct\Desktop\c-sharp-ojt-tutorials\Tutorial_04\CustomerInfo\CustomerInfo\image\Screenshot (291).png', N'Burma', 1, CAST(N'2024-09-29T22:21:03.083' AS DateTime), 0, CAST(N'2024-09-29T22:36:03.300' AS DateTime), 0, 0, NULL, N'48d275e4dbf972f57c9a326e7cbf3a2a')
INSERT [dbo].[Customers] ([id], [customer_id], [customer_name], [nrc_number], [dob], [member_card], [email], [gender], [phone_no_1], [phone_no_2], [photo], [address], [created_user_id], [created_datetime], [updated_user_id], [updated_datetime], [is_deleted], [deleted_user_id], [deleted_datetime], [password]) VALUES (7, N'C-0004', N'yeyint', N'12/NNN(C)330554', CAST(N'1994-02-28' AS Date), 2, N'yeyint@gmail.com', 1, N'097877878', N'0979797996', N'C:\Users\yyct\Desktop\c-sharp-ojt-tutorials\Tutorial_04\CustomerInfo\CustomerInfo\image\Screenshot (4).png', N'Bago', 1, CAST(N'2024-09-29T23:16:35.410' AS DateTime), 0, CAST(N'2024-09-29T23:26:07.827' AS DateTime), 0, 0, NULL, N'6d4d2e3ed0a8bae6f06eddfe526347e6')
INSERT [dbo].[Customers] ([id], [customer_id], [customer_name], [nrc_number], [dob], [member_card], [email], [gender], [phone_no_1], [phone_no_2], [photo], [address], [created_user_id], [created_datetime], [updated_user_id], [updated_datetime], [is_deleted], [deleted_user_id], [deleted_datetime], [password]) VALUES (8, N'C-0005', N'July', N'5/MaMa(N)456778', CAST(N'1999-01-06' AS Date), 2, N'july@gmail.com', 1, N'094545344534', N'09435542423', N'C:\Users\yyct\Desktop\c-sharp-ojt-tutorials\Tutorial_04\CustomerInfo\CustomerInfo\image\Screenshot (277).png', N'Hogwart', 1, CAST(N'2024-09-30T14:41:15.530' AS DateTime), 0, NULL, 0, 0, NULL, N'1aa4617fa53fdc28b16e757b5cf2abba')
INSERT [dbo].[Customers] ([id], [customer_id], [customer_name], [nrc_number], [dob], [member_card], [email], [gender], [phone_no_1], [phone_no_2], [photo], [address], [created_user_id], [created_datetime], [updated_user_id], [updated_datetime], [is_deleted], [deleted_user_id], [deleted_datetime], [password]) VALUES (9, N'C-0005', N'July', N'5/MaMa(N)456778', CAST(N'1999-01-06' AS Date), 2, N'july@gmail.com', 1, N'094545344534', N'09435542423', N'C:\Users\yyct\Desktop\c-sharp-ojt-tutorials\Tutorial_04\CustomerInfo\CustomerInfo\image\Screenshot (277).png', N'Hogwart', 1, CAST(N'2024-09-30T14:41:15.530' AS DateTime), 0, NULL, 0, 0, NULL, N'1aa4617fa53fdc28b16e757b5cf2abba')
INSERT [dbo].[Customers] ([id], [customer_id], [customer_name], [nrc_number], [dob], [member_card], [email], [gender], [phone_no_1], [phone_no_2], [photo], [address], [created_user_id], [created_datetime], [updated_user_id], [updated_datetime], [is_deleted], [deleted_user_id], [deleted_datetime], [password]) VALUES (10, N'C-0006', N'Khin Thu Zar', N'4/LLL(N)444555', CAST(N'2000-07-20' AS Date), 2, N'khin@gmail.com', 2, N'09764443345', N'094325444534', N'C:\Users\yyct\Desktop\c-sharp-ojt-tutorials\Tutorial_04\CustomerInfo\CustomerInfo\image\Screenshot (94).png', N'Mon', 1, CAST(N'2024-09-30T14:57:39.507' AS DateTime), 0, NULL, 0, 0, NULL, N'202cb962ac59075b964b07152d234b70')
INSERT [dbo].[Customers] ([id], [customer_id], [customer_name], [nrc_number], [dob], [member_card], [email], [gender], [phone_no_1], [phone_no_2], [photo], [address], [created_user_id], [created_datetime], [updated_user_id], [updated_datetime], [is_deleted], [deleted_user_id], [deleted_datetime], [password]) VALUES (11, N'C-0007', N'Moe Thu Zar', N'4/THZ(N)445554', CAST(N'1994-02-28' AS Date), 1, N'moe@gmail.com', 2, N'34234234', N'343423423', N'C:\Users\yyct\Desktop\c-sharp-ojt-tutorials\Tutorial_04\CustomerInfo\CustomerInfo\image\Screenshot (179).png', N'Lathar', 1, CAST(N'2024-09-30T15:03:44.527' AS DateTime), 0, NULL, 0, 0, NULL, N'd56a6e0b704c10a68a63331f7b6d2e39')
INSERT [dbo].[Customers] ([id], [customer_id], [customer_name], [nrc_number], [dob], [member_card], [email], [gender], [phone_no_1], [phone_no_2], [photo], [address], [created_user_id], [created_datetime], [updated_user_id], [updated_datetime], [is_deleted], [deleted_user_id], [deleted_datetime], [password]) VALUES (12, N'C-0008', N'zarni', N'2/ygn(N)444455', CAST(N'1994-02-28' AS Date), 2, N'zarni@gmail.com', 1, N'342343', N'234234', N'C:\Users\yyct\Desktop\c-sharp-ojt-tutorials\Tutorial_04\CustomerInfo\CustomerInfo\image\Screenshot (3).png', N'Botahtaung', 1, CAST(N'2024-09-30T15:18:51.370' AS DateTime), 0, NULL, 0, 0, NULL, N'202cb962ac59075b964b07152d234b70')
INSERT [dbo].[Customers] ([id], [customer_id], [customer_name], [nrc_number], [dob], [member_card], [email], [gender], [phone_no_1], [phone_no_2], [photo], [address], [created_user_id], [created_datetime], [updated_user_id], [updated_datetime], [is_deleted], [deleted_user_id], [deleted_datetime], [password]) VALUES (13, N'C-0009', N'mya', N'8/mama(N)334456', CAST(N'1994-02-28' AS Date), 2, N'mya@gmail.com', 2, N'24234234', N'2423423', N'C:\Users\yyct\Desktop\c-sharp-ojt-tutorials\Tutorial_04\CustomerInfo\CustomerInfo\image\Screenshot (1).png', N'Hinthada', 1, CAST(N'2024-09-30T15:37:20.443' AS DateTime), 0, NULL, 0, 0, NULL, N'202cb962ac59075b964b07152d234b70')
INSERT [dbo].[Customers] ([id], [customer_id], [customer_name], [nrc_number], [dob], [member_card], [email], [gender], [phone_no_1], [phone_no_2], [photo], [address], [created_user_id], [created_datetime], [updated_user_id], [updated_datetime], [is_deleted], [deleted_user_id], [deleted_datetime], [password]) VALUES (14, N'C-0010', N'BA', N'2/tht(N)334434', CAST(N'1994-02-28' AS Date), 2, N'baba@gmail.com', 0, N'234234234', N'23423423', N'C:\Users\yyct\Desktop\c-sharp-ojt-tutorials\Tutorial_04\CustomerInfo\CustomerInfo\image\Screenshot (3).png', N'Nay Pyi Taw', 1, CAST(N'2024-09-30T15:39:03.777' AS DateTime), 0, NULL, 0, 0, NULL, N'202cb962ac59075b964b07152d234b70')
INSERT [dbo].[Customers] ([id], [customer_id], [customer_name], [nrc_number], [dob], [member_card], [email], [gender], [phone_no_1], [phone_no_2], [photo], [address], [created_user_id], [created_datetime], [updated_user_id], [updated_datetime], [is_deleted], [deleted_user_id], [deleted_datetime], [password]) VALUES (15, N'C-0011', N'Ye', N'12/MaMa(N)344343', CAST(N'1994-02-02' AS Date), 2, N'yeyint@gmail.com', 1, N'343423423', N'4234234', N'C:\Users\yyct\Desktop\c-sharp-ojt-tutorials\Tutorial_04\CustomerInfo\CustomerInfo\image\Screenshot (258).png', N'yy', 1, CAST(N'2024-09-30T15:43:35.147' AS DateTime), 0, NULL, 0, 0, NULL, N'202cb962ac59075b964b07152d234b70')
SET IDENTITY_INSERT [dbo].[Customers] OFF
GO
ALTER TABLE [dbo].[Customers] ADD  CONSTRAINT [DF_Customers_created_datetime]  DEFAULT (getdate()) FOR [created_datetime]
GO
USE [master]
GO
ALTER DATABASE [CustomerDb] SET  READ_WRITE 
GO

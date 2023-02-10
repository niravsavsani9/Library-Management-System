USE [master]
GO
/****** Object:  Database [HiTechDatabase]    Script Date: 4/25/2022 8:38:37 PM ******/
CREATE DATABASE [HiTechDatabase]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'HiTechDatabase', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\HiTechDatabase.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'HiTechDatabase_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\HiTechDatabase_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [HiTechDatabase] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [HiTechDatabase].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [HiTechDatabase] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [HiTechDatabase] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [HiTechDatabase] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [HiTechDatabase] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [HiTechDatabase] SET ARITHABORT OFF 
GO
ALTER DATABASE [HiTechDatabase] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [HiTechDatabase] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [HiTechDatabase] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [HiTechDatabase] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [HiTechDatabase] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [HiTechDatabase] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [HiTechDatabase] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [HiTechDatabase] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [HiTechDatabase] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [HiTechDatabase] SET  DISABLE_BROKER 
GO
ALTER DATABASE [HiTechDatabase] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [HiTechDatabase] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [HiTechDatabase] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [HiTechDatabase] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [HiTechDatabase] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [HiTechDatabase] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [HiTechDatabase] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [HiTechDatabase] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [HiTechDatabase] SET  MULTI_USER 
GO
ALTER DATABASE [HiTechDatabase] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [HiTechDatabase] SET DB_CHAINING OFF 
GO
ALTER DATABASE [HiTechDatabase] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [HiTechDatabase] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [HiTechDatabase] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [HiTechDatabase] SET QUERY_STORE = OFF
GO
USE [HiTechDatabase]
GO
/****** Object:  Table [dbo].[AuthorBooks]    Script Date: 4/25/2022 8:38:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AuthorBooks](
	[AuthorID] [int] NOT NULL,
	[ISBN] [nvarchar](50) NOT NULL,
	[YearPublished] [nvarchar](50) NOT NULL,
	[Edition] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_AuthorBooks] PRIMARY KEY CLUSTERED 
(
	[AuthorID] ASC,
	[ISBN] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Authors]    Script Date: 4/25/2022 8:38:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Authors](
	[AuthorID] [int] NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Authors] PRIMARY KEY CLUSTERED 
(
	[AuthorID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Books]    Script Date: 4/25/2022 8:38:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Books](
	[ISBN] [nvarchar](50) NOT NULL,
	[BookTitle] [nvarchar](50) NOT NULL,
	[UnitPrice] [decimal](18, 2) NOT NULL,
	[YearPublished] [date] NOT NULL,
	[QOH] [int] NOT NULL,
	[CategoryID] [int] NOT NULL,
	[PublisherID] [int] NOT NULL,
 CONSTRAINT [PK_Books] PRIMARY KEY CLUSTERED 
(
	[ISBN] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 4/25/2022 8:38:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[CategoryID] [int] NOT NULL,
	[CategoryName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED 
(
	[CategoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customers]    Script Date: 4/25/2022 8:38:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customers](
	[CustomerID] [int] NOT NULL,
	[CustomerName] [nvarchar](50) NOT NULL,
	[StreetAddress] [nvarchar](50) NOT NULL,
	[City] [nvarchar](50) NOT NULL,
	[PostalCode] [nvarchar](50) NOT NULL,
	[PhoneNumber] [nvarchar](50) NOT NULL,
	[FaxNumber] [nvarchar](50) NOT NULL,
	[CreditLimit] [int] NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Customers] PRIMARY KEY CLUSTERED 
(
	[CustomerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employees]    Script Date: 4/25/2022 8:38:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employees](
	[EmployeeID] [int] NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[PhoneNumber] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[JobID] [nvarchar](50) NOT NULL,
	[StatusID] [int] NOT NULL,
 CONSTRAINT [PK_Employees] PRIMARY KEY CLUSTERED 
(
	[EmployeeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[JobPositions]    Script Date: 4/25/2022 8:38:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[JobPositions](
	[JobID] [nvarchar](50) NOT NULL,
	[JobTitle] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_JobPositions] PRIMARY KEY CLUSTERED 
(
	[JobID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderDetails]    Script Date: 4/25/2022 8:38:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderDetails](
	[OrderID] [int] NOT NULL,
	[ISBN] [nvarchar](50) NOT NULL,
	[QuantityOrdered] [int] NOT NULL,
 CONSTRAINT [PK_OrderDetails] PRIMARY KEY CLUSTERED 
(
	[OrderID] ASC,
	[ISBN] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 4/25/2022 8:38:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[OrderID] [int] NOT NULL,
	[OrderDate] [datetime] NOT NULL,
	[OrderType] [nvarchar](50) NOT NULL,
	[RequiredDate] [datetime] NOT NULL,
	[Shippingdate] [datetime] NOT NULL,
	[StatusID] [int] NOT NULL,
	[EmployeeID] [int] NOT NULL,
	[CustomerID] [int] NOT NULL,
	[Payment] [int] NOT NULL,
 CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED 
(
	[OrderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Publishers]    Script Date: 4/25/2022 8:38:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Publishers](
	[PublisherID] [int] NOT NULL,
	[PublisherName] [nvarchar](50) NOT NULL,
	[WebAddress] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Publishers] PRIMARY KEY CLUSTERED 
(
	[PublisherID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Status]    Script Date: 4/25/2022 8:38:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Status](
	[StatusId] [int] NOT NULL,
	[State] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Status] PRIMARY KEY CLUSTERED 
(
	[StatusId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserAccounts]    Script Date: 4/25/2022 8:38:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserAccounts](
	[UserID] [int] NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[EmployeeID] [int] NOT NULL,
 CONSTRAINT [PK_UserAccounts] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Books] ([ISBN], [BookTitle], [UnitPrice], [YearPublished], [QOH], [CategoryID], [PublisherID]) VALUES (N'111110', N'True Love Story', CAST(15.00 AS Decimal(18, 2)), CAST(N'2020-01-01' AS Date), 50, 32, 2)
GO
INSERT [dbo].[Categories] ([CategoryID], [CategoryName]) VALUES (30, N'Story Book')
INSERT [dbo].[Categories] ([CategoryID], [CategoryName]) VALUES (31, N'Nowel')
INSERT [dbo].[Categories] ([CategoryID], [CategoryName]) VALUES (32, N'True story')
GO
INSERT [dbo].[Customers] ([CustomerID], [CustomerName], [StreetAddress], [City], [PostalCode], [PhoneNumber], [FaxNumber], [CreditLimit], [Email]) VALUES (123456, N'Raj', N'Ridgewood', N'Montreal', N'H3H 1L1', N'(666) 666-6666', N'ABC123', 10000, N'raj@gmail.com')
GO
INSERT [dbo].[Employees] ([EmployeeID], [FirstName], [LastName], [PhoneNumber], [Email], [JobID], [StatusID]) VALUES (1011, N'Henry', N'Brown', N'1111111111', N'henry@gmail.com', N'1111', 1001)
INSERT [dbo].[Employees] ([EmployeeID], [FirstName], [LastName], [PhoneNumber], [Email], [JobID], [StatusID]) VALUES (1012, N'Thomas', N'Moore', N'2222222222', N'Thomas@gmail.com', N'2222', 1001)
INSERT [dbo].[Employees] ([EmployeeID], [FirstName], [LastName], [PhoneNumber], [Email], [JobID], [StatusID]) VALUES (1013, N'Peter', N'Wang', N'3333333333', N'Peter@gmail.com', N'3333', 1002)
INSERT [dbo].[Employees] ([EmployeeID], [FirstName], [LastName], [PhoneNumber], [Email], [JobID], [StatusID]) VALUES (1014, N'Mary', N'Brown', N'4444444444', N'Mary@gmail.com', N'4444', 1001)
INSERT [dbo].[Employees] ([EmployeeID], [FirstName], [LastName], [PhoneNumber], [Email], [JobID], [StatusID]) VALUES (1015, N'Jennifer', N'Bouchard', N'5555555555', N'Jennifer@gmail.com', N'4444', 1002)
INSERT [dbo].[Employees] ([EmployeeID], [FirstName], [LastName], [PhoneNumber], [Email], [JobID], [StatusID]) VALUES (1016, N'raj', N'ratan', N'(666) 666-6666', N'raj@gmail.com', N'1111', 1001)
INSERT [dbo].[Employees] ([EmployeeID], [FirstName], [LastName], [PhoneNumber], [Email], [JobID], [StatusID]) VALUES (1017, N'raj', N'ratan', N'(777) 777-7777', N'raj@gmail.com', N'2222', 1002)
GO
INSERT [dbo].[JobPositions] ([JobID], [JobTitle]) VALUES (N'1111', N'MIS Manager')
INSERT [dbo].[JobPositions] ([JobID], [JobTitle]) VALUES (N'2222', N'Sales Manager')
INSERT [dbo].[JobPositions] ([JobID], [JobTitle]) VALUES (N'3333', N'Inventory Controller')
INSERT [dbo].[JobPositions] ([JobID], [JobTitle]) VALUES (N'4444', N'Order Clerks')
GO
INSERT [dbo].[Orders] ([OrderID], [OrderDate], [OrderType], [RequiredDate], [Shippingdate], [StatusID], [EmployeeID], [CustomerID], [Payment]) VALUES (9009, CAST(N'2022-04-25T00:00:00.000' AS DateTime), N'Book', CAST(N'2022-04-25T00:00:00.000' AS DateTime), CAST(N'2022-04-25T00:00:00.000' AS DateTime), 1001, 1015, 123456, 100)
GO
INSERT [dbo].[Publishers] ([PublisherID], [PublisherName], [WebAddress]) VALUES (1, N'Revenue Books', N'www.revenue.com')
INSERT [dbo].[Publishers] ([PublisherID], [PublisherName], [WebAddress]) VALUES (2, N'Bindoo Books', N'www.bindoo.com')
INSERT [dbo].[Publishers] ([PublisherID], [PublisherName], [WebAddress]) VALUES (3, N'navneet', N'www.navneet.com')
GO
INSERT [dbo].[Status] ([StatusId], [State]) VALUES (1001, N'Active')
INSERT [dbo].[Status] ([StatusId], [State]) VALUES (1002, N'Inactive')
INSERT [dbo].[Status] ([StatusId], [State]) VALUES (1003, N'Deleted')
GO
INSERT [dbo].[UserAccounts] ([UserID], [Password], [EmployeeID]) VALUES (2001, N'Henry@1011', 1011)
INSERT [dbo].[UserAccounts] ([UserID], [Password], [EmployeeID]) VALUES (2002, N'Thomas@1012', 1012)
INSERT [dbo].[UserAccounts] ([UserID], [Password], [EmployeeID]) VALUES (2003, N'Peter@1013', 1013)
INSERT [dbo].[UserAccounts] ([UserID], [Password], [EmployeeID]) VALUES (2004, N'Mary@1014', 1014)
INSERT [dbo].[UserAccounts] ([UserID], [Password], [EmployeeID]) VALUES (2005, N'Jennifer@1015', 1015)
GO
ALTER TABLE [dbo].[AuthorBooks]  WITH CHECK ADD  CONSTRAINT [FK_AuthorBooks_Authors] FOREIGN KEY([AuthorID])
REFERENCES [dbo].[Authors] ([AuthorID])
GO
ALTER TABLE [dbo].[AuthorBooks] CHECK CONSTRAINT [FK_AuthorBooks_Authors]
GO
ALTER TABLE [dbo].[AuthorBooks]  WITH CHECK ADD  CONSTRAINT [FK_AuthorBooks_Books] FOREIGN KEY([ISBN])
REFERENCES [dbo].[Books] ([ISBN])
GO
ALTER TABLE [dbo].[AuthorBooks] CHECK CONSTRAINT [FK_AuthorBooks_Books]
GO
ALTER TABLE [dbo].[Books]  WITH CHECK ADD  CONSTRAINT [FK_Books_Categories] FOREIGN KEY([CategoryID])
REFERENCES [dbo].[Categories] ([CategoryID])
GO
ALTER TABLE [dbo].[Books] CHECK CONSTRAINT [FK_Books_Categories]
GO
ALTER TABLE [dbo].[Books]  WITH CHECK ADD  CONSTRAINT [FK_Books_Publishers] FOREIGN KEY([PublisherID])
REFERENCES [dbo].[Publishers] ([PublisherID])
GO
ALTER TABLE [dbo].[Books] CHECK CONSTRAINT [FK_Books_Publishers]
GO
ALTER TABLE [dbo].[Employees]  WITH CHECK ADD  CONSTRAINT [FK_Employees_JobPositions] FOREIGN KEY([JobID])
REFERENCES [dbo].[JobPositions] ([JobID])
GO
ALTER TABLE [dbo].[Employees] CHECK CONSTRAINT [FK_Employees_JobPositions]
GO
ALTER TABLE [dbo].[Employees]  WITH CHECK ADD  CONSTRAINT [FK_Employees_Status] FOREIGN KEY([StatusID])
REFERENCES [dbo].[Status] ([StatusId])
GO
ALTER TABLE [dbo].[Employees] CHECK CONSTRAINT [FK_Employees_Status]
GO
ALTER TABLE [dbo].[OrderDetails]  WITH CHECK ADD  CONSTRAINT [FK_OrderDetails_Books] FOREIGN KEY([ISBN])
REFERENCES [dbo].[Books] ([ISBN])
GO
ALTER TABLE [dbo].[OrderDetails] CHECK CONSTRAINT [FK_OrderDetails_Books]
GO
ALTER TABLE [dbo].[OrderDetails]  WITH CHECK ADD  CONSTRAINT [FK_OrderDetails_Orders] FOREIGN KEY([OrderID])
REFERENCES [dbo].[Orders] ([OrderID])
GO
ALTER TABLE [dbo].[OrderDetails] CHECK CONSTRAINT [FK_OrderDetails_Orders]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Customers] FOREIGN KEY([CustomerID])
REFERENCES [dbo].[Customers] ([CustomerID])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_Customers]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Employees] FOREIGN KEY([EmployeeID])
REFERENCES [dbo].[Employees] ([EmployeeID])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_Employees]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Status] FOREIGN KEY([StatusID])
REFERENCES [dbo].[Status] ([StatusId])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_Status]
GO
ALTER TABLE [dbo].[UserAccounts]  WITH CHECK ADD  CONSTRAINT [FK_UserAccounts_Employees] FOREIGN KEY([EmployeeID])
REFERENCES [dbo].[Employees] ([EmployeeID])
GO
ALTER TABLE [dbo].[UserAccounts] CHECK CONSTRAINT [FK_UserAccounts_Employees]
GO
USE [master]
GO
ALTER DATABASE [HiTechDatabase] SET  READ_WRITE 
GO

USE [master]
GO
CREATE DATABASE [MMTShop]
GO
USE [MMTShop]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 4/28/2021 12:16:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 4/28/2021 12:16:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](100) NULL,
	[SKUStart] [int] NOT NULL,
	[SKUEnd] [int] NOT NULL,
	[CanBeFeatured] [bit] NOT NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 4/28/2021 12:16:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[Id] [uniqueidentifier] NOT NULL,
	[SKU] [int] NOT NULL,
	[Name] [nvarchar](100) NULL,
	[Description] [nvarchar](500) NULL,
	[Price] [decimal](19, 4) NOT NULL,
	[IsFeatured] [bit] NOT NULL,
	[CreateDate] [datetime2](7) NOT NULL,
	[ModifyDate] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210427164541_Initial', N'3.1.3')
GO
INSERT [dbo].[Category] ([Id], [Name], [SKUStart], [SKUEnd], [CanBeFeatured]) VALUES (N'34e336dd-07fe-47cf-b6ee-0fb8e03d43e6', N'Electronics', 30000, 40000, 1)
GO
INSERT [dbo].[Category] ([Id], [Name], [SKUStart], [SKUEnd], [CanBeFeatured]) VALUES (N'550053c8-b842-441f-9a11-566c928399ce', N'Garden', 20000, 30000, 1)
GO
INSERT [dbo].[Category] ([Id], [Name], [SKUStart], [SKUEnd], [CanBeFeatured]) VALUES (N'4b11446b-89f4-45d9-a99d-b22cbecf60c5', N'Home', 10000, 20000, 1)
GO
INSERT [dbo].[Category] ([Id], [Name], [SKUStart], [SKUEnd], [CanBeFeatured]) VALUES (N'be2c4fa7-653f-49f5-9c81-be7ff77fdf85', N'Fitness', 40000, 50000, 0)
GO
INSERT [dbo].[Category] ([Id], [Name], [SKUStart], [SKUEnd], [CanBeFeatured]) VALUES (N'85b36747-2770-40ae-92f8-c8347a3b44b7', N'Toys', 50000, 60000, 0)
GO
INSERT [dbo].[Product] ([Id], [SKU], [Name], [Description], [Price], [IsFeatured], [CreateDate], [ModifyDate]) VALUES (N'73795f5c-c79e-4ea5-92ec-092e1a8b7e78', 10000, N'Product 1', N'Product Description 1', CAST(100.0000 AS Decimal(19, 4)), 1, CAST(N'2021-04-27T17:46:04.8715329' AS DateTime2), CAST(N'2021-04-27T17:46:04.8722408' AS DateTime2))
GO
INSERT [dbo].[Product] ([Id], [SKU], [Name], [Description], [Price], [IsFeatured], [CreateDate], [ModifyDate]) VALUES (N'4fcd2591-cb4e-4f2a-92f4-4a6221278284', 10001, N'Product 2', N'Product Description 2', CAST(200.0000 AS Decimal(19, 4)), 0, CAST(N'2021-04-27T17:46:04.8959694' AS DateTime2), CAST(N'2021-04-27T17:46:04.8959734' AS DateTime2))
GO
INSERT [dbo].[Product] ([Id], [SKU], [Name], [Description], [Price], [IsFeatured], [CreateDate], [ModifyDate]) VALUES (N'c4d40240-f5f9-4df0-b57e-94372b7bb861', 20000, N'Product 3', N'Product Description 3', CAST(300.0000 AS Decimal(19, 4)), 1, CAST(N'2021-04-27T17:46:04.8960649' AS DateTime2), CAST(N'2021-04-27T17:46:04.8960659' AS DateTime2))
GO
INSERT [dbo].[Product] ([Id], [SKU], [Name], [Description], [Price], [IsFeatured], [CreateDate], [ModifyDate]) VALUES (N'91da1033-592c-4501-bc3d-adff33256b77', 40000, N'Product 5', N'Product Description 5', CAST(500.0000 AS Decimal(19, 4)), 1, CAST(N'2021-04-27T17:46:04.8961366' AS DateTime2), CAST(N'2021-04-27T17:46:04.8961374' AS DateTime2))
GO
INSERT [dbo].[Product] ([Id], [SKU], [Name], [Description], [Price], [IsFeatured], [CreateDate], [ModifyDate]) VALUES (N'3139d8de-3ef6-4240-8f66-e03f2c53d78d', 50000, N'Product 6', N'Product Description 6', CAST(600.0000 AS Decimal(19, 4)), 0, CAST(N'2021-04-27T17:46:04.8961552' AS DateTime2), CAST(N'2021-04-27T17:46:04.8961559' AS DateTime2))
GO
INSERT [dbo].[Product] ([Id], [SKU], [Name], [Description], [Price], [IsFeatured], [CreateDate], [ModifyDate]) VALUES (N'ac91480b-7c32-4ad2-828d-e5cabaed0f99', 30000, N'Product 4', N'Product Description 4', CAST(400.0000 AS Decimal(19, 4)), 1, CAST(N'2021-04-27T17:46:04.8960866' AS DateTime2), CAST(N'2021-04-27T17:46:04.8960872' AS DateTime2))
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Product_Name]    Script Date: 4/28/2021 12:16:28 AM ******/
CREATE NONCLUSTERED INDEX [IX_Product_Name] ON [dbo].[Product]
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Product_SKU]    Script Date: 4/28/2021 12:16:28 AM ******/
CREATE NONCLUSTERED INDEX [IX_Product_SKU] ON [dbo].[Product]
(
	[SKU] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[uspGetFeaturedProducts]    Script Date: 4/28/2021 12:16:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[uspGetFeaturedProducts]
AS
SELECT p.* 
FROM Product p
JOIN Category c ON p.SKU >= c.SKUStart AND p.SKU < c.SKUEnd
WHERE p.IsFeatured = 1
AND c.CanBeFeatured = 1

/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 5/16/2022 9:41:10 AM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Accounts]    Script Date: 5/16/2022 9:41:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Accounts](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Email] [nvarchar](max) NOT NULL,
	[Password] [nvarchar](max) NOT NULL,
	[CreateDate] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Accounts] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AdminRoleMaps]    Script Date: 5/16/2022 9:41:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AdminRoleMaps](
	[AdminId] [bigint] NOT NULL,
	[RoleId] [bigint] NOT NULL,
	[CreateDate] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_AdminRoleMaps] PRIMARY KEY CLUSTERED 
(
	[AdminId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Admins]    Script Date: 5/16/2022 9:41:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Admins](
	[Id] [bigint] NOT NULL,
 CONSTRAINT [PK_Admins] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderProductMaps]    Script Date: 5/16/2022 9:41:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderProductMaps](
	[OrderId] [bigint] NOT NULL,
	[ProductId] [bigint] NOT NULL,
	[CreateDate] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_OrderProductMaps] PRIMARY KEY CLUSTERED 
(
	[OrderId] ASC,
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 5/16/2022 9:41:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Status] [int] NOT NULL,
	[UserId] [bigint] NOT NULL,
	[ShippingCompanyId] [bigint] NOT NULL,
	[ProductId] [bigint] NULL,
	[CreateDate] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductCategories]    Script Date: 5/16/2022 9:41:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductCategories](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Slug] [nvarchar](max) NOT NULL,
	[ShippingCompanyId] [bigint] NOT NULL,
	[CreateDate] [datetime2](7) NOT NULL,
	[IsCancellationRequiresConfirmation] [bit] NOT NULL,
 CONSTRAINT [PK_ProductCategories] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 5/16/2022 9:41:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Slug] [nvarchar](max) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[Quantity] [int] NOT NULL,
	[CategoryId] [bigint] NOT NULL,
	[CreateDate] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 5/16/2022 9:41:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[CreateDate] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ShippingCompanies]    Script Date: 5/16/2022 9:41:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ShippingCompanies](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[CreateDate] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_ShippingCompanies] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 5/16/2022 9:41:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [bigint] NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220515204408_Initial', N'5.0.17')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220516055101_IsCancellationRequiresConfirmationAddToProductCategory', N'5.0.17')
GO
SET IDENTITY_INSERT [dbo].[Accounts] ON 

INSERT [dbo].[Accounts] ([Id], [Email], [Password], [CreateDate]) VALUES (2, N'ebru@user.com', N'123456', CAST(N'2021-05-16T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Accounts] ([Id], [Email], [Password], [CreateDate]) VALUES (3, N'ebru@admin.com', N'123456', CAST(N'2022-05-16T00:00:00.0000000' AS DateTime2))
SET IDENTITY_INSERT [dbo].[Accounts] OFF
GO
INSERT [dbo].[AdminRoleMaps] ([AdminId], [RoleId], [CreateDate]) VALUES (3, 1, CAST(N'2022-05-16T00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[Admins] ([Id]) VALUES (3)
GO
INSERT [dbo].[OrderProductMaps] ([OrderId], [ProductId], [CreateDate]) VALUES (1, 1, CAST(N'2022-05-16T05:31:56.1921270' AS DateTime2))
INSERT [dbo].[OrderProductMaps] ([OrderId], [ProductId], [CreateDate]) VALUES (2, 2, CAST(N'2022-05-16T06:18:16.1586970' AS DateTime2))
GO
SET IDENTITY_INSERT [dbo].[Orders] ON 

INSERT [dbo].[Orders] ([Id], [Status], [UserId], [ShippingCompanyId], [ProductId], [CreateDate]) VALUES (1, 5, 2, 1, NULL, CAST(N'2022-05-16T05:31:56.1919620' AS DateTime2))
INSERT [dbo].[Orders] ([Id], [Status], [UserId], [ShippingCompanyId], [ProductId], [CreateDate]) VALUES (2, 5, 2, 2, NULL, CAST(N'2022-05-16T06:18:16.1585140' AS DateTime2))
SET IDENTITY_INSERT [dbo].[Orders] OFF
GO
SET IDENTITY_INSERT [dbo].[ProductCategories] ON 

INSERT [dbo].[ProductCategories] ([Id], [Name], [Slug], [ShippingCompanyId], [CreateDate], [IsCancellationRequiresConfirmation]) VALUES (1, N'Giyim', N'giyim', 1, CAST(N'2022-05-15T00:00:00.0000000' AS DateTime2), 0)
INSERT [dbo].[ProductCategories] ([Id], [Name], [Slug], [ShippingCompanyId], [CreateDate], [IsCancellationRequiresConfirmation]) VALUES (2, N'Gida', N'gida', 2, CAST(N'2022-05-15T00:00:00.0000000' AS DateTime2), 1)
SET IDENTITY_INSERT [dbo].[ProductCategories] OFF
GO
SET IDENTITY_INSERT [dbo].[Products] ON 

INSERT [dbo].[Products] ([Id], [Name], [Slug], [Description], [Quantity], [CategoryId], [CreateDate]) VALUES (1, N'Thsirt', N'thsirt', N'Lorem ipsum dolor sit amet.', 9, 1, CAST(N'2022-05-15T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Products] ([Id], [Name], [Slug], [Description], [Quantity], [CategoryId], [CreateDate]) VALUES (2, N'Chocolate', N'chocolate', N'Lorem ipsum dolor sit amet.', 9, 2, CAST(N'2022-05-15T00:00:00.0000000' AS DateTime2))
SET IDENTITY_INSERT [dbo].[Products] OFF
GO
SET IDENTITY_INSERT [dbo].[Roles] ON 

INSERT [dbo].[Roles] ([Id], [Name], [Description], [CreateDate]) VALUES (1, N'cancel-confirmation', N'iptal-onay yetkisi', CAST(N'2022-05-16T00:00:00.0000000' AS DateTime2))
SET IDENTITY_INSERT [dbo].[Roles] OFF
GO
SET IDENTITY_INSERT [dbo].[ShippingCompanies] ON 

INSERT [dbo].[ShippingCompanies] ([Id], [Name], [CreateDate]) VALUES (1, N'Aras Kargo', CAST(N'2022-05-15T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[ShippingCompanies] ([Id], [Name], [CreateDate]) VALUES (2, N'Yurtiçi Kargo', CAST(N'2022-05-15T00:00:00.0000000' AS DateTime2))
SET IDENTITY_INSERT [dbo].[ShippingCompanies] OFF
GO
INSERT [dbo].[Users] ([Id]) VALUES (2)
GO
ALTER TABLE [dbo].[ProductCategories] ADD  DEFAULT (CONVERT([bit],(0))) FOR [IsCancellationRequiresConfirmation]
GO
ALTER TABLE [dbo].[AdminRoleMaps]  WITH CHECK ADD  CONSTRAINT [FK_AdminRoleMaps_Admins_AdminId] FOREIGN KEY([AdminId])
REFERENCES [dbo].[Admins] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AdminRoleMaps] CHECK CONSTRAINT [FK_AdminRoleMaps_Admins_AdminId]
GO
ALTER TABLE [dbo].[AdminRoleMaps]  WITH CHECK ADD  CONSTRAINT [FK_AdminRoleMaps_Roles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Roles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AdminRoleMaps] CHECK CONSTRAINT [FK_AdminRoleMaps_Roles_RoleId]
GO
ALTER TABLE [dbo].[Admins]  WITH CHECK ADD  CONSTRAINT [FK_Admins_Accounts_Id] FOREIGN KEY([Id])
REFERENCES [dbo].[Accounts] ([Id])
GO
ALTER TABLE [dbo].[Admins] CHECK CONSTRAINT [FK_Admins_Accounts_Id]
GO
ALTER TABLE [dbo].[OrderProductMaps]  WITH CHECK ADD  CONSTRAINT [FK_OrderProductMaps_Orders_OrderId] FOREIGN KEY([OrderId])
REFERENCES [dbo].[Orders] ([Id])
GO
ALTER TABLE [dbo].[OrderProductMaps] CHECK CONSTRAINT [FK_OrderProductMaps_Orders_OrderId]
GO
ALTER TABLE [dbo].[OrderProductMaps]  WITH CHECK ADD  CONSTRAINT [FK_OrderProductMaps_Products_ProductId] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products] ([Id])
GO
ALTER TABLE [dbo].[OrderProductMaps] CHECK CONSTRAINT [FK_OrderProductMaps_Products_ProductId]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Products_ProductId] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products] ([Id])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_Products_ProductId]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_ShippingCompanies_ShippingCompanyId] FOREIGN KEY([ShippingCompanyId])
REFERENCES [dbo].[ShippingCompanies] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_ShippingCompanies_ShippingCompanyId]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Users_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_Users_UserId]
GO
ALTER TABLE [dbo].[ProductCategories]  WITH CHECK ADD  CONSTRAINT [FK_ProductCategories_ShippingCompanies_ShippingCompanyId] FOREIGN KEY([ShippingCompanyId])
REFERENCES [dbo].[ShippingCompanies] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ProductCategories] CHECK CONSTRAINT [FK_ProductCategories_ShippingCompanies_ShippingCompanyId]
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Products_ProductCategories_CategoryId] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[ProductCategories] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_Products_ProductCategories_CategoryId]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_Accounts_Id] FOREIGN KEY([Id])
REFERENCES [dbo].[Accounts] ([Id])
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_Accounts_Id]
GO

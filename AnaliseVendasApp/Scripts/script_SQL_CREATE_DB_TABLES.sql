USE [master]
GO
/****** Object:  Database [AnaliseVendas]    Script Date: 22/03/2020 23:54:48 ******/
CREATE DATABASE [AnaliseVendas]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'AnaliseVendas', FILENAME = N'C:\Users\Felipe_LAPTOP\AppData\Local\Microsoft\Microsoft SQL Server Local DB\Instances\MSSQLLocalDB\AnaliseVendas.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'AnaliseVendas_log', FILENAME = N'C:\Users\Felipe_LAPTOP\AppData\Local\Microsoft\Microsoft SQL Server Local DB\Instances\MSSQLLocalDB\AnaliseVendas.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [AnaliseVendas].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [AnaliseVendas] SET ANSI_NULL_DEFAULT ON 
GO
ALTER DATABASE [AnaliseVendas] SET ANSI_NULLS ON 
GO
ALTER DATABASE [AnaliseVendas] SET ANSI_PADDING ON 
GO
ALTER DATABASE [AnaliseVendas] SET ANSI_WARNINGS ON 
GO
ALTER DATABASE [AnaliseVendas] SET ARITHABORT ON 
GO
ALTER DATABASE [AnaliseVendas] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [AnaliseVendas] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [AnaliseVendas] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [AnaliseVendas] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [AnaliseVendas] SET CURSOR_DEFAULT  LOCAL 
GO
ALTER DATABASE [AnaliseVendas] SET CONCAT_NULL_YIELDS_NULL ON 
GO
ALTER DATABASE [AnaliseVendas] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [AnaliseVendas] SET QUOTED_IDENTIFIER ON 
GO
ALTER DATABASE [AnaliseVendas] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [AnaliseVendas] SET  DISABLE_BROKER 
GO
ALTER DATABASE [AnaliseVendas] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [AnaliseVendas] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [AnaliseVendas] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [AnaliseVendas] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [AnaliseVendas] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [AnaliseVendas] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [AnaliseVendas] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [AnaliseVendas] SET RECOVERY FULL 
GO
ALTER DATABASE [AnaliseVendas] SET  MULTI_USER 
GO
ALTER DATABASE [AnaliseVendas] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [AnaliseVendas] SET DB_CHAINING OFF 
GO
ALTER DATABASE [AnaliseVendas] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [AnaliseVendas] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [AnaliseVendas] SET DELAYED_DURABILITY = DISABLED 
GO
USE [AnaliseVendas]
GO
/****** Object:  Table [dbo].[Cliente]    Script Date: 22/03/2020 23:54:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Cliente](
	[Id] [varchar](16) NOT NULL,
	[name] [nchar](100) NULL,
	[businessArea] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING ON
GO
/****** Object:  Table [dbo].[Item]    Script Date: 22/03/2020 23:54:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Item](
	[id] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Venda]    Script Date: 22/03/2020 23:54:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Venda](
	[Id] [int] NOT NULL,
	[vendedorId] [varchar](13) NULL,
 CONSTRAINT [PK_Venda] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING ON
GO
/****** Object:  Table [dbo].[VendaItem]    Script Date: 22/03/2020 23:54:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VendaItem](
	[vendaId] [int] NOT NULL,
	[itemId] [int] NOT NULL,
	[quantity] [int] NULL,
	[price] [float] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Vendedor]    Script Date: 22/03/2020 23:54:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Vendedor](
	[Id] [varchar](13) NOT NULL,
	[name] [varchar](100) NULL,
	[salary] [float] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING ON
GO
INSERT [dbo].[Cliente] ([Id], [name], [businessArea]) VALUES (N'2345675433444345', N'Eduardo Pereira                                                                                     ', N'Rural')
INSERT [dbo].[Cliente] ([Id], [name], [businessArea]) VALUES (N'2345675434544345', N'Jose da Silva                                                                                       ', N'Rural')
INSERT [dbo].[Item] ([id]) VALUES (1)
INSERT [dbo].[Item] ([id]) VALUES (2)
INSERT [dbo].[Item] ([id]) VALUES (3)
INSERT [dbo].[Venda] ([Id], [vendedorId]) VALUES (8, N'3245678865434')
INSERT [dbo].[Venda] ([Id], [vendedorId]) VALUES (10, N'1234567891234')
INSERT [dbo].[VendaItem] ([vendaId], [itemId], [quantity], [price]) VALUES (10, 1, 10, 100)
INSERT [dbo].[VendaItem] ([vendaId], [itemId], [quantity], [price]) VALUES (10, 2, 30, 2.5)
INSERT [dbo].[VendaItem] ([vendaId], [itemId], [quantity], [price]) VALUES (10, 3, 40, 3.1)
INSERT [dbo].[VendaItem] ([vendaId], [itemId], [quantity], [price]) VALUES (8, 1, 34, 10)
INSERT [dbo].[VendaItem] ([vendaId], [itemId], [quantity], [price]) VALUES (8, 2, 33, 1.5)
INSERT [dbo].[VendaItem] ([vendaId], [itemId], [quantity], [price]) VALUES (8, 3, 40, 0.1)
INSERT [dbo].[Vendedor] ([Id], [name], [salary]) VALUES (N'1234567891234', N'Pedro', 50000)
INSERT [dbo].[Vendedor] ([Id], [name], [salary]) VALUES (N'3245678865434', N'Paulo', 4000099)
/****** Object:  Index [pk_VendaItem]    Script Date: 22/03/2020 23:54:49 ******/
ALTER TABLE [dbo].[VendaItem] ADD  CONSTRAINT [pk_VendaItem] PRIMARY KEY NONCLUSTERED 
(
	[itemId] ASC,
	[vendaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [idx_fk_vendaItem_item]    Script Date: 22/03/2020 23:54:49 ******/
CREATE NONCLUSTERED INDEX [idx_fk_vendaItem_item] ON [dbo].[VendaItem]
(
	[itemId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [idx_fk_vendaItem_venda]    Script Date: 22/03/2020 23:54:49 ******/
CREATE NONCLUSTERED INDEX [idx_fk_vendaItem_venda] ON [dbo].[VendaItem]
(
	[vendaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Venda]  WITH CHECK ADD  CONSTRAINT [FK_Venda_Vendedor] FOREIGN KEY([vendedorId])
REFERENCES [dbo].[Vendedor] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Venda] CHECK CONSTRAINT [FK_Venda_Vendedor]
GO
ALTER TABLE [dbo].[VendaItem]  WITH CHECK ADD  CONSTRAINT [FK_VendaItem_Item] FOREIGN KEY([itemId])
REFERENCES [dbo].[Item] ([id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[VendaItem] CHECK CONSTRAINT [FK_VendaItem_Item]
GO
ALTER TABLE [dbo].[VendaItem]  WITH CHECK ADD  CONSTRAINT [FK_VendaItem_Venda] FOREIGN KEY([vendaId])
REFERENCES [dbo].[Venda] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[VendaItem] CHECK CONSTRAINT [FK_VendaItem_Venda]
GO
USE [master]
GO
ALTER DATABASE [AnaliseVendas] SET  READ_WRITE 
GO

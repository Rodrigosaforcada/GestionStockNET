USE [Prog3RecurGoya]
GO

/****** Object:  Table [dbo].[Usuario]    Script Date: 21/6/2024 19:55:48 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Usuario](
	[UsuarioId] [int] NOT NULL,
	[Nombre] [nvarchar](50) NOT NULL,
	[Hash] [nvarchar](50) NOT NULL,
	[Salt] [nvarchar](50) NOT NULL
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[Categoria]    Script Date: 21/6/2024 19:56:09 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Categoria](
	[CategoriaId] [int] NOT NULL,
	[Nombre] [nvarchar](50) NOT NULL
) ON [PRIMARY]
GO


/****** Object:  Table [dbo].[Producto]    Script Date: 21/6/2024 19:56:45 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Producto](
	[ProductoId] [int] NOT NULL,
	[Nombre] [nvarchar](50) NOT NULL,
	[CategoriaId] [int] NOT NULL,
	[Habilitado] [bit] NOT NULL
) ON [PRIMARY]
GO


/****** Object:  Table [dbo].[Compra]    Script Date: 21/6/2024 19:57:08 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Compra](
	[CompraId] [int] NOT NULL,
	[Fecha] [datetime] NOT NULL,
	[ProductoId] [int] NOT NULL,
	[Cantidad] [int] NOT NULL,
	[UsuarioId] [int] NOT NULL
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[Venta]    Script Date: 21/6/2024 19:57:29 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Venta](
	[VentaId] [int] NOT NULL,
	[Fecha] [datetime] NOT NULL,
	[ProductoId] [int] NOT NULL,
	[Cantidad] [int] NOT NULL,
	[UsuarioId] [int] NOT NULL
) ON [PRIMARY]
GO
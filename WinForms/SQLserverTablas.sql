USE [Prueba]
GO
/****** Object:  Table [dbo].[Productos]    Script Date: 24/6/2024 16:17:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Productos](
	[productoId] [int] IDENTITY(1,1) NOT NULL,
	[nombreProducto] [varchar](50) NULL,
	[cantidad] [int] NULL,
	[categoria] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[productoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

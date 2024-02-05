USE [DbOsiguVuelos]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 4/02/2024 10:13:30 p. m. ******/
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
/****** Object:  Table [dbo].[Aereolinias]    Script Date: 4/02/2024 10:13:30 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Aereolinias](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Aereolinias] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ciudades]    Script Date: 4/02/2024 10:13:30 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ciudades](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Ciudades] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuarios]    Script Date: 4/02/2024 10:13:30 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuarios](
	[Id] [uniqueidentifier] NOT NULL,
	[NombreUsuario] [nvarchar](50) NOT NULL,
	[Contrasena] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](200) NOT NULL,
	[NombreCompleto] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Usuarios] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Vuelos]    Script Date: 4/02/2024 10:13:30 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Vuelos](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[NumeroVuelo] [int] NOT NULL,
	[CiudadOrigenId] [int] NOT NULL,
	[CiudadDestinoId] [int] NOT NULL,
	[Fecha] [datetime2](7) NOT NULL,
	[HoraSalida] [time](7) NOT NULL,
	[HoraLlegada] [time](7) NOT NULL,
	[AerolineaId] [int] NOT NULL,
	[Estado] [int] NOT NULL,
	[UsuarioCreacionId] [uniqueidentifier] NOT NULL,
	[FechaCreacion] [datetime2](7) NOT NULL,
	[UsuarioActualizacionId] [uniqueidentifier] NULL,
	[FechaActualizacion] [datetime2](7) NULL,
 CONSTRAINT [PK_Vuelos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240204035818_InicializaiconDeBaseDeDatos', N'7.0.11')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240204053330_EliminaColumnLKey', N'7.0.11')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240204070849_updateColomnsVuelos', N'7.0.11')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240204234806_actualizarColumnsAuditoriaVuelo', N'7.0.11')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240205001201_updateColumaAuditoriaVuelos', N'7.0.11')
GO
SET IDENTITY_INSERT [dbo].[Aereolinias] ON 
GO
INSERT [dbo].[Aereolinias] ([Id], [Nombre]) VALUES (1, N'Avianca')
GO
INSERT [dbo].[Aereolinias] ([Id], [Nombre]) VALUES (2, N'Satena')
GO
INSERT [dbo].[Aereolinias] ([Id], [Nombre]) VALUES (3, N'Click')
GO
SET IDENTITY_INSERT [dbo].[Aereolinias] OFF
GO
SET IDENTITY_INSERT [dbo].[Ciudades] ON 
GO
INSERT [dbo].[Ciudades] ([Id], [Nombre]) VALUES (1, N'Medellin - Antioquia')
GO
INSERT [dbo].[Ciudades] ([Id], [Nombre]) VALUES (2, N'Bogota - Antioquia')
GO
SET IDENTITY_INSERT [dbo].[Ciudades] OFF
GO
INSERT [dbo].[Usuarios] ([Id], [NombreUsuario], [Contrasena], [Email], [NombreCompleto]) VALUES (N'90628b8e-2ee4-4e8d-a2be-102342c8bffa', N'worerblack', N'123456789', N'worerblack@email.com', N'Kevin Santero')
GO
SET IDENTITY_INSERT [dbo].[Vuelos] ON 
GO
INSERT [dbo].[Vuelos] ([Id], [NumeroVuelo], [CiudadOrigenId], [CiudadDestinoId], [Fecha], [HoraSalida], [HoraLlegada], [AerolineaId], [Estado], [UsuarioCreacionId], [FechaCreacion], [UsuarioActualizacionId], [FechaActualizacion]) VALUES (1, 202400001, 1, 2, CAST(N'2024-02-04T00:00:00.0000000' AS DateTime2), CAST(N'01:00:00' AS Time), CAST(N'03:00:00' AS Time), 1, 1, N'90628b8e-2ee4-4e8d-a2be-102342c8bffa', CAST(N'2024-02-04T00:00:00.0000000' AS DateTime2), N'90628b8e-2ee4-4e8d-a2be-102342c8bffa', CAST(N'2024-02-04T00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[Vuelos] ([Id], [NumeroVuelo], [CiudadOrigenId], [CiudadDestinoId], [Fecha], [HoraSalida], [HoraLlegada], [AerolineaId], [Estado], [UsuarioCreacionId], [FechaCreacion], [UsuarioActualizacionId], [FechaActualizacion]) VALUES (2, 202400245, 2, 1, CAST(N'2024-02-04T00:00:00.0000000' AS DateTime2), CAST(N'05:00:00' AS Time), CAST(N'03:00:00' AS Time), 1, 1, N'90628b8e-2ee4-4e8d-a2be-102342c8bffa', CAST(N'2024-02-04T00:00:00.0000000' AS DateTime2), N'90628b8e-2ee4-4e8d-a2be-102342c8bffa', CAST(N'2024-02-04T00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[Vuelos] ([Id], [NumeroVuelo], [CiudadOrigenId], [CiudadDestinoId], [Fecha], [HoraSalida], [HoraLlegada], [AerolineaId], [Estado], [UsuarioCreacionId], [FechaCreacion], [UsuarioActualizacionId], [FechaActualizacion]) VALUES (5, 2024047, 2, 1, CAST(N'2024-02-04T21:52:18.6020000' AS DateTime2), CAST(N'11:00:00' AS Time), CAST(N'00:00:00' AS Time), 1, 1, N'90628b8e-2ee4-4e8d-a2be-102342c8bffa', CAST(N'2024-02-04T21:53:00.6295709' AS DateTime2), NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[Vuelos] OFF
GO
/****** Object:  Index [IX_Vuelos_AerolineaId]    Script Date: 4/02/2024 10:13:30 p. m. ******/
CREATE NONCLUSTERED INDEX [IX_Vuelos_AerolineaId] ON [dbo].[Vuelos]
(
	[AerolineaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Vuelos_CiudadDestinoId]    Script Date: 4/02/2024 10:13:30 p. m. ******/
CREATE NONCLUSTERED INDEX [IX_Vuelos_CiudadDestinoId] ON [dbo].[Vuelos]
(
	[CiudadDestinoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Vuelos_CiudadOrigenId]    Script Date: 4/02/2024 10:13:30 p. m. ******/
CREATE NONCLUSTERED INDEX [IX_Vuelos_CiudadOrigenId] ON [dbo].[Vuelos]
(
	[CiudadOrigenId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Vuelos_UsuarioActualizacionId]    Script Date: 4/02/2024 10:13:30 p. m. ******/
CREATE NONCLUSTERED INDEX [IX_Vuelos_UsuarioActualizacionId] ON [dbo].[Vuelos]
(
	[UsuarioActualizacionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Vuelos_UsuarioCreacionId]    Script Date: 4/02/2024 10:13:30 p. m. ******/
CREATE NONCLUSTERED INDEX [IX_Vuelos_UsuarioCreacionId] ON [dbo].[Vuelos]
(
	[UsuarioCreacionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Vuelos]  WITH CHECK ADD  CONSTRAINT [FK_Vuelos_Aereolinias_AerolineaId] FOREIGN KEY([AerolineaId])
REFERENCES [dbo].[Aereolinias] ([Id])
GO
ALTER TABLE [dbo].[Vuelos] CHECK CONSTRAINT [FK_Vuelos_Aereolinias_AerolineaId]
GO
ALTER TABLE [dbo].[Vuelos]  WITH CHECK ADD  CONSTRAINT [FK_Vuelos_Ciudades_CiudadDestinoId] FOREIGN KEY([CiudadDestinoId])
REFERENCES [dbo].[Ciudades] ([Id])
GO
ALTER TABLE [dbo].[Vuelos] CHECK CONSTRAINT [FK_Vuelos_Ciudades_CiudadDestinoId]
GO
ALTER TABLE [dbo].[Vuelos]  WITH CHECK ADD  CONSTRAINT [FK_Vuelos_Ciudades_CiudadOrigenId] FOREIGN KEY([CiudadOrigenId])
REFERENCES [dbo].[Ciudades] ([Id])
GO
ALTER TABLE [dbo].[Vuelos] CHECK CONSTRAINT [FK_Vuelos_Ciudades_CiudadOrigenId]
GO
ALTER TABLE [dbo].[Vuelos]  WITH CHECK ADD  CONSTRAINT [FK_Vuelos_Usuarios_UsuarioActualizacionId] FOREIGN KEY([UsuarioActualizacionId])
REFERENCES [dbo].[Usuarios] ([Id])
GO
ALTER TABLE [dbo].[Vuelos] CHECK CONSTRAINT [FK_Vuelos_Usuarios_UsuarioActualizacionId]
GO
ALTER TABLE [dbo].[Vuelos]  WITH CHECK ADD  CONSTRAINT [FK_Vuelos_Usuarios_UsuarioCreacionId] FOREIGN KEY([UsuarioCreacionId])
REFERENCES [dbo].[Usuarios] ([Id])
GO
ALTER TABLE [dbo].[Vuelos] CHECK CONSTRAINT [FK_Vuelos_Usuarios_UsuarioCreacionId]
GO

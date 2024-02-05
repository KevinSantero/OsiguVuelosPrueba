USE [DbOsiguVuelos]
GO

/****** Object:  View [dbo].[VmVuelos]    Script Date: 4/02/2024 10:20:09 p. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE   VIEW [dbo].[VmVuelos]
AS
SELECT vu.*,
       aero.Nombre as NombreAerolinia,
	   ciOrigen.Nombre as CiudadOrigen,
	   ciDestino.Nombre as CiudadDestino,
	   usuarioCreacion.NombreCompleto UsuarioCreacion,
	   usuarioActualizacion.NombreCompleto UsuarioActualizacion

FROM     dbo.Vuelos vu inner join Aereolinias aero on  aero.Id = vu.AerolineaId
         inner  join Ciudades ciOrigen on ciOrigen.Id = vu.CiudadOrigenId
		 inner  join Ciudades ciDestino on ciDestino.Id = vu.CiudadDestinoId
		 inner join Usuarios usuarioCreacion on usuarioCreacion.Id = vu.UsuarioCreacionId
		 left join   Usuarios usuarioActualizacion on usuarioActualizacion.Id = vu.UsuarioActualizacionId
GO



# PRÁCTICA NRC2257

Recopilación de todo lo hecho en clases

## Procedimientos Almacenados

### TipoMedicamento

```SQL
USE [BDFarmacia]
GO
/****** Object:  StoredProcedure [dbo].[uspListarTipoMedicamento]    Script Date: 24/02/2025 0:18:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[uspListarTipoMedicamento]
AS
BEGIN
    SELECT IIDTIPOMEDICAMENTO, NOMBRE, DESCRIPCION
    FROM TipoMedicamento
    WHERE BHABILITADO = 1;
END

---------------------------------------------------------------------------------------------------

USE [BDFarmacia]
GO
/****** Object:  StoredProcedure [dbo].[uspFiltrarTipoMedicamento]    Script Date: 24/02/2025 0:22:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER procedure [dbo].[uspFiltrarTipoMedicamento]
@descmedicamento varchar(100)
as
begin

if @descmedicamento=''
select *
from TipoMedicamento
where BHABILITADO=1
else
select *
from TipoMedicamento
where BHABILITADO=1 and DESCRIPCION like '%'+@descmedicamento+'%'

end

---------------------------------------------------------------------------------------------------

USE [BDFarmacia]
GO
/****** Object:  StoredProcedure [dbo].[uspGuardarTipoMedicamento]    Script Date: 24/02/2025 0:23:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[uspGuardarTipoMedicamento]
@nombre varchar(100),
@descripcion varchar(300)
as
begin
insert into TipoMedicamento(NOMBRE, DESCRIPCION, BHABILITADO) values(@nombre, @descripcion, 1)
end
```

### Sucursal

```SQL
USE [BDFarmacia]
GO
/****** Object:  StoredProcedure [dbo].[uspListarSucursal]    Script Date: 24/02/2025 0:19:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER procedure [dbo].[uspListarSucursal]
as
begin
select IIDSUCURSAL,NOMBRE,DIRECCION
from Sucursal
where BHABILITADO=1

end

---------------------------------------------------------------------------------------------------

USE [BDFarmacia]
GO
/****** Object:  StoredProcedure [dbo].[uspFiltrarSucursal]    Script Date: 24/02/2025 0:24:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER procedure [dbo].[uspFiltrarSucursal]
@nombre varchar(100),
@direccion varchar(100)
as
begin

declare @sql NVARCHAR(400)

SET @sql= 'select IIDSUCURSAL,NOMBRE,DIRECCION
from Sucursal
where BHABILITADO=1'

IF @nombre!=''
SET @sql=@sql+ ' AND NOMBRE LIKE ''%'+@nombre+'%'''
IF @direccion!=''
SET @sql=@sql+ ' AND DIRECCION LIKE ''%'+@direccion+'%'''

EXECUTE SP_EXECUTESQL @sql

end
```

### Laboratorio

```SQL
USE [BDFarmacia]
GO
/****** Object:  StoredProcedure [dbo].[uspListarLaboratorio]    Script Date: 24/02/2025 0:21:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[uspListarLaboratorio]
as
begin
select IIDLABORATORIO,NOMBRE,DIRECCION,PERSONACONTACTO
from Laboratorio
where BHABILITADO=1
end

---------------------------------------------------------------------------------------------------

USE [BDFarmacia]
GO
/****** Object:  StoredProcedure [dbo].[uspFiltrarLaboratorio]    Script Date: 24/02/2025 0:25:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER procedure [dbo].[uspFiltrarLaboratorio]
@nombre varchar(100),
@direccion varchar(100),
@personacontacto varchar(100)
as
begin

declare @sql NVARCHAR(400)

SET @sql= 'select IIDLABORATORIO,NOMBRE,DIRECCION,PERSONACONTACTO
from Laboratorio
where BHABILITADO=1'

IF @nombre!=''
SET @sql=@sql+ ' AND NOMBRE LIKE ''%'+@nombre+'%'''
IF @direccion!=''
SET @sql=@sql+ ' AND DIRECCION LIKE ''%'+@direccion+'%'''
IF @personacontacto!=''
SET @sql=@sql+ ' AND PERSONACONTACTO LIKE ''%'+@personacontacto+'%'''

EXECUTE SP_EXECUTESQL @sql

end
```
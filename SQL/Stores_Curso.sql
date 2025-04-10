go
use DBESCUELA
go
--************************ VALIDAMOS SI EXISTE EL PROCEDIMIENTO ************************--

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'cso_registrar')
DROP PROCEDURE cso_registrar

go

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'cso_modificar')
DROP PROCEDURE cso_modificar

go

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'cso_obtener')
DROP PROCEDURE cso_obtener

go

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'cso_listar')
DROP PROCEDURE cso_obtener

go

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'cso_eliminar')
DROP PROCEDURE cso_eliminar

go

--************************ PROCEDIMIENTOS PARA CREAR ************************--
create procedure cso_registrar(
@Nombre varchar(60),
@Descripcion varchar(60),
@Codigo_unico varchar(60)
)
as
begin

insert into CURSOS(Nombre,Descripcion,Codigo_unico)
values
(
@Nombre,
@Descripcion,
@Codigo_unico
)

end


go

create procedure cso_modificar(
@IdCurso int,
@Nombre varchar(60),
@Descripcion varchar(60),
@Codigo_unico varchar(60)
)
as
begin

update CURSOS set 
Nombre = @Nombre,
Descripcion = @Descripcion,
Codigo_unico = @Codigo_unico
where IdCurso = @IdCurso

end

go

create procedure cso_obtener(@IdCurso int)
as
begin

select * from CURSOS where IdCurso = @IdCurso
end

go
create procedure cso_listar
as
begin

select * from CURSOS
end


go

go

create procedure cso_eliminar(
@IdCurso int
)
as
begin

delete from CURSOS where IdCurso = @IdCurso

end

go

alter table maestro add edad int;


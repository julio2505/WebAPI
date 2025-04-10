go
use DBESCUELA
go
--************************ VALIDAMOS SI EXISTE EL PROCEDIMIENTO ************************--

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'amno_registrar')
DROP PROCEDURE amno_registrar

go

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'amno_modificar')
DROP PROCEDURE amno_modificar

go

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'amno_obtener')
DROP PROCEDURE amno_obtener

go

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'amno_listar')
DROP PROCEDURE amno_obtener

go

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'amno_eliminar')
DROP PROCEDURE amno_eliminar

go

--************************ PROCEDIMIENTOS PARA CREAR ************************--
create procedure amno_registrar(
@Nombre varchar(60),
@Apellido varchar(60),
@FechaNacimiento Datetime,
@Numero_unico varchar(60)
)
as
begin

insert into ALUMNO(Nombre,Apellido,FechaNacimiento,Numero_unico)
values
(
@Nombre,
@Apellido,
@FechaNacimiento,
@Numero_unico
)

end


go

create procedure amno_modificar(
@IdAlumno int,
@Nombre varchar(60),
@Apellido varchar(60),
@FechaNacimiento Datetime,
@Numero_unico varchar(60)
)
as
begin

update ALUMNO set 
Nombre = @Nombre,
Apellido = @Apellido,
FechaNacimiento = @FechaNacimiento,
Numero_unico = @Numero_unico
where IdAlumno = @IdAlumno

end

go

create procedure amno_obtener(@IdAlumno int)
as
begin

select * from ALUMNO where IdAlumno = @IdAlumno
end

go
create procedure amno_listar
as
begin

select * from ALUMNO
end


go

go

create procedure amno_eliminar(
@IdAlumno int
)
as
begin

delete from ALUMNO where IdAlumno = @IdAlumno

end

go


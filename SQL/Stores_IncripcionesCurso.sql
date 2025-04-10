go
use DBESCUELA
go
--************************ VALIDAMOS SI EXISTE EL PROCEDIMIENTO ************************--

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'icion_registrar')
DROP PROCEDURE icion_registrar

go

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'icion_modificar')
DROP PROCEDURE icion_modificar

go

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'icion_obtener')
DROP PROCEDURE icion_obtener

go

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'icion_listar')
DROP PROCEDURE icion_listar

go

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'icion_eliminar')
DROP PROCEDURE icion_eliminar

go

--************************ PROCEDIMIENTOS PARA CREAR ************************--
create procedure icion_registrar(
@IdAlumno int,
@IdCurso int
)
as
begin

insert into INSCRIPCIONES(IdAlumno,IdCurso)
values
(
@IdAlumno,
@IdCurso
)

end


go

create procedure icion_modificar(
@IdInscripciones int,
@IdAlumno int,
@IdCurso int
)
as
begin

update INSCRIPCIONES set 
IdAlumno = @IdAlumno,
IdCurso = @IdCurso

end

go

create procedure icion_obtener(@IdInscripcion int)
as
begin

select * from INSCRIPCIONES where IdInscripcion = @IdInscripcion
end

go
create procedure icion_listar
as
begin

select * from INSCRIPCIONES
end


go

go

create procedure icion_eliminar(
@IdInscripcion int
)
as
begin

delete from INSCRIPCIONES where IdInscripcion = @IdInscripcion

end

go

create procedure icion_listar_cursos_alumnos(
@IdCurso int
)
as
begin

select a.Nombre, a.Apellido, a.Numero_unico,c.Nombre, c.Descripcion, c.Codigo_unico from ALUMNO as a inner join inscripciones as i 
on a.IdAlumno=i.IdAlumno inner join CURSOS c on c.IdCurso=i.IdCurso order by a.IdAlumno asc

end

go
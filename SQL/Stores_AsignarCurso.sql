go
use DBESCUELA
go
--************************ VALIDAMOS SI EXISTE EL PROCEDIMIENTO ************************--

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'asig_registrar')
DROP PROCEDURE asig_registrar

go

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'asig_modificar')
DROP PROCEDURE asig_modificar

go

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'asig_obtener')
DROP PROCEDURE asig_obtener

go

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'asig_listar')
DROP PROCEDURE asig_listar

go

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'asig_eliminar')
DROP PROCEDURE asig_eliminar

go

--************************ PROCEDIMIENTOS PARA CREAR ************************--
create procedure asig_registrar(
@IdMaestro int,
@IdCurso int
)
as
begin

insert into ASIGNACIONES(IdMaestro,IdCurso)
values
(
@IdMaestro,
@IdCurso
)

end


go

create procedure asig_modificar(
@IdAsignacion int,
@IdMaestro int,
@IdCurso int
)
as
begin

update ASIGNACIONES set 
IdMaestro = @IdMaestro,
IdCurso = @IdCurso
where IdAsignacion = @IdAsignacion

end

go

create procedure asig_obtener(@IdAsignacion int)
as
begin

select * from ASIGNACIONES where IdAsignacion = @IdAsignacion
end

go
create procedure asig_listar
as
begin

select * from ASIGNACIONES
end


go

go

create procedure asig_eliminar(
@IdAsignacion int
)
as
begin

delete from ASIGNACIONES where IdAsignacion = @IdAsignacion

end

go

create procedure asig_listar_cursos_alumnos(
@IdCurso int
)
as
begin

select a.Nombre, a.Apellido, a.Numero_unico,c.Nombre, c.Descripcion, c.Codigo_unico from ALUMNO as a inner join inscripciones as i 
on a.IdAlumno=i.IdAlumno inner join CURSOS c on c.IdCurso=i.IdCurso order by a.IdAlumno asc

end

go

create procedure asig_listar_cursos_maestros
as
begin

select c.NombreCurso, c.Descripcion, c.Codigo_unico,m.NombreMaestro,m.ApellidoMaestro,a.Nombre, a.Apellido, a.Numero_unico from ALUMNO as a inner join inscripciones as i 
on a.IdAlumno=i.IdAlumno inner join CURSOS c on c.IdCurso=i.IdCurso inner join Asignaciones as Asi on Asi.IdCurso = c.IdCurso inner join MAESTRO m on Asi.IdMaestro = m.IdMaestro
order by m.IdMaestro asc 

end

go
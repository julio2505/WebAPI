use master
go
IF NOT EXISTS(SELECT name FROM master.dbo.sysdatabases WHERE NAME = 'DBESCUELA')
CREATE DATABASE DBESCUELA

GO 

USE DBESCUELA

GO

if not exists (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbo' AND TABLE_NAME = 'CURSOS')
create table CURSOS(
IdCurso int primary key identity(1,1),
Nombre varchar(60),
Descripcion varchar(60),
Codigo_unico varchar(60) unique,
FechaRegistro datetime default getdate()
)

go

USE DBESCUELA

GO

if not exists (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbo' AND TABLE_NAME = 'ALUMNO')
create table ALUMNO(
IdAlumno int primary key identity(1,1),
Nombre varchar(60),
Apellido varchar(60),
FechaNacimiento date,
Numero_unico varchar(60) unique,
FechaRegistro datetime default getdate()
)

go

USE DBESCUELA

GO

if not exists (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbo' AND TABLE_NAME = 'MAESTRO')
create table MAESTRO(
IdAlumno int primary key identity(1,1),
Nombre varchar(60),
Apellido varchar(60),
Numero_unico varchar(60) unique,
FechaRegistro datetime default getdate()
)

go

if not exists (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbo' AND TABLE_NAME = 'INSCRIPCIONES')
create table INSCRIPCIONES(
IdInscripcion int primary key identity(1,1),
IdAlumno int foreign key references Alumno(IdAlumno),
IdCurso  int foreign key references Cursos(IdCurso)
)

go

if not exists (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbo' AND TABLE_NAME = 'ASIGNACIONES')
create table ASIGNACIONES(
IdAsignacion int primary key identity(1,1),
IdMaestro int foreign key references Maestro(IdMaestro),
IdCurso  int foreign key references Cursos(IdCurso)
)

go
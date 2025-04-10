GO
SET IDENTITY_INSERT [dbo].[CURSOS] ON 

INSERT [dbo].[CURSOS] ([IdCurso],[Nombre], [Descripcion], [Codigo_unico]) VALUES (1, N'Ciencias',N'Ciencias exactas',N'54545')
INSERT [dbo].[CURSOS] ([IdCurso],[Nombre], [Descripcion], [Codigo_unico]) VALUES (2,N'Matematicas',N'Matematicas de Algebra',N'6321')


SET IDENTITY_INSERT [dbo].[CURSOS] OFF

GO
SET IDENTITY_INSERT [dbo].[ALUMNO] ON 

INSERT [dbo].[ALUMNO] ([IdAlumno],[Nombre],[Apellido],[FechaNacimiento],[Numero_Unico]) VALUES (1, N'Juan',N'Perez','12/01/2000','63321')
INSERT [dbo].[ALUMNO] ([IdAlumno],[Nombre],[Apellido],[FechaNacimiento],[Numero_Unico]) VALUES (2, N'Rafael',N'Medina','12/01/1999','85412')




SET IDENTITY_INSERT [dbo].[MAESTRO] ON 

INSERT [dbo].[MAESTRO] ([IdAlumno],[Nombre],[Apellido],[Numero_Unico]) VALUES (1, N'Nicolas',N'Mora','11111')
INSERT [dbo].[MAESTRO] ([IdAlumno],[Nombre],[Apellido],[Numero_Unico]) VALUES (2, N'Antonio',N'Gomez','22222')


SET IDENTITY_INSERT [dbo].[MAESTRO] OFF

SET IDENTITY_INSERT [dbo].[INSCRIPCIONES] ON 

INSERT [dbo].[INSCRIPCIONES] ([IdInscripcion],[IdAlumno],[IdCurso]) VALUES (1,1,1)
INSERT [dbo].[INSCRIPCIONES] ([IdInscripcion],[IdAlumno],[IdCurso]) VALUES (2,1,2)


SET IDENTITY_INSERT [dbo].[INSCRIPCIONES] OFF

SET IDENTITY_INSERT [dbo].[ASIGNACIONES] ON 

INSERT [dbo].[ASIGNACIONES] ([IdAsignacion],[IdMaestro],[IdCurso]) VALUES (1,1,1)
INSERT [dbo].[ASIGNACIONES] ([IdAsignacion],[IdMaestro],[IdCurso]) VALUES (2,1,2)


SET IDENTITY_INSERT [dbo].[INSCRIPCIONES] OFF
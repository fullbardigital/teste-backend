
IF NOT EXISTS (SELECT [name] FROM sys.databases WHERE [name] = 'DB_TESTE')
BEGIN
	CREATE DATABASE DB_TESTE
END
GO

USE DB_TESTE
GO

IF NOT EXISTS (SELECT [name] FROM sys.tables WHERE [name] = 't_periodo')
BEGIN
	CREATE TABLE [dbo].[t_periodo]
	(
		id_periodo		INT IDENTITY(1,1) NOT NULL,
		nm_periodo		VARCHAR(20) NOT NULL
		CONSTRAINT PK_t_periodo PRIMARY KEY (id_periodo)
	)
END

IF NOT EXISTS (SELECT [name] FROM sys.tables WHERE [name] = 't_curso')
BEGIN 
	CREATE TABLE [dbo].[t_curso]
	(
		id_curso				INT IDENTITY(1,1) NOT NULL,
		nm_curso				VARCHAR(20) NOT NULL,
		CONSTRAINT PK_t_curso PRIMARY KEY (id_curso)
	)
END

IF NOT EXISTS (SELECT [name] FROM sys.tables WHERE [name] = 't_aluno')
BEGIN
	CREATE TABLE [dbo].[t_aluno]
	(
		id_aluno				INT IDENTITY(1,1) NOT NULL,
		nm_aluno				VARCHAR(100) NOT NULL,
		nr_registro_academico	VARCHAR(20)	NOT NULL,
		id_curso				INT NOT NULL,
		id_periodo				INT NOT NULL,
		CONSTRAINT PK_t_aluno PRIMARY KEY (id_aluno),
		CONSTRAINT FK_t_aluno_X_t_curso FOREIGN KEY (id_curso) REFERENCES [dbo].[t_curso] (id_curso), 
		CONSTRAINT FK_t_aluno_X_t_Periodo FOREIGN KEY (id_periodo) REFERENCES [dbo].[t_periodo] (id_periodo)
	)
END
GO

IF NOT EXISTS (SELECT * FROM [dbo].[t_periodo])
BEGIN
	INSERT INTO [dbo].[t_periodo] VALUES
	('Matutino'), ('Vespertino'), ('Noturno')
END

IF NOT EXISTS (SELECT * FROM [dbo].[t_curso])
BEGIN
	INSERT INTO [dbo].[t_curso] VALUES
	('Matemática'), ('Inglês'), ('História'), ('Física'), ('Química'), ('Ed. Fisica')
END
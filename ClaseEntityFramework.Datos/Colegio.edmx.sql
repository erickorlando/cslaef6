
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 10/13/2017 09:59:44
-- Generated from EDMX file: C:\Users\Erick Orlando\OneDrive\Documentos\Visual Studio 2017\Projects\Clase Entity Framework\ClaseEntityFramework.Datos\Colegio.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [ColegioModelFirstBD];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_AlumnoAlumnoCurso]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[EntityBase_AlumnoCurso] DROP CONSTRAINT [FK_AlumnoAlumnoCurso];
GO
IF OBJECT_ID(N'[dbo].[FK_CursoAlumnoCurso]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[EntityBase_AlumnoCurso] DROP CONSTRAINT [FK_CursoAlumnoCurso];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[EntityBase_Alumno]', 'U') IS NOT NULL
    DROP TABLE [dbo].[EntityBase_Alumno];
GO
IF OBJECT_ID(N'[dbo].[EntityBase_AlumnoCurso]', 'U') IS NOT NULL
    DROP TABLE [dbo].[EntityBase_AlumnoCurso];
GO
IF OBJECT_ID(N'[dbo].[EntityBase_Curso]', 'U') IS NOT NULL
    DROP TABLE [dbo].[EntityBase_Curso];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Alumno'
CREATE TABLE [dbo].[Alumno] (
    [AlumnoId] int IDENTITY(1,1) NOT NULL,
    [Nombres] nvarchar(50)  NOT NULL,
    [Apellidos] nvarchar(50)  NOT NULL,
    [Correo] nvarchar(100)  NOT NULL,
    [FechaInscripcion] datetime  NOT NULL
);
GO

-- Creating table 'Curso'
CREATE TABLE [dbo].[Curso] (
    [CursoId] int IDENTITY(1,1) NOT NULL,
    [Nombre] nvarchar(50)  NOT NULL,
    [Codigo] nvarchar(10)  NOT NULL,
    [NroCreditos] int  NOT NULL
);
GO

-- Creating table 'AlumnoCurso'
CREATE TABLE [dbo].[AlumnoCurso] (
    [AlumnoCursoId] int IDENTITY(1,1) NOT NULL,
    [AlumnoId] int  NOT NULL,
    [CursoId] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [AlumnoId] in table 'Alumno'
ALTER TABLE [dbo].[Alumno]
ADD CONSTRAINT [PK_Alumno]
    PRIMARY KEY CLUSTERED ([AlumnoId] ASC);
GO

-- Creating primary key on [CursoId] in table 'Curso'
ALTER TABLE [dbo].[Curso]
ADD CONSTRAINT [PK_Curso]
    PRIMARY KEY CLUSTERED ([CursoId] ASC);
GO

-- Creating primary key on [AlumnoCursoId] in table 'AlumnoCurso'
ALTER TABLE [dbo].[AlumnoCurso]
ADD CONSTRAINT [PK_AlumnoCurso]
    PRIMARY KEY CLUSTERED ([AlumnoCursoId] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [AlumnoId] in table 'AlumnoCurso'
ALTER TABLE [dbo].[AlumnoCurso]
ADD CONSTRAINT [FK_AlumnoAlumnoCurso]
    FOREIGN KEY ([AlumnoId])
    REFERENCES [dbo].[Alumno]
        ([AlumnoId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AlumnoAlumnoCurso'
CREATE INDEX [IX_FK_AlumnoAlumnoCurso]
ON [dbo].[AlumnoCurso]
    ([AlumnoId]);
GO

-- Creating foreign key on [CursoId] in table 'AlumnoCurso'
ALTER TABLE [dbo].[AlumnoCurso]
ADD CONSTRAINT [FK_CursoAlumnoCurso]
    FOREIGN KEY ([CursoId])
    REFERENCES [dbo].[Curso]
        ([CursoId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CursoAlumnoCurso'
CREATE INDEX [IX_FK_CursoAlumnoCurso]
ON [dbo].[AlumnoCurso]
    ([CursoId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------
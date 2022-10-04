
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 09/29/2022 09:32:02
-- Generated from EDMX file: C:\Users\Meydell Lezama\source\repos\EjercicioMVC8\Models\EjercicioMVC8BD.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [EjercicioMVC8BD];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Unidades'
CREATE TABLE [dbo].[Unidades] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Nombre] nvarchar(max)  NOT NULL,
    [Codigo] nvarchar(max)  NOT NULL,
    [PlantaId] int  NOT NULL,
    [DoctorId] int  NOT NULL
);
GO

-- Creating table 'Plantas'
CREATE TABLE [dbo].[Plantas] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Nombre] nvarchar(max)  NOT NULL,
    [CantUnidades] int  NOT NULL
);
GO

-- Creating table 'Doctores'
CREATE TABLE [dbo].[Doctores] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Nombres] nvarchar(max)  NOT NULL,
    [Especialidad] nvarchar(max)  NOT NULL,
    [Telefono] int  NOT NULL
);
GO

-- Creating table 'Pacientes'
CREATE TABLE [dbo].[Pacientes] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Nombres] nvarchar(max)  NOT NULL,
    [ISS] nvarchar(max)  NOT NULL,
    [Edad] int  NOT NULL,
    [Telefono] int  NOT NULL
);
GO

-- Creating table 'Atenciones'
CREATE TABLE [dbo].[Atenciones] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Fecha] datetime  NOT NULL,
    [Sintoma] nvarchar(max)  NOT NULL,
    [Diagnostico] nvarchar(max)  NOT NULL,
    [Medicamentos] nvarchar(max)  NOT NULL,
    [DoctorId] int  NOT NULL,
    [PacienteId] int  NOT NULL
);
GO

-- Creating table 'Estadias'
CREATE TABLE [dbo].[Estadias] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Entrada] datetime  NOT NULL,
    [Salida] datetime  NOT NULL,
    [Cita] datetime  NULL,
    [PacienteId] int  NOT NULL,
    [UnidadId] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Unidades'
ALTER TABLE [dbo].[Unidades]
ADD CONSTRAINT [PK_Unidades]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Plantas'
ALTER TABLE [dbo].[Plantas]
ADD CONSTRAINT [PK_Plantas]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Doctores'
ALTER TABLE [dbo].[Doctores]
ADD CONSTRAINT [PK_Doctores]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Pacientes'
ALTER TABLE [dbo].[Pacientes]
ADD CONSTRAINT [PK_Pacientes]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Atenciones'
ALTER TABLE [dbo].[Atenciones]
ADD CONSTRAINT [PK_Atenciones]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Estadias'
ALTER TABLE [dbo].[Estadias]
ADD CONSTRAINT [PK_Estadias]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [PlantaId] in table 'Unidades'
ALTER TABLE [dbo].[Unidades]
ADD CONSTRAINT [FK_PlantaUnidad]
    FOREIGN KEY ([PlantaId])
    REFERENCES [dbo].[Plantas]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PlantaUnidad'
CREATE INDEX [IX_FK_PlantaUnidad]
ON [dbo].[Unidades]
    ([PlantaId]);
GO

-- Creating foreign key on [DoctorId] in table 'Unidades'
ALTER TABLE [dbo].[Unidades]
ADD CONSTRAINT [FK_DoctorUnidad]
    FOREIGN KEY ([DoctorId])
    REFERENCES [dbo].[Doctores]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DoctorUnidad'
CREATE INDEX [IX_FK_DoctorUnidad]
ON [dbo].[Unidades]
    ([DoctorId]);
GO

-- Creating foreign key on [DoctorId] in table 'Atenciones'
ALTER TABLE [dbo].[Atenciones]
ADD CONSTRAINT [FK_DoctorAtencion]
    FOREIGN KEY ([DoctorId])
    REFERENCES [dbo].[Doctores]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DoctorAtencion'
CREATE INDEX [IX_FK_DoctorAtencion]
ON [dbo].[Atenciones]
    ([DoctorId]);
GO

-- Creating foreign key on [PacienteId] in table 'Atenciones'
ALTER TABLE [dbo].[Atenciones]
ADD CONSTRAINT [FK_PacienteAtencion]
    FOREIGN KEY ([PacienteId])
    REFERENCES [dbo].[Pacientes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PacienteAtencion'
CREATE INDEX [IX_FK_PacienteAtencion]
ON [dbo].[Atenciones]
    ([PacienteId]);
GO

-- Creating foreign key on [PacienteId] in table 'Estadias'
ALTER TABLE [dbo].[Estadias]
ADD CONSTRAINT [FK_PacienteEstadia]
    FOREIGN KEY ([PacienteId])
    REFERENCES [dbo].[Pacientes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PacienteEstadia'
CREATE INDEX [IX_FK_PacienteEstadia]
ON [dbo].[Estadias]
    ([PacienteId]);
GO

-- Creating foreign key on [UnidadId] in table 'Estadias'
ALTER TABLE [dbo].[Estadias]
ADD CONSTRAINT [FK_UnidadEstadia]
    FOREIGN KEY ([UnidadId])
    REFERENCES [dbo].[Unidades]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UnidadEstadia'
CREATE INDEX [IX_FK_UnidadEstadia]
ON [dbo].[Estadias]
    ([UnidadId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------
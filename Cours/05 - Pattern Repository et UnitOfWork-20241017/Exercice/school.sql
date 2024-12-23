
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 07/16/2016 11:03:14
-- Generated from EDMX file: O:\TRAVAIL\COURS\DOTNET\2016-2017\05 - LINQ to Entities\05 - Solution\School\School\Model\Model1.edmx
-- --------------------------------------------------



USE master
GO
if exists (select * from sysdatabases where name='School')
		drop database School
go

CREATE DATABASE School;
GO

USE [School];


-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_ProfessorCourse]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Courses] DROP CONSTRAINT [FK_ProfessorCourse];
GO
IF OBJECT_ID(N'[dbo].[FK_SectionProfessor]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Professors] DROP CONSTRAINT [FK_SectionProfessor];
GO
IF OBJECT_ID(N'[dbo].[FK_StudentSection]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Students] DROP CONSTRAINT [FK_StudentSection];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Courses]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Courses];
GO
IF OBJECT_ID(N'[dbo].[Professors]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Professors];
GO
IF OBJECT_ID(N'[dbo].[Sections]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Sections];
GO
IF OBJECT_ID(N'[dbo].[Students]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Students];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Courses'
CREATE TABLE [dbo].[Courses] (
    [Course_Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Professor_Id] int  NOT NULL
);
GO

-- Creating table 'Professors'
CREATE TABLE [dbo].[Professors] (
    [Professor_Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Firstname] nvarchar(max)  NOT NULL,
    [Section_Id] int  NOT NULL
);
GO

-- Creating table 'Sections'
CREATE TABLE [dbo].[Sections] (
    [Section_Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Students'
CREATE TABLE [dbo].[Students] (
    [Student_Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Firstname] nvarchar(max)  NOT NULL,
    [YearResult] bigint  NOT NULL,
    [Section_Id] int  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Course_Id] in table 'Courses'
ALTER TABLE [dbo].[Courses]
ADD CONSTRAINT [PK_Courses]
    PRIMARY KEY CLUSTERED ([Course_Id] ASC);
GO

-- Creating primary key on [Professor_Id] in table 'Professors'
ALTER TABLE [dbo].[Professors]
ADD CONSTRAINT [PK_Professors]
    PRIMARY KEY CLUSTERED ([Professor_Id] ASC);
GO

-- Creating primary key on [Section_Id] in table 'Sections'
ALTER TABLE [dbo].[Sections]
ADD CONSTRAINT [PK_Sections]
    PRIMARY KEY CLUSTERED ([Section_Id] ASC);
GO

-- Creating primary key on [Student_Id] in table 'Students'
ALTER TABLE [dbo].[Students]
ADD CONSTRAINT [PK_Students]
    PRIMARY KEY CLUSTERED ([Student_Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Professor_Professor_Id] in table 'Courses'
ALTER TABLE [dbo].[Courses]
ADD CONSTRAINT [FK_ProfessorCourse]
    FOREIGN KEY ([Professor_Id])
    REFERENCES [dbo].[Professors]
        ([Professor_Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProfessorCourse'
CREATE INDEX [IX_FK_ProfessorCourse]
ON [dbo].[Courses]
    ([Professor_Id]);
GO

-- Creating foreign key on [Section_Section_Id] in table 'ProfessorSet'
ALTER TABLE [dbo].[Professors]
ADD CONSTRAINT [FK_SectionProfessor]
    FOREIGN KEY ([Section_Id])
    REFERENCES [dbo].[Sections]
        ([Section_Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SectionProfessor'
CREATE INDEX [IX_FK_SectionProfessor]
ON [dbo].[Professors]
    ([Section_Id]);
GO

-- Creating foreign key on [Section_Section_Id] in table 'Students'
ALTER TABLE [dbo].[Students]
ADD CONSTRAINT [FK_StudentSection]
    FOREIGN KEY ([Section_Id])
    REFERENCES [dbo].[Sections]
        ([Section_Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_StudentSection'
CREATE INDEX [IX_FK_StudentSection]
ON [dbo].[Students]
    ([Section_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------
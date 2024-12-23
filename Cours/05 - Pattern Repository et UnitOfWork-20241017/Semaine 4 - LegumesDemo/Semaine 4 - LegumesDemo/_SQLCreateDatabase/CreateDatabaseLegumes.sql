USE master
GO
if exists (select * from sysdatabases where name='Legumes')
		alter database Legumes set single_user with rollback immediate
		drop database Legumes
go

CREATE DATABASE Legumes;
GO

USE [Legumes];

CREATE TABLE [dbo].[Legumes]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] NCHAR(50) NOT NULL
)

GO

USE [master]

IF (EXISTS (SELECT name FROM master.dbo.sysdatabases WHERE ('[' + name + ']' = 'SimpleWeb_Signup' OR name = 'SimpleWeb_Signup')))
BEGIN
	ALTER DATABASE [SimpleWeb_Signup] SET SINGLE_USER WITH ROLLBACK IMMEDIATE
	DROP DATABASE [SimpleWeb_Signup]
END
CREATE DATABASE [SimpleWeb_Signup];
GO

USE [SimpleWeb_Signup]

CREATE TABLE [dbo].[Signup](
    [Id] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
    [Email] [nvarchar](256) NOT NULL,
    [Number] [int] IDENTITY(1,1) NOT NULL,
    [CreatedAt] [datetime] NOT NULL,
 CONSTRAINT [PK_Signup] PRIMARY KEY CLUSTERED 
(
    [Id] ASC
))

CREATE TABLE [dbo].[Invitation](
    [Id] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
    [SignupId] [uniqueidentifier] NOT NULL,
    [InvitedAt] [datetime] NOT NULL,
    [InvitedBy] [nvarchar](40) NOT NULL,
 CONSTRAINT [PK_Invitation] PRIMARY KEY CLUSTERED 
(
    [Id] ASC
))
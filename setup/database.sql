USE [master]

IF (EXISTS (SELECT name FROM master.dbo.sysdatabases WHERE ('[' + name + ']' = 'SimpleWeb_Signup' OR name = 'SimpleWeb_Signup')))
BEGIN
	ALTER DATABASE [SimpleWeb_Signup] SET SINGLE_USER WITH ROLLBACK IMMEDIATE
	DROP DATABASE [SimpleWeb_Signup]
END
CREATE DATABASE [SimpleWeb_Signup];
GO

IF NOT EXISTS(SELECT name FROM master.dbo.syslogins WHERE name = 'SimpleWeb_SignupUser')
BEGIN
    CREATE LOGIN [SimpleWeb_SignupUser] WITH PASSWORD = 'password', DEFAULT_DATABASE=[SimpleWeb_SignupUser], CHECK_EXPIRATION=OFF, CHECK_POLICY=OFF
END
GO

USE [SimpleWeb_Signup]

CREATE USER [SimpleWeb_SignupUser] FOR LOGIN [SimpleWeb_SignupUser] WITH DEFAULT_SCHEMA=[dbo];
exec sp_addrolemember 'db_owner', 'SimpleWeb_SignupUser';

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
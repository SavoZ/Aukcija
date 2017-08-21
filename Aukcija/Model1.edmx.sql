
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 08/19/2017 20:40:13
-- Generated from EDMX file: C:\Users\SavoZ\Desktop\SavoZepinicTask8\Aukcija\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Prodaja];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[tblLogin]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblLogin];
GO
IF OBJECT_ID(N'[dbo].[tblProduct]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblProduct];
GO
IF OBJECT_ID(N'[ProdajaModelStoreContainer].[vwProduct]', 'U') IS NOT NULL
    DROP TABLE [ProdajaModelStoreContainer].[vwProduct];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'tblLogins'
CREATE TABLE [dbo].[tblLogins] (
    [loginID] int IDENTITY(1,1) NOT NULL,
    [username] nvarchar(50)  NULL,
    [password] nvarchar(50)  NULL,
    [role] nchar(10)  NULL
);
GO

-- Creating table 'tblProducts'
CREATE TABLE [dbo].[tblProducts] (
    [productID] int IDENTITY(1,1) NOT NULL,
    [name] nvarchar(50)  NULL,
    [price] int  NULL,
    [time] nvarchar(50)  NULL,
    [bid] int  NULL,
    [customer] nvarchar(50)  NULL
);
GO

-- Creating table 'vwProducts'
CREATE TABLE [dbo].[vwProducts] (
    [productID] int IDENTITY(1,1) NOT NULL,
    [name] nvarchar(50)  NULL,
    [price] int  NULL,
    [time] nvarchar(50)  NULL,
    [bid] int  NULL,
    [customer] nvarchar(50)  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [loginID] in table 'tblLogins'
ALTER TABLE [dbo].[tblLogins]
ADD CONSTRAINT [PK_tblLogins]
    PRIMARY KEY CLUSTERED ([loginID] ASC);
GO

-- Creating primary key on [productID] in table 'tblProducts'
ALTER TABLE [dbo].[tblProducts]
ADD CONSTRAINT [PK_tblProducts]
    PRIMARY KEY CLUSTERED ([productID] ASC);
GO

-- Creating primary key on [productID] in table 'vwProducts'
ALTER TABLE [dbo].[vwProducts]
ADD CONSTRAINT [PK_vwProducts]
    PRIMARY KEY CLUSTERED ([productID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------
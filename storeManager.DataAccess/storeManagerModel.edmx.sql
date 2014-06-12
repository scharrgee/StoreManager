
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 10/15/2013 07:15:30
-- Generated from EDMX file: C:\Users\Prince\Documents\Visual Studio 2010\Projects\storeManager\storeManager.DataAccess\StoreManagerModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [StoreManagerDB];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_ProductBrand]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Products] DROP CONSTRAINT [FK_ProductBrand];
GO
IF OBJECT_ID(N'[dbo].[FK_ProductCategory]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Products] DROP CONSTRAINT [FK_ProductCategory];
GO
IF OBJECT_ID(N'[dbo].[FK_ProductSupplier]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Products] DROP CONSTRAINT [FK_ProductSupplier];
GO
IF OBJECT_ID(N'[dbo].[FK_ProductLocationLocation]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProductLocations] DROP CONSTRAINT [FK_ProductLocationLocation];
GO
IF OBJECT_ID(N'[dbo].[FK_ProductLocationProduct]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProductLocations] DROP CONSTRAINT [FK_ProductLocationProduct];
GO
IF OBJECT_ID(N'[dbo].[FK_SaleSaleDetail]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SaleDetails] DROP CONSTRAINT [FK_SaleSaleDetail];
GO
IF OBJECT_ID(N'[dbo].[FK_MeasurementProduct]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Products] DROP CONSTRAINT [FK_MeasurementProduct];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Addresses]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Addresses];
GO
IF OBJECT_ID(N'[dbo].[AddressTypes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AddressTypes];
GO
IF OBJECT_ID(N'[dbo].[Brands]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Brands];
GO
IF OBJECT_ID(N'[dbo].[Categories]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Categories];
GO
IF OBJECT_ID(N'[dbo].[Companies]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Companies];
GO
IF OBJECT_ID(N'[dbo].[Countries]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Countries];
GO
IF OBJECT_ID(N'[dbo].[Customers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Customers];
GO
IF OBJECT_ID(N'[dbo].[Employees]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Employees];
GO
IF OBJECT_ID(N'[dbo].[InvoiceNumbers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[InvoiceNumbers];
GO
IF OBJECT_ID(N'[dbo].[Locations]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Locations];
GO
IF OBJECT_ID(N'[dbo].[PaymentModes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PaymentModes];
GO
IF OBJECT_ID(N'[dbo].[Products]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Products];
GO
IF OBJECT_ID(N'[dbo].[PurchaseDetails]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PurchaseDetails];
GO
IF OBJECT_ID(N'[dbo].[Purchases]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Purchases];
GO
IF OBJECT_ID(N'[dbo].[SaleDetails]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SaleDetails];
GO
IF OBJECT_ID(N'[dbo].[Sales]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Sales];
GO
IF OBJECT_ID(N'[dbo].[SaleStatuses]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SaleStatuses];
GO
IF OBJECT_ID(N'[dbo].[SaleTypes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SaleTypes];
GO
IF OBJECT_ID(N'[dbo].[Suppliers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Suppliers];
GO
IF OBJECT_ID(N'[dbo].[Taxes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Taxes];
GO
IF OBJECT_ID(N'[dbo].[ProductLocations]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ProductLocations];
GO
IF OBJECT_ID(N'[dbo].[CardInformations]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CardInformations];
GO
IF OBJECT_ID(N'[dbo].[ProductAdjustments]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ProductAdjustments];
GO
IF OBJECT_ID(N'[dbo].[CompanyDetails]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CompanyDetails];
GO
IF OBJECT_ID(N'[dbo].[Roles]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Roles];
GO
IF OBJECT_ID(N'[dbo].[Users]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Users];
GO
IF OBJECT_ID(N'[dbo].[Measurements]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Measurements];
GO
IF OBJECT_ID(N'[dbo].[ErrorLogs]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ErrorLogs];
GO
IF OBJECT_ID(N'[dbo].[StockTranfers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[StockTranfers];
GO
IF OBJECT_ID(N'[dbo].[AccessRights]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AccessRights];
GO
IF OBJECT_ID(N'[dbo].[LabelSettings]', 'U') IS NOT NULL
    DROP TABLE [dbo].[LabelSettings];
GO
IF OBJECT_ID(N'[dbo].[BackupDetails]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BackupDetails];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Addresses'
CREATE TABLE [dbo].[Addresses] (
    [Id] int IDENTITY(1,1) NOT NULL
);
GO

-- Creating table 'AddressTypes'
CREATE TABLE [dbo].[AddressTypes] (
    [Id] int IDENTITY(1,1) NOT NULL
);
GO

-- Creating table 'Brands'
CREATE TABLE [dbo].[Brands] (
    [BrandID] int IDENTITY(1,1) NOT NULL,
    [BrandName] nvarchar(20)  NOT NULL,
    [Description] nvarchar(100)  NULL
);
GO

-- Creating table 'Categories'
CREATE TABLE [dbo].[Categories] (
    [CategoryID] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(50)  NOT NULL,
    [Comment] nvarchar(max)  NULL
);
GO

-- Creating table 'Companies'
CREATE TABLE [dbo].[Companies] (
    [CompanyNum] nvarchar(20)  NOT NULL,
    [CompanyName] nvarchar(30)  NOT NULL,
    [Address1] nvarchar(100)  NOT NULL,
    [Address2] nvarchar(100)  NULL,
    [Address3] nvarchar(100)  NULL,
    [PhoneLine1] nvarchar(20)  NOT NULL,
    [PhoneLine2] nvarchar(20)  NULL,
    [PhoneLine3] nvarchar(20)  NULL,
    [Motto] nvarchar(150)  NULL,
    [Logo] varbinary(max)  NULL,
    [Location] nvarchar(50)  NULL,
    [FaxNumber] nvarchar(20)  NULL,
    [Email] nvarchar(50)  NULL,
    [CompanyID] int IDENTITY(1,1) NOT NULL,
    [Misc] nvarchar(100)  NULL,
    [DefaultLocation] int  NULL,
    [WebSite] nvarchar(50)  NULL,
    [City] nvarchar(50)  NULL,
    [Country] nvarchar(50)  NULL
);
GO

-- Creating table 'Countries'
CREATE TABLE [dbo].[Countries] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Customers'
CREATE TABLE [dbo].[Customers] (
    [CustomerNum] nvarchar(20)  NULL,
    [Surname] nvarchar(50)  NULL,
    [OtherNames] nvarchar(50)  NULL,
    [Sex] char(10)  NULL,
    [CustomerTypeID] int  NULL,
    [PhoneNumber1] nvarchar(20)  NULL,
    [PhoneNumber2] nvarchar(20)  NULL,
    [PhoneNumber3] nvarchar(20)  NULL,
    [EmailAddress] nvarchar(50)  NULL,
    [Website] nvarchar(50)  NULL,
    [Discount] decimal(18,2)  NULL,
    [CreditLimit] decimal(18,2)  NULL,
    [DateAdded] datetime  NOT NULL,
    [IsActive] bit  NULL,
    [CustomerName] varchar(30)  NULL,
    [ContactPerson] nvarchar(100)  NULL,
    [PostalAddress] nvarchar(100)  NULL,
    [LocationAdress] nvarchar(100)  NULL,
    [Remarks] nvarchar(200)  NULL,
    [CustomerSince] datetime  NULL,
    [Salutation] nchar(10)  NULL,
    [Country] nvarchar(50)  NULL,
    [City] nvarchar(50)  NULL,
    [CustomerID] int IDENTITY(1,1) NOT NULL
);
GO

-- Creating table 'Employees'
CREATE TABLE [dbo].[Employees] (
    [EmployeeNum] nvarchar(20)  NULL,
    [FisrtName] nvarchar(50)  NOT NULL,
    [OtherNames] nvarchar(100)  NOT NULL,
    [Sex] nchar(10)  NOT NULL,
    [PhoneNumber1] nvarchar(50)  NOT NULL,
    [PhoneNumber2] nvarchar(50)  NULL,
    [PhoneNumber3] nvarchar(50)  NULL,
    [Title] nvarchar(50)  NULL,
    [Email] nvarchar(50)  NULL,
    [JobTitle] nvarchar(50)  NULL,
    [StoreID] nvarchar(20)  NULL,
    [CardID] int  NULL,
    [EmployeeID] int IDENTITY(1,1) NOT NULL,
    [Address] nvarchar(100)  NULL,
    [EmployeeSince] datetime  NULL,
    [ContactPerson] nvarchar(50)  NULL
);
GO

-- Creating table 'InvoiceNumbers'
CREATE TABLE [dbo].[InvoiceNumbers] (
    [id] int IDENTITY(1,1) NOT NULL,
    [InvoiceNum] bigint  NOT NULL
);
GO

-- Creating table 'Locations'
CREATE TABLE [dbo].[Locations] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [IsDefault] bit  NULL,
    [Comment] nvarchar(100)  NULL
);
GO

-- Creating table 'PaymentModes'
CREATE TABLE [dbo].[PaymentModes] (
    [PaymentModeID] int IDENTITY(1,1) NOT NULL,
    [PayMode] varchar(20)  NULL
);
GO

-- Creating table 'Products'
CREATE TABLE [dbo].[Products] (
    [Barcode] nvarchar(50)  NULL,
    [ProductName] nvarchar(50)  NOT NULL,
    [Description] nvarchar(50)  NULL,
    [Quantity] int  NOT NULL,
    [UnitPrice] decimal(18,2)  NOT NULL,
    [CategoryID] int  NOT NULL,
    [ManufactureDate] datetime  NULL,
    [ExpiryDate] datetime  NULL,
    [ReorderLevel] int  NULL,
    [PurchasePrice] decimal(18,2)  NULL,
    [SellingPrice] decimal(18,2)  NOT NULL,
    [ProductImage] varbinary(max)  NULL,
    [OnSale] bit  NULL,
    [SupplierID] int  NOT NULL,
    [ProductNum] nvarchar(20)  NOT NULL,
    [Commission] decimal(10,8)  NULL,
    [Discount] decimal(10,8)  NULL,
    [DateAdded] datetime  NULL,
    [LastDateAdjusted] datetime  NULL,
    [EmployeeID] nvarchar(20)  NULL,
    [BrandID] int  NOT NULL,
    [AdjustmentReason] nvarchar(150)  NULL,
    [ProductID] int IDENTITY(1,1) NOT NULL,
    [LocationID] int  NOT NULL,
    [MeasurementID] int  NOT NULL
);
GO

-- Creating table 'PurchaseDetails'
CREATE TABLE [dbo].[PurchaseDetails] (
    [InvoiceNumber] nvarchar(20)  NULL,
    [ProductID] nvarchar(20)  NULL,
    [Quantity] int  NULL,
    [UnitPrice] decimal(18,2)  NULL,
    [PurchaseDetailID] int IDENTITY(1,1) NOT NULL,
    [Discount] decimal(18,2)  NULL,
    [Tax] decimal(18,2)  NULL
);
GO

-- Creating table 'Purchases'
CREATE TABLE [dbo].[Purchases] (
    [InvoiceNumber] nvarchar(20)  NOT NULL,
    [SupplierID] nvarchar(20)  NOT NULL,
    [PurchaseAmount] decimal(18,2)  NOT NULL,
    [PurchaseDate] datetime  NOT NULL,
    [AmountPaid] decimal(18,0)  NULL,
    [Balance] decimal(18,0)  NULL,
    [StoreID] int  NULL,
    [PurchaseType] nchar(10)  NULL,
    [EmployeeID] nvarchar(20)  NULL,
    [PurchasetypeID] int  NULL,
    [DetailedAccountID] varchar(20)  NULL,
    [BillState] varchar(10)  NULL,
    [Discount] decimal(18,2)  NULL,
    [Tax] decimal(18,2)  NULL,
    [PromisedDate] datetime  NULL,
    [DateClosed] datetime  NULL,
    [PurchaseOrderNo] varchar(20)  NULL
);
GO

-- Creating table 'SaleDetails'
CREATE TABLE [dbo].[SaleDetails] (
    [InvoiceNumber] nvarchar(20)  NOT NULL,
    [UnitPrice] decimal(18,2)  NOT NULL,
    [Quantity] int  NOT NULL,
    [SalesDetailsID] int IDENTITY(1,1) NOT NULL,
    [ProductID] nvarchar(20)  NULL,
    [Discount] decimal(18,2)  NULL,
    [Tax] decimal(18,2)  NULL,
    [SaleID] int  NOT NULL,
    [LineTotal] decimal(8,2)  NULL,
    [LocationID] int  NULL
);
GO

-- Creating table 'Sales'
CREATE TABLE [dbo].[Sales] (
    [InvoiceNumber] nvarchar(20)  NOT NULL,
    [Amount] decimal(18,2)  NOT NULL,
    [InvoiceDate] datetime  NOT NULL,
    [AmountPaid] decimal(18,2)  NULL,
    [Balance] decimal(18,2)  NULL,
    [EmployeeID] nvarchar(20)  NULL,
    [StoreID] int  NULL,
    [CustomerID] nvarchar(20)  NULL,
    [SaleTypeID] int  NULL,
    [InvoiceState] varchar(10)  NULL,
    [Discount] decimal(18,2)  NULL,
    [Tax] decimal(18,2)  NULL,
    [PromisedDate] datetime  NULL,
    [DateClosed] datetime  NULL,
    [CustomerPO] varchar(40)  NULL,
    [PaymentModeID] int  NULL,
    [VoidSale] bit  NULL,
    [VoucherCode] varchar(20)  NULL,
    [SaleStatusID] int  NULL,
    [SaleID] int IDENTITY(1,1) NOT NULL,
    [SubTotal] decimal(8,2)  NULL,
    [LocationID] int  NULL
);
GO

-- Creating table 'SaleStatuses'
CREATE TABLE [dbo].[SaleStatuses] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Status] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'SaleTypes'
CREATE TABLE [dbo].[SaleTypes] (
    [SaleTypeID] int IDENTITY(1,1) NOT NULL,
    [TypeName] nvarchar(30)  NOT NULL
);
GO

-- Creating table 'Suppliers'
CREATE TABLE [dbo].[Suppliers] (
    [SupplierNum] nvarchar(20)  NULL,
    [Name] nvarchar(50)  NOT NULL,
    [ContactPerson] nvarchar(50)  NULL,
    [PostalAddress] nvarchar(100)  NULL,
    [LocationAdress] nvarchar(100)  NULL,
    [PhoneNumber1] nvarchar(50)  NULL,
    [PhoneNumber2] nvarchar(50)  NULL,
    [PhoneNumber3] nvarchar(50)  NULL,
    [Email] nvarchar(50)  NULL,
    [Website] nvarchar(50)  NULL,
    [Remarks] varchar(200)  NULL,
    [SupplierSince] datetime  NULL,
    [Salutation] nchar(10)  NULL,
    [Country] nvarchar(50)  NULL,
    [City] nvarchar(50)  NULL,
    [IsActive] bit  NULL,
    [SupplierID] int IDENTITY(1,1) NOT NULL
);
GO

-- Creating table 'Taxes'
CREATE TABLE [dbo].[Taxes] (
    [TaxID] int IDENTITY(1,1) NOT NULL,
    [TaxName] nvarchar(50)  NOT NULL,
    [TaxRate] decimal(10,5)  NOT NULL,
    [TaxNumber] nvarchar(50)  NULL
);
GO

-- Creating table 'ProductLocations'
CREATE TABLE [dbo].[ProductLocations] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [LocationID] int  NOT NULL,
    [ProductID] int  NOT NULL,
    [Quantity] int  NOT NULL
);
GO

-- Creating table 'CardInformations'
CREATE TABLE [dbo].[CardInformations] (
    [CardID] int IDENTITY(1,1) NOT NULL,
    [CardType] nvarchar(30)  NOT NULL
);
GO

-- Creating table 'ProductAdjustments'
CREATE TABLE [dbo].[ProductAdjustments] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [ProductID] int  NOT NULL,
    [LocationID] int  NOT NULL,
    [ProductLocationID] int  NOT NULL,
    [CurrentQty] int  NOT NULL,
    [NewQty] int  NOT NULL,
    [Difference] int  NOT NULL,
    [AdjustmentDate] datetime  NULL,
    [Remarks] nvarchar(500)  NULL,
    [EmployeeID] int  NULL
);
GO

-- Creating table 'CompanyDetails'
CREATE TABLE [dbo].[CompanyDetails] (
    [CompanyID] int IDENTITY(1,1) NOT NULL,
    [CompanyName] varchar(50)  NULL,
    [Motto] varchar(100)  NULL,
    [CompanyAddress] varchar(100)  NULL,
    [LandLine] varchar(20)  NULL,
    [Mobile] varchar(20)  NULL,
    [Logo] varbinary(max)  NULL,
    [City] varchar(50)  NULL,
    [Email] varchar(50)  NULL,
    [Website] varchar(20)  NULL,
    [Fax] varchar(20)  NULL,
    [MiscInfo] varchar(200)  NULL
);
GO

-- Creating table 'Roles'
CREATE TABLE [dbo].[Roles] (
    [RoleID] int IDENTITY(1,1) NOT NULL,
    [RoleName] varchar(20)  NULL
);
GO

-- Creating table 'Users'
CREATE TABLE [dbo].[Users] (
    [UserID] int IDENTITY(1,1) NOT NULL,
    [UserName] varchar(20)  NULL,
    [UserPassword] varchar(20)  NULL,
    [EmployeeID] int  NULL,
    [DateCreated] datetime  NULL,
    [LastLogInDate] datetime  NULL,
    [RoleID] int  NULL,
    [Active] bit  NULL,
    [IsAdmin] bit  NULL
);
GO

-- Creating table 'Measurements'
CREATE TABLE [dbo].[Measurements] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Description] nvarchar(max)  NOT NULL,
    [Name] nvarchar(20)  NULL
);
GO

-- Creating table 'ErrorLogs'
CREATE TABLE [dbo].[ErrorLogs] (
    [ErrorLogID] int IDENTITY(1,1) NOT NULL,
    [CustomMessage] nvarchar(max)  NULL,
    [ExceptionStackTrace] nvarchar(max)  NULL,
    [ExceptionMessage] nvarchar(max)  NULL,
    [InnerExeptionMessage] nvarchar(max)  NULL,
    [InnerExceptionStackTrace] nvarchar(max)  NULL,
    [ExceptionDate] datetime  NULL,
    [ControlName] nvarchar(100)  NULL,
    [FormName] nvarchar(100)  NULL
);
GO

-- Creating table 'StockTranfers'
CREATE TABLE [dbo].[StockTranfers] (
    [StockTranferID] int IDENTITY(1,1) NOT NULL,
    [FromLocationID] int  NULL,
    [FromLocationQtyBeforeTranfer] int  NULL,
    [FromLocationQtyAfterTransfer] int  NULL,
    [ToLocationID] int  NULL,
    [ToLocationBeforeTransfer] int  NULL,
    [ToLocationAfterTranfer] int  NULL,
    [ProductID] int  NULL,
    [UserID] int  NULL,
    [TransferDate] datetime  NULL,
    [TransferQty] int  NULL
);
GO

-- Creating table 'AccessRights'
CREATE TABLE [dbo].[AccessRights] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [FormID] varchar(50)  NULL,
    [UserID] int  NULL,
    [CanView] bit  NULL,
    [CanEdit] bit  NULL
);
GO

-- Creating table 'LabelSettings'
CREATE TABLE [dbo].[LabelSettings] (
    [id] int IDENTITY(1,1) NOT NULL,
    [ListStart] int  NULL,
    [ListEnd] int  NULL,
    [LabelLenghth] int  NULL,
    [QtyToPrint] int  NULL,
    [BarcodeType] varchar(20)  NULL,
    [BorderType] varchar(20)  NULL,
    [FontFamily] varchar(20)  NULL,
    [ForeColor] varchar(20)  NULL,
    [BarHeight] int  NULL,
    [FontSize] int  NULL,
    [ShowTest] bit  NULL,
    [ShowBorder] bit  NULL,
    [ShowCheckSum] bit  NULL
);
GO

-- Creating table 'BackupDetails'
CREATE TABLE [dbo].[BackupDetails] (
    [BackupID] int IDENTITY(1,1) NOT NULL,
    [BackupDate] datetime  NULL,
    [BackupFolder] varchar(100)  NULL,
    [StartTime] varchar(10)  NULL,
    [EndTime] varchar(10)  NULL,
    [Comments] nvarchar(max)  NOT NULL,
    [UserID] smallint  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Addresses'
ALTER TABLE [dbo].[Addresses]
ADD CONSTRAINT [PK_Addresses]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'AddressTypes'
ALTER TABLE [dbo].[AddressTypes]
ADD CONSTRAINT [PK_AddressTypes]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [BrandID] in table 'Brands'
ALTER TABLE [dbo].[Brands]
ADD CONSTRAINT [PK_Brands]
    PRIMARY KEY CLUSTERED ([BrandID] ASC);
GO

-- Creating primary key on [CategoryID] in table 'Categories'
ALTER TABLE [dbo].[Categories]
ADD CONSTRAINT [PK_Categories]
    PRIMARY KEY CLUSTERED ([CategoryID] ASC);
GO

-- Creating primary key on [CompanyID] in table 'Companies'
ALTER TABLE [dbo].[Companies]
ADD CONSTRAINT [PK_Companies]
    PRIMARY KEY CLUSTERED ([CompanyID] ASC);
GO

-- Creating primary key on [Id] in table 'Countries'
ALTER TABLE [dbo].[Countries]
ADD CONSTRAINT [PK_Countries]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [CustomerID] in table 'Customers'
ALTER TABLE [dbo].[Customers]
ADD CONSTRAINT [PK_Customers]
    PRIMARY KEY CLUSTERED ([CustomerID] ASC);
GO

-- Creating primary key on [EmployeeID] in table 'Employees'
ALTER TABLE [dbo].[Employees]
ADD CONSTRAINT [PK_Employees]
    PRIMARY KEY CLUSTERED ([EmployeeID] ASC);
GO

-- Creating primary key on [id] in table 'InvoiceNumbers'
ALTER TABLE [dbo].[InvoiceNumbers]
ADD CONSTRAINT [PK_InvoiceNumbers]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [Id] in table 'Locations'
ALTER TABLE [dbo].[Locations]
ADD CONSTRAINT [PK_Locations]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [PaymentModeID] in table 'PaymentModes'
ALTER TABLE [dbo].[PaymentModes]
ADD CONSTRAINT [PK_PaymentModes]
    PRIMARY KEY CLUSTERED ([PaymentModeID] ASC);
GO

-- Creating primary key on [ProductID] in table 'Products'
ALTER TABLE [dbo].[Products]
ADD CONSTRAINT [PK_Products]
    PRIMARY KEY CLUSTERED ([ProductID] ASC);
GO

-- Creating primary key on [PurchaseDetailID] in table 'PurchaseDetails'
ALTER TABLE [dbo].[PurchaseDetails]
ADD CONSTRAINT [PK_PurchaseDetails]
    PRIMARY KEY CLUSTERED ([PurchaseDetailID] ASC);
GO

-- Creating primary key on [InvoiceNumber] in table 'Purchases'
ALTER TABLE [dbo].[Purchases]
ADD CONSTRAINT [PK_Purchases]
    PRIMARY KEY CLUSTERED ([InvoiceNumber] ASC);
GO

-- Creating primary key on [SalesDetailsID] in table 'SaleDetails'
ALTER TABLE [dbo].[SaleDetails]
ADD CONSTRAINT [PK_SaleDetails]
    PRIMARY KEY CLUSTERED ([SalesDetailsID] ASC);
GO

-- Creating primary key on [SaleID] in table 'Sales'
ALTER TABLE [dbo].[Sales]
ADD CONSTRAINT [PK_Sales]
    PRIMARY KEY CLUSTERED ([SaleID] ASC);
GO

-- Creating primary key on [Id] in table 'SaleStatuses'
ALTER TABLE [dbo].[SaleStatuses]
ADD CONSTRAINT [PK_SaleStatuses]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [SaleTypeID] in table 'SaleTypes'
ALTER TABLE [dbo].[SaleTypes]
ADD CONSTRAINT [PK_SaleTypes]
    PRIMARY KEY CLUSTERED ([SaleTypeID] ASC);
GO

-- Creating primary key on [SupplierID] in table 'Suppliers'
ALTER TABLE [dbo].[Suppliers]
ADD CONSTRAINT [PK_Suppliers]
    PRIMARY KEY CLUSTERED ([SupplierID] ASC);
GO

-- Creating primary key on [TaxID] in table 'Taxes'
ALTER TABLE [dbo].[Taxes]
ADD CONSTRAINT [PK_Taxes]
    PRIMARY KEY CLUSTERED ([TaxID] ASC);
GO

-- Creating primary key on [Id] in table 'ProductLocations'
ALTER TABLE [dbo].[ProductLocations]
ADD CONSTRAINT [PK_ProductLocations]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [CardID] in table 'CardInformations'
ALTER TABLE [dbo].[CardInformations]
ADD CONSTRAINT [PK_CardInformations]
    PRIMARY KEY CLUSTERED ([CardID] ASC);
GO

-- Creating primary key on [ID] in table 'ProductAdjustments'
ALTER TABLE [dbo].[ProductAdjustments]
ADD CONSTRAINT [PK_ProductAdjustments]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [CompanyID] in table 'CompanyDetails'
ALTER TABLE [dbo].[CompanyDetails]
ADD CONSTRAINT [PK_CompanyDetails]
    PRIMARY KEY CLUSTERED ([CompanyID] ASC);
GO

-- Creating primary key on [RoleID] in table 'Roles'
ALTER TABLE [dbo].[Roles]
ADD CONSTRAINT [PK_Roles]
    PRIMARY KEY CLUSTERED ([RoleID] ASC);
GO

-- Creating primary key on [UserID] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [PK_Users]
    PRIMARY KEY CLUSTERED ([UserID] ASC);
GO

-- Creating primary key on [Id] in table 'Measurements'
ALTER TABLE [dbo].[Measurements]
ADD CONSTRAINT [PK_Measurements]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [ErrorLogID] in table 'ErrorLogs'
ALTER TABLE [dbo].[ErrorLogs]
ADD CONSTRAINT [PK_ErrorLogs]
    PRIMARY KEY CLUSTERED ([ErrorLogID] ASC);
GO

-- Creating primary key on [StockTranferID] in table 'StockTranfers'
ALTER TABLE [dbo].[StockTranfers]
ADD CONSTRAINT [PK_StockTranfers]
    PRIMARY KEY CLUSTERED ([StockTranferID] ASC);
GO

-- Creating primary key on [Id] in table 'AccessRights'
ALTER TABLE [dbo].[AccessRights]
ADD CONSTRAINT [PK_AccessRights]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [id] in table 'LabelSettings'
ALTER TABLE [dbo].[LabelSettings]
ADD CONSTRAINT [PK_LabelSettings]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [BackupID] in table 'BackupDetails'
ALTER TABLE [dbo].[BackupDetails]
ADD CONSTRAINT [PK_BackupDetails]
    PRIMARY KEY CLUSTERED ([BackupID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [BrandID] in table 'Products'
ALTER TABLE [dbo].[Products]
ADD CONSTRAINT [FK_ProductBrand]
    FOREIGN KEY ([BrandID])
    REFERENCES [dbo].[Brands]
        ([BrandID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ProductBrand'
CREATE INDEX [IX_FK_ProductBrand]
ON [dbo].[Products]
    ([BrandID]);
GO

-- Creating foreign key on [CategoryID] in table 'Products'
ALTER TABLE [dbo].[Products]
ADD CONSTRAINT [FK_ProductCategory]
    FOREIGN KEY ([CategoryID])
    REFERENCES [dbo].[Categories]
        ([CategoryID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ProductCategory'
CREATE INDEX [IX_FK_ProductCategory]
ON [dbo].[Products]
    ([CategoryID]);
GO

-- Creating foreign key on [SupplierID] in table 'Products'
ALTER TABLE [dbo].[Products]
ADD CONSTRAINT [FK_ProductSupplier]
    FOREIGN KEY ([SupplierID])
    REFERENCES [dbo].[Suppliers]
        ([SupplierID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ProductSupplier'
CREATE INDEX [IX_FK_ProductSupplier]
ON [dbo].[Products]
    ([SupplierID]);
GO

-- Creating foreign key on [LocationID] in table 'ProductLocations'
ALTER TABLE [dbo].[ProductLocations]
ADD CONSTRAINT [FK_ProductLocationLocation]
    FOREIGN KEY ([LocationID])
    REFERENCES [dbo].[Locations]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ProductLocationLocation'
CREATE INDEX [IX_FK_ProductLocationLocation]
ON [dbo].[ProductLocations]
    ([LocationID]);
GO

-- Creating foreign key on [ProductID] in table 'ProductLocations'
ALTER TABLE [dbo].[ProductLocations]
ADD CONSTRAINT [FK_ProductLocationProduct]
    FOREIGN KEY ([ProductID])
    REFERENCES [dbo].[Products]
        ([ProductID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ProductLocationProduct'
CREATE INDEX [IX_FK_ProductLocationProduct]
ON [dbo].[ProductLocations]
    ([ProductID]);
GO

-- Creating foreign key on [SaleID] in table 'SaleDetails'
ALTER TABLE [dbo].[SaleDetails]
ADD CONSTRAINT [FK_SaleSaleDetail]
    FOREIGN KEY ([SaleID])
    REFERENCES [dbo].[Sales]
        ([SaleID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_SaleSaleDetail'
CREATE INDEX [IX_FK_SaleSaleDetail]
ON [dbo].[SaleDetails]
    ([SaleID]);
GO

-- Creating foreign key on [MeasurementID] in table 'Products'
ALTER TABLE [dbo].[Products]
ADD CONSTRAINT [FK_MeasurementProduct]
    FOREIGN KEY ([MeasurementID])
    REFERENCES [dbo].[Measurements]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_MeasurementProduct'
CREATE INDEX [IX_FK_MeasurementProduct]
ON [dbo].[Products]
    ([MeasurementID]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------
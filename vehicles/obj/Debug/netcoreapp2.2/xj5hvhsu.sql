IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [CarStatuses] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(20) NULL,
    CONSTRAINT [PK_CarStatuses] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Customers] (
    [Id] int NOT NULL IDENTITY,
    [CreatedById] int NOT NULL,
    [UpdatedById] int NULL,
    [DeletedById] int NULL,
    [CreatedDate] datetime2 NOT NULL,
    [UpdatedDate] datetime2 NULL,
    [DeletedDate] datetime2 NULL,
    [FullName] nvarchar(150) NULL,
    [Address] nvarchar(400) NULL,
    CONSTRAINT [PK_Customers] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Cars] (
    [Id] int NOT NULL IDENTITY,
    [CreatedById] int NOT NULL,
    [UpdatedById] int NULL,
    [DeletedById] int NULL,
    [CreatedDate] datetime2 NOT NULL,
    [UpdatedDate] datetime2 NULL,
    [DeletedDate] datetime2 NULL,
    [CustomerId] int NOT NULL,
    [VehicleId] nvarchar(17) NULL,
    [RegNo] nvarchar(6) NULL,
    CONSTRAINT [PK_Cars] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Cars_Customers_CustomerId] FOREIGN KEY ([CustomerId]) REFERENCES [Customers] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [CarStatusTransactions] (
    [Id] int NOT NULL IDENTITY,
    [CreatedById] int NOT NULL,
    [UpdatedById] int NULL,
    [DeletedById] int NULL,
    [CreatedDate] datetime2 NOT NULL,
    [UpdatedDate] datetime2 NULL,
    [DeletedDate] datetime2 NULL,
    [CarId] int NOT NULL,
    [StatusId] int NOT NULL,
    CONSTRAINT [PK_CarStatusTransactions] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_CarStatusTransactions_Cars_CarId] FOREIGN KEY ([CarId]) REFERENCES [Cars] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_CarStatusTransactions_CarStatuses_StatusId] FOREIGN KEY ([StatusId]) REFERENCES [CarStatuses] ([Id]) ON DELETE CASCADE
);

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Name') AND [object_id] = OBJECT_ID(N'[CarStatuses]'))
    SET IDENTITY_INSERT [CarStatuses] ON;
INSERT INTO [CarStatuses] ([Id], [Name])
VALUES (1, N'Connected'),
(2, N'DisConnected');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Name') AND [object_id] = OBJECT_ID(N'[CarStatuses]'))
    SET IDENTITY_INSERT [CarStatuses] OFF;

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Address', N'CreatedById', N'CreatedDate', N'DeletedById', N'DeletedDate', N'FullName', N'UpdatedById', N'UpdatedDate') AND [object_id] = OBJECT_ID(N'[Customers]'))
    SET IDENTITY_INSERT [Customers] ON;
INSERT INTO [Customers] ([Id], [Address], [CreatedById], [CreatedDate], [DeletedById], [DeletedDate], [FullName], [UpdatedById], [UpdatedDate])
VALUES (1, N'Cementvägen 8, 111 11 Södertälje', -1, '2019-11-13T12:19:28.8929203+02:00', NULL, NULL, N'Kalles Grustransporter AB', NULL, NULL),
(2, N'Balkvägen 12, 222 22 Stockholm', -1, '2019-11-13T12:19:28.8939692+02:00', NULL, NULL, N'Johans Bulk AB', NULL, NULL),
(3, N'Budgetvägen 1, 333 33 Uppsala', -1, '2019-11-13T12:19:28.8939700+02:00', NULL, NULL, N'Haralds Värdetransporter AB', NULL, NULL);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Address', N'CreatedById', N'CreatedDate', N'DeletedById', N'DeletedDate', N'FullName', N'UpdatedById', N'UpdatedDate') AND [object_id] = OBJECT_ID(N'[Customers]'))
    SET IDENTITY_INSERT [Customers] OFF;

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedById', N'CreatedDate', N'CustomerId', N'DeletedById', N'DeletedDate', N'RegNo', N'UpdatedById', N'UpdatedDate', N'VehicleId') AND [object_id] = OBJECT_ID(N'[Cars]'))
    SET IDENTITY_INSERT [Cars] ON;
INSERT INTO [Cars] ([Id], [CreatedById], [CreatedDate], [CustomerId], [DeletedById], [DeletedDate], [RegNo], [UpdatedById], [UpdatedDate], [VehicleId])
VALUES (1, -1, '2019-11-13T12:19:28.8953262+02:00', 1, NULL, NULL, N'ABC123', NULL, NULL, N'YS2R4X20005399401'),
(2, -1, '2019-11-13T12:19:28.8953300+02:00', 1, NULL, NULL, N'DEF456', NULL, NULL, N'VLUR4X20009093588'),
(3, -1, '2019-11-13T12:19:28.8953304+02:00', 1, NULL, NULL, N'GHI789', NULL, NULL, N'VLUR4X20009048066'),
(4, -1, '2019-11-13T12:19:28.8953305+02:00', 2, NULL, NULL, N'JKL012', NULL, NULL, N'YS2R4X20005388011'),
(5, -1, '2019-11-13T12:19:28.8953307+02:00', 2, NULL, NULL, N'MNO345', NULL, NULL, N'YS2R4X20005387949'),
(6, -1, '2019-11-13T12:19:28.8953312+02:00', 3, NULL, NULL, N'PQR678', NULL, NULL, N'VLUR4X20009048066'),
(7, -1, '2019-11-13T12:19:28.8953313+02:00', 3, NULL, NULL, N'STU901', NULL, NULL, N'YS2R4X20005387055');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedById', N'CreatedDate', N'CustomerId', N'DeletedById', N'DeletedDate', N'RegNo', N'UpdatedById', N'UpdatedDate', N'VehicleId') AND [object_id] = OBJECT_ID(N'[Cars]'))
    SET IDENTITY_INSERT [Cars] OFF;

GO

CREATE INDEX [IX_Cars_CustomerId] ON [Cars] ([CustomerId]);

GO

CREATE INDEX [IX_CarStatusTransactions_CarId] ON [CarStatusTransactions] ([CarId]);

GO

CREATE INDEX [IX_CarStatusTransactions_StatusId] ON [CarStatusTransactions] ([StatusId]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20191113101929_Initial', N'2.2.6-servicing-10079');

GO

ALTER TABLE [Cars] ADD [CurrentStatusId] int NULL;

GO

UPDATE [Cars] SET [CreatedDate] = '2019-11-13T16:00:46.5645107+02:00', [CurrentStatusId] = 1
WHERE [Id] = 1;
SELECT @@ROWCOUNT;


GO

UPDATE [Cars] SET [CreatedDate] = '2019-11-13T16:00:46.5645165+02:00', [CurrentStatusId] = 1
WHERE [Id] = 2;
SELECT @@ROWCOUNT;


GO

UPDATE [Cars] SET [CreatedDate] = '2019-11-13T16:00:46.5645169+02:00', [CurrentStatusId] = 2
WHERE [Id] = 3;
SELECT @@ROWCOUNT;


GO

UPDATE [Cars] SET [CreatedDate] = '2019-11-13T16:00:46.5645170+02:00', [CurrentStatusId] = 1
WHERE [Id] = 4;
SELECT @@ROWCOUNT;


GO

UPDATE [Cars] SET [CreatedDate] = '2019-11-13T16:00:46.5645175+02:00', [CurrentStatusId] = 1
WHERE [Id] = 5;
SELECT @@ROWCOUNT;


GO

UPDATE [Cars] SET [CreatedDate] = '2019-11-13T16:00:46.5645182+02:00', [CurrentStatusId] = 1
WHERE [Id] = 6;
SELECT @@ROWCOUNT;


GO

UPDATE [Cars] SET [CreatedDate] = '2019-11-13T16:00:46.5645184+02:00', [CurrentStatusId] = 2
WHERE [Id] = 7;
SELECT @@ROWCOUNT;


GO

UPDATE [Customers] SET [CreatedDate] = '2019-11-13T16:00:46.5574947+02:00'
WHERE [Id] = 1;
SELECT @@ROWCOUNT;


GO

UPDATE [Customers] SET [CreatedDate] = '2019-11-13T16:00:46.5617806+02:00'
WHERE [Id] = 2;
SELECT @@ROWCOUNT;


GO

UPDATE [Customers] SET [CreatedDate] = '2019-11-13T16:00:46.5617839+02:00'
WHERE [Id] = 3;
SELECT @@ROWCOUNT;


GO

CREATE INDEX [IX_Cars_CurrentStatusId] ON [Cars] ([CurrentStatusId]);

GO

ALTER TABLE [Cars] ADD CONSTRAINT [FK_Cars_CarStatuses_CurrentStatusId] FOREIGN KEY ([CurrentStatusId]) REFERENCES [CarStatuses] ([Id]) ON DELETE NO ACTION;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20191113140046_UpdateCarEntity', N'2.2.6-servicing-10079');

GO

CREATE TABLE [LogDatas] (
    [Id] int NOT NULL IDENTITY,
    [LogType] nvarchar(max) NULL,
    [LogMessage] nvarchar(max) NULL,
    CONSTRAINT [PK_LogDatas] PRIMARY KEY ([Id])
);

GO

UPDATE [Cars] SET [CreatedDate] = '2019-11-16T21:03:53.4048718+02:00'
WHERE [Id] = 1;
SELECT @@ROWCOUNT;


GO

UPDATE [Cars] SET [CreatedDate] = '2019-11-16T21:03:53.4048772+02:00'
WHERE [Id] = 2;
SELECT @@ROWCOUNT;


GO

UPDATE [Cars] SET [CreatedDate] = '2019-11-16T21:03:53.4048777+02:00'
WHERE [Id] = 3;
SELECT @@ROWCOUNT;


GO

UPDATE [Cars] SET [CreatedDate] = '2019-11-16T21:03:53.4048779+02:00'
WHERE [Id] = 4;
SELECT @@ROWCOUNT;


GO

UPDATE [Cars] SET [CreatedDate] = '2019-11-16T21:03:53.4048781+02:00'
WHERE [Id] = 5;
SELECT @@ROWCOUNT;


GO

UPDATE [Cars] SET [CreatedDate] = '2019-11-16T21:03:53.4048788+02:00'
WHERE [Id] = 6;
SELECT @@ROWCOUNT;


GO

UPDATE [Cars] SET [CreatedDate] = '2019-11-16T21:03:53.4048790+02:00'
WHERE [Id] = 7;
SELECT @@ROWCOUNT;


GO

UPDATE [Customers] SET [CreatedDate] = '2019-11-16T21:03:53.4017620+02:00'
WHERE [Id] = 1;
SELECT @@ROWCOUNT;


GO

UPDATE [Customers] SET [CreatedDate] = '2019-11-16T21:03:53.4029689+02:00'
WHERE [Id] = 2;
SELECT @@ROWCOUNT;


GO

UPDATE [Customers] SET [CreatedDate] = '2019-11-16T21:03:53.4029699+02:00'
WHERE [Id] = 3;
SELECT @@ROWCOUNT;


GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20191116190353_AddLogDBEntity', N'2.2.6-servicing-10079');

GO


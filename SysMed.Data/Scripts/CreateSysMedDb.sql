IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [dbo].[MedicalDevices] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(250) NOT NULL,
    [Description] nvarchar(max) NULL,
    [Brand] nvarchar(250) NOT NULL,
    [Model] nvarchar(250) NOT NULL,
    [PurchaseDate] datetime2 NULL,
    [LastMaintenanceDate] datetime2 NULL,
    [MaintenanceIntervalInDays] int NOT NULL,
    CONSTRAINT [PK_MedicalDevices] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [dbo].[Maintenances] (
    [Id] int NOT NULL IDENTITY,
    [MedicalDeviceId] int NOT NULL,
    [Type] int NOT NULL,
    [Description] nvarchar(max) NULL,
    [ScheduledDate] datetime2 NOT NULL,
    [CompletedOn] datetime2 NULL,
    [Completed] bit NOT NULL,
    [PerformedBy] nvarchar(max) NULL,
    CONSTRAINT [PK_Maintenances] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Maintenances_MedicalDevices_MedicalDeviceId] FOREIGN KEY ([MedicalDeviceId]) REFERENCES [dbo].[MedicalDevices] ([Id]) ON DELETE CASCADE
);
GO

CREATE INDEX [IX_Maintenances_MedicalDeviceId] ON [dbo].[Maintenances] ([MedicalDeviceId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230824053409_CreateSysMedDb', N'7.0.10');
GO

COMMIT;
GO


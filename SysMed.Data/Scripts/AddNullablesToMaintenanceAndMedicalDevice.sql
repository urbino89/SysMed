BEGIN TRANSACTION;
GO

DECLARE @var0 sysname;
SELECT @var0 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[dbo].[MedicalDevices]') AND [c].[name] = N'PurchaseDate');
IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [dbo].[MedicalDevices] DROP CONSTRAINT [' + @var0 + '];');
ALTER TABLE [dbo].[MedicalDevices] ALTER COLUMN [PurchaseDate] datetime2 NULL;
GO

DECLARE @var1 sysname;
SELECT @var1 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[dbo].[MedicalDevices]') AND [c].[name] = N'LastMaintenanceDate');
IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [dbo].[MedicalDevices] DROP CONSTRAINT [' + @var1 + '];');
ALTER TABLE [dbo].[MedicalDevices] ALTER COLUMN [LastMaintenanceDate] datetime2 NULL;
GO

DECLARE @var2 sysname;
SELECT @var2 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[dbo].[Maintenances]') AND [c].[name] = N'CompletedOn');
IF @var2 IS NOT NULL EXEC(N'ALTER TABLE [dbo].[Maintenances] DROP CONSTRAINT [' + @var2 + '];');
ALTER TABLE [dbo].[Maintenances] ALTER COLUMN [CompletedOn] datetime2 NULL;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230824032732_AddNullablesToMaintenanceAndMedicalDevice', N'7.0.10');
GO

COMMIT;
GO


First two migrations - had to update ProductId from 'TEXT' to 'UNIQUEIDENTIFIER' (so it's the same type as Guid). And Name/Description from 'TEXT' to 'NVARCHAR' (as my program interprets strings as nvarchars)


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

CREATE TABLE [Product] (
    [ProductId] UNIQUEIDENTIFIER NOT NULL,
    [Name] NVARCHAR(MAX) NOT NULL,
    [Description] NVARCHAR(MAX) NOT NULL,
    [Price] INTEGER NOT NULL,
    CONSTRAINT [PK_Product] PRIMARY KEY ([ProductId])
);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20240304143140_InitialMigration', N'7.0.2');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

EXEC sp_rename N'[Product].[ProductId]', N'Id', N'COLUMN';
GO

DECLARE @var0 sysname;
SELECT @var0 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Product]') AND [c].[name] = N'Price');
IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [Product] DROP CONSTRAINT [' + @var0 + '];');
ALTER TABLE [Product] ALTER COLUMN [Price] REAL NOT NULL;
GO

ALTER TABLE [Product] ADD [ImageUrl] NVARCHAR(MAX) NULL;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20240311135254_ImageUrlAndPriceUpdate', N'7.0.2');
GO



**UserTableAdded script**

BEGIN TRANSACTION;
GO


CREATE TABLE [User] (
   [Id] UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID(),
   [UserName] NVARCHAR(MAX) NOT NULL,
   [Name] NVARCHAR(MAX) NOT NULL,
   [Email] NVARCHAR(MAX) NOT NULL,
   [Password] NVARCHAR(MAX) NOT NULL,
   CONSTRAINT [PK_User] PRIMARY KEY ([Id])
);
GO


INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20240501132945_UserTableAdded', N'7.0.2');
GO


COMMIT;
GO








COMMIT;
GO

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
CREATE TABLE [Departamentos] (
    [Id] int NOT NULL IDENTITY,
    [Direccion] nvarchar(200) NOT NULL,
    [Colonia] nvarchar(120) NOT NULL,
    [Ciudad] nvarchar(120) NOT NULL,
    [Habitaciones] int NOT NULL,
    [Banios] int NOT NULL,
    [PrecioRenta] decimal(12,2) NOT NULL,
    [Estado] nvarchar(30) NOT NULL,
    [Arrendatario] nvarchar(150) NULL,
    [FechaInicioRenta] datetime2 NULL,
    [Imagenes] nvarchar(max) NOT NULL,
    [Descripcion] nvarchar(2000) NULL,
    [Amenidades] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Departamentos] PRIMARY KEY ([Id])
);

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Amenidades', N'Arrendatario', N'Banios', N'Ciudad', N'Colonia', N'Descripcion', N'Direccion', N'Estado', N'FechaInicioRenta', N'Habitaciones', N'Imagenes', N'PrecioRenta') AND [object_id] = OBJECT_ID(N'[Departamentos]'))
    SET IDENTITY_INSERT [Departamentos] ON;
INSERT INTO [Departamentos] ([Id], [Amenidades], [Arrendatario], [Banios], [Ciudad], [Colonia], [Descripcion], [Direccion], [Estado], [FechaInicioRenta], [Habitaciones], [Imagenes], [PrecioRenta])
VALUES (1, N'', NULL, 1, N'Ciudad de México', N'Centro', NULL, N'Av. Reforma 123', N'Disponible', NULL, 2, N'', 8500.0),
(2, N'', N'Juan Pérez', 2, N'Ciudad de México', N'Doctores', NULL, N'Calle 5 de Mayo 45', N'Rentado', '2025-01-15T00:00:00.0000000', 3, N'', 12000.0),
(3, N'', NULL, 1, N'Guadalajara', N'Del Valle', NULL, N'Blvd. Insurgentes 800', N'Mantenimiento', NULL, 1, N'', 6000.0);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Amenidades', N'Arrendatario', N'Banios', N'Ciudad', N'Colonia', N'Descripcion', N'Direccion', N'Estado', N'FechaInicioRenta', N'Habitaciones', N'Imagenes', N'PrecioRenta') AND [object_id] = OBJECT_ID(N'[Departamentos]'))
    SET IDENTITY_INSERT [Departamentos] OFF;

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20260630122444_Inicial', N'9.0.0');

COMMIT;
GO


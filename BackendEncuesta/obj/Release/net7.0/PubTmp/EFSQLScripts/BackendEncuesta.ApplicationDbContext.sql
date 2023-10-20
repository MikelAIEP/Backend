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

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231015041353_initial')
BEGIN
    CREATE TABLE [ComunasResidencia] (
        [ComunaResidenciaId] int NOT NULL IDENTITY,
        [Nombre] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_ComunasResidencia] PRIMARY KEY ([ComunaResidenciaId])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231015041353_initial')
BEGIN
    CREATE TABLE [ComunasTrabajo] (
        [ComunaTrabajoId] int NOT NULL IDENTITY,
        [Nombre] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_ComunasTrabajo] PRIMARY KEY ([ComunaTrabajoId])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231015041353_initial')
BEGIN
    CREATE TABLE [Estados] (
        [EstadoId] int NOT NULL IDENTITY,
        [Nombre] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_Estados] PRIMARY KEY ([EstadoId])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231015041353_initial')
BEGIN
    CREATE TABLE [ModalidadTrabajos] (
        [ModalidadTrabajoId] int NOT NULL IDENTITY,
        [Mombre] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_ModalidadTrabajos] PRIMARY KEY ([ModalidadTrabajoId])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231015041353_initial')
BEGIN
    CREATE TABLE [TipoTransportes] (
        [TipoTransporteId] int NOT NULL IDENTITY,
        [Comparte] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_TipoTransportes] PRIMARY KEY ([TipoTransporteId])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231015041353_initial')
BEGIN
    CREATE TABLE [Usuarios] (
        [usuarioId] int NOT NULL IDENTITY,
        [nombres] nvarchar(max) NOT NULL,
        [apellidos] nvarchar(max) NOT NULL,
        [rut] nvarchar(max) NOT NULL,
        [email] nvarchar(max) NOT NULL,
        [contrasena] nvarchar(max) NOT NULL,
        [trabaja] nvarchar(max) NOT NULL,
        [recuperar] nvarchar(max) NOT NULL,
        [ModalidadTrabajoId] int NOT NULL,
        [ComunaResidenciaId] int NOT NULL,
        [EstadoId] int NOT NULL,
        [ComunaTrabajoId] int NOT NULL,
        CONSTRAINT [PK_Usuarios] PRIMARY KEY ([usuarioId]),
        CONSTRAINT [FK_Usuarios_ComunasResidencia_ComunaResidenciaId] FOREIGN KEY ([ComunaResidenciaId]) REFERENCES [ComunasResidencia] ([ComunaResidenciaId]) ON DELETE CASCADE,
        CONSTRAINT [FK_Usuarios_ComunasTrabajo_ComunaTrabajoId] FOREIGN KEY ([ComunaTrabajoId]) REFERENCES [ComunasTrabajo] ([ComunaTrabajoId]) ON DELETE CASCADE,
        CONSTRAINT [FK_Usuarios_Estados_EstadoId] FOREIGN KEY ([EstadoId]) REFERENCES [Estados] ([EstadoId]) ON DELETE CASCADE,
        CONSTRAINT [FK_Usuarios_ModalidadTrabajos_ModalidadTrabajoId] FOREIGN KEY ([ModalidadTrabajoId]) REFERENCES [ModalidadTrabajos] ([ModalidadTrabajoId]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231015041353_initial')
BEGIN
    CREATE TABLE [Encuestas] (
        [EncuestaId] int NOT NULL IDENTITY,
        [fecharealizacion] datetime2 NOT NULL,
        [Pregunta1] nvarchar(max) NOT NULL,
        [Pregunta2] nvarchar(max) NOT NULL,
        [Pregunta3] nvarchar(max) NOT NULL,
        [Pregunta4] nvarchar(max) NOT NULL,
        [Pregunta5] nvarchar(max) NOT NULL,
        [Pregunta6] nvarchar(max) NOT NULL,
        [TipoTransporteId] int NOT NULL,
        [UsuarioId] int NOT NULL,
        CONSTRAINT [PK_Encuestas] PRIMARY KEY ([EncuestaId]),
        CONSTRAINT [FK_Encuestas_TipoTransportes_TipoTransporteId] FOREIGN KEY ([TipoTransporteId]) REFERENCES [TipoTransportes] ([TipoTransporteId]) ON DELETE CASCADE,
        CONSTRAINT [FK_Encuestas_Usuarios_UsuarioId] FOREIGN KEY ([UsuarioId]) REFERENCES [Usuarios] ([usuarioId]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231015041353_initial')
BEGIN
    CREATE INDEX [IX_Encuestas_TipoTransporteId] ON [Encuestas] ([TipoTransporteId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231015041353_initial')
BEGIN
    CREATE INDEX [IX_Encuestas_UsuarioId] ON [Encuestas] ([UsuarioId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231015041353_initial')
BEGIN
    CREATE INDEX [IX_Usuarios_ComunaResidenciaId] ON [Usuarios] ([ComunaResidenciaId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231015041353_initial')
BEGIN
    CREATE INDEX [IX_Usuarios_ComunaTrabajoId] ON [Usuarios] ([ComunaTrabajoId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231015041353_initial')
BEGIN
    CREATE INDEX [IX_Usuarios_EstadoId] ON [Usuarios] ([EstadoId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231015041353_initial')
BEGIN
    CREATE INDEX [IX_Usuarios_ModalidadTrabajoId] ON [Usuarios] ([ModalidadTrabajoId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231015041353_initial')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20231015041353_initial', N'7.0.12');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231017022052_161020232220_Identity')
BEGIN
    CREATE TABLE [AspNetRoles] (
        [Id] nvarchar(450) NOT NULL,
        [Name] nvarchar(256) NULL,
        [NormalizedName] nvarchar(256) NULL,
        [ConcurrencyStamp] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetRoles] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231017022052_161020232220_Identity')
BEGIN
    CREATE TABLE [AspNetUsers] (
        [Id] nvarchar(450) NOT NULL,
        [UserName] nvarchar(256) NULL,
        [NormalizedUserName] nvarchar(256) NULL,
        [Email] nvarchar(256) NULL,
        [NormalizedEmail] nvarchar(256) NULL,
        [EmailConfirmed] bit NOT NULL,
        [PasswordHash] nvarchar(max) NULL,
        [SecurityStamp] nvarchar(max) NULL,
        [ConcurrencyStamp] nvarchar(max) NULL,
        [PhoneNumber] nvarchar(max) NULL,
        [PhoneNumberConfirmed] bit NOT NULL,
        [TwoFactorEnabled] bit NOT NULL,
        [LockoutEnd] datetimeoffset NULL,
        [LockoutEnabled] bit NOT NULL,
        [AccessFailedCount] int NOT NULL,
        CONSTRAINT [PK_AspNetUsers] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231017022052_161020232220_Identity')
BEGIN
    CREATE TABLE [AspNetRoleClaims] (
        [Id] int NOT NULL IDENTITY,
        [RoleId] nvarchar(450) NOT NULL,
        [ClaimType] nvarchar(max) NULL,
        [ClaimValue] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [AspNetRoles] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231017022052_161020232220_Identity')
BEGIN
    CREATE TABLE [AspNetUserClaims] (
        [Id] int NOT NULL IDENTITY,
        [UserId] nvarchar(450) NOT NULL,
        [ClaimType] nvarchar(max) NULL,
        [ClaimValue] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231017022052_161020232220_Identity')
BEGIN
    CREATE TABLE [AspNetUserLogins] (
        [LoginProvider] nvarchar(450) NOT NULL,
        [ProviderKey] nvarchar(450) NOT NULL,
        [ProviderDisplayName] nvarchar(max) NULL,
        [UserId] nvarchar(450) NOT NULL,
        CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY ([LoginProvider], [ProviderKey]),
        CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231017022052_161020232220_Identity')
BEGIN
    CREATE TABLE [AspNetUserRoles] (
        [UserId] nvarchar(450) NOT NULL,
        [RoleId] nvarchar(450) NOT NULL,
        CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY ([UserId], [RoleId]),
        CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [AspNetRoles] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231017022052_161020232220_Identity')
BEGIN
    CREATE TABLE [AspNetUserTokens] (
        [UserId] nvarchar(450) NOT NULL,
        [LoginProvider] nvarchar(450) NOT NULL,
        [Name] nvarchar(450) NOT NULL,
        [Value] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY ([UserId], [LoginProvider], [Name]),
        CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231017022052_161020232220_Identity')
BEGIN
    CREATE INDEX [IX_AspNetRoleClaims_RoleId] ON [AspNetRoleClaims] ([RoleId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231017022052_161020232220_Identity')
BEGIN
    EXEC(N'CREATE UNIQUE INDEX [RoleNameIndex] ON [AspNetRoles] ([NormalizedName]) WHERE [NormalizedName] IS NOT NULL');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231017022052_161020232220_Identity')
BEGIN
    CREATE INDEX [IX_AspNetUserClaims_UserId] ON [AspNetUserClaims] ([UserId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231017022052_161020232220_Identity')
BEGIN
    CREATE INDEX [IX_AspNetUserLogins_UserId] ON [AspNetUserLogins] ([UserId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231017022052_161020232220_Identity')
BEGIN
    CREATE INDEX [IX_AspNetUserRoles_RoleId] ON [AspNetUserRoles] ([RoleId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231017022052_161020232220_Identity')
BEGIN
    CREATE INDEX [EmailIndex] ON [AspNetUsers] ([NormalizedEmail]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231017022052_161020232220_Identity')
BEGIN
    EXEC(N'CREATE UNIQUE INDEX [UserNameIndex] ON [AspNetUsers] ([NormalizedUserName]) WHERE [NormalizedUserName] IS NOT NULL');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231017022052_161020232220_Identity')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20231017022052_161020232220_Identity', N'7.0.12');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231018034338_userb')
BEGIN
    ALTER TABLE [AspNetUsers] ADD [ComunaResidenciaId] int NOT NULL DEFAULT 0;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231018034338_userb')
BEGIN
    ALTER TABLE [AspNetUsers] ADD [ComunaTrabajoId] int NOT NULL DEFAULT 0;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231018034338_userb')
BEGIN
    ALTER TABLE [AspNetUsers] ADD [EstadoId] int NOT NULL DEFAULT 0;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231018034338_userb')
BEGIN
    ALTER TABLE [AspNetUsers] ADD [ModalidadTrabajoId] int NOT NULL DEFAULT 0;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231018034338_userb')
BEGIN
    ALTER TABLE [AspNetUsers] ADD [apellidos] nvarchar(max) NOT NULL DEFAULT N'';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231018034338_userb')
BEGIN
    ALTER TABLE [AspNetUsers] ADD [nombres] nvarchar(max) NOT NULL DEFAULT N'';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231018034338_userb')
BEGIN
    ALTER TABLE [AspNetUsers] ADD [recuperar] nvarchar(max) NOT NULL DEFAULT N'';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231018034338_userb')
BEGIN
    ALTER TABLE [AspNetUsers] ADD [rut] nvarchar(max) NOT NULL DEFAULT N'';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231018034338_userb')
BEGIN
    ALTER TABLE [AspNetUsers] ADD [trabaja] nvarchar(max) NOT NULL DEFAULT N'';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231018034338_userb')
BEGIN
    CREATE INDEX [IX_AspNetUsers_ComunaResidenciaId] ON [AspNetUsers] ([ComunaResidenciaId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231018034338_userb')
BEGIN
    CREATE INDEX [IX_AspNetUsers_ComunaTrabajoId] ON [AspNetUsers] ([ComunaTrabajoId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231018034338_userb')
BEGIN
    CREATE INDEX [IX_AspNetUsers_EstadoId] ON [AspNetUsers] ([EstadoId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231018034338_userb')
BEGIN
    CREATE INDEX [IX_AspNetUsers_ModalidadTrabajoId] ON [AspNetUsers] ([ModalidadTrabajoId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231018034338_userb')
BEGIN
    ALTER TABLE [AspNetUsers] ADD CONSTRAINT [FK_AspNetUsers_ComunasResidencia_ComunaResidenciaId] FOREIGN KEY ([ComunaResidenciaId]) REFERENCES [ComunasResidencia] ([ComunaResidenciaId]) ON DELETE CASCADE;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231018034338_userb')
BEGIN
    ALTER TABLE [AspNetUsers] ADD CONSTRAINT [FK_AspNetUsers_ComunasTrabajo_ComunaTrabajoId] FOREIGN KEY ([ComunaTrabajoId]) REFERENCES [ComunasTrabajo] ([ComunaTrabajoId]) ON DELETE CASCADE;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231018034338_userb')
BEGIN
    ALTER TABLE [AspNetUsers] ADD CONSTRAINT [FK_AspNetUsers_Estados_EstadoId] FOREIGN KEY ([EstadoId]) REFERENCES [Estados] ([EstadoId]) ON DELETE CASCADE;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231018034338_userb')
BEGIN
    ALTER TABLE [AspNetUsers] ADD CONSTRAINT [FK_AspNetUsers_ModalidadTrabajos_ModalidadTrabajoId] FOREIGN KEY ([ModalidadTrabajoId]) REFERENCES [ModalidadTrabajos] ([ModalidadTrabajoId]) ON DELETE CASCADE;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231018034338_userb')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20231018034338_userb', N'7.0.12');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231018042839_userb2')
BEGIN
    ALTER TABLE [AspNetUsers] DROP CONSTRAINT [FK_AspNetUsers_ComunasResidencia_ComunaResidenciaId];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231018042839_userb2')
BEGIN
    ALTER TABLE [AspNetUsers] DROP CONSTRAINT [FK_AspNetUsers_ComunasTrabajo_ComunaTrabajoId];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231018042839_userb2')
BEGIN
    ALTER TABLE [AspNetUsers] DROP CONSTRAINT [FK_AspNetUsers_Estados_EstadoId];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231018042839_userb2')
BEGIN
    ALTER TABLE [AspNetUsers] DROP CONSTRAINT [FK_AspNetUsers_ModalidadTrabajos_ModalidadTrabajoId];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231018042839_userb2')
BEGIN
    DROP INDEX [IX_AspNetUsers_ComunaResidenciaId] ON [AspNetUsers];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231018042839_userb2')
BEGIN
    DROP INDEX [IX_AspNetUsers_ComunaTrabajoId] ON [AspNetUsers];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231018042839_userb2')
BEGIN
    DROP INDEX [IX_AspNetUsers_EstadoId] ON [AspNetUsers];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231018042839_userb2')
BEGIN
    DROP INDEX [IX_AspNetUsers_ModalidadTrabajoId] ON [AspNetUsers];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231018042839_userb2')
BEGIN
    DECLARE @var0 sysname;
    SELECT @var0 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Usuarios]') AND [c].[name] = N'recuperar');
    IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [Usuarios] DROP CONSTRAINT [' + @var0 + '];');
    ALTER TABLE [Usuarios] DROP COLUMN [recuperar];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231018042839_userb2')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20231018042839_userb2', N'7.0.12');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231019225142_updateFN')
BEGIN
    ALTER TABLE [AspNetUsers] ADD [fechaNacimiento] datetime2 NOT NULL DEFAULT '0001-01-01T00:00:00.0000000';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231019225142_updateFN')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20231019225142_updateFN', N'7.0.12');
END;
GO

COMMIT;
GO


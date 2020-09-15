CREATE TABLE IF NOT EXISTS `__EFMigrationsHistory` (
    `MigrationId` varchar(95) NOT NULL,
    `ProductVersion` varchar(32) NOT NULL,
    CONSTRAINT `PK___EFMigrationsHistory` PRIMARY KEY (`MigrationId`)
);


DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20200816021949_init') THEN

    CREATE TABLE `licenciaConducir` (
        `licenciaConducirId` int NOT NULL AUTO_INCREMENT,
        `licenciaConducirNombre` nvarchar(150) NOT NULL,
        CONSTRAINT `PK_licenciaConducir` PRIMARY KEY (`licenciaConducirId`)
    );

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;


DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20200816021949_init') THEN

    CREATE TABLE `pais` (
        `paisId` int NOT NULL AUTO_INCREMENT,
        `paisNombre` nvarchar(150) NOT NULL,
        CONSTRAINT `PK_pais` PRIMARY KEY (`paisId`)
    );

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;


DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20200816021949_init') THEN

    CREATE TABLE `paisDepartamento` (
        `paisDepartamentoId` int NOT NULL AUTO_INCREMENT,
        `paisDepartamentoNombre` nvarchar(150) NULL,
        `pais_Id` int NOT NULL,
        CONSTRAINT `PK_paisDepartamento` PRIMARY KEY (`paisDepartamentoId`),
        CONSTRAINT `FK_paisDepartamento_pais_pais_Id` FOREIGN KEY (`pais_Id`) REFERENCES `pais` (`paisId`) ON DELETE RESTRICT
    );

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;


DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20200816021949_init') THEN

    CREATE TABLE `paisCiudad` (
        `paisCiudadId` int NOT NULL AUTO_INCREMENT,
        `paisCiudadNombre` nvarchar(150) NULL,
        `paisDepartamento_Id` int NOT NULL,
        CONSTRAINT `PK_paisCiudad` PRIMARY KEY (`paisCiudadId`),
        CONSTRAINT `FK_paisCiudad_paisDepartamento_paisDepartamento_Id` FOREIGN KEY (`paisDepartamento_Id`) REFERENCES `paisDepartamento` (`paisDepartamentoId`) ON DELETE RESTRICT
    );

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;


DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20200816021949_init') THEN

    CREATE TABLE `usuario` (
        `usuarioId` int NOT NULL AUTO_INCREMENT,
        `usuarioNombre` nvarchar(150) NOT NULL,
        `usuarioCorreo` nvarchar(150) NOT NULL,
        `usuarioContraseña` nvarchar(150) NOT NULL,
        `usuarioDNI` nvarchar(150) NULL,
        `usuarioTelefono` nvarchar(150) NULL,
        `usuarioSkype` nvarchar(150) NULL,
        `usuarioDireccion` nvarchar(150) NULL,
        `usuarioCodigoPostal` nvarchar(150) NULL,
        `usuarioEstadoCivil` char(1) NOT NULL,
        `usuarioVehiculoPropio` char(1) NOT NULL,
        `usuarioGenero` char(1) NOT NULL,
        `usuarioFechaNacimiento` date NOT NULL,
        `usuarioTimestamp` timestamp(6) NULL DEFAULT CURRENT_TIMESTAMP(6) ON UPDATE CURRENT_TIMESTAMP(6),
        `pais_Id` int NOT NULL,
        `paisDepartamento_Id` int NOT NULL,
        `paisCiudad_Id` int NOT NULL,
        `licenciaConducir_Id` int NOT NULL,
        CONSTRAINT `PK_usuario` PRIMARY KEY (`usuarioId`),
        CONSTRAINT `FK_usuario_licenciaConducir_licenciaConducir_Id` FOREIGN KEY (`licenciaConducir_Id`) REFERENCES `licenciaConducir` (`licenciaConducirId`) ON DELETE RESTRICT,
        CONSTRAINT `FK_usuario_paisCiudad_paisCiudad_Id` FOREIGN KEY (`paisCiudad_Id`) REFERENCES `paisCiudad` (`paisCiudadId`) ON DELETE RESTRICT,
        CONSTRAINT `FK_usuario_paisDepartamento_paisDepartamento_Id` FOREIGN KEY (`paisDepartamento_Id`) REFERENCES `paisDepartamento` (`paisDepartamentoId`) ON DELETE RESTRICT,
        CONSTRAINT `FK_usuario_pais_pais_Id` FOREIGN KEY (`pais_Id`) REFERENCES `pais` (`paisId`) ON DELETE RESTRICT
    );

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;


DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20200816021949_init') THEN

    CREATE INDEX `IX_paisCiudad_paisDepartamento_Id` ON `paisCiudad` (`paisDepartamento_Id`);

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;


DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20200816021949_init') THEN

    CREATE INDEX `IX_paisDepartamento_pais_Id` ON `paisDepartamento` (`pais_Id`);

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;


DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20200816021949_init') THEN

    CREATE INDEX `IX_usuario_licenciaConducir_Id` ON `usuario` (`licenciaConducir_Id`);

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;


DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20200816021949_init') THEN

    CREATE INDEX `IX_usuario_paisCiudad_Id` ON `usuario` (`paisCiudad_Id`);

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;


DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20200816021949_init') THEN

    CREATE INDEX `IX_usuario_paisDepartamento_Id` ON `usuario` (`paisDepartamento_Id`);

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;


DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20200816021949_init') THEN

    CREATE INDEX `IX_usuario_pais_Id` ON `usuario` (`pais_Id`);

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;


DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20200816021949_init') THEN

    INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
    VALUES ('20200816021949_init', '3.1.7');

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;


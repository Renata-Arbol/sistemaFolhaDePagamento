CREATE TABLE IF NOT EXISTS `__EFMigrationsHistory` (
    `MigrationId` varchar(150) CHARACTER SET utf8mb4 NOT NULL,
    `ProductVersion` varchar(32) CHARACTER SET utf8mb4 NOT NULL,
    CONSTRAINT `PK___EFMigrationsHistory` PRIMARY KEY (`MigrationId`)
) CHARACTER SET=utf8mb4;

START TRANSACTION;

ALTER DATABASE CHARACTER SET utf8mb4;

CREATE TABLE `Empresas` (
    `auto_id` bigint NOT NULL AUTO_INCREMENT,
    `Nome` longtext CHARACTER SET utf8mb4 NOT NULL,
    `Cnpj` varchar(14) CHARACTER SET utf8mb4 NOT NULL,
    `RazaoSocial` longtext CHARACTER SET utf8mb4 NOT NULL,
    `Telefone` longtext CHARACTER SET utf8mb4 NOT NULL,
    CONSTRAINT `PK_Empresas` PRIMARY KEY (`auto_id`)
) CHARACTER SET=utf8mb4;

CREATE TABLE `TiposEmail` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Nome` longtext CHARACTER SET utf8mb4 NOT NULL,
    CONSTRAINT `PK_TiposEmail` PRIMARY KEY (`Id`)
) CHARACTER SET=utf8mb4;

CREATE TABLE `Departamentos` (
    `auto_id` bigint NOT NULL AUTO_INCREMENT,
    `Nome` longtext CHARACTER SET utf8mb4 NOT NULL,
    `Descricao` longtext CHARACTER SET utf8mb4 NOT NULL,
    `EmpresaId` bigint NULL,
    CONSTRAINT `PK_Departamentos` PRIMARY KEY (`auto_id`),
    CONSTRAINT `FK_Departamentos_Empresas_EmpresaId` FOREIGN KEY (`EmpresaId`) REFERENCES `Empresas` (`auto_id`)
) CHARACTER SET=utf8mb4;

CREATE TABLE `Cargos` (
    `auto_id` bigint NOT NULL AUTO_INCREMENT,
    `Nome` longtext CHARACTER SET utf8mb4 NOT NULL,
    `JornadaTrabalhoHoras` int NOT NULL,
    `SalarioMensal` decimal(65,30) NOT NULL,
    `SalarioHora` decimal(65,30) NOT NULL,
    `DepartamentoId` bigint NULL,
    CONSTRAINT `PK_Cargos` PRIMARY KEY (`auto_id`),
    CONSTRAINT `FK_Cargos_Departamentos_DepartamentoId` FOREIGN KEY (`DepartamentoId`) REFERENCES `Departamentos` (`auto_id`)
) CHARACTER SET=utf8mb4;

CREATE TABLE `Contatos` (
    `auto_id` bigint NOT NULL AUTO_INCREMENT,
    `Email` longtext CHARACTER SET utf8mb4 NOT NULL,
    `Telefone` longtext CHARACTER SET utf8mb4 NOT NULL,
    `FuncionarioId` bigint NULL,
    CONSTRAINT `PK_Contatos` PRIMARY KEY (`auto_id`)
) CHARACTER SET=utf8mb4;

CREATE TABLE `Dependentes` (
    `auto_id` bigint NOT NULL AUTO_INCREMENT,
    `Nome` longtext CHARACTER SET utf8mb4 NOT NULL,
    `DataNascimento` datetime(6) NOT NULL,
    `GrauParentesco` longtext CHARACTER SET utf8mb4 NOT NULL,
    `FuncionarioId` bigint NULL,
    CONSTRAINT `PK_Dependentes` PRIMARY KEY (`auto_id`)
) CHARACTER SET=utf8mb4;

CREATE TABLE `Documentos` (
    `auto_id` bigint NOT NULL AUTO_INCREMENT,
    `RG` varchar(20) CHARACTER SET utf8mb4 NOT NULL,
    `CPF` varchar(11) CHARACTER SET utf8mb4 NOT NULL,
    `DataNascimento` datetime(6) NOT NULL,
    `DataEmissao` datetime(6) NOT NULL,
    `OrgaoEmissor` varchar(10) CHARACTER SET utf8mb4 NOT NULL,
    `EstadoEmissor` varchar(2) CHARACTER SET utf8mb4 NOT NULL,
    `PaisEmissor` longtext CHARACTER SET utf8mb4 NOT NULL,
    `Sexo` longtext CHARACTER SET utf8mb4 NOT NULL,
    `FuncionarioId` bigint NULL,
    CONSTRAINT `PK_Documentos` PRIMARY KEY (`auto_id`)
) CHARACTER SET=utf8mb4;

CREATE TABLE `Funcionarios` (
    `auto_id` bigint NOT NULL AUTO_INCREMENT,
    `Nome` longtext CHARACTER SET utf8mb4 NOT NULL,
    `DataNascimento` datetime(6) NOT NULL,
    `DocumentoId` bigint NULL,
    `LoginId` bigint NULL,
    `EmpresaId` bigint NOT NULL,
    CONSTRAINT `PK_Funcionarios` PRIMARY KEY (`auto_id`),
    CONSTRAINT `FK_Funcionarios_DocumentoId` FOREIGN KEY (`DocumentoId`) REFERENCES `Documentos` (`auto_id`),
    CONSTRAINT `FK_Funcionarios_Empresa` FOREIGN KEY (`EmpresaId`) REFERENCES `Empresas` (`auto_id`) ON DELETE CASCADE,
    CONSTRAINT `FK_Funcionarios_Empresas_EmpresaId1` FOREIGN KEY (`EmpresaId1`) REFERENCES `Empresas` (`auto_id`)
) CHARACTER SET=utf8mb4;

CREATE TABLE `Enderecos` (
    `auto_id` bigint NOT NULL AUTO_INCREMENT,
    `Rua` longtext CHARACTER SET utf8mb4 NOT NULL,
    `Numero` longtext CHARACTER SET utf8mb4 NOT NULL,
    `Complemento` longtext CHARACTER SET utf8mb4 NULL,
    `Bairro` longtext CHARACTER SET utf8mb4 NOT NULL,
    `Cidade` longtext CHARACTER SET utf8mb4 NOT NULL,
    `Estado` varchar(2) CHARACTER SET utf8mb4 NOT NULL,
    `CEP` varchar(8) CHARACTER SET utf8mb4 NOT NULL,
    `EmpresaId` bigint NULL,
    `FuncionarioId` bigint NULL,
    CONSTRAINT `PK_Enderecos` PRIMARY KEY (`auto_id`),
    CONSTRAINT `FK_Enderecos_Empresas_EmpresaId` FOREIGN KEY (`EmpresaId`) REFERENCES `Empresas` (`auto_id`),
    CONSTRAINT `FK_Enderecos_Funcionarios_FuncionarioId` FOREIGN KEY (`FuncionarioId`) REFERENCES `Funcionarios` (`auto_id`)
) CHARACTER SET=utf8mb4;

CREATE TABLE `FuncionariosCargos` (
    `auto_id` bigint NOT NULL AUTO_INCREMENT,
    `FuncionarioId` bigint NULL,
    `CargoId` bigint NULL,
    `DataInicio` datetime(6) NULL,
    `DataFim` datetime(6) NULL,
    `Atual` int NOT NULL,
    CONSTRAINT `PK_FuncionariosCargos` PRIMARY KEY (`auto_id`),
    CONSTRAINT `FK_FuncionariosCargos_Cargos_CargoId` FOREIGN KEY (`CargoId`) REFERENCES `Cargos` (`auto_id`),
    CONSTRAINT `FK_FuncionariosCargos_Funcionarios_FuncionarioId` FOREIGN KEY (`FuncionarioId`) REFERENCES `Funcionarios` (`auto_id`)
) CHARACTER SET=utf8mb4;

CREATE TABLE `Logins` (
    `Id` bigint NOT NULL AUTO_INCREMENT,
    `Usuario` longtext CHARACTER SET utf8mb4 NOT NULL,
    `Senha` longtext CHARACTER SET utf8mb4 NOT NULL,
    `EmpresaId` bigint NULL,
    `FuncionarioId` bigint NULL,
    CONSTRAINT `PK_Logins` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_Funcionarios_Login` FOREIGN KEY (`FuncionarioId`) REFERENCES `Funcionarios` (`auto_id`),
    CONSTRAINT `FK_Logins_Empresas_EmpresaId` FOREIGN KEY (`EmpresaId`) REFERENCES `Empresas` (`auto_id`)
) CHARACTER SET=utf8mb4;

CREATE TABLE `Telefones` (
    `auto_id` int NOT NULL AUTO_INCREMENT,
    `Numero` varchar(20) CHARACTER SET utf8mb4 NOT NULL,
    `Tipo` varchar(255) CHARACTER SET utf8mb4 NOT NULL,
    `FuncionarioId` bigint NULL,
    CONSTRAINT `PK_Telefones` PRIMARY KEY (`auto_id`),
    CONSTRAINT `FK_Telefones_Funcionarios_FuncionarioId` FOREIGN KEY (`FuncionarioId`) REFERENCES `Funcionarios` (`auto_id`)
) CHARACTER SET=utf8mb4;

CREATE TABLE `RegistroPontos` (
    `auto_id` int NOT NULL AUTO_INCREMENT,
    `DataHora` datetime(6) NOT NULL,
    `Tipo` varchar(50) CHARACTER SET utf8mb4 NOT NULL,
    `Observacao` varchar(255) CHARACTER SET utf8mb4 NULL,
    `FuncionarioCargoId` bigint NULL,
    CONSTRAINT `PK_RegistroPontos` PRIMARY KEY (`auto_id`),
    CONSTRAINT `FK_RegistroPontos_FuncionariosCargos_FuncionarioCargoId` FOREIGN KEY (`FuncionarioCargoId`) REFERENCES `FuncionariosCargos` (`auto_id`)
) CHARACTER SET=utf8mb4;

CREATE INDEX `IX_Cargos_DepartamentoId` ON `Cargos` (`DepartamentoId`);

CREATE INDEX `IX_Contatos_FuncionarioId` ON `Contatos` (`FuncionarioId`);

CREATE INDEX `IX_Departamentos_EmpresaId` ON `Departamentos` (`EmpresaId`);

CREATE INDEX `IX_Dependentes_FuncionarioId` ON `Dependentes` (`FuncionarioId`);

CREATE INDEX `IX_Documentos_FuncionarioId` ON `Documentos` (`FuncionarioId`);

CREATE INDEX `IX_Enderecos_EmpresaId` ON `Enderecos` (`EmpresaId`);

CREATE INDEX `IX_Enderecos_FuncionarioId` ON `Enderecos` (`FuncionarioId`);

CREATE INDEX `IX_Funcionarios_DocumentoId` ON `Funcionarios` (`DocumentoId`);

CREATE INDEX `IX_Funcionarios_EmpresaId` ON `Funcionarios` (`EmpresaId`);

CREATE INDEX `IX_Funcionarios_EmpresaId1` ON `Funcionarios` (`EmpresaId1`);

CREATE INDEX `IX_FuncionariosCargos_CargoId` ON `FuncionariosCargos` (`CargoId`);

CREATE INDEX `IX_FuncionariosCargos_FuncionarioId` ON `FuncionariosCargos` (`FuncionarioId`);

CREATE INDEX `IX_Logins_EmpresaId` ON `Logins` (`EmpresaId`);

CREATE UNIQUE INDEX `IX_Logins_FuncionarioId` ON `Logins` (`FuncionarioId`);

CREATE INDEX `IX_RegistroPontos_FuncionarioCargoId` ON `RegistroPontos` (`FuncionarioCargoId`);

CREATE INDEX `IX_Telefones_FuncionarioId` ON `Telefones` (`FuncionarioId`);

ALTER TABLE `Contatos` ADD CONSTRAINT `FK_Contatos_Funcionarios_FuncionarioId` FOREIGN KEY (`FuncionarioId`) REFERENCES `Funcionarios` (`auto_id`);

ALTER TABLE `Dependentes` ADD CONSTRAINT `FK_Dependentes_Funcionarios_FuncionarioId` FOREIGN KEY (`FuncionarioId`) REFERENCES `Funcionarios` (`auto_id`);

ALTER TABLE `Documentos` ADD CONSTRAINT `FK_Documentos_Funcionarios_FuncionarioId` FOREIGN KEY (`FuncionarioId`) REFERENCES `Funcionarios` (`auto_id`);

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20230917034802_allModelsUpdate1.0.0', '7.0.11');

COMMIT;

START TRANSACTION;

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20230917035848_allModelsUpdate1.0.1', '7.0.11');

COMMIT;

START TRANSACTION;

CREATE TABLE `Pagamentos` (
    `auto_id` bigint NOT NULL AUTO_INCREMENT,
    `ValorLiquido` double NOT NULL,
    CONSTRAINT `PK_Pagamentos` PRIMARY KEY (`auto_id`)
) CHARACTER SET=utf8mb4;

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20231014185918_Pagamento', '7.0.11');

COMMIT;

START TRANSACTION;

CREATE TABLE `TabelaINSS` (
    `auto_id` bigint NOT NULL AUTO_INCREMENT,
    `Aliquota` decimal(65,30) NOT NULL,
    `FaixaInicial` decimal(65,30) NOT NULL,
    `FaixaFinal` decimal(65,30) NOT NULL,
    CONSTRAINT `PK_TabelaINSS` PRIMARY KEY (`auto_id`)
) CHARACTER SET=utf8mb4;

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20231014230746_TabelaINSS', '7.0.11');

COMMIT;

START TRANSACTION;

CREATE TABLE `TabelaIR` (
    `auto_id` bigint NOT NULL AUTO_INCREMENT,
    `Aliquota` decimal(65,30) NOT NULL,
    `FaixaInicial` decimal(65,30) NOT NULL,
    `FaixaFinal` decimal(65,30) NOT NULL,
    `Deducao` decimal(65,30) NOT NULL,
    CONSTRAINT `PK_TabelaIR` PRIMARY KEY (`auto_id`)
) CHARACTER SET=utf8mb4;

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20231014233456_TabelaIR', '7.0.11');

COMMIT;

START TRANSACTION;

ALTER TABLE `Cargos` DROP FOREIGN KEY `FK_Cargos_Departamentos_DepartamentoId`;

DROP TABLE `Departamentos`;

DROP TABLE `Telefones`;

DROP TABLE `TiposEmail`;

ALTER TABLE `Cargos` DROP INDEX `IX_Cargos_DepartamentoId`;

ALTER TABLE `Cargos` DROP COLUMN `DepartamentoId`;

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20231025190230_update', '7.0.11');

COMMIT;

START TRANSACTION;

ALTER TABLE `Funcionarios` ADD `Email` longtext CHARACTER SET utf8mb4 NOT NULL;

ALTER TABLE `Funcionarios` ADD `EstadoCivil` longtext CHARACTER SET utf8mb4 NOT NULL;

ALTER TABLE `Funcionarios` ADD `Nacionalidade` longtext CHARACTER SET utf8mb4 NOT NULL;

ALTER TABLE `Funcionarios` ADD `NoCtps` longtext CHARACTER SET utf8mb4 NOT NULL;

ALTER TABLE `Funcionarios` ADD `PIS` longtext CHARACTER SET utf8mb4 NOT NULL;

ALTER TABLE `Funcionarios` ADD `RNE` longtext CHARACTER SET utf8mb4 NOT NULL;

ALTER TABLE `Funcionarios` ADD `Sexo` longtext CHARACTER SET utf8mb4 NOT NULL;

ALTER TABLE `Funcionarios` ADD `Telefone` longtext CHARACTER SET utf8mb4 NOT NULL;

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20231025191612_update-adding', '7.0.11');

COMMIT;

START TRANSACTION;

ALTER TABLE `Funcionarios` DROP COLUMN `EstadoCivil`;

ALTER TABLE `Funcionarios` DROP COLUMN `Nacionalidade`;

ALTER TABLE `Funcionarios` DROP COLUMN `NoCtps`;

ALTER TABLE `Funcionarios` DROP COLUMN `PIS`;

ALTER TABLE `Funcionarios` DROP COLUMN `RNE`;

ALTER TABLE `Documentos` ADD `EstadoCivil` longtext CHARACTER SET utf8mb4 NOT NULL;

ALTER TABLE `Documentos` ADD `Nacionalidade` longtext CHARACTER SET utf8mb4 NOT NULL;

ALTER TABLE `Documentos` ADD `NoCtps` longtext CHARACTER SET utf8mb4 NOT NULL;

ALTER TABLE `Documentos` ADD `PIS` longtext CHARACTER SET utf8mb4 NOT NULL;

ALTER TABLE `Documentos` ADD `RNE` longtext CHARACTER SET utf8mb4 NOT NULL;

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20231025193343_update-docs', '7.0.11');

COMMIT;

START TRANSACTION;

ALTER TABLE `Documentos` DROP COLUMN `DataNascimento`;

ALTER TABLE `Documentos` DROP COLUMN `Sexo`;

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20231026014050_CleanUp-func-doc', '7.0.11');

COMMIT;



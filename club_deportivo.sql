CREATE DATABASE IF NOT EXISTS club_deportivo CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci;
USE club_deportivo;
CREATE TABLE IF NOT EXISTS usuarios(
 id_usuario BIGINT AUTO_INCREMENT PRIMARY KEY,
 nombre_usuario VARCHAR(40) NOT NULL UNIQUE,
 password_hash CHAR(64) NOT NULL,
 rol ENUM('ADMINISTRADOR','OPERADOR') NOT NULL DEFAULT 'OPERADOR',
 activo BOOLEAN NOT NULL DEFAULT TRUE
);
CREATE TABLE IF NOT EXISTS personas(
 id_persona BIGINT AUTO_INCREMENT PRIMARY KEY,
 nombre VARCHAR(60) NOT NULL, apellido VARCHAR(60) NOT NULL,
 tipo_documento VARCHAR(15) NOT NULL, documento VARCHAR(20) NOT NULL UNIQUE,
 telefono VARCHAR(30) NOT NULL, email VARCHAR(120) NOT NULL,
 es_socio BOOLEAN NOT NULL DEFAULT FALSE, apto_fisico BOOLEAN NOT NULL DEFAULT FALSE,
 ficha_completa BOOLEAN NOT NULL DEFAULT FALSE,
 fecha_alta DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP
);
CREATE TABLE IF NOT EXISTS socios(
 id_socio BIGINT AUTO_INCREMENT PRIMARY KEY, id_persona BIGINT NOT NULL UNIQUE,
 fecha_alta DATE NOT NULL DEFAULT (CURRENT_DATE),
 FOREIGN KEY(id_persona) REFERENCES personas(id_persona)
);
CREATE TABLE IF NOT EXISTS carnets(
 id_carnet BIGINT AUTO_INCREMENT PRIMARY KEY, id_socio BIGINT NOT NULL UNIQUE,
 fecha_emision DATE NOT NULL,
 FOREIGN KEY(id_socio) REFERENCES socios(id_socio)
);
CREATE TABLE IF NOT EXISTS pagos(
 id_pago BIGINT AUTO_INCREMENT PRIMARY KEY, id_persona BIGINT NOT NULL,
 tipo_pago ENUM('MENSUAL','DIARIA') NOT NULL, monto DECIMAL(12,2) NOT NULL,
 fecha_pago DATE NOT NULL, fecha_inicio DATE NOT NULL, fecha_vencimiento DATE NOT NULL,
 FOREIGN KEY(id_persona) REFERENCES personas(id_persona),
 INDEX ix_pagos_vencimiento(fecha_vencimiento), INDEX ix_pagos_persona(id_persona)
);
-- Usuario inicial admin / Club2026! (cambiar luego del primer ingreso)
INSERT IGNORE INTO usuarios(nombre_usuario,password_hash,rol)
VALUES('admin','6D4C95F6BB4D09E42A97D525E6FFC1A7720B33E7D44AD341264F8A16FE8504A2','ADMINISTRADOR');
DELIMITER $$
DROP PROCEDURE IF EXISTS sp_buscar_persona_por_documento$$
CREATE PROCEDURE sp_buscar_persona_por_documento(IN p_documento VARCHAR(20))
BEGIN
 SELECT id_persona,nombre,apellido,documento,es_socio FROM personas WHERE documento=p_documento;
END$$
DROP PROCEDURE IF EXISTS sp_vencimientos$$
CREATE PROCEDURE sp_vencimientos()
BEGIN
 SELECT pe.apellido,pe.nombre,pe.documento,pa.tipo_pago,pa.monto,pa.fecha_vencimiento
 FROM pagos pa JOIN personas pe ON pe.id_persona=pa.id_persona
 WHERE pe.es_socio=TRUE
 AND pa.tipo_pago='MENSUAL'
 AND pa.id_pago=(SELECT MAX(p2.id_pago) FROM pagos p2 WHERE p2.id_persona=pa.id_persona AND p2.tipo_pago='MENSUAL')
 AND pa.fecha_vencimiento=CURRENT_DATE
 ORDER BY pa.fecha_vencimiento;
END$$
DELIMITER ;

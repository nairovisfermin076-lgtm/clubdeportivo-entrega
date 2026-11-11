/* =====================================================
   BASE DE DATOS: CLUB
   Orden del script:
   1. Crear base
   2. Tablas
   3. Procedimiento almacenado (login)
   4. Datos de prueba
   5. Consultas de prueba
   ===================================================== */


/* =====================================================
   1. CREAR BASE
   ===================================================== */

DROP DATABASE IF EXISTS club;
CREATE DATABASE club;
USE club;


/* =====================================================
   2. TABLAS
   ===================================================== */

/* ACA VOY CREANDO USUARIOS DEL SISTEMA PARA PODER PROGRAMAR EL LOGIN */

CREATE TABLE usuarios (
    id_usuario INT PRIMARY KEY AUTO_INCREMENT,
    nombre_usuario VARCHAR(30) UNIQUE NOT NULL,
    contrasenia VARCHAR(30) NOT NULL,
    rol VARCHAR(30) NOT NULL
);


/* ACA LA TABLA DE LA CLASE PERSONA */

CREATE TABLE persona (
    id_persona INT PRIMARY KEY AUTO_INCREMENT,
    nombre VARCHAR(30) NOT NULL,
    apellido VARCHAR(30) NOT NULL,
    documento VARCHAR(15) NOT NULL UNIQUE
);


/* ACA LA DE LA CLASE SOCIO */

CREATE TABLE socio (
    id_socio INT PRIMARY KEY AUTO_INCREMENT,
    id_persona INT NOT NULL UNIQUE,
    fecha_alta DATE NOT NULL DEFAULT (CURRENT_DATE),
    FOREIGN KEY (id_persona) REFERENCES persona(id_persona)
);


/* ACA LA CLASE CARNET */

CREATE TABLE carnet (
    nro_carnet INT PRIMARY KEY AUTO_INCREMENT,
    id_socio INT NOT NULL UNIQUE,
    fecha_entrega DATE NOT NULL,
    FOREIGN KEY (id_socio) REFERENCES socio(id_socio)
);


/* ACA LOS PAGOS Y VENCIMIENTOS */

CREATE TABLE cuota (
    id_cuota INT PRIMARY KEY AUTO_INCREMENT,
    id_persona INT NOT NULL,
    tipo_cuota ENUM('MENSUAL','DIARIA') NOT NULL,
    monto DECIMAL(10,2) NOT NULL,
    fecha_pago DATE NOT NULL,
    fecha_inicio DATE NOT NULL,
    fecha_vencimiento DATE NOT NULL,
    FOREIGN KEY (id_persona) REFERENCES persona(id_persona)
);

/* NOTA DE DISEÑO:
   NO CREE UNA TABLA DE NO SOCIOS. ESA INFO SE PUEDE SACAR DEL TIPO DE CUOTA QUE ABONA
   ES DECIR DIARIA O MENSUAL. SUPONGO QUE CUANDO SE IMPLEMENTE VA A SER POSIBLE DISCERNIR ASI
   EN EL FORO UN LOCO PREGUNTO POR SI UN NO SOCIO PASA A SER SOCIO, CREO QUE MODIFICANDO EL TIPO DE CUOTA
   VA ADEMAS DE IMPRIMIRLE UN CARNET. HAY Q MIRARLO BIEN ESO */


/* =====================================================
   3. PROCEDIMIENTO ALMACENADO PARA EL LOGIN
   (el SP de login se debe llamar ingresoLogin)
   Se cambia el delimitador de linea para poder almacenar en
   el sistema gestor el codigo del procedimiento.
   Se puede utilizar cualquier caracter.
   ===================================================== */

DROP PROCEDURE IF EXISTS ingresoLogin;

DELIMITER $$

CREATE PROCEDURE ingresoLogin(
    IN p_usuario VARCHAR(30),
    IN p_clave VARCHAR(30)
)
BEGIN
    SELECT id_usuario, nombre_usuario, rol
    FROM usuarios
    WHERE nombre_usuario = p_usuario
      AND contrasenia = p_clave;
END$$

DELIMITER ;


/* =====================================================
   4. DATOS DE PRUEBA
   ===================================================== */

/* USUARIOS (NOS CARGO A NOSOTROS) */

INSERT INTO usuarios (nombre_usuario, contrasenia, rol)
VALUES
    ('Rodrigo', '123456', 'administrador'),
    ('Nairovis', '123456', 'administrador'),
    ('Leo', '123456', 'administrador'),
    ('Enrique', '123456', 'administrador');


/* PERSONAS */

INSERT INTO persona (nombre, apellido, documento)
VALUES
('Juan', 'Perez', '30111222'),
('Maria', 'Gomez', '28999888'),
('Carlos', 'Lopez', '33444555'),
('Ana', 'Rodriguez', '27666777'),
('Lucia', 'Fernandez', '35123456'),
('Pedro', 'Martinez', '31987654');


/* SOCIOS */

INSERT INTO socio (id_persona, fecha_alta)
VALUES
(1, '2026-09-01'),
(2, '2026-09-05'),
(4, '2026-09-10'),
(5, '2026-10-01');


/* CARNETS */

INSERT INTO carnet (id_socio, fecha_entrega)
VALUES
(1, '2026-09-01'),
(2, '2026-09-05'),
(3, '2026-09-10'),
(4, '2026-10-01');


/* CUOTAS */

INSERT INTO cuota
(id_persona, tipo_cuota, monto, fecha_pago, fecha_inicio, fecha_vencimiento)
VALUES
(1, 'mensual', 15000.00, '2026-10-01', '2026-10-01', '2026-10-31'),
(2, 'mensual', 15000.00, '2026-09-01', '2026-09-01', '2026-09-30'),
(3, 'diaria', 2000.00, '2026-10-06', '2026-10-06', '2026-10-06'),
(4, 'mensual', 15000.00, '2026-09-10', '2026-09-10', '2026-10-09'),
(5, 'mensual', 15000.00, '2026-10-01', '2026-10-01', '2026-10-31'),
(5, 'mensual', 15000.00, '2026-09-01', '2026-09-01', '2026-09-30'),
(6, 'diaria', 2000.00, '2026-10-06', '2026-10-06', '2026-10-06');


/* =====================================================
   5. CONSULTAS DE PRUEBA
   ===================================================== */

/* 0. PROBAR EL LOGIN */

CALL ingresoLogin('Rodrigo', '123456');


/* 1. VER TODAS LAS PERSONAS */

SELECT *
FROM persona;


/* 2. VER TODOS LOS SOCIOS */

SELECT *
FROM socio;


/* 3. BUSCAR UNA PERSONA POR DOCUMENTO */

SELECT *
FROM persona
WHERE documento = '30111222';


/* 4. BUSCAR PERSONAS POR APELLIDO */

SELECT *
FROM persona
WHERE apellido = 'Perez';


/* 5. VER SOCIOS CON SUS DATOS PERSONALES */

SELECT
    persona.nombre,
    persona.apellido,
    persona.documento,
    socio.fecha_alta
FROM persona
INNER JOIN socio
ON persona.id_persona = socio.id_persona;


/* 6. VER SOCIOS CON NUMERO DE CARNET */

SELECT
    persona.nombre,
    persona.apellido,
    persona.documento,
    socio.fecha_alta,
    carnet.nro_carnet,
    carnet.fecha_entrega
FROM persona
INNER JOIN socio
ON persona.id_persona = socio.id_persona
INNER JOIN carnet
ON socio.id_socio = carnet.id_socio;


/* 7. VER TODAS LAS CUOTAS */

SELECT *
FROM cuota;


/* 8. VER SOLAMENTE CUOTAS MENSUALES */

SELECT *
FROM cuota
WHERE tipo_cuota = 'mensual';


/* 9. VER SOLAMENTE PAGOS DIARIOS */

SELECT *
FROM cuota
WHERE tipo_cuota = 'diaria';


/* 10. VER LAS CUOTAS DE UNA PERSONA */

SELECT *
FROM cuota
WHERE id_persona = 1;


/* 11. VER CUOTAS CON LOS DATOS DE LA PERSONA */

SELECT
    persona.nombre,
    persona.apellido,
    persona.documento,
    cuota.tipo_cuota,
    cuota.monto,
    cuota.fecha_pago,
    cuota.fecha_inicio,
    cuota.fecha_vencimiento
FROM persona
INNER JOIN cuota
ON persona.id_persona = cuota.id_persona;


/* 12. VER CUOTAS VENCIDAS */

SELECT *
FROM cuota
WHERE fecha_vencimiento < CURRENT_DATE;


/* 13. VER CUOTAS QUE VENCEN HOY */

SELECT *
FROM cuota
WHERE fecha_vencimiento = CURRENT_DATE;


/* 14. VER SOCIOS CUYA CUOTA VENCE HOY */

SELECT
    persona.apellido,
    persona.nombre,
    persona.documento,
    cuota.fecha_vencimiento
FROM persona
INNER JOIN socio
ON persona.id_persona = socio.id_persona
INNER JOIN cuota
ON persona.id_persona = cuota.id_persona
WHERE cuota.fecha_vencimiento = CURRENT_DATE;


/* 15. VER SOCIOS ORDENADOS POR APELLIDO */

SELECT
    persona.apellido,
    persona.nombre,
    persona.documento
FROM persona
INNER JOIN socio
ON persona.id_persona = socio.id_persona
ORDER BY persona.apellido;


/* 16. VER SOCIOS CON CUOTA VENCIDA */

SELECT
    persona.apellido,
    persona.nombre,
    persona.documento,
    cuota.fecha_vencimiento
FROM persona
INNER JOIN socio
ON persona.id_persona = socio.id_persona
INNER JOIN cuota
ON persona.id_persona = cuota.id_persona
WHERE cuota.fecha_vencimiento < CURRENT_DATE;


/* 17. VER TODAS LAS PERSONAS Y SABER SI SON SOCIOS */

SELECT
    persona.nombre,
    persona.apellido,
    persona.documento,
    socio.id_socio
FROM persona
LEFT JOIN socio
ON persona.id_persona = socio.id_persona;


/* =====================================================
   6. PRUEBA: CARLOS SE HACE SOCIO
   (esto modifica datos, por eso va al final)
   ===================================================== */

INSERT INTO socio (id_persona, fecha_alta)
VALUES (3, CURRENT_DATE);


/* VERIFICAR QUE CARLOS AHORA ES SOCIO */

SELECT
    persona.nombre,
    persona.apellido,
    persona.documento,
    socio.id_socio,
    socio.fecha_alta
FROM persona
INNER JOIN socio
ON persona.id_persona = socio.id_persona
WHERE persona.id_persona = 3;
CALL ingresoLogin('Rodrigo','123456');
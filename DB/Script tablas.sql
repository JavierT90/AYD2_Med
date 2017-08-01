-- Generado por Oracle SQL Developer Data Modeler 4.1.3.901
--   en:        2017-05-03 18:04:50 CST
--   sitio:      SQL Server 2012
--   tipo:      SQL Server 2012




CREATE
  TABLE CITA
  (
    id_cita  INTEGER NOT NULL IDENTITY NOT FOR REPLICATION ,
    fecha    DATE ,
    hora     VARCHAR (50) ,
    paciente INTEGER NOT NULL ,
    personal INTEGER NOT NULL ,
    sala     INTEGER NOT NULL
  )
  ON "default"
GO
ALTER TABLE CITA ADD CONSTRAINT CITA_PK PRIMARY KEY CLUSTERED (id_cita)
WITH
  (
    ALLOW_PAGE_LOCKS = ON ,
    ALLOW_ROW_LOCKS  = ON
  )
  ON "default"
GO

CREATE
  TABLE ENFERMEDAD
  (
    id_enfermedad INTEGER NOT NULL IDENTITY NOT FOR REPLICATION ,
    nombre        VARCHAR (50) ,
    descripcion   VARCHAR (250)
  )
  ON "default"
GO
ALTER TABLE ENFERMEDAD ADD CONSTRAINT ENFERMEDAD_PK PRIMARY KEY CLUSTERED (
id_enfermedad)
WITH
  (
    ALLOW_PAGE_LOCKS = ON ,
    ALLOW_ROW_LOCKS  = ON
  )
  ON "default"
GO

CREATE
  TABLE HISTORIAL
  (
    id_historial  INTEGER NOT NULL IDENTITY NOT FOR REPLICATION ,
    observaciones VARCHAR (250) ,
    cita          INTEGER NOT NULL ,
    receta        INTEGER NOT NULL ,
    enfermedad    INTEGER NOT NULL
  )
  ON "default"
GO
ALTER TABLE HISTORIAL ADD CONSTRAINT HISTORIAL_PK PRIMARY KEY CLUSTERED (
id_historial)
WITH
  (
    ALLOW_PAGE_LOCKS = ON ,
    ALLOW_ROW_LOCKS  = ON
  )
  ON "default"
GO

CREATE
  TABLE MEDICAMENTO
  (
    id_medicamento INTEGER NOT NULL IDENTITY NOT FOR REPLICATION ,
    nombre         VARCHAR (50) ,
    cantidad       INTEGER ,
    descripcion    VARCHAR (250)
  )
  ON "default"
GO
ALTER TABLE MEDICAMENTO ADD CONSTRAINT MEDICAMENTO_PK PRIMARY KEY CLUSTERED (
id_medicamento)
WITH
  (
    ALLOW_PAGE_LOCKS = ON ,
    ALLOW_ROW_LOCKS  = ON
  )
  ON "default"
GO

CREATE
  TABLE PACIENTE
  (
    id_paciente INTEGER NOT NULL IDENTITY NOT FOR REPLICATION ,
    Nombre      VARCHAR (50) ,
    contrasenia VARCHAR (50) ,
    dpi         VARCHAR (50) ,
    fecha_nac   DATE ,
    telefono    VARCHAR (50) ,
    email       VARCHAR (50) ,
    no_tarjeta  VARCHAR (50)
  )
  ON "default"
GO
ALTER TABLE PACIENTE ADD CONSTRAINT PACIENTE_PK PRIMARY KEY CLUSTERED (
id_paciente)
WITH
  (
    ALLOW_PAGE_LOCKS = ON ,
    ALLOW_ROW_LOCKS  = ON
  )
  ON "default"
GO

CREATE
  TABLE PERSONAL
  (
    id_personal INTEGER NOT NULL IDENTITY NOT FOR REPLICATION ,
    nombre      VARCHAR (50) ,
    tipo_puesto INTEGER NOT NULL
  )
  ON "default"
GO
ALTER TABLE PERSONAL ADD CONSTRAINT PERSONAL_PK PRIMARY KEY CLUSTERED (
id_personal)
WITH
  (
    ALLOW_PAGE_LOCKS = ON ,
    ALLOW_ROW_LOCKS  = ON
  )
  ON "default"
GO

CREATE
  TABLE RECETA
  (
    id_receta   INTEGER NOT NULL IDENTITY NOT FOR REPLICATION ,
    medicamento INTEGER NOT NULL
  )
  ON "default"
GO
ALTER TABLE RECETA ADD CONSTRAINT RECETA_PK PRIMARY KEY CLUSTERED (id_receta)
WITH
  (
    ALLOW_PAGE_LOCKS = ON ,
    ALLOW_ROW_LOCKS  = ON
  )
  ON "default"
GO

CREATE
  TABLE SALA
  (
    id_sala     INTEGER NOT NULL IDENTITY NOT FOR REPLICATION ,
    nombre      VARCHAR (50) ,
    descripción VARCHAR (250)
  )
  ON "default"
GO
ALTER TABLE SALA ADD CONSTRAINT SALA_PK PRIMARY KEY CLUSTERED (id_sala)
WITH
  (
    ALLOW_PAGE_LOCKS = ON ,
    ALLOW_ROW_LOCKS  = ON
  )
  ON "default"
GO

CREATE
  TABLE TIPO_PUESTO
  (
    id_tipo INTEGER NOT NULL IDENTITY NOT FOR REPLICATION ,
    nombre  VARCHAR (50)
  )
  ON "default"
GO
ALTER TABLE TIPO_PUESTO ADD CONSTRAINT TIPO_PUESTO_PK PRIMARY KEY CLUSTERED (
id_tipo)
WITH
  (
    ALLOW_PAGE_LOCKS = ON ,
    ALLOW_ROW_LOCKS  = ON
  )
  ON "default"
GO

CREATE
  TABLE USUARIO
  (
    id_usuario INTEGER NOT NULL IDENTITY NOT FOR REPLICATION ,
    usuario    VARCHAR (50) ,
    pass       VARCHAR (50) ,
    tipo       INTEGER
  )
  ON "default"
GO
ALTER TABLE USUARIO ADD CONSTRAINT USUARIO_PK PRIMARY KEY CLUSTERED (id_usuario
)
WITH
  (
    ALLOW_PAGE_LOCKS = ON ,
    ALLOW_ROW_LOCKS  = ON
  )
  ON "default"
GO

ALTER TABLE CITA
ADD CONSTRAINT CITA_PACIENTE_FK FOREIGN KEY
(
paciente
)
REFERENCES PACIENTE
(
id_paciente
)
ON
DELETE
  NO ACTION ON
UPDATE NO ACTION
GO

ALTER TABLE CITA
ADD CONSTRAINT CITA_PERSONAL_FK FOREIGN KEY
(
personal
)
REFERENCES PERSONAL
(
id_personal
)
ON
DELETE
  NO ACTION ON
UPDATE NO ACTION
GO

ALTER TABLE CITA
ADD CONSTRAINT CITA_SALA_FK FOREIGN KEY
(
sala
)
REFERENCES SALA
(
id_sala
)
ON
DELETE
  NO ACTION ON
UPDATE NO ACTION
GO

ALTER TABLE HISTORIAL
ADD CONSTRAINT HISTORIAL_CITA_FK FOREIGN KEY
(
cita
)
REFERENCES CITA
(
id_cita
)
ON
DELETE
  NO ACTION ON
UPDATE NO ACTION
GO

ALTER TABLE HISTORIAL
ADD CONSTRAINT HISTORIAL_ENFERMEDAD_FK FOREIGN KEY
(
enfermedad
)
REFERENCES ENFERMEDAD
(
id_enfermedad
)
ON
DELETE
  NO ACTION ON
UPDATE NO ACTION
GO

ALTER TABLE HISTORIAL
ADD CONSTRAINT HISTORIAL_RECETA_FK FOREIGN KEY
(
receta
)
REFERENCES RECETA
(
id_receta
)
ON
DELETE
  NO ACTION ON
UPDATE NO ACTION
GO

ALTER TABLE PERSONAL
ADD CONSTRAINT PERSONAL_TIPO_PUESTO_FK FOREIGN KEY
(
tipo_puesto
)
REFERENCES TIPO_PUESTO
(
id_tipo
)
ON
DELETE
  NO ACTION ON
UPDATE NO ACTION
GO

ALTER TABLE RECETA
ADD CONSTRAINT RECETA_MEDICAMENTO_FK FOREIGN KEY
(
medicamento
)
REFERENCES MEDICAMENTO
(
id_medicamento
)
ON
DELETE
  NO ACTION ON
UPDATE NO ACTION
GO


-- Informe de Resumen de Oracle SQL Developer Data Modeler: 
-- 
-- CREATE TABLE                            10
-- CREATE INDEX                             0
-- ALTER TABLE                             18
-- CREATE VIEW                              0
-- ALTER VIEW                               0
-- CREATE PACKAGE                           0
-- CREATE PACKAGE BODY                      0
-- CREATE PROCEDURE                         0
-- CREATE FUNCTION                          0
-- CREATE TRIGGER                           0
-- ALTER TRIGGER                            0
-- CREATE DATABASE                          0
-- CREATE DEFAULT                           0
-- CREATE INDEX ON VIEW                     0
-- CREATE ROLLBACK SEGMENT                  0
-- CREATE ROLE                              0
-- CREATE RULE                              0
-- CREATE SCHEMA                            0
-- CREATE SEQUENCE                          0
-- CREATE PARTITION FUNCTION                0
-- CREATE PARTITION SCHEME                  0
-- 
-- DROP DATABASE                            0
-- 
-- ERRORS                                   0
-- WARNINGS                                 0

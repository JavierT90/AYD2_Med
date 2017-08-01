INSERT INTO TIPO_PUESTO (nombre) VALUES('MEDICO')
INSERT INTO TIPO_PUESTO (nombre) VALUES('ENFERMERA')

INSERT INTO USUARIO(usuario, pass, tipo) VALUES('nat','123123',1)--ROL 1: ADMINISTRADOR
INSERT INTO USUARIO(usuario, pass, tipo) VALUES('ariel','123123',2)-- 


  INSERT INTO ENFERMEDAD (nombre, descripcion) VALUES ('COMÚN','gripe, fiebre...')
  INSERT INTO ENFERMEDAD (nombre, descripcion) VALUES ('HEPATITIS','tipo A')
  INSERT INTO ENFERMEDAD (nombre, descripcion) VALUES ('HEPATITIS','tipo B')

  INSERT INTO MEDICAMENTO (nombre, cantidad, descripcion)VALUES ('MED 1',2,'GOTAS')
  INSERT INTO MEDICAMENTO (nombre, cantidad, descripcion)VALUES ('MED 2',3,'CREMA')
  INSERT INTO MEDICAMENTO (nombre, cantidad, descripcion)VALUES ('MED 3',4,'PASTILLAS')

  INSERT INTO RECETA (medicamento) VALUES (1)
  INSERT INTO RECETA (medicamento) VALUES (2)
  INSERT INTO RECETA (medicamento) VALUES (3)

  INSERT INTO HISTORIAL (observaciones, cita, receta, enfermedad) VALUES ('nada',4,4,1)
  INSERT INTO HISTORIAL (observaciones, cita, receta, enfermedad) VALUES ('nada',5,4,1)
  INSERT INTO HISTORIAL (observaciones, cita, receta, enfermedad) VALUES ('nada',4,4,1)
  INSERT INTO HISTORIAL (observaciones, cita, receta, enfermedad) VALUES ('nada',6,4,2)
  INSERT INTO HISTORIAL (observaciones, cita, receta, enfermedad) VALUES ('nada',7,4,2)
  INSERT INTO HISTORIAL (observaciones, cita, receta, enfermedad) VALUES ('nada',4,4,3)

  /*reportes*/
   SELECT fecha, hora, paciente, personal, sala FROM CITA
 WHERE MONTH(fecha) = 4
 AND YEAR(fecha) = 2017
 ORDER BY MONTH(fecha)

 SELECT * FROM CITA

/* SELECT fecha, hora, paciente, personal, sala FROM CITA
 WHERE DAY(fecha) = 4
 AND MONTH(fecha) = 5
 AND YEAR (fecha) = 2017
 ORDER BY DAY(fecha)*/

 SELECT fecha, hora, paciente, personal, sala FROM CITA
 WHERE fecha = '05/05/2017'
 ORDER BY fecha

 SELECT TOP 3 H.enfermedad, E.nombre ,Count(H.enfermedad) cantidad from HISTORIAL H
 INNER JOIN ENFERMEDAD E ON E.id_enfermedad = H.enfermedad
 GROUP BY H.enfermedad, E.nombre
 ORDER BY cantidad DESC

 SELECT * FROM TIPO_PUESTO

 SELECT fecha, hora, paciente, personal, sala FROM CITA  WHERE MONTH(fecha) = MONTH(05/05/2017) AND YEAR(fecha) = YEAR(05/05/2017) ORDER BY MONTH(fecha)

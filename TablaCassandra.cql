CREATE TABLE Reg_medicos(cedula_profesional int primary key, 
	nombre text, 
	especialidad text,
	fecha_ingreso timestamp, 
	sueldo double,
	edad int
	);
ALTER TABLE Reg_medicos ADD diaslaborales list<text>;


SELECT * FROM Reg_medicos;
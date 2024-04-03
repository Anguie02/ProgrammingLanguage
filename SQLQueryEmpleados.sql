use empleados;

CREATE TABLE empleados (
    id INT PRIMARY KEY IDENTITY(1,1),
    nombre VARCHAR(50) NOT NULL,
    apellido VARCHAR(50) NOT NULL,
    correo_electronico VARCHAR(100) NOT NULL,
    departamento VARCHAR(50),
    cargo VARCHAR(50),
    salario DECIMAL(10, 2)
);


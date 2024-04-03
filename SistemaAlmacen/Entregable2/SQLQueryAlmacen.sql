create database almacen;

use almacen;

-- Crear tabla Proveedores
CREATE TABLE Proveedores (
    id_proveedor INT PRIMARY KEY,
    nombre_empresa VARCHAR(100),
    nombre_contacto VARCHAR(100),
    direccion VARCHAR(255),
    telefono VARCHAR(20),
    correo VARCHAR(100),
    terminos_pago VARCHAR(100)
);

-- Crear tabla Productos
CREATE TABLE Productos (
    id_producto INT PRIMARY KEY,
    nombre VARCHAR(100),
    descripcion VARCHAR(255),
    sku VARCHAR(50),
    categoria VARCHAR(50),
    precio DECIMAL(10, 2),
    cantidad_stock INT,
    unidad_medida VARCHAR(50),
    fecha_vencimiento DATE
);

-- Crear tabla Clientes
CREATE TABLE Clientes (
    id_cliente INT PRIMARY KEY,
    nombre_cliente VARCHAR(100),
    telefono VARCHAR(20),
    correo VARCHAR(100),
    direccion VARCHAR(255)
);

-- Crear tabla Entradas
CREATE TABLE Entradas (
    id_entrada INT PRIMARY KEY,
    id_producto INT,
    cantidad_recibida INT,
    fecha_entrada DATE,
    hora_entrada TIME,
    id_proveedor INT,
    numero_factura VARCHAR(50),
    FOREIGN KEY (id_producto) REFERENCES Productos(id_producto),
    FOREIGN KEY (id_proveedor) REFERENCES Proveedores(id_proveedor)
);

-- Crear tabla Salidas
CREATE TABLE Salidas (
    id_salida INT PRIMARY KEY,
    id_producto INT,
    cantidad_retirada INT,
    fecha_salida DATE,
    hora_salida TIME,
    motivo_salida VARCHAR(255),
    numero_factura VARCHAR(50),
    FOREIGN KEY (id_producto) REFERENCES Productos(id_producto)
);

-- Crear tabla Movimientos
CREATE TABLE Movimientos (
    id_movimiento INT PRIMARY KEY,
    tipo VARCHAR(50),
    id_producto INT,
    cantidad_movida INT,
    fecha_movimiento DATE,
    hora_movimiento TIME,
    origen VARCHAR(100),
    destino VARCHAR(100),
    FOREIGN KEY (id_producto) REFERENCES Productos(id_producto)
);


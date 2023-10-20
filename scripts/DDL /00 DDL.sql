DROP DATABASE IF EXISTS 5to_Espuchifai;
CREATE DATABASE 5to_Espuchifai;
USE 5to_Espuchifai;
CREATE TABLE Bandas(
id_banda int not null,
nombre varchar(45) not null,
anio year not null,
FULLTEXT (nombre),
CONSTRAINT PK_Bandas PRIMARY KEY (id_banda),
CONSTRAINT UQ_Banda_nombre UNIQUE (nombre)
);
CREATE TABLE Albumes(
id_album int not null,
nombre varchar(45) not null,
lazamiento date not null,
id_banda int not null,
Reproducciones int not null,
FULLTEXT (nombre),
CONSTRAINT PK_Albumes PRIMARY KEY (id_album),
CONSTRAINT UQ_Abumes_nombre UNIQUE (nombre),
CONSTRAINT FK_Albumes FOREIGN KEY (id_banda)
REFERENCES Bandas (id_banda)
);
CREATE TABLE Canciones(
idcancion int not null,
nombre varchar(45) not null,
numero int not null,
id_album int not null,
Reproducciones int not null,
FULLTEXT (nombre),
CONSTRAINT PK_Canciones PRIMARY KEY (idcancion),
CONSTRAINT FK_album FOREIGN KEY (id_album)
REFERENCES Albumes (id_album)
);
CREATE TABLE Clientes(
id_cliente int not null,
nombre varchar(45) not null,
apellido varchar(45) not null,
email varchar (45) not null,
contrasena character(64) not null,
CONSTRAINT PK_Cliente PRIMARY KEY (id_cliente)
);
CREATE TABLE Reproducciones(
momento_reproduccion time not null,
idcancion int not null,
cliente int not null,
id_album int not null,
Reproducciones int not null,
CONSTRAINT PK_Reproducciones PRIMARY KEY (momento_reproduccion, idcancion, cliente),
CONSTRAINT FK_Reprudcciones FOREIGN KEY (idcancion)
REFERENCES Canciones (idcancion),
CONSTRAINT FK_Reproducciones FOREIGN KEY (cliente)
REFERENCES Clientes (id_cliente)
);
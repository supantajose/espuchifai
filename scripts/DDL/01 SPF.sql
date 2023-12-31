-- Active: 1699473969193@@localhost@3306@5to_Espuchifai
-- 1) Realizar los SP para dar de alta todas las entidades menos las tablas Cliente y Reproducción. En la tabla reproducción el SP se debe llamar ‘Reproducir’.
delimiter $$
SELECT 'Creando SPs' Estado $$
Drop procedure if exists altaBandas $$
Create procedure altaBandas (OUT unid_banda int, unnombre varchar(45), unanio date)
begin
    insert into Bandas ( nombre, anio)
        values(unnombre, unanio );

    SET unid_banda = LAST_INSERT_ID();
end $$


delimiter $$
Drop procedure if exists altaAlbumes $$
Create procedure altaAlbumes (OUT unid_album int, unnombre varchar(45), unlanzamiento datetime, unid_banda int, unReproduccion int)
begin
    insert into Albumes (nombre, lanzamiento, id_banda, Reproduccion)
        values(unnombre, unlanzamiento, unid_banda, unReproduccion);
    
    SET unid_album = LAST_INSERT_ID();
end $$


delimiter $$
Drop procedure if exists altaCanciones $$
Create procedure altaCanciones (OUT unidcancion int, unnombre varchar (45), unnumero int, unid_album int, unReproduccion int)
begin
    insert into Canciones (nombre, numero, id_album, Reproduccion)
        values(unnombre, unnumero, unid_album, unReproduccion);
    
    SET unidcancion = LAST_INSERT_ID();
end $$


delimiter $$
Drop procedure if exists Reproducir $$
Create procedure Reproducir (uncancion int, uncliente int, unareproduccion int)
begin
    insert into Reproduccion (momento_reproducion, cancion, cliente, Reproducciones)
        values (now(), uncancion, uncliente, unareproduccion);
end $$


-- 2) Se pide hacer el SP ‘registrarCliente’ que reciba los datos del cliente. Es importante guardar encriptada la contraseña del cliente usando SHA256.
delimiter $$
Drop procedure if exists registrarCliente $$
Create procedure registrarCliente (OUT unid_Cliente int, unnombre varchar(45), unapellido varchar(45), unemail varchar(45))
begin
    insert into Clientes( nombre, apellido, email, contrasena) values(unnombre, unapellido, unemail, contrasena);
    SET unid_Cliente= LAST_INSERT_ID();
end $$


-- 3) Se pide hacer el SF ‘CantidadReproduccionesBanda’ que reciba por parámetro un identificador de banda y 2 fechas, se debe devolver la cantidad de reproducciones que tuvieron las canciones de esa banda entre esas 2 fechas (inclusive).
delimiter $$
drop function if exists CantidadReproduccionesBanda $$
create function CantidadReproduccionesBanda (unid_banda int, fechaInicio date, fechaFin date)returns int
reads sql data
begin
declare CantidadReproduccionesBanda int;
    select COUNT(*) into CantidadReproduccionesBanda
    from Reproducciones r
    join Cancion c on r.IdCancion = c.IdCancion
    where c.Idbanda = unid_banda
    and r.FechaReproduccion BETWEEN fechaInicio and fechaFin;
    return CantidadReproduccionesBanda;
end $$


-- 4) Se pide hacer el SP ‘Buscar’ que reciba por parámetro una cadena. El SP tiene que devolver las canciones que contengan la cadena en su título, nombre de álbum o nombre de banda (Documentación función MATCH-AGAINST).
DELIMITER $$
CREATE PROCEDURE Buscar(IN cadena_busqueda VARCHAR(255))
BEGIN
SELECT id_cancion, nombre, numero, id_album
FROM canciones C
join Banda B on c.id_banda = B.id_banda
WHERE
Match (C.nombre)
AGAINST (cadena_busqueda IN NATURAL LANGUAGE MODE)
    or  Match (B.nombre)
        AGAINST (cadena_busqueda IN NATURAL LANGUAGE MODE)
    or Match (A.nombre)
        AGAINST (cadena_busqueda IN NATURAL LANGUAGE MODE);
end $$


-- 5) En base a un email y contraseña devuelva un cliente si lo encontro y null si no lo encontro

Delimiter $$
DROP PROCEDURE IF EXISTS ClientesPoremailcontrasena $$
CREATE PROCEDURE ClientesPoremailcontrasena (unemail VARCHAR(45), uncontrasena VARCHAR(45))
BEGIN
    SELECT  id_cliente, nombre, apellido, email
    FROM    Clientes
    WHERE   email = unemail
    AND     contrasena = SHA2(uncontrasena, 256);
END $$
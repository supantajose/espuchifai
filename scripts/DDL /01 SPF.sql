-- 1) Realizar los SP para dar de alta todas las entidades menos las tablas Cliente y Reproducción. En la tabla reproducción el SP se debe llamar ‘Reproducir’.
delimiter $$
Drop procedure if exists altaBandas	$$
Create procedure altaBandas (unid_banda int, unnombre varchar(45), unanio year)
begin
	insert into Bandas (id_banda, nombre, anio)
		values(unid_banda, unnombre, unanio );
end $$


delimiter $$
Drop procedure if exists altaAlbumes $$
Create procedure altaAlbumes (unid_album int, unnombre varchar(45), unlanzamiento date, unid_banda int)
begin
	insert into Albumes (id_album, nombre, lanzamiento, id_banda)
		values(unid_album, unnombre, unlanzamiento, unid_banda);
end $$


delimiter $$
Drop procedure if exists altaCanciones $$
Create procedure altaCanciones (unidcancion int, unnombre varchar (45), unnumero int, unid_album int)
begin
	insert into Canciones (idcancion, nombre, numero, id_album)
		values(unidcancion, unnombre, unnumero, unid_album);
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
Create procedure registrarCliente (unid_Cliente int, unnombre varchar(45), unapellido varchar(45), unemail varchar(45))
begin
	insert into registrarCliente(id_Cliente, nombre, apellido, email, contrasena)
		values(unid_Cliente, unnombre, unapellido, unemail, SHA2(contrasena, 256));
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
	or	Match (B.nombre)
		AGAINST (cadena_busqueda IN NATURAL LANGUAGE MODE)
	or Match (A.nombre)
		AGAINST (cadena_busqueda IN NATURAL LANGUAGE MODE);
end $$
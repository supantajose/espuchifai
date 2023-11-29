DELIMITER ;
SELECT 'Inserts' Estado ;
INSERT into Clientes(id_Cliente, nombre, apellido, email, contrasena)
		values(1, "Vanina", "Condorpocco","vanyabrilconblas@gmail.com",'root');
insert into Bandas(id_banda, nombre, anio)
		values(1, "Drako", '2022');
INSERT into Albumes(id_album, nombre, lazamiento, id_banda, Reproduccion)
		values(1, "Bad Bunny",'2022-2-2' , 1, 2);
INSERT into Canciones(idcancion, nombre, numero, id_album, Reproduccion)
		values(1, "Te bote", 1, 1, 1);

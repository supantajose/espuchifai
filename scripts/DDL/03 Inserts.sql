-- Active: 1699473969193@@localhost@3306@5to_Espuchifai
DELIMITER ;
USE 5to_espuchifai;
SELECT 'Inserts' Estado ;
INSERT into Clientes(nombre, apellido, email, contrasena)
		values("Vanina", "Condorpocco","vanyabrilconblas@gmail.com",'root');
insert into Bandas(nombre, anio)
		values("Drako", "2019/09/12");
INSERT into Albumes(nombre, lanzamiento, id_banda, Reproduccion)
		values("Bad Bunny",'2022-2-2' , 1, 2);

INSERT into Canciones(nombre, numero, id_album, Reproduccion)
		values("Te bote", 1, 1, 1);
INSERT into Reproducciones(momento_reproduccion, idcancion, cliente)
		values(now(), 1, 1);

-- Active: 1699473969193@@localhost@3306@5to_Espuchifai
-- 1) Cada vez que se inserta una reproducción, se incrementa el contador de reproducciones de la canción en uno.
Delimiter $$
SELECT 'Creando Triggers' Estado $$
Drop Trigger if exists IncrementarReproduccionesCancion $$
Create Trigger IncrementarReproduccionesCancion after Insert on Canciones
For each row
Begin
	update Canciones
	set Reproducciones = Reproducciones + 1
	where idcancion = new.idcancion;
END $$


-- 2) Cada vez que se actualiza el contador de la canción en N reproducciones, se incrementa el contador del álbum también en N.
Delimiter $$
Drop Trigger if exists ReproduccionesAlbum $$
Create Trigger ReproduccionesAlbum before update on Canciones
For each row
Begin
if(Reproducciones <= Reproducciones)then
	update Albumes
	set Reproducciones = Reproducciones + 1
	where id_album = new.id_album;
	end if;
END $$

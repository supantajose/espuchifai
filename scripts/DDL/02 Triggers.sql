-- Active: 1699473969193@@localhost@3306@5to_Espuchifai
-- 1) Cada vez que se inserta una reproducción, se incrementa el contador de reproducciones de la canción en uno.
Delimiter $$
USE 5to_espuchifai $$
SELECT 'Creando Triggers' Estado $$
Delimiter $$
Drop Trigger if exists IncrementarReproduccionesCancion $$
Create Trigger IncrementarReproduccionesCancion after Insert on Reproducciones
For each row
Begin
	update Canciones
	set Reproduccion = Reproduccion + 1
	where idcancion = new.idcancion;
END $$


-- 2) Cada vez que se actualiza el contador de la canción en N reproducciones, se incrementa el contador del álbum también en N.
Delimiter $$
Drop Trigger if exists ReproduccionesAlbum $$

Create Trigger ReproduccionesAlbum after update on Canciones $$

Create Trigger ReproduccionesAlbum after update on Canciones

For each row
Begin
	if (new.Reproduccion > old.Reproduccion)then
	update Albumes
	set Reproduccion = Reproduccion + 1
	where id_album = new.id_album;
	end if;
END $$
-- 1) Cada vez que se inserta una reproducción, se incrementa el contador de reproducciones de la canción en uno.
Delimiter $$
Drop Trigger if exists IncrementarReproduccionesCancion $$
Create Trigger IncrementarReproduccionesCancion after Insert on Reproducciones
For each row
Begin
	update Reproducciones
	set Reproducciones = Reproducciones + 1
	where cancion = new.idcancion;
END $$


-- 2) Cada vez que se actualiza el contador de la canción en N reproducciones, se incrementa el contador del álbum también en N.
Delimiter $$
Drop Trigger if exists ReproduccionesAlbum $$
Create Trigger ReproduccionesAlbum before update on Canciones
For each row
Begin
if(old.Reproducciones <= new.Reproducciones)then
	update Albumes
	set Reproducciones = Reproducciones + 1
	where id_album = new.id_album;
	end if;
END $$

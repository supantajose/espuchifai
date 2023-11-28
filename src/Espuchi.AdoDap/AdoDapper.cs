using System.Data;

using Espuchi.Core;
using Dapper;
using MySqlConnector;

namespace Espuchi.AdoDap;
public class AdoDapper : IAdo
{
    private readonly IDbConnection _conexion;

    public AdoDapper(IDbConnection conexion) => this._conexion = conexion;

    public AdoDapper(string cadena) => _conexion = new MySqlConnection(cadena);


    #region Banda
<<<<<<< HEAD
    public void AltaBanda(Banda banda)
    {
        var parametros = new DynamicParameters();
        parametros.Add("@unid_banda", direction:ParameterDirection.Output);
        parametros.Add("@unnombre", banda.Nombre);
        parametros.Add("@unanio", banda.anio);
        _conexion.Execute("altaBandas", parametros, commandType: CommandType.StoredProcedure);
        
        banda.id_banda = parametros.Get<int>("@unid_banda");
=======
    public void altaBanda(Banda banda)
    {
        var parametros = new DynamicParameters();
        parametros.Add("unid_banda", banda.id_banda);
        parametros.Add("unnombre", banda.Nombre);
        parametros.Add("unanio", banda.anio);
        _conexion.Execute("altaBanda", parametros, commandType: CommandType.StoredProcedure);
        banda.id_banda = parametros.Get<sbyte>("unid_banda");
>>>>>>> cb9f4e842ea928d8e63d0f1654b712303df07738
    }
    private static readonly string _queryBanda
    = @"SELECT id_banda, nombre
        FROM Bandas";
    public List<Banda> ObtenerBandas()
        => _conexion.Query<Banda>(_queryBanda).ToList();

    #endregion
    #region Canciones
    public void AltaCancion(Canciones canciones)
    {
        var parametros = new DynamicParameters();
<<<<<<< HEAD
        parametros.Add("@unidcancion", direction: ParameterDirection.Output);
        parametros.Add("@unnombre", canciones.Nombre);
        parametros.Add("@unnumero", canciones.numero);
        parametros.Add("@unid_album", canciones.Albumes.id_album);
        parametros.Add("@unReproduccion", canciones.Reproduccion);
        _conexion.Execute("@altaCanciones", parametros, commandType: CommandType.StoredProcedure);

        canciones.idcancion = parametros.Get<int>("@unidcancion");

    }

    private static readonly string _queryCanciones
    = @"SELECT idcancion, nombre
            FROM Canciones
            JOIN Albumes USING(id_album)";
=======
        parametros.Add("unidcancion", direction: ParameterDirection.Output);
        parametros.Add("unnombre", canciones.Nombre);
        parametros.Add("unnumero", canciones.numero);
        parametros.Add("unid_album", canciones.id_album);
        parametros.Add("unReproduccion", canciones.Reproduccion);
        _conexion.Execute("altaCanciones", parametros, commandType: CommandType.StoredProcedure);

        canciones.idcancion = parametros.Get<sbyte>(@"unidcancion");

    }

    private static readonly string _queryCanciones
    = @"SELECT idcancion, Nombre
            FROM Canciones";
>>>>>>> cb9f4e842ea928d8e63d0f1654b712303df07738
    public List<Canciones> ObtenerCanciones()
    {
        return _conexion.Query<Canciones>(_queryCanciones).ToList();
    }
<<<<<<< HEAD

    #endregion
    #region Albumes

=======
    #endregion
    #region Albumes

>>>>>>> cb9f4e842ea928d8e63d0f1654b712303df07738
    public void AltaAlbum(Albumes albumes)
    {
        var parametros = new DynamicParameters();
        parametros.Add("@unid_album", direction: ParameterDirection.Output);
        parametros.Add("@unnombre", albumes.Nombre);
        parametros.Add("@unlanzamiento", albumes.Lanzamiento);
        parametros.Add("@unid_banda", albumes.Banda.id_banda);
        parametros.Add("@unReproduccion", albumes.Reproduccion);

        _conexion.Execute("altaAlbumes", parametros, commandType: CommandType.StoredProcedure);

<<<<<<< HEAD
        albumes.id_album = parametros.Get<int>("@unid_album");
=======
        albumes.id_album = parametros.Get<sbyte>("unid_album");
>>>>>>> cb9f4e842ea928d8e63d0f1654b712303df07738
    }

    private static readonly string _queryAlbumes
    = @"SELECT id_album, nombre
        FROM Albumes
        JOIN Bandas USING (id_banda)";
    public List<Albumes> ObtenerAlbumes()
    {
        return _conexion.Query<Albumes>(_queryAlbumes).ToList();
    }

    #endregion 
    #region Clientes

    public void AltaCliente(Clientes cliente)
    {
        var parametros= new DynamicParameters();
        parametros.Add("@unid_Cliente", direction: ParameterDirection.Output);
        parametros.Add("@unnombre", cliente.Nombre);
        parametros.Add("@unapellido", cliente.Apellido);
        parametros.Add("@unemail", cliente.email);
        //falta contraseña preguntar como hacerlo en alta

        _conexion.Execute("registrarCliente", parametros, commandType: CommandType.StoredProcedure);
        cliente.id_cliente = parametros.Get<int>("@unid_Cliente");
    }
    private static readonly string _queryClientes
    = @"SELECT id_cliente, nombre, apellido
        FROM Clientes";
    public List<Clientes> ObtenerClientes()
    {
        return _conexion.Query<Clientes>(_queryClientes).ToList();
    }

<<<<<<< HEAD
    #endregion    
=======
    public Banda? ObtenerBanda(int id_banda)

    => _conexion.QueryFirstOrDefault<Banda>(_queryBanda, new { unid_banda = id_banda, });

    void IAdo.AltaBanda(Banda banda)
    {
        var parametros = new DynamicParameters();
        parametros.Add("unid_banda", banda.id_banda);
        parametros.Add("unnombre", banda.Nombre);
        parametros.Add("unanio", banda.anio);
    }
    List<Albumes> IAdo.ObtenerAlbumes()
    {
        throw new NotImplementedException();
    }

    Albumes? IAdo.ObtenerAlbumes(int id_album)
    {
        throw new NotImplementedException();
    }

    #region Canciones
    private static readonly string _queryCancion
    = @"SELECT *
        FROM Canciones
        WHERE cancion = @unidcancion
        AND   nombre = SHA2(@unNombre,)
        LIMIT 1";

    private static readonly string _queryAltacancion
    = @"INSERT INTO Canciones VALUES(@idcancion, @nombre, numero, @id_album, Reproduccion)";
    private readonly string _querycanciones;

    public void canciones(Canciones canciones, string nombre)
    => _conexion.Execute(
        _queryAltacancion,
        new
        {
            nombre = canciones.Nombre,
            numero = canciones.numero,
            id_album = canciones.id_album,
            Reproducciones = canciones.Reproduccion
        }
    );
    Canciones? IAdo.ObtenerCanciones(int idcancion)
    => _conexion.QueryFirstOrDefault<Canciones>(_querycanciones, new { unidcancion = idcancion, unnombre = nombre });
    #endregion
>>>>>>> cb9f4e842ea928d8e63d0f1654b712303df07738
}
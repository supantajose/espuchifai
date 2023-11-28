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
    public void AltaBanda(Banda banda)
    {
        var parametros = new DynamicParameters();
        parametros.Add("@unid_banda", direction:ParameterDirection.Output);
        parametros.Add("@unnombre", banda.Nombre);
        parametros.Add("@unanio", banda.anio);
        _conexion.Execute("altaBandas", parametros, commandType: CommandType.StoredProcedure);
        
        banda.id_banda = parametros.Get<int>("@unid_banda");
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
        parametros.Add("@unidcancion", direction: ParameterDirection.Output);
        parametros.Add("@unnombre", canciones.Nombre);
        parametros.Add("@unnumero", canciones.numero);
        parametros.Add("@unid_album", canciones.Albumes. id_album);
        parametros.Add("@unReproduccion", canciones.Reproduccion);
        _conexion.Execute("@altaCanciones", parametros, commandType: CommandType.StoredProcedure);

        canciones.idcancion = parametros.Get<int>("@unidcancion");

    }

    private static readonly string _queryCanciones
    = @"SELECT idcancion, nombre
            FROM Canciones
            JOIN Albumes USING(id_album)";
    public List<Canciones> ObtenerCanciones()
    {
        return _conexion.Query<Canciones>(_queryCanciones).ToList();
    }
    #endregion
    #region Albumes

    public void AltaAlbum(Albumes albumes)
    {
        var parametros = new DynamicParameters();
        parametros.Add("@unid_album", direction: ParameterDirection.Output);
        parametros.Add("@unnombre", albumes.Nombre);
        parametros.Add("@unlanzamiento", albumes.Lanzamiento);
        parametros.Add("@unid_banda", albumes.Banda. id_banda);
        parametros.Add("@unReproduccion", albumes.Reproduccion);

        _conexion.Execute("altaAlbumes", parametros, commandType: CommandType.StoredProcedure);

        albumes.id_album = parametros.Get<int>("@unid_album");
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
    #endregion    
}
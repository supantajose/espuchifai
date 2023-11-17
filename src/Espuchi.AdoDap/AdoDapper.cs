using System.Data;
using Espuchi.Core;
using Dapper;   
using MySqlConnector;

namespace Espuchi.AdoDap;
public class AdoDapper : IAdo
{
    private readonly IDbConnection _conexion;

    public AdoDapper(IDbConnection conexion)=> this._conexion = conexion;
    
    public AdoDapper(string cadena) => _conexion = new MySqlConnection(cadena);


#region Banda
    public void altaBanda(Banda banda)
    {
        var parametros = new DynamicParameters();
        parametros.Add("unid_banda", banda.id_banda);
        parametros.Add("unnombre", banda.Nombre);
        parametros.Add("unanio", banda.anio);
        _conexion.Execute("altaBanda", parametros, commandType: CommandType.StoredProcedure);
        banda.id_banda=parametros.Get<sbyte>("unid_banda");
    }
    private static readonly string _queryBanda
    = @"SELECT id_banda, Nombre
        FROM Banda";
    public List<Banda> ObtenerBandas()
        => _conexion.Query<Banda>(_queryBanda).ToList();

    #endregion
#region Canciones
    public void altaCanciones(Canciones canciones)
    {
        var parametros = new DynamicParameters();
        parametros.Add("unidcancion", canciones.idcancion);
        parametros.Add("unnombre", canciones.Nombre);
        parametros.Add("unnumero", canciones.numero);
        parametros.Add("unid_album", direction: ParameterDirection.Output);
        parametros.Add("unReproduccion", direction: ParameterDirection.Output);
        _conexion.Execute("altaCanciones", parametros, commandType: CommandType.StoredProcedure);

        canciones.idcancion=parametros.Get<sbyte>(@"unidcancion");
    }

        private static readonly string _queryCanciones
        = @"SELECT idcancion, Nombre
            FROM Canciones";
    public List<Canciones> ObtenerCanciones()
    {
        return _conexion.Query<Canciones>(_queryCanciones).ToList();
    }
    #endregion
#region Albumes

    public void altaAlbumes(Albumes albumes)
    {
        var parametros = new DynamicParameters();
        parametros.Add("unid_album", albumes.id_album);
        parametros.Add("unnombre", albumes.Nombre);
        parametros.Add("unlanzamiento", albumes.Lanzamiento);
        parametros.Add("unid_banda", albumes.id_Banda);
        parametros.Add("unReproduccion", direction: ParameterDirection.Output);

        _conexion.Execute("altaAlbumes",parametros,commandType: CommandType.StoredProcedure);

            albumes.id_album=parametros.Get<sbyte>("unid_album");
    }

    private static readonly string _queryAlbumes
    = @"SELECT id_album, Nalbum
        FROM Album";
    public List<Albumes> ObtenerAlbumes()
    {
        return _conexion.Query<Albumes>(_queryAlbumes).ToList();
    }
    #endregion


    public Albumes? ObtenerAlbumes(int id_album)
    {
        throw new NotImplementedException();
    }

    public Banda? ObtenerBanda(int id_banda)
    
    => _conexion.QueryFirstOrDefault<Banda>(_queryBanda, new { unid_banda = id_banda,});

    public Canciones? obtenerCanciones(int idcancion)
    {
        throw new NotImplementedException();
    }

    void IAdo.altaBandas(Banda banda)
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

    Canciones? IAdo.ObtenerCanciones(int idcancion)
    {
    
    }
}
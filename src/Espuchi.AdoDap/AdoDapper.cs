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
    }
            _conexion.Execute("altaBanda", parametros, commandType: commandType.StoredProcedure);
            banda.id_Banda=parametros.Get<int>("@unid_Banda");


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
    }
    public void altaAlbumes(Albumes albumes)
    {
        var parametros = new DynamicParameters();
        parametros.Add("unid_album", albumes.id_album);
        parametros.Add("unnombre", albumes.Nombre);
        parametros.Add("unlanzamiento", albumes.Lanzamiento);
        parametros.Add("unid_banda", albumes.id_Banda);
        parametros.Add("unReproduccion", direction: ParameterDirection.Output);

    }

    public List<Albumes> ObtenerAlbumes()
    
        => _conexion.Query<Albumes>(_queryAlbumes).ToList();

    public Albumes? ObtenerAlbumes(int id_album, string nombre, DateTime lanzamiento, int id_banda, int Reproduccion)
    {
        throw new NotImplementedException();
    }

    public Banda? ObtenerBanda(int id_banda, string nombre, ushort anio)
    
    => _conexion.QueryFirstOrDefault<Banda>(_queryBanda, new{ unid_banda = id_banda, unnombre = nombre, unanio = anio });

    public List<Banda> ObtenerBandas()
    {
        throw new NotImplementedException();
    }

    public List<Canciones> ObtenerCanciones()
    {
        throw new NotImplementedException();
    }

    public Canciones? ObtenerCanciones(int idcancion, string nombre, int numero, int id_album, int Reproduccion)
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

    List<Banda> IAdo.ObtenerBandas()
    {

    }

    Banda? IAdo.ObtenerBanda(int id_banda, string nombre, ushort anio)
    {

    }

    void IAdo.altaAlbumes(Albumes albumes)
    {
        var parametros = new DynamicParameters();
        parametros.Add("unid_album", albumes.id_album);
        parametros.Add("unnombre", albumes.Nombre);
        parametros.Add("unlanzamiento", albumes.Lanzamiento);
        parametros.Add("unid_banda", albumes.id_Banda);
        parametros.Add("unReproduccion", direction: ParameterDirection.Output);
    }

    List<Albumes> IAdo.ObtenerAlbumes()
    {
        throw new NotImplementedException();
    }

    Albumes? IAdo.ObtenerAlbumes(int id_album, string nombre, DateTime lanzamiento, int id_banda, int Reproduccion)
    {
        throw new NotImplementedException();
    }

    void IAdo.altaCanciones(Canciones canciones)
    {
        var parametros = new DynamicParameters();
        parametros.Add("unidcancion", canciones.idcancion);
        parametros.Add("unnombre", canciones.Nombre);
        parametros.Add("unnumero", canciones.numero);
        parametros.Add("unid_album", direction: ParameterDirection.Output);
        parametros.Add("unReproduccion", direction: ParameterDirection.Output);
    }
    List<Canciones> IAdo.ObtenerCanciones()
    {

    }
    List<Canciones> IAdo.ObtenerCanciones()
    {

    }

    Canciones? IAdo.ObtenerCanciones(int idcancion, string nombre,int numero, int id_album, int Reproduccion)
    {
    
    }
}
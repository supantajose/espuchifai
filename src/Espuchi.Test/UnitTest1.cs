using Espuchi.Core;

namespace Espuchi.Dapper.Test;

public class TestEspuchi : TestAdo
{
    [Fact]
    public void AltaBandas()
    {
        var newBandas = new Bandas ()
        {
            Nombre = "Drako",
            anio = "2022"
        };

        Ado.AltaBandas(newBandas);

        Assert.NotEqual(0, newBandas.id_banda);
    }
}


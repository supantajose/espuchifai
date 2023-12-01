using Espuchi.Core;
using Espuchi.Test;

namespace Espuchi.Dapper.Test;

public class TestEspuchi : TestAdo
{
    [Fact]
    public void AltaBanda()
    {
        var newBandas = new Banda()
        {
            Nombre = "Drako",
            anio = new DateTime (2022, 02, 23)

        };

        Ado.AltaBanda(newBandas);

        Assert.NotEqual(0, newBandas.id_banda);
    }
}


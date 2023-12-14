using Espuchi.Core;
using Espuchi.Test;

namespace Espuchi.Dapper.Test;

public class TestAdoClientes : TestAdo
{
    [Fact]
    public void AltaCliente()
    {
        var newClientes = new Clientes()
    {
            Nombre = "Puma",
            Apellido = "Terrile",
            email = "Puma.Terrile@gmail.com",
            contrasena = "gustavocerati",
            
        };

        Ado.AltaCliente(newClientes);

        Assert.NotEqual(0, newClientes.id_cliente);
    }
}

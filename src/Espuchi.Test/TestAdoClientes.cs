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

    [Fact]
    public void AltaClientes()
    {
        int id_cliente = 1000;
        string contrasena = "root";
        string nombre = "Vanina";
        string apellido = "Condorpocco";
        string email = "vanyabrilconblas@gmail.com";


        var vanina = Ado.ClienteporContrasena(email, contrasena);

        Assert.NotNull(vanina);
        Assert.Equal(nombre, vanina.Nombre);
        Assert.Equal(apellido, vanina.Apellido);

        
    }
}

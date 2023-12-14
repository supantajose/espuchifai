using Espuchi.AdoDap;

using Espuchi.Core;

namespace Espuchi.Test;

public class TestAdo
{
    protected readonly IAdo Ado;
    private static readonly string _cadena="Server=localhost;Database=5to_Espuchifai;Uid=5to_agbd;pwd=Trigg3rs!;Allow User Variables=True";
    public TestAdo (string cadena)=> Ado =new AdoDapper(cadena);
    public TestAdo():this(_cadena){}
}


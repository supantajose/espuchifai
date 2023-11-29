using Espuchi.AdoDap;

using Espuchi.Core;

namespace Espuchi.Test;

public class TestAdo
{
    protected readonly IAdo Ado;
    private static readonly string _cadena="Server=localhost;Database=5to_Espuchifai;Uid=test;pwd=T12-test;Allow User Variables=true";
    public TestAdo (string cadena)=> Ado =new AdoDapper(cadena);
    public TestAdo():this(_cadena){}
}


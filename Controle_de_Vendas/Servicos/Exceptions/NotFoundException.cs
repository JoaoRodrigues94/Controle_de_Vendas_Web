using System;

namespace Controle_de_Vendas.Servicos.Exceptions
{
  public class NotFoundException: ApplicationException
  {
    public NotFoundException(string message): base(message)
    {

    }
  }
}

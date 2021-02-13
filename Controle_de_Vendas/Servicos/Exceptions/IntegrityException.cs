using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Controle_de_Vendas.Servicos.Exceptions
{
  public class IntegrityException : ApplicationException
  {
    public IntegrityException(string message) : base(message)
    {

    }
  }
}

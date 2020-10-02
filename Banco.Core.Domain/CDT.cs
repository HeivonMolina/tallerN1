using System;
using System.Collections.Generic;
using System.Text;

namespace Banco.Core.Domain
{
    public class CDT : CuentaBancaria
    {
     
        public CDT(string numero, string nombre, string ciudad) : base(numero, nombre, ciudad)
        {
        }

        public override string Consignar(decimal valorConsignacion, string ciudadConsignacion)
        {
            throw new NotImplementedException();
        }

        public override string Retirar(decimal valorRetirar)
        {
            throw new NotImplementedException();
        }
    }
}

using System;

namespace Banco.Core.Domain
{
    public interface IServicioFinanciero
    {
        string Numero { get; }
        string Ciudad { get; }
        decimal Saldo { get; }
        string Consignar(decimal valorConsignacion, string Envio);
        string Retirar(decimal valorRetirar);
    }
}

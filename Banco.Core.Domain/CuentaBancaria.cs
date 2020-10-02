using System;
using System.Collections.Generic;
using System.Linq;

namespace Banco.Core.Domain
{
    public abstract class CuentaBancaria : IServicioFinanciero
    {
        protected CuentaBancaria(string numero, string nombre, string ciudad)
        {
            Numero = numero;
            Nombre = nombre;
            Ciudad = ciudad;
            Saldo = 0;
            _movimientos = new List<CuentaBancariaMovimiento>();
        }

        public string Numero { get; }
        public string Nombre { get; }
        public string Ciudad { get; }
        public decimal Saldo { get; protected set; }
        public abstract string Consignar(decimal valorConsignacion, String ciudadConsignacion);
        public abstract string Retirar(decimal valorRetirar);

        protected readonly List<CuentaBancariaMovimiento> _movimientos;

    }
    public class CuentaBancariaMovimiento 
    {
        public CuentaBancariaMovimiento(decimal saldoAnterior, decimal valorCredito, decimal valorDebito, string tipo)
        {
            SaldoAnterior = saldoAnterior;
            ValorCredito = valorCredito;
            ValorDebito = valorDebito;
            Tipo = tipo;
        }

        public decimal SaldoAnterior { get; private set; }
        public decimal ValorCredito { get; private set; }
        public decimal ValorDebito { get; private set; }
        public string Tipo { get; private set; }
    }

}





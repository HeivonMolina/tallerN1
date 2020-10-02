using System;
using System.Collections.Generic;
using System.Text;

namespace Banco.Core.Domain
{
    public class TarjetaCredito : IServicioFinanciero
    {
        public TarjetaCredito(string numero, string ciudad,decimal credito)
        {
            Numero = numero;
            Ciudad = ciudad;
            Saldo = credito;
            Credito = credito;
            _movimientos = new List<CuentaBancariaMovimiento>();
        }
        private readonly List<CuentaBancariaMovimiento> _movimientos;
        public string Numero { get; private set; }

        public string Ciudad { get; private set; }

        public decimal Saldo { get; private set; }
        public decimal Credito { get; private set; }

        
        public string Consignar(decimal valorConsignacion, string Envio)
        {
            
        decimal saldoAnterior = Saldo;
            decimal CreditoAnterior = Credito;
            if (valorConsignacion <= 0)
            {
                return "Valor incorrecto a consignar";
            }
            if (valorConsignacion>Saldo)
            {
                return "El valor del abono no puede ser mayor al saldo";
            }
            Credito += valorConsignacion;
            Saldo -= valorConsignacion;
            DateTime fecha = new DateTime();
            string fechaActual = fecha.ToString("yyyy-mm-dd");
            _movimientos.Add(new CuentaBancariaMovimiento(saldoAnterior, Credito, Saldo, "ABONO"));
            return $"Abono exito. Su cupo disponible es: ${Credito:n2}. Su saldo es: ${Saldo:n2}.";
        }

        public string Retirar(decimal valorRetirar)
        {
            if (valorRetirar <= 0)
            {
                return "El valor del avance debe ser mayor a 0.";
            }
            if (valorRetirar > Credito)
            {
                return "El valor del avance no debe ser mayor al cupo disponible.";
            }
            Credito -= valorRetirar;
            return $"Avance exitoso. Su cupo disponible es: ${Credito:n2}.";


      
        }
    }
}

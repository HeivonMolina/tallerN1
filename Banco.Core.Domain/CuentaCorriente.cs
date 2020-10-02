using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace Banco.Core.Domain
{
    public class CuentaCorriente : CuentaBancaria
    {

        public CuentaCorriente(string numero, string nombre, string ciudad) : base(numero, nombre, ciudad)
        {
        }

        const decimal CUPOINICIAL = 1000000;

        public override string Consignar(decimal valorConsignacion, string ciudadConsignacion)
        {
            Saldo = CUPOINICIAL;
            const decimal CONSIGNACIONINICIAL = 100000;
            if (valorConsignacion <=0)
                return "El valor a consignar es incorrecto";

            if (NoTieneConsignacion() && valorConsignacion < CONSIGNACIONINICIAL)
                return "El valor mínimo de la primera consignación debe ser de $100.000 mil pesos";
            var saldoAnterior = Saldo;
            Saldo += valorConsignacion;

            _movimientos.Add(new CuentaBancariaMovimiento(saldoAnterior, valorConsignacion, 0, "CONSIGNACION"));


            return $"Su Nuevo Saldo es de ${Saldo:n2} pesos.";
        }



        //retiroooos

        public override string Retirar(decimal valorRetirar)
        {
            decimal saldoAnterior = Saldo;
            if (valorRetirar > Saldo || (Saldo - (valorRetirar + ((valorRetirar * 4)/1000))) < CUPOINICIAL)
                return "Saldo insuficiente";
            else
                Saldo -= (valorRetirar + ((valorRetirar * 4) / 1000));
            return $"Saldo retirado. Su Nuevo Saldo es de ${Saldo:n2} pesos";
        }
        private bool NoTieneConsignacion()
        {
            return !_movimientos.Any(t => t.Tipo == "CONSIGNACION");
        }
        private bool MasDeTresConsignaciones()
        {
            return _movimientos.Count > 3 ? true : false;
        }

     

      


    }
}

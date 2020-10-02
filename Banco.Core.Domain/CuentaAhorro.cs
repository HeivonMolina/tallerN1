using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Banco.Core.Domain
{
    public class CuentaAhorro : CuentaBancaria
    {
        public CuentaAhorro(string numero, string nombre, string ciudad) : base(numero, nombre, ciudad)
        {
        }


        public override string Consignar(decimal valorConsignar, string ciudadEnvio)
        {
            String resultado = "";

            if (valorConsignar <= 0)
                return "El valor a consignar es incorrecto";

            var saldoAnterior = Saldo;

            if (valorConsignar < 50000 && NoTieneConsignacion())
            {
                resultado = "El valor mínimo de la primera consignación debe ser de $50.000 mil pesos. Su nuevo saldo es $0 pesos";

            }
            else if (ConsignacionNacional(ciudadEnvio))
            {
                Saldo += valorConsignar;
                resultado = $"Su Nuevo Saldo es de ${Saldo:n2} pesos m/c";
            }
            else
            {
                valorConsignar += 10000;
                Saldo += valorConsignar;
                resultado = $"Su Nuevo Saldo es de ${Saldo:n2} pesos m/c";
            }

            _movimientos.Add(new CuentaBancariaMovimiento(saldoAnterior, valorConsignar, 0, "CONSIGNACION"));

            return resultado;
        }
        /*
         2.1 El valor a retirar se debe descontar del saldo de la cuenta.
            2.2 El saldo mínimo de la cuenta deberá ser de 20 mil pesos.
          2.3 Los primeros 3 retiros del mes no tendrán costo.
            2.4 Del cuarto retiro en adelante del mes tendrán un valor de 5 mil pesos.
         */

        public override string Retirar(decimal valorRetirar)
        {
            const decimal SALDOMINIMO = 20000m;
            var saldoAnterior = Saldo;
            string respuesta = string.Empty;
            if (MasDeTresConsignaciones()==false)
            {
                if ((Saldo - valorRetirar) < SALDOMINIMO)
                {
                    return "El saldo minimo debe ser 20000";
                }
               
                Saldo -= valorRetirar;
                
                
            }
            else
            {
                if ((Saldo - valorRetirar+5000) < SALDOMINIMO)
                {
                    return "El saldo minimo debe ser 20000";
                }
                Saldo -= (valorRetirar+5000);
               
                
            }
            respuesta = $"Su retiro fue exitoso. Su nuevo saldo es: {Saldo:n2} pesos.";
            _movimientos.Add(new CuentaBancariaMovimiento(saldoAnterior, valorRetirar, 0, "RETIRO"));

            return respuesta;
        }
        

        private bool ConsignacionNacional(String ciudad)
        {
            bool respuesta = false;
            respuesta = Ciudad == ciudad ? true : false;
            return respuesta;
        }

        private bool NoTieneConsignacion()
        {
            return !_movimientos.Any(t => t.Tipo == "CONSIGNACION");
        }
        private bool MasDeTresConsignaciones()
        {
            return _movimientos.Count >3? true:false;
        }
    }
}

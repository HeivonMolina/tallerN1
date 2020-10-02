using NUnit.Framework;
using System;

namespace Banco.Core.Domain.Test
{
    public class TestsTarjetaCredito
    {
        [SetUp]
        public void Setup()
        {
        }


        /* Las Cuentas Corrientes pueden tener un cupo de sobregiro el cual es equivalente a un cr�dito preaprobado y recargable de forma autom�tica al realizarle consignaciones a la cuenta.
         HU 3.
        Como Usuario quiero realizar consignaciones a una cuenta corriente para salvaguardar el dinero.
        Criterios de Aceptaci�n
        3.1 La consignaci�n inicial debe ser de m�nimo 100 mil pesos.
        3.2 El valor consignado debe ser adicionado al saldo de la cuenta.*/
        [Test]
        public void NoPuedoConsignarNumeroNegativo()
        {
            //Preparar
            var cuentaCorriente = new CuentaCorriente(numero: "10001", nombre: "Cuenta Ejemplo", ciudad: "Valledupar");
            //Acci�n
            var resultado = cuentaCorriente.Consignar(0, "Valledupar");
            //Verificaci�n
            Assert.AreEqual("El valor a consignar es incorrecto", resultado);
        }
     


}
}
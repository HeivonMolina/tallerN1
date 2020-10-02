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


        /* Las Cuentas Corrientes pueden tener un cupo de sobregiro el cual es equivalente a un crédito preaprobado y recargable de forma automática al realizarle consignaciones a la cuenta.
         HU 3.
        Como Usuario quiero realizar consignaciones a una cuenta corriente para salvaguardar el dinero.
        Criterios de Aceptación
        3.1 La consignación inicial debe ser de mínimo 100 mil pesos.
        3.2 El valor consignado debe ser adicionado al saldo de la cuenta.*/
        [Test]
        public void NoPuedoConsignarNumeroNegativo()
        {
            //Preparar
            var cuentaCorriente = new CuentaCorriente(numero: "10001", nombre: "Cuenta Ejemplo", ciudad: "Valledupar");
            //Acción
            var resultado = cuentaCorriente.Consignar(0, "Valledupar");
            //Verificación
            Assert.AreEqual("El valor a consignar es incorrecto", resultado);
        }
     


}
}
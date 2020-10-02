using NUnit.Framework;
using System;

namespace Banco.Core.Domain.Test
{
    public class TestsCorriente
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
        [Test]
        public void NoPuedoConsignarMenosDe100Mil()
        {
            //Preparar
            var cuentaCorriente = new CuentaCorriente(numero: "10001", nombre: "Cuenta Ejemplo", ciudad: "Valledupar");
            //Acción
            var resultado = cuentaCorriente.Consignar(40000, "Valledupar");
            //Verificación
            Assert.AreEqual("El valor mínimo de la primera consignación debe ser de $100.000 mil pesos", resultado);
        }

        [Test]
        public void PuedoConsignar100MilPrimeraVez()
        {
            //Preparar
            var cuentaCorriente = new CuentaCorriente(numero: "10001", nombre: "Cuenta Ejemplo", ciudad: "Valledupar");
            //Acción
            var resultado = cuentaCorriente.Consignar(800000, "Valledupar");
            //Verificación
            Assert.AreEqual("Su Nuevo Saldo es de $1.800.000,00 pesos.", resultado);
        }

        //RETIROS
        /*HU 4.
        Como Usuario quiero realizar retiros a una cuenta corriente para salvaguardar el dinero.
        Criterios de Aceptación
        4.1 El valor a retirar se debe descontar del saldo de la cuenta.*/

        [Test]
        public void NoPuedoRetirarSiNoHAySaldo()
        {
            //Preparar
            var cuentaCorriente= new CuentaCorriente(numero: "10001", nombre: "Cuenta Ejemplo", ciudad: "Valledupar");
            //Acción
            cuentaCorriente.Consignar(100000, "Valedupar");
            var resultado = cuentaCorriente.Retirar(200000);
            //Verificación
            Assert.AreEqual("Saldo insuficiente", resultado);
            /*Tengo un cupo de 1millon, y consigno 100.000, eso me da un total de
            1.100.000, ahora a eso le voy a retirar 200.000 y me sale que no hay cupo
            ya que el saldo minimo para retirar debe ser mayor o igual al cupo de sobregiro.*/
        }

        [Test]
        public void PuedoRetirar()
        {
            //Preparar
            var cuentaCorriente = new CuentaCorriente(numero: "10001", nombre: "Cuenta Ejemplo", ciudad: "Valledupar");
            //Acción
            cuentaCorriente.Consignar(500000, "Valedupar");
            var resultado = cuentaCorriente.Retirar(200000);
            //Verificación
            Assert.AreEqual("Saldo retirado. Su Nuevo Saldo es de $1.299.200,00 pesos", resultado);
        }




}
}
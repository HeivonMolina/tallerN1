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
        public void NoPuedoConsignarNumeroNegativoTest()
        {
            //Preparar
            var tarjetaCedito = new TarjetaCredito(numero: "10001", ciudad: "Valledupar", 1000000);
            //Acción
            var resultado = tarjetaCedito.Consignar(0, "Valledupar");
            //Verificación
            Assert.AreEqual("Valor incorrecto a consignar", resultado);
        }
        [Test]
        public void NoPuedoAbonarMasQueElSaldoTest()
        {
            //Preparar
            var tarjetaCedito = new TarjetaCredito(numero: "10001", ciudad: "Valledupar", 1000000);
            //Acción
            var resultado = tarjetaCedito.Consignar(1100000, "Valledupar");
            //Verificación
            Assert.AreEqual("El valor del abono no puede ser mayor al saldo", resultado);
        }
        [Test]
        public void PuedoAbonarCorrectamente()
        {
            var tarjetaCedito = new TarjetaCredito(numero: "10001", ciudad: "Valledupar",1000000);
            //Acción
            var resultado = tarjetaCedito.Consignar(900000, "Valledupar");
            //Verificación
            Assert.AreEqual("Abono exito. Su cupo disponible es: $1.900.000,00. Su saldo es: $100.000,00.", resultado);
        }


        // Retiroos
        /*HU 6.
        Como Usuario quiero realizar retiros (avances) a una cuenta de crédito para retirar dinero en
        forma de avances del servicio de crédito.
        Criterios de Aceptación
        6.1 El valor del avance debe ser mayor a 0.
        6.2 Al realizar un avance se debe reducir el valor disponible del cupo con el valor del avance.
        6.3 Un avance no podrá ser mayor al valor disponible del cupo.*/
        [Test]
        public void valorAvanceDebeSerMayorACeroTest()
        {
            var tarjetaCedito = new TarjetaCredito(numero: "10001", ciudad: "Valledupar", 1000000);
            //Acción
            var resultado = tarjetaCedito.Retirar(0);
            //Verificación
            Assert.AreEqual("El valor del avance debe ser mayor a 0.", resultado);
        }


        [Test]
        public void PuedoRealizarAvanceTest()
        {
            var tarjetaCedito = new TarjetaCredito(numero: "10001", ciudad: "Valledupar", 1000000);
            //Acción
            var resultado = tarjetaCedito.Retirar(200000);
            //Verificación
            Assert.AreEqual("Avance exitoso. Su cupo disponible es: $800.000,00.", resultado);
        }

        [Test]
        public void NoPuedoRealizarAvanceMayorAlCupoTest()
        {
            var tarjetaCedito = new TarjetaCredito(numero: "10001", ciudad: "Valledupar", 1000000);
            //Acción
            var resultado = tarjetaCedito.Retirar(1200000);
            //Verificación
            Assert.AreEqual("El valor del avance no debe ser mayor al cupo disponible.", resultado);
        }

    }
}
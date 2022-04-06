using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Pruebas_Unitarias
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestCreacion1()     //Test de la creacion de una carta de equipo
        {
            bool resultado = ElJugonSAS.Program.crearCartaEquipo("Mina de c-4");
            Assert.AreEqual(true, resultado);
        }
        [TestMethod]
        public void TestCreacion2()     //Test de la creacion de una carta de personajes
        {
            bool resultado = ElJugonSAS.Program.crearCartaPersonaje();
            Assert.AreEqual(true, resultado);
        }
        [TestMethod]
        public void TestCreacion3()     //Test de la creacion de una carta de habilidad
        {
            bool resultado = ElJugonSAS.Program.crearCartaHabilidad();
            Assert.AreEqual(true, resultado);
        }
        [TestMethod]
        public void TestAgregar1()     //Test de agregar un equipo a un personaje
        {
            bool resultado = ElJugonSAS.Program.agregarEquipoAPersonaje();
            Assert.AreEqual(true, resultado);
        }
        [TestMethod]
        public void TestVerInfoCartas()     //Test de la informacion de las cartas
        {
            bool resultado = ElJugonSAS.Program.verInfoCartas();
            Assert.AreEqual(true, resultado);
        }
        [TestMethod]
        public void TestExcederCPdelaBaraja()     //Test donde se excede los CP de la baraja
        {
            ElJugonSAS.Program.crearCartaHabilidad();
            ElJugonSAS.Program.crearCartaHabilidad();
            ElJugonSAS.Program.crearCartaHabilidad();
            ElJugonSAS.Program.crearCartaHabilidad();
            ElJugonSAS.Program.agregarEquipoAPersonaje();
            bool resultado = ElJugonSAS.Program.crearCartaEquipo("Espada de esmeralda");
            Assert.AreEqual(false, resultado);
        }
        [TestMethod]
        public void TestAtacarPersonaje()     //Test donde se ataca a un personaje
        {
            Random rn = new Random();
            int v_rareza = rn.Next(4);

            ElJugonSAS.Personaje pr = new ElJugonSAS.Personaje("El villano", 3, ElJugonSAS.Program.rareza[v_rareza]);

            ElJugonSAS.Program.baraja_enemiga.Add(pr);

            ElJugonSAS.Program.agregarEquipoAPersonaje();

            bool resultado = ElJugonSAS.Program.atacarPersonaje("El principe sin cabeza", "El villano");
            Assert.AreEqual(true, resultado);
        }
        [TestMethod]
        public void TestAgregarHabilidad()     //Test de agregar un equipo a un personaje
        {
            ElJugonSAS.Program.agregarEquipoAPersonaje();

            ElJugonSAS.Program.crearCartaHabilidad();

            bool resultado = ElJugonSAS.Program.ImplementarHabilidad("El principe sin cabeza", "Elixir magico");
            Assert.AreEqual(true, resultado);
        }
    }
}

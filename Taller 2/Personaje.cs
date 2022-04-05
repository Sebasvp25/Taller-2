using System;
using System.Collections.Generic;
using System.Text;

namespace ElJugonSAS
{
    public class Personaje : Carta
    {
        private int puntos_ataque;
        private int resistencia;
        private List<Equipo> equipo;
        private int afinidad;   //Puede ser 3: Knight, 2: Mage, 1: Undead , si la comparacion es entre 3 y 1 gana 1

        public int Puntos_ataque { get => puntos_ataque; set => puntos_ataque = value; }
        public int Resistencia { get => resistencia; set => resistencia = value; }
        public List<Equipo> Equipo { get => equipo; set => equipo = value; }
        public int Afinidad { get => afinidad; }

        public Personaje(string nombre, int costo, string rareza) : base(nombre, costo, rareza)
        {
            Random rn = new Random();
            puntos_ataque = rn.Next(1, 4);
            resistencia = rn.Next(1, 4);
            afinidad = rn.Next(1, 4);
            equipo = new List<Equipo>();
        }

    }
}

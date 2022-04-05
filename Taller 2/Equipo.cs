using System;
using System.Collections.Generic;
using System.Text;

namespace ElJugonSAS
{
    public class Equipo : Carta
    {
        private string objetivo;
        private int puntos_agregados;
        private int afinidad; //Indica que tipos de personajes pueden usar esta carta 1, 2, 3 o 4: All

        public string Objetivo { get => objetivo; set => objetivo = value; }
        public int Puntos_agregados { get => puntos_agregados; set => puntos_agregados = value; }
        public int Afinidad { get => afinidad; set => afinidad = value; }

        public Equipo(string nombre, int costo, string rareza, string objetivo) : base(nombre, costo, rareza)
        {
            this.objetivo = objetivo;
            Random rn = new Random();
            puntos_agregados = rn.Next(1, 4);
            afinidad = rn.Next(1, 5);
        }
    }
}

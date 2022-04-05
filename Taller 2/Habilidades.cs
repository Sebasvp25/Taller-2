using System;
using System.Collections.Generic;
using System.Text;

namespace ElJugonSAS
{
    public class Habilidades : Carta
    {
        private string tipo_efecto;
        private int puntos_efecto;

        public string Tipo_efecto { get => tipo_efecto; set => tipo_efecto = value; }
        public int Puntos_efecto { get => puntos_efecto; set => puntos_efecto = value; }

        public Habilidades(string nombre, int costo, string rareza, string tipo_efecto) : base(nombre, costo, rareza)
        {
            this.tipo_efecto = tipo_efecto;
            Random rn = new Random();
            puntos_efecto = rn.Next(1, 4);
        }
    }
}
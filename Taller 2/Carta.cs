using System;
using System.Collections.Generic;
using System.Text;

namespace ElJugonSAS
{
	public class Carta
	{
		private string nombre;
		private string rareza;
		private int costo;

		public string Nombre { get => nombre; }
		public string Rareza { get => rareza; set => rareza = value; }
		public int Costo { get => costo; }

		public Carta(string nombre, int costo, string rareza)
		{
			this.nombre = nombre;
			this.costo = costo;
			this.rareza = rareza;
		}

	}
}

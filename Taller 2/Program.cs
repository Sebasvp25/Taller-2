using System;
using System.Collections.Generic;

namespace ElJugonSAS
{
    public class Program
    {
        public static string[] rareza = { "Comun", "Rara", "Super rara", "Ultra rara" };
        public static string[] objetivo = { "AP", "RP", "ALL" };
        public static string[] afinidad = { "Undead", "Mage", "Knight", "All" };
        public static string[] tipo_efecto = { "reduceAP", "reduceRP", "reduceAll", "DestruyeEquipo", "restaurarRP" };

        public static int baraja_cp = 12;

        public static List<Carta> baraja = new List<Carta>();
        public static List<Carta> baraja_enemiga = new List<Carta>();
        static void Main(string[] args)
        {
            Random rn = new Random();
            int v_rareza = rn.Next(4);

            Personaje pr = new Personaje("El villano", 3, rareza[v_rareza]);

            baraja_enemiga.Add(pr);

            Console.WriteLine("Hello World!");
            crearCartaEquipo("Espada de diamante");
            crearCartaEquipo("Espada de bronce");
            crearCartaEquipo("Espada de piedra");
            crearCartaPersonaje();
            crearCartaHabilidad();
            agregarEquipoAPersonaje();
            verInfoCartas();
            ImplementarHabilidad("El principe sin cabeza", "Elixir magico");
        }

        public static bool crearCartaEquipo(string nombre)
        {
            try
            {
                Random rn = new Random();
                int v_rareza = rn.Next(4);
                int v_objetivo = rn.Next(3);

                Equipo cardE = new Equipo(nombre, 2, rareza[v_rareza], objetivo[v_objetivo]);

                if (baraja_cp >= cardE.Costo)
                {
                    baraja.Add(cardE);
                    baraja_cp -= cardE.Costo;
                }
                else
                {
                    throw new Exception("Ya no tienes mas Puntos de costo de la baraja");
                }

                return true;
            }
            catch (Exception e)
            {
                return false;
                throw e;
            }
        }

        public static bool crearCartaPersonaje()
        {
            try
            {
                Random rn = new Random();
                int v_rareza = rn.Next(4);

                Personaje pr = new Personaje("El principe sin cabeza", 3, rareza[v_rareza]);

                if (baraja_cp >= pr.Costo)
                {
                    baraja.Add(pr);
                    baraja_cp -= pr.Costo;
                }
                else
                {
                    throw new Exception("Ya no tienes mas Puntos de costo de la baraja");
                }

                return true;
            }
            catch (Exception e)
            {
                return false;
                throw e;
            }
        }

        public static bool crearCartaHabilidad()
        {
            try
            {
                Random rn = new Random();
                int v_rareza = rn.Next(4);
                int v_efecto = rn.Next(5);

                Habilidades hab = new Habilidades("Elixir magico", 2, rareza[v_rareza], tipo_efecto[v_efecto]);

                if (baraja_cp >= hab.Costo)
                {
                    baraja.Add(hab);
                    baraja_cp -= hab.Costo;
                }
                else
                {
                    throw new Exception("Ya no tienes mas Puntos de costo de la baraja");
                }

                return true;
            }
            catch (Exception e)
            {
                return false;
                throw e;
            }
        }

        public static bool agregarEquipoAPersonaje()
        {
            try
            {
                Personaje pr = null;
                foreach (var i in baraja)
                {
                    if (i.GetType().Name == "Personaje")
                    {
                        pr = (Personaje)i;
                        continue;
                    }
                }
                Equipo eq = null;
                foreach (var i in baraja)
                {
                    if (i.GetType().Name == "Equipo")
                    {
                        eq = (Equipo)i;
                        if (eq.Objetivo == "AP")
                        {
                            pr.Puntos_ataque += eq.Puntos_agregados;
                        }
                        else if (eq.Objetivo == "RP")
                        {
                            pr.Resistencia += eq.Puntos_agregados;
                        }
                        else
                        {
                            pr.Puntos_ataque += eq.Puntos_agregados;
                            pr.Resistencia += eq.Puntos_agregados;
                        }
                        pr.Equipo.Add(eq);
                        break;
                    }
                }

                return true;
            }
            catch (Exception e)
            {
                return false;
                throw e;
            }
        }

        public static bool atacarPersonaje(string nombre, string nombre_enemigo)
        {
            try
            {
                Personaje prv = null;
                foreach (var i in baraja_enemiga)
                {
                    if (i.Nombre == nombre_enemigo)
                    {
                        prv = (Personaje)i;
                        break;
                    }
                }

                Personaje pr = null;
                foreach (var i in baraja)
                {
                    if (i.Nombre == nombre)
                    {
                        pr = (Personaje)i;

                        if (prv.Resistencia >= pr.Puntos_ataque)
                        {
                            prv.Resistencia -= pr.Puntos_ataque;
                        }
                        else
                        {
                            Console.WriteLine("Personaje destruido");
                            baraja_enemiga.RemoveAt(baraja_enemiga.IndexOf(prv));
                        }
                    }
                }


                return true;
            }
            catch (Exception e)
            {
                return false;
                throw e;
            }
        }

        public static bool ImplementarHabilidad(string nombre_personaje, string nombre_habilidad)
        {
            try
            {
                Personaje pr = null;
                foreach (var i in baraja)
                {
                    if (i.GetType().Name == "Personaje")
                    {
                        if (i.Nombre == nombre_personaje)
                        {
                            pr = (Personaje)i;
                            Habilidades hb = null;
                            foreach (var j in baraja)
                            {
                                if (j.GetType().Name == "Habilidades")
                                {
                                    if (j.Nombre == nombre_habilidad)
                                    {
                                        hb = (Habilidades)j;
                                        if (hb.Tipo_efecto == "reduceAP")
                                        {
                                            pr.Puntos_ataque -= hb.Puntos_efecto;
                                        }
                                        else if (hb.Tipo_efecto == "reduceRP")
                                        {
                                            pr.Resistencia -= hb.Puntos_efecto;
                                        }
                                        else if (hb.Tipo_efecto == "reduceAll")
                                        {
                                            pr.Puntos_ataque -= hb.Puntos_efecto;
                                            pr.Resistencia -= hb.Puntos_efecto;
                                        }
                                        else if (hb.Tipo_efecto == "DestruyeEquipo")
                                        {
                                            //Destroy equipo
                                        }
                                        else if (hb.Tipo_efecto == "restaurarRP")
                                        {
                                            pr.Resistencia += hb.Puntos_efecto;
                                        }
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }


                return true;
            }
            catch (Exception e)
            {
                return false;
                throw e;
            }
        }

        public static bool verInfoCartas()
        {
            try
            {
                foreach (var i in baraja)
                {
                    if (i.GetType().Name == "Equipo")
                    {
                        Equipo j = (Equipo)i;
                        Console.WriteLine($"Carta: {j.Nombre} \n{j.Rareza} \nCosto: {j.Costo} \nObjetivo: {j.Objetivo}" +
                    $"\n Agrega {j.Puntos_agregados} a los personajes de {afinidad[j.Afinidad - 1]}");
                    }
                    else if (i.GetType().Name == "Personaje")
                    {
                        Personaje j = (Personaje)i;
                        Console.WriteLine($"Carta: {j.Nombre} \n{j.Rareza} \nCosto: {j.Costo} \nPuntos de ataque: {j.Puntos_ataque}" +
                    $"\n Resistencia: {j.Resistencia} \nEs un personaje de {afinidad[j.Afinidad - 1]}");
                        foreach (var l in j.Equipo)
                        {
                            Console.WriteLine($"Tiene una carta {l.Nombre}");
                        }
                    }
                    else if (i.GetType().Name == "Habilidades")
                    {
                        Habilidades j = (Habilidades)i;
                        Console.WriteLine($"Carta: {j.Nombre} \n{j.Rareza} \nCosto: {j.Costo} \nTipo de efecto: {j.Tipo_efecto}" +
                    $"\n Puntos del efecto: {j.Puntos_efecto}");
                    }
                }

                return true;
            }
            catch (Exception e)
            {
                return false;
                throw e;
            }
        }
    }
}

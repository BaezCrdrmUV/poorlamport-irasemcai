using System;
using System.Collections.Generic;

namespace Reloj_de_Lamport_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> eventos = new List<string>();
            List<Nodo> nodos = new List<Nodo>(3);                      
          
            Nodo nodo1 = new Nodo(1);
            Nodo nodo2 = new Nodo(2);
            Nodo nodo3 = new Nodo(3);

            nodos.Add(nodo1);
            nodos.Add(nodo2);
            nodos.Add(nodo3);

            for (int i = 0; i<3; i++)
            {
                Console.WriteLine("¿Nodo Emisor? 1, 2 o 3");
                string emisor = Console.ReadLine();
                Console.WriteLine("¿Nodo Receptor? 1, 2 o 3");
                string receptor = Console.ReadLine();
                Console.WriteLine("Escribe un mensaje: ");
                string mensaje = Console.ReadLine();

                int EmisorInt= int.Parse(emisor);
                int ReceptorInt= int.Parse(receptor);

                var nodoEmisor = nodos.Find(n => n.Id == EmisorInt);
                var nodoRecep = nodos.Find(n => n.Id == ReceptorInt);

                var evento_A = nodoEmisor.enviarMensaje(nodoRecep.Id, mensaje);
                var evento_B = nodoRecep.recibirMensaje(nodoEmisor.Id, nodoEmisor.Contador, mensaje);
                eventos.Add(evento_A);
                eventos.Add(evento_B);
            }
            
            foreach(var evento in eventos)
            {                
                Console.WriteLine(evento);
            }

            
        }
    }
}

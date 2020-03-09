using System;


namespace Reloj_de_Lamport_Console
{
    class Nodo
    {
        public int Id;
        public int Contador;

        public Nodo (int id)
        {
            Id = id;
            Contador = 0;
        }
        public string enviarMensaje(int idReceptor, string mensaje) 
        {
            Contador++;
            Console.WriteLine("***Nodo "+Id+":"+Contador);

            string evento = Id +"->"+ idReceptor + ": "+ Contador;
            return evento;
        }

        public string recibirMensaje(int idEmisor, int contadorMensaje, string mensaje)
        {
            if (contadorMensaje > Contador)
            {               
                Contador = contadorMensaje + 1;                
            }            
            else
            {
                Contador++;               
            }
            Console.WriteLine("***Nodo "+Id +": "+ Contador+ "- "+mensaje);

            string evento = idEmisor + "->" + Id + ": "+Contador;
            return evento;
        }        
    }
}

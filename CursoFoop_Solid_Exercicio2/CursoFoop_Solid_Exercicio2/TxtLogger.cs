using System;
using CursoFoop_Solid_Exercicio2.Interfaces;

namespace CursoFoop_Solid_Exercicio2
{
    public class TxtLogger : ILogger
    {
        public void Registrar(string mensagem)
        {
            Console.WriteLine("Mensagem registrada em txt: " + mensagem);
        }
    }
}
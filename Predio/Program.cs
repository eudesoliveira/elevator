using System;
using System.Collections.Generic;

namespace Predio
{
    class Program
    {
        static void Main(string[] args)
        {
            // Setup inicial do Predio e Elevador
            #region
            Console.WriteLine("==========SETUP DO PRÉDIO E ELEVADOR============");
            Console.Write("Informe a quantidade de andares: ");
            int qtdAndares = int.Parse(Console.ReadLine());

            Console.Write("Informe a posição atual do elevador: ");
            int psElevador = int.Parse(Console.ReadLine());

            Console.WriteLine("==========SETUP DO(S) PASSAGEIRO(S)=============");
            Console.Write("Informe a quantidade de passageiros solicitantes: ");

            int qtdPassageiros = int.Parse(Console.ReadLine());

            // Matriz de solicitações de chamadas do elevador (id do passageiro, andar origem e andar destino)
            int[,] matSolElev = new int [qtdPassageiros, 3];
            int idPassageiro = 0;
            for (int i = 0; i < qtdPassageiros;  i++)
            {
                idPassageiro++;
                Console.Write("Informe o ANDAR ORIGEM do {0}º passageiro: ", idPassageiro);
                int andarOrigem = int.Parse(Console.ReadLine());
                Console.Write("Digite o ANDAR DESTINO do {0}º passageiro: ", idPassageiro);
                int andarDestino = int.Parse(Console.ReadLine());

                matSolElev[i, 0] = idPassageiro;
                matSolElev[i, 1] = andarOrigem;
                matSolElev[i, 2] = andarDestino;
            }
            Console.WriteLine("================================================");
            #endregion
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Predio
{
    public class Elevador
    {
        private string marca = "Atlas Schindler";
        private string modelo = "3300 New Edition";
        private double _capacidade = 600.00; //KG
        private int passageiros = 8;
        private int percursoMaximo = 75; // metros
        private double velocidade = 1.00; //0,75m/s – 1,00m/s – 1,6m/s

        private int _andarAtual;
        private int[,] _matSolicitacao;

        //Construtor da classe Elevador
        public Elevador(int andarAtual, int[,] matSolicitacao)
        {
            _andarAtual = andarAtual;
            _matSolicitacao = matSolicitacao;
        }

        /*
        Método publico da classe IniciarTrajeto 
        Objetivo: Inicia o trajeto dos passageiros solicitantes.
        */
        public void IniciarTrajeto()
        {
            // Cacular a rota com melhor tempo.
            CalculaMelhorTempo(_matSolicitacao, out int idPassageiro, out int menorDistancia);

            int passageirosAtendidos = 0;
            int difAndarAtualOrigem = 0;

            for (int i = 0; i < _matSolicitacao.GetLength(0); i++)
            {
                if (_matSolicitacao[i, 3] == -1)
                {
                    Console.WriteLine("Iniciando trajeto.........");
                    difAndarAtualOrigem = (_matSolicitacao[i, 1] > _andarAtual) ? (_matSolicitacao[i, 1] - _andarAtual) : (_andarAtual - _matSolicitacao[i, 1]);

                    if (_andarAtual != _matSolicitacao[i, 1])
                    {
                        Console.WriteLine("Elevador saindo do {0}º andar para o {1}º andar", _andarAtual, _matSolicitacao[i, 1]);
                    }
                    else Console.WriteLine("Elevador abrindo as portas para o passageiro no {0}º andar", _andarAtual);

                    _andarAtual = _matSolicitacao[i, 2]; // Andar atual do elevador passa a ser o destino do passageiro
                    _matSolicitacao[i, 3] = -2; // -2 identifica Passageiro atendidos

                    Console.WriteLine("{0}º Passageiro entregue no {1}º andar", _matSolicitacao[i, 0], _matSolicitacao[i, 2]);
                    Console.WriteLine("Andar(es) percorrido(s) entre a posição atual do elevador e a solicitação do passageiro: {0}", difAndarAtualOrigem);
                    Console.WriteLine("Término de trajeto.........");
                    Console.WriteLine(" ");
                }
                if (_matSolicitacao[i, 3] == -2)
                    passageirosAtendidos++;
            }
            // Libera a recursividade de chamadas para o próximo passageiro caso não tenha lido todos destinos.
            if (passageirosAtendidos != _matSolicitacao.GetLength(0))
                IniciarTrajeto();
        }

        /*
        Método privado da classe Elevador 
        Objetivo: Calcular a menor distância (andares) entre a origem do elevador e a origem do passageiro.
        */
        private void CalculaMelhorTempo(int[,] matSolicitacao, out int idPassageiro, out int menorDistancia)
        {
            idPassageiro = -1;
            menorDistancia = 999;
            int andarSolicitado = 0;

            for (int i = 0; i < matSolicitacao.GetLength(0); i++)
            {
                if (matSolicitacao[i, 3] == 0)
                {
                    andarSolicitado = (matSolicitacao[i, 1] > _andarAtual) ? (matSolicitacao[i, 1] - _andarAtual) : (_andarAtual - matSolicitacao[i, 1]);

                    if (andarSolicitado < menorDistancia)
                    {
                        menorDistancia = (andarSolicitado);
                        idPassageiro = i;
                    }
                }
            }
            _matSolicitacao[idPassageiro, 3] = -1;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Predio
{
    public class Passageiros
    {
        int[,] _matSolicitacao { get; set; }

        public Passageiros(int[,] matSolicitacao)
        {
            _matSolicitacao = matSolicitacao;

        }

        public void ChamarElevador(int psElevador)
        {
            Elevador elevador = new Elevador(psElevador, _matSolicitacao);
            elevador.IniciarTrajeto();
        }

    }
}

using System;
using System.Collections.Generic;
using System.Text;
using tabuleiro;

namespace xadrex {
    class PartidaDeXadrez {
        public Tabuleiro tab { get; private set; }
        public int turno { get; private set; }
        public Cor jogadorAtual { get; private set; }
        public bool terminada { get; private set; }

        public PartidaDeXadrez() {
            tab = new Tabuleiro(8, 8);
            turno = 1;
            terminada = false;
            jogadorAtual = Cor.Branca;
            colocarPecas();
        }

        public void execultaMovimento(Posicao origem, Posicao destino) {
            Peca p = tab.retirarPeca(origem);
            p.incrementarQteMovimentos();
            Peca pecaCaptura = tab.retirarPeca(destino);
            tab.colocarPeca(p, destino);
        }

        public void realizaJogada(Posicao origem, Posicao destino) {
            execultaMovimento(origem, destino);
            turno++;
            mudaJogador();
        }
        public void validarPosicaoDeOrigem(Posicao pos) {
            if (tab.peca(pos) == null) {
                throw new TabuleiroException("não tem nenhuma peça nesse ponto de origem. Por favor, escolha outro");
            }
            if (jogadorAtual != tab.peca(pos).cor) {
                throw new TabuleiroException("A peça escolhida não é sua!");
            }
            if (!tab.peca(pos).existeMovimentosPosiveis()) {
                throw new TabuleiroException("não a movimentos possiveis para essa peça");
            }
        }
        public void validarPosicaoDeDestino(Posicao pos) {
            if (!tab.peca(pos).podeMoverPara(pos)) {
                throw new TabuleiroException("Você não pode ir nessa posição");
            }
        }

            public void mudaJogador() {
            if(jogadorAtual == Cor.Branca) {
                jogadorAtual = Cor.Preta;
            }
            else {
                jogadorAtual = Cor.Branca;
            }
        }

        private void colocarPecas() {
            tab.colocarPeca(new Torre(tab, Cor.Preta), new PosicaoXadrez('c', 1).toPosicao());
            tab.colocarPeca(new Torre(tab, Cor.Preta), new PosicaoXadrez('a', 1).toPosicao());

        }
    }
}

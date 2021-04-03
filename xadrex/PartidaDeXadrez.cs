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
        private HashSet<Peca> pecas;
        private HashSet<Peca> capturadas;

        public PartidaDeXadrez() {
            tab = new Tabuleiro(8, 8);
            turno = 1;
            terminada = false;
            jogadorAtual = Cor.Branca;
            pecas = new HashSet<Peca>();
            capturadas = new HashSet<Peca>();
            colocarPecas();
        }

        public void execultaMovimento(Posicao origem, Posicao destino) {
            Peca p = tab.retirarPeca(origem);
            p.incrementarQteMovimentos();
            Peca pecaCaptura = tab.retirarPeca(destino);
            tab.colocarPeca(p, destino);
            if (pecaCaptura != null) {
                capturadas.Add(pecaCaptura);
            }
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
        public void validarPosicaoDeDestino(Posicao origem, Posicao destino) {
            if (!tab.peca(origem).podeMoverPara(destino)) {
                throw new TabuleiroException("Você não pode ir nessa posição");
            }
        }

        public void mudaJogador() {
            if (jogadorAtual == Cor.Branca) {
                jogadorAtual = Cor.Preta;
            }
            else {
                jogadorAtual = Cor.Branca;
            }
        }

        public HashSet<Peca> pecasCapturadas(Cor cor) {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach(Peca x in capturadas) {
                if(x.cor == cor) {
                    aux.Add(x); 
                }
            }
            return aux;
        }

        public HashSet<Peca> pecasEmJogo(Cor cor) {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach (Peca x in pecas) {
                if (x.cor == cor) {
                    aux.Add(x);
                }
            }
            aux.ExceptWith(pecasCapturadas(cor));
            return aux;
        }

        public void colocarNovaPeca(char coluna, int linha, Peca peca) {
            tab.colocarPeca(peca, new PosicaoXadrez(coluna, linha).toPosicao());
            pecas.Add(peca);
        }
        private void colocarPecas() {
            colocarNovaPeca('c', 1, new Torre(tab, Cor.Preta));
            colocarNovaPeca('a', 1, new Torre(tab, Cor.Preta));
        }
    }
}

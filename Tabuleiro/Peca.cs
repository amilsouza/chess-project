﻿namespace tabuleiro {
    abstract class Peca {
        public Posicao posicao { get; set;}
        public Cor cor { get; protected set; }
        public int qteMovimento { get; protected set; }
        public Tabuleiro tab { get; protected set; }

        public Peca(Tabuleiro tab, Cor cor) {
            this.posicao = null;
            this.cor = cor;
            this.tab = tab;
            this.qteMovimento = 0;
        }

        public void incrementarQteMovimentos() {
            qteMovimento++;
        }

        public bool existeMovimentosPosiveis() {
            bool[,] mat = movimentosPosiveis();
            for(int i=0; i<=tab.linhas; i++) {
                for (int j = 0; j <= tab.colunas; j++) {
                    if(mat[i, j]) {
                        return true;
                    }
                
                }
            }
            return false;
        }

        public bool podeMoverPara(Posicao pos) {
            return movimentosPosiveis()[pos.linha, pos.coluna];
        }
        public abstract bool[,] movimentosPosiveis();
      
    }
}

using System;
using tabuleiro;

namespace xadrex {
    class Bispo : Peca {
        public Bispo(Tabuleiro tab, Cor cor)
        : base(tab, cor) {
        }

        public override string ToString() {
            return "B";
        }
    }
}

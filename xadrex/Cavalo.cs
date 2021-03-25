using System;
using tabuleiro;

namespace xadrex {
    class Cavalo : Peca {
        public Cavalo(Tabuleiro tab, Cor cor)
        : base(tab, cor) {
        }

        public override string ToString() {
            return "C";
        }
    }
}

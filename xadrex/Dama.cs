using System;
using tabuleiro;

namespace xadrex {
    class Dama : Peca {
        public Dama(Tabuleiro tab, Cor cor)
        : base(tab, cor) {
        }

        public override string ToString() {
            return "D";
        }
    }
}

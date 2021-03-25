using System;
using tabuleiro;

namespace xadrex {
    class Soldado : Peca {
        public Soldado(Tabuleiro tab, Cor cor)
        : base(tab, cor) {
        }

        public override string ToString() {
            return "S";
        }
    }
}

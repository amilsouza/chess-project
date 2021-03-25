using System;
using tabuleiro;
using xadrex;

namespace xadrez_console {
    class Program {
        static void Main(string[] args) {
            Tabuleiro tab = new Tabuleiro(8, 8);

            tab.colocarPeca(new Torre(tab, Cor.Preta), new Posicao(0,0));
            tab.colocarPeca(new Cavalo(tab, Cor.Preta), new Posicao(0, 1));
            tab.colocarPeca(new Bispo(tab, Cor.Preta), new Posicao(0, 2));
            tab.colocarPeca(new Rei(tab, Cor.Preta), new Posicao(0, 3));
            tab.colocarPeca(new Dama(tab, Cor.Preta), new Posicao(0, 4));

            Tela.imprimirTabuleiro(tab);

            Console.ReadLine();


        }
    }
}

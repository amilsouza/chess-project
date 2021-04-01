using System;
using tabuleiro;
using xadrex;

namespace xadrez_console {
    class Program {
        static void Main(string[] args) {
            try {
                PartidaDeXadrez partida = new PartidaDeXadrez();

                while (!partida.terminada) {
                    try {
                        Console.Clear();
                        Tela.imprimirTabuleiro(partida.tab);
                        Console.Write("Turno: " + partida.turno);
                        Console.WriteLine("Aguardando o jogador de cor " + partida.jogadorAtual);

                        Console.Write("digite a peça de origem: ");
                        Posicao origem = Tela.lerPosicaoXadrez().toPosicao();
                        partida.validarPosicaoDeOrigem(origem);

                        Console.Clear();
                        bool[,] posicoesPossiveis = partida.tab.peca(origem).movimentosPosiveis();
                        Tela.imprimirTabuleiro(partida.tab, posicoesPossiveis);

                        Console.Write("digite a peça de destino: ");
                        Posicao destino = Tela.lerPosicaoXadrez().toPosicao();
                        partida.validarPosicaoDeDestino(origem, destino);

                        partida.execultaMovimento(origem, destino);
                    }
                    catch (TabuleiroException e) {
                        Console.WriteLine(e.Message);
                        Console.Read();
                    }
                    
                }

                Tela.imprimirTabuleiro(partida.tab);
            }
            catch (TabuleiroException e){
                Console.WriteLine(e.Message);
            }

            Console.ReadLine();


        }
    }
}

using System;
using NuvemDeCinzas.Libraries;

namespace NuvemDeCinzas {
    class Program {
        static void Main (string[] args) {

            // Saudações ao usuário
            System.Console.WriteLine ("===========================================");
            System.Console.WriteLine ("Bem-vindo à ao simulador da nuvem de cinzas!");
            System.Console.WriteLine ("===========================================");
            System.Console.WriteLine ();
            System.Console.WriteLine ("Vamos à ação?");
            System.Console.WriteLine ();
            System.Console.WriteLine ("Digite 's' para acessar o menu' e 'n' para fechar'");
            string optSaudacoes = System.Console.ReadLine ();

            bool usuarioQuerUsar = true;
            while (usuarioQuerUsar == true) {
                switch (optSaudacoes) {
                    case "s":
                        bool usuarioQuerFicarMenu = true;
                        do {
                            Console.Clear ();
                            System.Console.WriteLine ("O que você quer fazer?");
                            System.Console.WriteLine ();
                            System.Console.WriteLine ("Digite o número correspondente e pressione ENTER.");
                            System.Console.WriteLine ("1 - Mostra pra mim aí a simulação, tio.");
                            System.Console.WriteLine ("2 - Me tira daqui, por favor");

                            string optMenu = System.Console.ReadLine ();
                            switch (optMenu) {
                                case "1":
                                    new Runner ();
                                    Console.WriteLine ("=================================================================");
                                    Console.WriteLine ("Lembre-se de que você pode configurar quase tudo no arquivo Setup!\n");
                                    Console.WriteLine ("Pressione ENTER para voltar ao menu.");
                                    Console.ReadLine ();
                                    break;
                                case "2":
                                    usuarioQuerFicarMenu = false;
                                    usuarioQuerUsar = false;
                                    break;
                                default:

                                    break;
                            }
                        } while (usuarioQuerFicarMenu == true);
                        break;
                    case "n":
                        usuarioQuerUsar = false;
                        break;

                    default:
                        Console.Clear ();
                        System.Console.WriteLine ("Você precisa escolher uma opção!");
                        System.Console.WriteLine ();
                        System.Console.WriteLine ("Digite 's' para acessar o menu' e 'n' para fechar'");
                        break;
                }
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;

namespace Palavras_Primas {
    class Program {
        static void Main (string[] args) {
            // Cria uma array com o alfabeto maiúsculo e maiúsculo
            char[] arrayAlfabeto = new char[52];
            int soma;

            int i = 0;
            for (char c = 'a'; c < 'z'; c++) {
                arrayAlfabeto[i] = c;
                i++;
            }

            for (char c = 'A'; c < 'Z'; c++) {
                arrayAlfabeto[i] = c;
                i++;
            }

            // Saudações ao usuário
            System.Console.WriteLine ("==========================================");
            System.Console.WriteLine ("Bem-vindo à calculadora de palavras primas");
            System.Console.WriteLine ("==========================================");
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
<<<<<<< HEAD
                            Console.Clear();
=======
                            Console.Clear ();
>>>>>>> 04eda018e58745a49753a079dbb2808a23be4f14
                            System.Console.WriteLine ("O que você quer fazer?");
                            System.Console.WriteLine ();
                            System.Console.WriteLine ("Digite o número correspondente e pressione ENTER.");
                            System.Console.WriteLine ("1 - Minha palavra é prima?");
                            System.Console.WriteLine ("2 - Como funciona?");
                            System.Console.WriteLine ("3 - Me tira daqui, por favor");
                            string optMenu = System.Console.ReadLine ();
                            switch (optMenu) {
                                case "1":
                                    System.Console.WriteLine ("Digite uma palavra qualquer.");
                                    string input = Console.ReadLine ();
                                    char[] arrayInput = input.ToCharArray ();

                                    foreach (var letraInput in arrayInput) {
                                        for (i = 0; i < arrayAlfabeto.Length; i++) {
                                            if (letraInput == letraAlfabeto) {
                                                soma += (i + 1);
                                            }
                                        }
                                    }

                                    var resultado = (soma % 2) == 0 ? "é primo" : "não é primo";

                                    System.Console.WriteLine ("Somando o que você digitou, posso dizer que {0}, {1}.", input, resultado);
                                    System.Console.WriteLine ("Aperte ENTER para continuar");
                                    Console.ReadLine ();
                                    break;

                                case "2":
                                    System.Console.WriteLine ("Cada letra tem seu respectivo valor.");
                                    System.Console.WriteLine ("'a' é 1, 'b' é 2, z é 26, 'A' é 27 e assim por diante.");
                                    System.Console.WriteLine ("A calculadora vai somar todas as letras de uma frase e,");
                                    System.Console.WriteLine ("depois, irá checar se a palavra é prima ou não.\n");
                                    System.Console.WriteLine ("Aperte ENTER para continuar");
                                    Console.ReadLine ();
                                    break;
                                case "3":
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
<<<<<<< HEAD
                        Console.Clear();
=======
                        Console.Clear ();
>>>>>>> 04eda018e58745a49753a079dbb2808a23be4f14
                        System.Console.WriteLine ("Você precisa escolher uma opção!");
                        System.Console.WriteLine ();
                        System.Console.WriteLine ("Digite 's' para acessar o menu' e 'n' para fechar'");
                        break;
                }
            }
        }
<<<<<<< HEAD

        public static char ChecaAcento () {
            char palavraSemAcento = 'á';
            return palavraSemAcento;
        }
=======
>>>>>>> 04eda018e58745a49753a079dbb2808a23be4f14
    }
}
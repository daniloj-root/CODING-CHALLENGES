using System;
using System.Collections.Generic;

namespace Conta_Bancaria {
    class Program {
        static void Main (string[] args) {
            var notasDisponiveis = new int[] { 100, 50, 20, 10 }; //Declara as notas disponíveis no caixa
            var notasQtd = new int[4];
            string stringValor;

            System.Console.WriteLine ("======================================");
            System.Console.WriteLine ("Bem-vindo ao caixa 24 horas do Danilo!");
            System.Console.WriteLine ("======================================");


            do {
            System.Console.WriteLine ("Só temos notas de 100, 50, 20 e 10. Sendo assim, seu saque pode acabar atualmente sendo inferior ao desejado.");
            System.Console.WriteLine ("Maximo de saque: R$3000.\n");
                System.Console.WriteLine ("Digite quanto quer sacar, em números INTEIROS.");
            } while (!ChecaValor (stringValor = Console.ReadLine ())); //Checa se o valor que o usuário inputou é um inteiroou não e, se não for,  manda o usuário digitar de novo

            var valorUsuario = int.Parse (stringValor);

            var i = 0;
            foreach (var notas in notasDisponiveis) {
                double divisaoNota = ((valorUsuario - RetornaValorAtualSaque (notasDisponiveis, notasQtd)) / notas); //Adquire o valor apropriado através de RetornaValorAtualSaque() e divide por uma posição da array de notasDisponiveis 
                notasQtd[i] = (int) Math.Floor (divisaoNota); //Arrendonda para baixo, e coloca o dado na posição da array notasQtd correspondente
                System.Console.WriteLine (i);
                i++;
            }

            Console.Clear ();

            System.Console.WriteLine ("Relação de notas que serão sacadas:");
            for (i = 0; i < 4; i++) {
                if (notasQtd[i] != 0) {
                    System.Console.WriteLine ($"De notas de R${notasDisponiveis[i]}, {(notasQtd[i] == 1 ? "será" : "serão")} {notasQtd[i]}.");
                }
            }

            var valorTotal = RetornaValorAtualSaque (notasDisponiveis, notasQtd);
            System.Console.WriteLine ("Você desejou sacar R$ {0} e o valor total sacado será de R${1}", valorUsuario, valorTotal);
        }

        public static int RetornaValorAtualSaque (int[] notasDisponiveis, int[] notasQtd) {
            var valorAtual = 0; //Controla a entrada de dados na divisão 
            for (var i = 0; i < 4; i++) {
                valorAtual += (notasDisponiveis[i] * notasQtd[i]); //Multiplica o valor da nota em alguma posição no vetor notasDisponiveis com a respectiva quantidade delas no vetor notasQtd
            }
            return valorAtual;
        }

        // Cuida do tratamento de erros mais comuns 
        public static bool ChecaValor (string valorUsuario) {
            try {
                int valorConvertido = int.Parse (valorUsuario);

                if (valorConvertido > 3000)
                    return Erro ("Seu número um valor igual ou menor que 3000.");

                if (valorConvertido < 10)
                    return Erro ("Seu número não é um valor igual ou maior que 10. É nossa menor cédula disponível.");

                return true; // Retorna true se nenhuma erro acontecer

            } catch {
                return Erro ("Seu input não é um inteiro.");
            }
        }
        public static Func<string, bool> Erro = x => {
            Console.Clear ();
            Console.WriteLine ("{0}\n", x);
            return false;
        };
    }
}
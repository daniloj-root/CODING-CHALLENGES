using System;

namespace Conta_Bancaria {
    class Program {
        static void Main (string[] args) {
            //Declara as notas disponíveis no caixa
            var notasDisponiveis = new int[] { 100, 50, 20, 10 };
            var notasQtd = new int[4];
            var stringValor = "";

            System.Console.WriteLine ("=================================================");
            System.Console.WriteLine ("Bem-vindo ao caixa 24 horas de dinheiro infinito!");
            System.Console.WriteLine ("=================================================");
            System.Console.WriteLine ();
            System.Console.WriteLine ("OBS: Só temos de 100, 50, 20 e 10, sendo assim, seu saque pode acabar atualmente sendo inferior ao desejado.");
            System.Console.WriteLine ("OBS2: Não temos muito caixa disponível. Máximo de saque: R$3000");

            do {
                System.Console.WriteLine ("Digite quanto quer sacar, em números inteiros, desde que seja menos do  R$3000.");

                //Checa se o valor que o usuário inputou é um inteiroou não, e manda o usuário digitar de novo, se não for
            } while (!ChecaValor (stringValor = Console.ReadLine ()));

            var valorUsuario = int.Parse (stringValor);

            var i = 0;
            foreach (var notas in notasDisponiveis) {
                //Adquire o valor apropriado através de RetornaValorAtualSaque() e divide por uma posição da array de notasDisponiveis por loop
                double divisaoNota = ((valorUsuario - RetornaValorAtualSaque (valorUsuario, notasDisponiveis, notasQtd)) / notas);
                //Arrendonda para baixo, e coloca o dado na posição da array notasQtd correspondente
                notasQtd[i] = (int) Math.Floor (divisaoNota);
                System.Console.WriteLine (i);
                i++;
            }

            Console.Clear();
            System.Console.WriteLine ("Relação de notas que serão sacadas:");
            for (i = 0; i <= 3; i++) {
                if (notasQtd[i] != 0) {
                    System.Console.WriteLine ($"De notas de R${notasDisponiveis[i]}, serão {notasQtd[i]}.");
                }
            }
            var valorTotal = RetornaValorAtualSaque(valorUsuario, notasDisponiveis, notasQtd);
            System.Console.WriteLine ($"Você desejou sacar R${valorUsuario} e o valor total sacado será de R${valorTotal}");
        }
        ////Controla a entrada de dados na divisão 
        public static int RetornaValorAtualSaque (int valorUsuario, int[] notasDisponiveis, int[] notasQtd) {
            var valorAtual = 0;
            for (var i = 0; i <= 3; i++) {
                //Multiplica o valor da nota em alguma posição no vetor notasDisponiveis com a respectiva quantidade no vetor notasQtd
                valorAtual += (notasDisponiveis[i] * notasQtd[i]);
            }
            return valorAtual;
        }
        public static bool ChecaValor (string valorUsuario) {
            try {
                var valorConvertido = int.Parse (valorUsuario);
                if (valorConvertido <= 3000) {
                    return true;
                } else {
                    return false;
                }
            } catch {
                return false;
            }
        }
    }
}
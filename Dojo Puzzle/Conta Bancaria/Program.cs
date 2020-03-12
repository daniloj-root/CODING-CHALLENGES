using System;
using System.Collections.Generic;

namespace Conta_Bancaria
{
    class Program
    {
        static void Main(string[] args)
        {
            var notasDisponiveis = new int[] { 100, 50, 20, 10 }; //Declara as notas disponíveis no caixa
            var notasQtd = new int[4];
            string stringValor;

            System.Console.WriteLine("==================================================");
            System.Console.WriteLine("Bem-vindo ao caixa 24 horas de dinheiro infinito!");
            System.Console.WriteLine("=================================================");
            System.Console.WriteLine();
            System.Console.WriteLine("OBS: Só temos de 100, 50, 20 e 10, sendo assim, seu saque pode acabar atualmente sendo inferior ao desejado.");
            System.Console.WriteLine("OBS2: Não temos muito caixa disponível. Máximo de saque: R$3000");

            do
            {
                System.Console.WriteLine("Digite quanto quer sacar, em números inteiros, desde que seja menos do  R$3000.");


            } while (!ChecaValor(stringValor = Console.ReadLine())); //Checa se o valor que o usuário inputou é um inteiroou não e, se não for,  manda o usuário digitar de novo

            var valorUsuario = int.Parse(stringValor);

            var i = 0;
            foreach (var notas in notasDisponiveis)
            {
                double divisaoNota = ((valorUsuario - RetornaValorAtualSaque(notasDisponiveis, notasQtd)) / notas); //Adquire o valor apropriado através de RetornaValorAtualSaque() e divide por uma posição da array de notasDisponiveis 
                notasQtd[i] = (int) Math.Floor(divisaoNota); //Arrendonda para baixo, e coloca o dado na posição da array notasQtd correspondente
                System.Console.WriteLine(i);
                i++;
            }

            Console.Clear();

            System.Console.WriteLine("Relação de notas que serão sacadas:");
            for (i = 0; i <= 3; i++)
            {
                if (notasQtd[i] != 0)
                {
                    System.Console.WriteLine($"De notas de R${notasDisponiveis[i]}, serão {notasQtd[i]}.");
                }
            }
            var valorTotal = RetornaValorAtualSaque(notasDisponiveis, notasQtd);
            System.Console.WriteLine($"Você desejou sacar R${valorUsuario} e o valor total sacado será de R${valorTotal}");
        }

        public static int RetornaValorAtualSaque(int[] notasDisponiveis, int[] notasQtd)
        {  
            var valorAtual = 0;  //Controla a entrada de dados na divisão 
            for (var i = 0; i <= 3; i++)
            {
                valorAtual += (notasDisponiveis[i] * notasQtd[i]);  //Multiplica o valor da nota em alguma posição no vetor notasDisponiveis com a respectiva quantidade delas no vetor notasQtd
            }
            return valorAtual;
        }

        public static bool ChecaValor(string valorUsuario)
        {
            try
            {
                var valorConvertido = int.Parse(valorUsuario);
                if (valorConvertido <= 3000)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
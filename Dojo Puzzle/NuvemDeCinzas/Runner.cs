using System;
using NuvemDeCinzas.Libraries;
using NuvemDeCinzas.Models;

namespace NuvemDeCinzas {
    public class Runner : ControladorQuadrados {
        public Runner () {
            IniciarCoordenadas ();

            PreencherVazios ();

            PreencherNuvens ();

            PreencherAeroportos ();

            foreach (var coordenada in Coordenadas) {
                if (coordenada == RetornarValor (TipoQuadrado.AEROPORTO)) {
                    qtdInicialAeroportos++;
                }
            }

            var loopsPermitidos = 1;
            int qtdAeroportos;

            while (true) {
                qtdAeroportos = 0;
                diasTotais++;
            
                DesenharCoordenadas ();
            
                foreach (var coordenada in Coordenadas) {
                    if (coordenada == RetornarValor (TipoQuadrado.AEROPORTO)) {
                        qtdAeroportos++;
                    }
                }

                if (qtdAeroportos != qtdInicialAeroportos && loopsPermitidos == 1) {
                    qtdDiasPrimeiroAeroporto = diasTotais;
                    loopsPermitidos = 0;
                }

                if (qtdAeroportos == 0) {
                    break;
                }
                
                AvancarDia ();
            }
            Console.WriteLine ("\nResultados:\n");
            Console.WriteLine ("Quantidade de aeroportos: {0}", qtdInicialAeroportos);
            Console.WriteLine ("Quantidade de dias para que o primeiro aeroporto fosse pego: {0}", qtdDiasPrimeiroAeroporto);
            Console.WriteLine ("Quantidade de dias para que todos os aeroportos fossem pegos: {0}", diasTotais);
        }
    }
}
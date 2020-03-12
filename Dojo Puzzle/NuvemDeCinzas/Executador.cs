using NuvemDeCinzas.Classes;
using System;

namespace NuvemDeCinzas
{
    public class Executador : ControladorQuadrados
    {
        public Executador()
        {
            Coordenadas = new char[8, 40];

            IniciarCoordenadas();

            PreencherVazios();

            PreencherNuvens();

            PreencherAeroportos();

            foreach (var coordenada in Coordenadas)
            {
                if (coordenada == RetornarValor(TipoQuadrado.AEROPORTO))
                {
                    qtdInicialAeroportos++;
                }
            }

            var loopsPermitidos = 1;

            while (true)
            {
                DesenharCoordenadas();

                int qtdAeroportos = 0;

                foreach (var coordenada in Coordenadas)
                {
                    if (coordenada == RetornarValor(TipoQuadrado.AEROPORTO))
                    {
                        qtdAeroportos++;
                    }

                }

                if (qtdAeroportos != qtdInicialAeroportos && loopsPermitidos == 1)
                {
                    diasPrimAeroporto = qtdAeroportos;
                    loopsPermitidos = 0;
                }

                if (qtdAeroportos == 0)
                {
                    break;
                }

                AvancarDia();
            }
            Console.WriteLine($"Demorará {diasPrimAeroporto} para o primeiro aeroporto ser coberto, e {diasTotais} para todos eles.");
        }
    }
}

using System;

namespace NuvemDeCinzas.Classes
{
    public class ControladorQuadrados : BibliotecaQuadrados
    {

        protected void IniciarCoordenadas() // faz com que a primeira nuvem seja criada na borda da matriz
        {
            Random random = new Random();
            x = random.Next(0, 8);
            if (x == 0 || x == 7) // verifica se x marca os cantos da array bidimensional
            {
                y = random.Next(0, 38); // se true, é designado qualquer y dentre as colunas inferiores e superiores 
            }
            else // se false, o y precisa ser o extremo superior ou o extremo inferior
            {
                if (random.Next(1, 3) == 1)
                {
                    y = 0;
                }
                else
                {
                    y = 39;
                }
            }
        }

        protected void PreencherVazios()
        {
            for (var xIndex = 0; xIndex < 7; xIndex++)
            {
                for (var yIndex = 0; yIndex < 39; yIndex++)
                {
                    Coordenadas[xIndex, yIndex] = RetornarValor(TipoQuadrado.VAZIO);
                }
            }
        }

        protected void PreencherNuvens()
        {
            var contadorNuvens = 1;
            Random random = new Random(DateTime.Now.Millisecond);

            while (contadorNuvens < 10) //se repete até que todas as 10 nuvens sejam colocadas
            {
                Coordenadas[x, y] = RetornarValor(TipoQuadrado.NUVEM);

                switch (random.Next(1, 5))
                {
                    case 1:
                        if (y != 0 && (Coordenadas[x, (y - 1)] == RetornarValor(TipoQuadrado.VAZIO))) //evita que o index saia dos limites da array e que uma nuvem seja sobrescrita
                        {
                            MoverPraCima();
                            contadorNuvens++;
                            break;
                        }
                        break;
                    case 2:
                        if (y != 39 && (Coordenadas[x, (y + 1)] == RetornarValor(TipoQuadrado.VAZIO)))
                        {
                            MoverPraBaixo();
                            contadorNuvens++;
                            break;
                        }
                        break;
                    case 3:
                        if (x != 0 && (Coordenadas[(x - 1), y] == RetornarValor(TipoQuadrado.VAZIO)))
                        {
                            MoverPraEsquerda();
                            contadorNuvens++;
                            break;
                        }
                        break;
                    case 4:
                        if (x != 7 && (Coordenadas[(x + 1), y] == RetornarValor(TipoQuadrado.VAZIO)))
                        {
                            MoverPraDireita();
                            contadorNuvens++;
                            break;
                        }
                        break;
                }
            }
        }

        protected void PreencherAeroportos()
        {
            Random random = new Random(DateTime.Now.Millisecond);
            var contadorAeroportos = 0;
            for (var xIndex = 0; xIndex < 7; xIndex++)
            {
                for (var yIndex = 0; yIndex < 39; yIndex++)
                {
                    if ((Coordenadas[xIndex, yIndex] == RetornarValor(TipoQuadrado.VAZIO)) && (random.Next(0, 41) == 40)) // 2,5% de chance de um vazio ser preenchido por um aeroporto
                    {
                        Coordenadas[xIndex, yIndex] = RetornarValor(TipoQuadrado.AEROPORTO);
                        contadorAeroportos++;
                    }

                    if (contadorAeroportos >= 4) //deixa a quantidade de aeroportos ao redor de 4
                    {
                        break;
                    }
                }
            }
        }


        protected void AvancarDia()
        {
            var coordenadasLegado = Coordenadas;

            for (var xIndex = 0; xIndex < 7; xIndex++)
            {
                for (var yIndex = 0; yIndex < 39; yIndex++)
                {
                    if (coordenadasLegado[xIndex, yIndex] == RetornarValor(TipoQuadrado.NUVEM)) // usa o legado das coordenadas para determinar quais blocos são nuvens, já que as coordenadas vão ser atualizadas com novas nuvens
                    {
                        if (xIndex != 0 && Coordenadas[xIndex - 1, yIndex] != RetornarValor(TipoQuadrado.NUVEM))   // evita os limites da array e checa se os blocos adjacentes estão vazios
                        {
                            Coordenadas[xIndex - 1, yIndex] = RetornarValor(TipoQuadrado.NUVEM);
                        }
                        else if (xIndex != 7 && Coordenadas[xIndex + 1, yIndex] != RetornarValor(TipoQuadrado.NUVEM))
                        {
                            Coordenadas[xIndex + 1, yIndex] = RetornarValor(TipoQuadrado.NUVEM);
                        }
                        else if (yIndex != 0 && Coordenadas[xIndex, yIndex - 1] != RetornarValor(TipoQuadrado.NUVEM))
                        {
                            Coordenadas[xIndex, yIndex - 1] = RetornarValor(TipoQuadrado.NUVEM);
                        }
                        else if (yIndex != 39 && Coordenadas[xIndex, yIndex + 1] != RetornarValor(TipoQuadrado.NUVEM))
                        {
                            Coordenadas[xIndex, yIndex + 1] = RetornarValor(TipoQuadrado.NUVEM);
                        }
                    }
                }
            }
        }

        public void DesenharCoordenadas()
        {
            diasTotais++;

            Console.WriteLine($"============== DIA {diasTotais} ==================");

            for (var xIndex = 0; xIndex < 7; xIndex++)
            {
                string output = "";
                for (var yIndex = 0; yIndex < 39; yIndex++)
                {
                    output += Coordenadas[xIndex, yIndex];

                }
                Console.WriteLine(output);
            }

            Console.WriteLine($"=======================================");
            Console.WriteLine($"");
        }
    }
}
using System;
using System.Runtime.InteropServices;
using NuvemDeCinzas.Models;

namespace NuvemDeCinzas.Libraries {
    public class ControladorQuadrados : Setup {
        protected void IniciarCoordenadas () // Faz com que a primeira nuvem seja criada na borda da matriz de forma aleatoria
        {
            Coordenadas = new char[xLength, yLength];

            Random random = new Random (Guid.NewGuid ().GetHashCode ());
            x = random.Next (0, xLength); // Entregar valor random para a posicao horizontal da array

            if (x == 0 || x == xLength - 1) // Verifica se x marca os cantos da array bidimensional
            {
                y = random.Next (0, yLength); // Se true, é designado qualquer y dentre as colunas inferiores e superiores 
            } else // Se false, faz o y ser o extremo superior ou o extremo inferior da array 
            {
                var sorteador = random.Next (0, 2);
                switch (sorteador) {
                    case 0:
                        y = 0;
                        break;
                    case 1:
                        y = yLength - 1;
                        break;
                }
            }
        }

        protected void PreencherVazios () {
            for (var xIndex = 0; xIndex < xLength; xIndex++) {
                for (var yIndex = 0; yIndex < yLength; yIndex++) {
                    Coordenadas[xIndex, yIndex] = RetornarValor (TipoQuadrado.VAZIO);
                }
            }
        }

        protected void PreencherNuvens () {
            var contadorNuvens = 0;
            while (contadorNuvens < maximoNuvensIniciais) // Se repete até que todas as 10 nuvens sejam colocadas
            {
                Coordenadas[x, y] = RetornarValor (TipoQuadrado.NUVEM); // Insere a nuvem na coordenada
                if (MoverNuvem (x, y))
                    contadorNuvens++;
            }
        }

        private bool MoverNuvem (int x, int y) {
            Random random = new Random (Guid.NewGuid ().GetHashCode ());
            switch (random.Next (1, 5)) { // Decide pra qual direcao a nuvem vai
                case 1:
                    if (PodeMover (x, y - 1)) {
                        MoverPraCima ();
                        return true;
                    }
                    break;
                case 2:
                    if (PodeMover (x, y + 1)) {
                        MoverPraBaixo ();
                        return true;
                    }
                    break;
                case 3:
                    if (PodeMover (x - 1, y)) {
                        MoverPraEsquerda ();
                        return true;
                    }
                    break;
                case 4:
                    if (PodeMover (x + 1, y)) {
                        MoverPraDireita ();
                        return true;
                    }
                    break;
            }
            return false;
        }

        /// Qualifica a movimentação impedindo com que nuvens sejam colocadas além dos limites da array
        // Poderia ter sido feito com switch, no modelo PodeMover(int x, int y, string direcao)
        // mas achei que deixaria mais complicado do que ajudaria na legibilidade
        private bool PodeMover (int x, int y) {
            if (x != 0 && x != (xLength - 1) && y != 0 && y != (yLength - 1)) {
                if (Coordenadas[x, y] == RetornarValor (TipoQuadrado.VAZIO)) {
                    return true;
                }
            }
            return false;
        }

        protected void PreencherAeroportos () {
            Random random = new Random (Guid.NewGuid ().GetHashCode ());
            var contadorAeroportos = 0;

            while (true) {
                for (var xIndex = 0; xIndex < xLength; xIndex++) {
                    for (var yIndex = 0; yIndex < yLength; yIndex++) {
                        if ((Coordenadas[xIndex, yIndex] == RetornarValor (TipoQuadrado.VAZIO)) && ((random.Next (0, 101)) <= chanceAeroportoAparecer)) // Define a chance de um vazio ser preenchido por um aeroporto
                        {
                            Coordenadas[xIndex, yIndex] = RetornarValor (TipoQuadrado.AEROPORTO);
                            contadorAeroportos++;
                        }
                    }
                    if (contadorAeroportos >= indiceAeroportos) // Mantem a quantidade de aeroportos perto do indice
                    {
                        break;
                    }
                }
                break;
            }
        }

        protected void AvancarDia () {
            var coordenadasLegado = CriarLegadoCoordenadas ();
            for (var yIndex = 0; yIndex < yLength; yIndex++) {
                for (var xIndex = 0; xIndex < xLength; xIndex++) {
                    if (coordenadasLegado[xIndex, yIndex] == RetornarValor (TipoQuadrado.NUVEM)) {
                        PreencherVizinhosComNuvens (xIndex, yIndex);
                    }
                }
            }
        }

        //// Cria um legado das posicões preenchidas
        // Evita com que uma nova nuvem seja contabilizada durante a iteração
        private char[, ] CriarLegadoCoordenadas () {
            var coordenadasLegado = new char[xLength, yLength];
            for (var yIndex = 0; yIndex < yLength; yIndex++) {
                for (var xIndex = 0; xIndex < xLength; xIndex++) {
                    coordenadasLegado[xIndex, yIndex] = Coordenadas[xIndex, yIndex];
                }
            }
            return coordenadasLegado;
        }

        private void PreencherVizinhosComNuvens (int xIndex, int yIndex) {
            if (xIndex != 0) // Evita os limites da array e checa se os blocos adjacentes estão vazios
                Coordenadas[xIndex - 1, yIndex] = RetornarValor (TipoQuadrado.NUVEM);

            if (xIndex != xLength - 1)
                Coordenadas[xIndex + 1, yIndex] = RetornarValor (TipoQuadrado.NUVEM);

            if (yIndex != 0)
                Coordenadas[xIndex, yIndex - 1] = RetornarValor (TipoQuadrado.NUVEM);

            if (yIndex != yLength - 1)
                Coordenadas[xIndex, yIndex + 1] = RetornarValor (TipoQuadrado.NUVEM);;
        }

        protected void DesenharCoordenadas () {
            Console.WriteLine ($"======= DIA {diasTotais} ======");
            for (var yIndex = 0; yIndex < yLength; yIndex++) {
                string output = "";
                for (var xIndex = 0; xIndex < xLength; xIndex++) {
                    output += Coordenadas[xIndex, yIndex];
                }
                Console.WriteLine (output);
            }
            Console.WriteLine ("=====================");
        }

        protected char RetornarValor (TipoQuadrado Tipo) {
            return Tipo.valorCoordenada;
        }

        private void MoverPraEsquerda () {
            x -= 1;
        }

        private void MoverPraDireita () {
            x += 1;
        }

        private void MoverPraCima () {
            y -= 1;
        }

        private void MoverPraBaixo () {
            y += 1;
        }
    }
}
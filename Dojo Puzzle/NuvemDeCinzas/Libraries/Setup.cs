using System;
using NuvemDeCinzas.Models;

namespace NuvemDeCinzas.Libraries {
    public class Setup {

        // configuracoes
        protected int xLength => 20;
        protected int yLength => 5;
        protected int chanceAeroportoAparecer => 5; // em porcentagem e em inteiros
        protected int maximoNuvensIniciais => 6;
        protected int indiceAeroportos => Convert.ToInt32 (Math.Ceiling (Convert.ToDouble (xLength) / Convert.ToDouble ((yLength/ 2))));

        // variaveis uteis
        protected int qtdInicialAeroportos { get; set; }
        protected int qtdDiasPrimeiroAeroporto { get; set; }
        protected int diasTotais { get; set; }
        protected char[, ] Coordenadas;
        protected int x { get; set; }
        protected int y { get; set; }
    }
}
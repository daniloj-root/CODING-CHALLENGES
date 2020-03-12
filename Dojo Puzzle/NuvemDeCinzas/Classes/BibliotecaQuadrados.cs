namespace NuvemDeCinzas.Classes
{
    public class BibliotecaQuadrados
    {
        protected int x { get; set; }
        protected int y { get; set; }

        protected int diasTotais { get; set; }

        protected int qtdInicialAeroportos { get; set; }

        protected int diasPrimAeroporto { get; set; }
        protected int diasTodosAeroportos { get; set; }

        protected char[,] Coordenadas { get; set; }

        protected void MoverPraEsquerda()
        {
            this.x -= 1;
        }

        protected void MoverPraDireita()
        {
            this.x += 1;
        }

        protected void MoverPraCima()
        {
            this.y -= 1;
        }

        protected void MoverPraBaixo()
        {
            this.y += 1;
        }

        protected char RetornarValor(TipoQuadrado Tipo)
        {
            return Tipo.valorCoordenada;
        }
    }
}
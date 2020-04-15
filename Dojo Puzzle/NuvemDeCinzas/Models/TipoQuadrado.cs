namespace NuvemDeCinzas.Models
{
    public class TipoQuadrado
    {
        public static TipoQuadrado NUVEM { get { return new TipoQuadrado('*'); } }

        public static TipoQuadrado AEROPORTO { get { return new TipoQuadrado('A'); } }

        public static TipoQuadrado VAZIO { get { return new TipoQuadrado('.'); } }

        public TipoQuadrado(char valorCoordenada)
        {
            this.valorCoordenada = valorCoordenada;
        }

        public char valorCoordenada { get; set; }
    }
}
namespace EleicaoTesteUnitario
{
    public class Candidato
    {
        public string? Nome { get; set; }
        public int Votos { get; set; }

        public Candidato(string nome)
        {
            Nome = nome;
        }

        public Candidato()
        {

        }

        public void AdicionarVoto()
        {
            Votos++;
        }

        public int RetornarVotos()
        {
            return Votos;
        }

    }
}
using Xunit;
using EleicaoTesteUnitario;

namespace EleicaoTesteUnitario.Teste
{
    public class CandidatoTeste
    {
        private readonly Candidato candidato = new Candidato();

        //Unidade(método)_contexto(oque o teste faz)_Resultadoesperado

        [Fact]
        public void Candidato_VerificaVotoAoCadastrar_Zero()
        {
            //Arrange
            int resultadoEsperado = 0;

            //Act
            var votosAoCadastrar = candidato.Votos;
            Console.WriteLine(votosAoCadastrar);

            //Assert
            Assert.Equal(resultadoEsperado, votosAoCadastrar);
        }

        [Fact]
        public void AdicionarVoto_ValidaInsercaoVoto_True()
        {
            int resultadoEsperado = 1;
            candidato.AdicionarVoto();

            Assert.Equal(resultadoEsperado, candidato.Votos);
        }

        [Fact]
        public void Candidato_ValidaNomeInserido_nome()
        {
            var testeNomeCanditato = "Isa";
            var canditatoTeste = new Candidato(testeNomeCanditato);
            var nomeCanditato = canditatoTeste.Nome;
            Assert.Equal(testeNomeCanditato, nomeCanditato);
        }
    }

}
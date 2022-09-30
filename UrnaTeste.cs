using Xunit;
using FluentAssertions;
using EleicaoTesteUnitario;

namespace EleicaoTesteUnitario.Teste
{
    public class UrnaTeste
    {
        private readonly Urna urna = new Urna();

        [Fact]
        public void Construtor_ValidaInformacoesConstrutor_True()
        {
            urna.VencedorEleicao = "";
            urna.VotosVencedor = 0;
            urna.Candidatos = new List<Candidato>();
            urna.EleicaoAtiva = false;

            var testeUrna = new Urna();

            urna.Should()
                .BeEquivalentTo(testeUrna);
        }

        [Fact]
        public void IniciarEncerrarEleicao_IniciaEleicao_True()
        {
            urna.IniciarEncerrarEleicao();
            Assert.True(urna.EleicaoAtiva);
        }

        [Fact]
        public void IniciarEncerrarEleicao_EncerraEleicao_True()
        {
            urna.IniciarEncerrarEleicao();
            urna.IniciarEncerrarEleicao();
            Assert.False(urna.EleicaoAtiva);
        }

        [Fact]
        public void CadastrarCandidato_ValidarListaDeCadastro_True()
        {
            urna.CadastrarCandidato("Lucas");
            urna.CadastrarCandidato("Isabella");

            var ultimoCandidato = urna.Candidatos.Select(c => c.Nome).Last();

            Assert.Equal("Isabella", ultimoCandidato);
        }

        [Fact]
        public void Votar_ValidaCandidatoNaoCadastrado_False()
        {
            urna.CadastrarCandidato("Lucas");
            urna.CadastrarCandidato("Isabella");

            Assert.False(urna.Votar("Gabi"));
        }

        [Fact]
        public void Votar_ValidaCandidatoCadastrado_True()
        {
            urna.CadastrarCandidato("Lucas");
            urna.CadastrarCandidato("Isabella");

            Assert.True(urna.Votar("Lucas"));
        }

        [Fact]
        public void MostrarResultadoEleicao_ValidaResultadoVotacao_True()
        {
            urna.CadastrarCandidato("Lucas");
            urna.CadastrarCandidato("Isabella");

            urna.Votar("Lucas");
            urna.Votar("Lucas");
            urna.Votar("Lucas");
            urna.Votar("Isabella");
            urna.Votar("Isabella");

            Assert.Equal("Nome vencedor: Lucas. Votos: 3", urna.MostrarResultadoEleicao());
        }

        [Fact]
        public void MostrarResultadoEleicao_ValidaEmpateVotacao_True()
        {
            urna.CadastrarCandidato("Lucas");
            urna.CadastrarCandidato("Isabella");

            urna.Votar("Lucas");
            urna.Votar("Lucas");
            urna.Votar("Isabella");
            urna.Votar("Isabella");

            Assert.Equal("Nome vencedor: Isabella. Votos: 2", urna.MostrarResultadoEleicao());
        }
    }
}
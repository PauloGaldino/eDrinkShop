namespace Domain.Entities.Pessoas.Profissoes
{
    public class ProfissaoCliente
    {
        public int Id { get; set; }

        //Chave estrangeira

        public int ClienteId { get; set; }
        public int ProfissaoId { get; set; }

        //propriedade de navegaçção
        public Cliente Cliente { get; set; }
        public Profissao Profissao { get; set; }
    }
}

namespace APPLICATION.CORE.Entities
{
    
    public class CatalogoItem : BaseEntity
    {
        public string Nome { get; set; }
        public string DescricaoCurta { get; set; }
        public string DescricaoLonga { get; set; }
        public decimal Preco { get; set; }
        public string FotoUri { get; set; }
        public int CatalogoTipoId { get; set; }
        public CatalogoTipo CatalogoTipo { get; set; }
        public int CatalogoMarcaId { get; set; }
        public CatalogoMarca CatalogoMarca { get; set; }
    }
}

namespace APPLICATION.CORE.Entities
{
    /// <summary>
    ///Isso pode ser facilmente modificado para ser BaseEntity <T> e publico T Id para suportar diferentes tipos de chaves.
    // Usando tipos inteiros não genéricos para simplificar e facilitar a lógica de armazenamento em cache
    /// </summary>
    public class BaseEntity
    {
        public int Id { get; set; }
    }
}

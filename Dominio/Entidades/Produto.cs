namespace Dominio.Entidades
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        //virtual pode ser carregado de forma lenta, preguiçosa conceito do LazyLoadingProxies
        public virtual Categoria Categoria { get; set; }
        public int CategoriaId { get; set; }       
        public bool Ativo { get; set; }
    }
}
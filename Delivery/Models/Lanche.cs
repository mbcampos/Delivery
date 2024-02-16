using System.ComponentModel;

namespace LanchesMac.Models
{
    public class Lanche
    {
        public int LancheId { get; set; }
        [DisplayName("Lanche")]
        public string Nome { get; set; }
        [DisplayName("Descrição Curtas")]
        public string DescricaoCurta { get; set; }
        public string DescricaoDetalhada { get; set; }
        [DisplayName("Preço")]
        public decimal Preco { get; set; }
        public string ImagemUrl { get; set; }
        public string ImagemThumbnailUrl { get; set; }
        public bool IsLanchePreferido { get; set; }
        public bool EmEstoque { get; set; }

        public int CategoriaId { get; set; }
        public virtual Categoria? Categoria { get; set; }
    }
}

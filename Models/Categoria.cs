using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

public partial class Categoria
{
        public Categoria()
        {
           this.Articles = new HashSet<Articolo>();     
        }

        [Key]
        public int CategoriaID{ get; set; }
        
        public string Descrizione { get; set; }

        public ICollection<Articolo> Articles {get; set;}
                
        public override string ToString() => $"{CategoriaID}\t{Descrizione}";
}

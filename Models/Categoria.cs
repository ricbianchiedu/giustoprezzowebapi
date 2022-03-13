using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

public class Categoria
{
        [Key]
        public int CategoriaID{ get; set; }
        
        public string Descrizione { get; set; }

        public ICollection<Articolo> Articles {get; set;}
                
        public override string ToString() => $"{CategoriaID}\t{Descrizione}";
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

public class Categoria
{
        [Key]
        public int CategoriaID{ get; set; }
        
        public string DescrizioneCat { get; set; }

        public ICollection<Articolo> Articles {get; set;}
        
}

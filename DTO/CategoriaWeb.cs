using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

public class CategoriaWeb
{
        public int CategoriaID{ get; set; }
        public string Descrizione { get; set; }
         
        public override string ToString() => $"{CategoriaID}\t{Descrizione}";
}

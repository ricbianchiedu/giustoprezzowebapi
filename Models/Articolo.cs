using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

public class Articolo
{
        [Key]
        public int ArticoloID{ get; set; }

        public string Descrizione { get; set; }
        public float GiustoPrezzo { get; set; }
        public float PrezzoUno { get; set; }
        public float PrezzoDue { get; set; }
        
        [DefaultValue("https://www.viridea.it/wp-content/uploads/2019/09/Marzo-quale-fiori-regalare-alle-donne-1.jpg")]
        public string UrlImmagine {get; set;}
        public DateTime DataAggiornamento {get; set;}
        public int Count {get; set;} = 0;

        [ForeignKey("CategoriaID")]
        public int? CategoriaID { get; set; }
        public Categoria Categoria { get; set; }

        public override string ToString()
        => $"{ArticoloID}\t{Descrizione} {CategoriaID} {GiustoPrezzo} {PrezzoUno} {PrezzoDue} {DataAggiornamento} {Count}";
}

public class ArticoloWeb
{
        //public int ArticoloID{ get; set; }
        public string Descrizione { get; set; }
        public float GiustoPrezzo { get; set; }
        public float PrezzoUno { get; set; }
        public float PrezzoDue { get; set; }
        public string UrlImmagine {get; set;}
        //public DateTime DataAggiornamento {get; set;}
        //public int Count {get; set;} = 0;
        //public int? CategoriaID { get; set; }
      
        public override string ToString()
        => $"{Descrizione} {GiustoPrezzo} {PrezzoUno} {PrezzoDue}";
}

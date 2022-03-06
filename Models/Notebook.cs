// public class Articolo
// {
//   public int CourseID { get; set; }
//   public string Title { get; set; }
//   public int Credits { get; set; }
//   public int CategoriaID { get; set; }
//   public virtual Categoria Categoria { get; set; }
// }

// public class Categoria
// {
//    public Categoria()
//    {
//      this.Articoli = new HashSet<Articolo>();
//    }  
//    public int ArticoloID { get; set; }
//    public string Name { get; set; }
//    public decimal Budget { get; set; }
//    public DateTime StartDate { get; set; }
//    public int? Administrator {get ; set; }
//    public virtual ICollection<Articolo> Articoli { get; set; }
// }
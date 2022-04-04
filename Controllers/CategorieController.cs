using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GiustoPrezzo.Controllers
{
    //Gestisce il path di accesso al controller
    //[Route("api/[controller]")]
    [Route("/[controller]")]
    [ApiController]
    public class CategorieController : ControllerBase
    {
        private readonly DbArticoli _context;

        public CategorieController(DbArticoli context)
        {
            _context = context;
        }

        // GET: api/GiocoUno
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoriaWeb>>> GetCategorie()
        {
            //Articoli è un oggetto DBSet definito nella classe DbArticoli.cs
            //Metodi della classe DBSet
            //https://docs.microsoft.com/en-us/dotnet/api/microsoft.entityframeworkcore.dbset-1?view=efcore-6.0
            var cat = await _context.Categorie.ToListAsync();
            return ConvertiCategoria(cat);
        }

        List<CategoriaWeb> ConvertiCategoria(List<Categoria> lista)
        {
            //Eliminazione delle properties di navigabilità
            List<CategoriaWeb> query = new List<CategoriaWeb>();

            foreach (var x in lista)
            {
                CategoriaWeb c = new CategoriaWeb();
                
                c.CategoriaWebID = x.CategoriaID;
                c.Descrizione = x.DescrizioneCat;
                               
                query.Add(c);
            }

            return query;
        }

    }
}

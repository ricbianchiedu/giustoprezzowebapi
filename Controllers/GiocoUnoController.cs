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
    [Route("/")]
    [ApiController]
    public class GiocoUnoController : ControllerBase
    {
        private readonly DbArticoli _context;

        public GiocoUnoController(DbArticoli context)
        {
            _context = context;
        }

        // // GET: api/GiocoUno
        // [HttpGet]
        // public async Task<ActionResult<IEnumerable<Articolo>>> GetArticoli()
        // {
        //     //Articoli è un oggetto DBSet definito nella classe DbArticoli.cs
        //     //Metodi della classe DBSet
        //     //https://docs.microsoft.com/en-us/dotnet/api/microsoft.entityframeworkcore.dbset-1?view=efcore-6.0
        //     return await _context.Articoli.ToListAsync();
        // }

        // GET: api/GiocoUno/5
        [HttpGet("{numrecord}")]
        public async Task<ActionResult<List<ArticoloWeb>>>GetArticoli(int numrecord)
        {
            /*
            * Restituisce un numero di articoli pari al parametro ricevuto.
            * Valore ammesso per il parametro 1 -> 5
            * Incrementa di uno il valore dell'attributo Count degli articoli trasmessi.
            */
            
            if (numrecord <= 0 || numrecord > 5)
            {
                /*
                * https://docs.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.mvc.controllerbase.notfound?view=aspnetcore-6.0
                * Metodo di ControllerBase
                * Creates an NotFoundObjectResult that produces a Status404NotFound response.
                */
                return BadRequest();
            }

            var elementi = await _context.Articoli.OrderBy( r => r.Count ).Take(numrecord).ToListAsync();
            foreach (var item in elementi)
            {
                item.Count++;
            }
            await _context.SaveChangesAsync();

            return ConvertiArticolo(elementi);
        }

        List<ArticoloWeb> ConvertiArticolo(List<Articolo> lista)
        {
            //Eliminazione delle properties di navigabilità
            List<ArticoloWeb> query = new List<ArticoloWeb>();

            foreach (var x in lista)
            {
                ArticoloWeb a = new ArticoloWeb();
                
                a.Descrizione = x.Descrizione;
                a.GiustoPrezzo = x.GiustoPrezzo;
                a.PrezzoDue = x.PrezzoDue;
                a.PrezzoUno = x.PrezzoUno;
                a.UrlImmagine = x.UrlImmagine; 

                query.Add(a);
            }

            return query;
        }

        // GET: api/GiocoUno/5
        [HttpGet("{numrecord}/{catRequested}")]
        public async Task<ActionResult<IEnumerable<ArticoloWeb>>>GetArticoli(int numrecord, int catRequested)
        {
            /*
            * Restituisce un numero di articoli pari al parametro ricevuto.
            * Valore ammesso per il parametro 1 -> 5
            * Incrementa di uno il valore dell'attributo Count degli articoli trasmessi.
            */
            
            if (numrecord <= 0 || numrecord > 5)
            {
                /*
                * https://docs.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.mvc.controllerbase.notfound?view=aspnetcore-6.0
                * Metodo di ControllerBase
                * Creates an NotFoundObjectResult that produces a Status404NotFound response.
                */
                return BadRequest();
            }

            var elementi = await _context.Articoli.OrderBy( r => r.Count ).Where( c => c.CategoriaID == catRequested).Take(numrecord).ToListAsync();
            foreach (var item in elementi)
            {
                item.Count++;
            }
            await _context.SaveChangesAsync();
            
            return ConvertiArticolo(elementi);
        }


        // Metodo Get creato dal genereratore di codice
        // // GET: api/GiocoUno/5
        // [HttpGet("{id}")]
        // public async Task<ActionResult<Articolo>> GetArticolo(int id)
        // {
        //     /*
        //     * Finds an entity with the given primary key values. 
        //     * If an entity with the given primary key values is being tracked by the 
        //     * context, then it is returned immediately without making a request to 
        //     * the database. Otherwise, a query is made to the database for an entity 
        //     * with the given primary key values and this entity, if found, is attached 
        //     * to the context and returned. If no entity is found, then null is returned.
        //     */
        //     var articolo = await _context.Articoli.FindAsync(id);

        //     if (articolo == null)
        //     {
        //         /*
        //         * https://docs.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.mvc.controllerbase.notfound?view=aspnetcore-6.0
        //         * Metodo di ControllerBase
        //         * Creates an NotFoundObjectResult that produces a Status404NotFound response.
        //         */
        //         return NotFound();
        //     }

        //     return articolo;
        // }

        // PUT: api/GiocoUno/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        // La PUT è usata SOLO PER MODIFICHE di un record esistente
        // [HttpPut("{id}")]
        // public async Task<IActionResult> PutArticolo(int id, Articolo articolo)
        // {
        //     // Effettua un piccolo controllo formale perché ArticoloID è una PK e, come
        //     // tale, non può essere modificata da una PUT.
        //     if (id != articolo.ArticoloID)
        //     {
        //         /*
        //         * https://docs.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.mvc.controllerbase.badrequest?view=aspnetcore-6.0
        //         * Metodo di ControllerBase
        //         * Creates an BadRequestResult that produces a Status400BadRequest response.
        //         */
        //         return BadRequest();
        //     }

        //     /*
        //     * https://docs.microsoft.com/en-us/dotnet/api/microsoft.entityframeworkcore.dbcontext.entry?view=efcore-6.0#microsoft-entityframeworkcore-dbcontext-entry(system-object)
        //     * Gets an EntityEntry for the given entity. The entry provides access 
        //     * to change tracking information and operations for the entity.
        //     * This method may be called on an entity that is not tracked. 
        //     * You can then set the State property on the returned entry to have 
        //     * the context begin tracking the entity in the specified state.
        //     *
        //     * https://docs.microsoft.com/en-us/dotnet/api/microsoft.entityframeworkcore.entitystate?view=efcore-6.0#microsoft-entityframeworkcore-entitystate-modified
        //     * The entity is being tracked by the context and exists in the database. 
        //     * Some or all of its property values have been modified.
        //     *
        //     * Il DataSet non è ancora in memoria, di conseguenza non è possibile sapere
        //     * se il record di cui si chiede la modifica è o meno esistente. Per cui 
        //     * è necessario che l'oggetto JSON passato tramite PUT sia convertito in un
        //     * oggetto C# e venga marcato come modificato per consentire a EF di 
        //     * tracciarlo e scriverlo sul DB durante il SaveChanges.
        //     */
        //     _context.Entry(articolo).State = EntityState.Modified;

        //     try
        //     {
        //         await _context.SaveChangesAsync();
        //     }
        //     catch (DbUpdateConcurrencyException)
        //     {
        //         if (!ArticoloExists(id))
        //         {
        //             return NotFound();
        //         }
        //         else
        //         {
        //             throw;
        //         }
        //     }

        //     /*
        //     * https://docs.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.mvc.controllerbase.nocontent?view=aspnetcore-6.0
        //     * The created NoContentResult object for the response.
        //     */
        //     return NoContent();
        // }

        // // POST: api/GiocoUno
        // // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        // [HttpPost]
        // public async Task<ActionResult<Articolo>> PostArticolo(Articolo articolo)
        // {
        //     _context.Articoli.Add(articolo);
        //     await _context.SaveChangesAsync();

        //     /*
        //     * https://docs.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.mvc.controllerbase.createdataction?view=aspnetcore-6.0
        //     * Creates a CreatedAtActionResult object that produces a Status201Created 
        //     * response.
        //     * CreatedAtAction(String, Object, Object)
        //     */
        //     return CreatedAtAction("GetArticolo", new { id = articolo.ArticoloID }, articolo);
        // }

        // // DELETE: api/GiocoUno/5
        // [HttpDelete("{id}")]
        // public async Task<IActionResult> DeleteArticolo(int id)
        // {
        //     var articolo = await _context.Articoli.FindAsync(id);
        //     if (articolo == null)
        //     {
        //         return NotFound();
        //     }

        //     /*
        //     * https://docs.microsoft.com/en-us/dotnet/api/microsoft.entityframeworkcore.dbcontext.remove?view=efcore-6.0#microsoft-entityframeworkcore-dbcontext-remove(system-object)
        //     * Begins tracking the given entity in the Deleted state such that it will 
        //     * be removed from the database when SaveChanges() is called.
        //     */
        //     _context.Articoli.Remove(articolo);
        //     await _context.SaveChangesAsync();

        //     return NoContent();
        // }

        // private bool ArticoloExists(int id)
        // {
        //     return _context.Articoli.Any(e => e.ArticoloID == id);
        // }
    }
}

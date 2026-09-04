
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Veterinaria_Arca_de_Noe.Models;
using Veterinaria_Arca_de_Noe.Datos;

public class PropietariosController : Controller
{
    private readonly ConexionBaseDatos _context;

    public PropietariosController(ConexionBaseDatos context)
    {
        _context = context;
    }

    // GET: PROPIETARIOS
    public async Task<IActionResult> Index()    
    {
        return View(await _context.Propietarios.ToListAsync());
    }

    // GET: PROPIETARIOS/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var propietario = await _context.Propietarios
            .FirstOrDefaultAsync(m => m.Id == id);
        if (propietario == null)
        {
            return NotFound();
        }

        return View(propietario);
    }

    // GET: PROPIETARIOS/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: PROPIETARIOS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,Nombre,Apellidos,Telefono,Email,Estado,Mascotas")] Propietario propietario)
    {
        if (ModelState.IsValid)
        {
            _context.Add(propietario);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(propietario);
    }

    // GET: PROPIETARIOS/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var propietario = await _context.Propietarios.FindAsync(id);
        if (propietario == null)
        {
            return NotFound();
        }
        return View(propietario);
    }

    // POST: PROPIETARIOS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? id, [Bind("Id,Nombre,Apellidos,Telefono,Email,Estado,Mascotas")] Propietario propietario)
    {
        if (id != propietario.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(propietario);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PropietarioExists(propietario.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
        }
        return View(propietario);
    }

    // GET: PROPIETARIOS/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var propietario = await _context.Propietarios
            .FirstOrDefaultAsync(m => m.Id == id);
        if (propietario == null)
        {
            return NotFound();
        }

        return View(propietario);
    }

    // POST: PROPIETARIOS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? id)
    {
        var propietario = await _context.Propietarios.FindAsync(id);
        if (propietario != null)
        {
            _context.Propietarios.Remove(propietario);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool PropietarioExists(int? id)
    {
        return _context.Propietarios.Any(e => e.Id == id);
    }
}


using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Veterinaria_Arca_de_Noe.Models;
using Veterinaria_Arca_de_Noe.Datos;

public class VeterinariosController : Controller
{
    private readonly ConexionBaseDatos _context;

    public VeterinariosController(ConexionBaseDatos context)
    {
        _context = context;
    }

    // GET: VETERINARIOS
    public async Task<IActionResult> Index()    
    {
        return View(await _context.Veterinarios.ToListAsync());
    }

    // GET: VETERINARIOS/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var veterinario = await _context.Veterinarios
            .FirstOrDefaultAsync(m => m.Id == id);
        if (veterinario == null)
        {
            return NotFound();
        }

        return View(veterinario);
    }

    // GET: VETERINARIOS/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: VETERINARIOS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,Nombre,Apellidos,Especialidad,Telefono,Estado,Citas")] Veterinario veterinario)
    {
        if (ModelState.IsValid)
        {
            _context.Add(veterinario);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(veterinario);
    }

    // GET: VETERINARIOS/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var veterinario = await _context.Veterinarios.FindAsync(id);
        if (veterinario == null)
        {
            return NotFound();
        }
        return View(veterinario);
    }

    // POST: VETERINARIOS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? id, [Bind("Id,Nombre,Apellidos,Especialidad,Telefono,Estado,Citas")] Veterinario veterinario)
    {
        if (id != veterinario.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(veterinario);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VeterinarioExists(veterinario.Id))
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
        return View(veterinario);
    }

    // GET: VETERINARIOS/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var veterinario = await _context.Veterinarios
            .FirstOrDefaultAsync(m => m.Id == id);
        if (veterinario == null)
        {
            return NotFound();
        }

        return View(veterinario);
    }

    // POST: VETERINARIOS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? id)
    {
        var veterinario = await _context.Veterinarios.FindAsync(id);
        if (veterinario != null)
        {
            _context.Veterinarios.Remove(veterinario);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool VeterinarioExists(int? id)
    {
        return _context.Veterinarios.Any(e => e.Id == id);
    }
}

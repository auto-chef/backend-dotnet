using AutoChef.Data;
using AutoChef.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AutoChef.Controllers;
public class RestaurantController : Controller
{
    private readonly ApplicationDbContext _context;

    public RestaurantController(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        return View(_context.Restaurant.ToList());
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(RestaurantModel restaurant)
    {
        if (ModelState.IsValid)
        {
            restaurant.CNPJ = restaurant.CNPJ.Replace(".", "").Replace("/", "").Replace("-", "");

            _context.Restaurant.Add(restaurant);

            _context.SaveChanges();

            return RedirectToAction("Index");
        }
        return View(restaurant);
    }

    public IActionResult Edit(int id)
    {
        var restaurant = _context.Restaurant.Find(id);

        if (restaurant == null)
        {
            return NotFound();
        }
        return View(restaurant);
    }
    [HttpPost]

    public IActionResult Edit(RestaurantModel restaurant)
    {
        if (ModelState.IsValid)
        {
            restaurant.CNPJ = restaurant.CNPJ.Replace(".", "").Replace("/", "").Replace("-", "");

            _context.Entry(restaurant).State = EntityState.Modified;

            _context.SaveChanges();

            return RedirectToAction("Index");
        }
        return View(restaurant);
    }
    public IActionResult Delete(int ID)
    {
        var restaurant = _context.Restaurant.Find(ID);

        if (restaurant == null)
        {
            return NotFound();
        }

        return View(restaurant);
    }

    [HttpPost, ActionName("Delete")]
    public IActionResult DeleteConfirmed(int ID)
    {
        var restaurant = _context.Restaurant.Find(ID);

        if (restaurant == null)
        {
            return NotFound();
        }

        _context.Restaurant.Remove(restaurant);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }
}

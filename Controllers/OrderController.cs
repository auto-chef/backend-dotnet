using AutoChef.Data;
using AutoChef.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AutoChef.Controllers;
public class OrderController : Controller
{
    private readonly ApplicationDbContext _context;

    public OrderController(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        return View(_context.Order.ToList());
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(OrderModel order)
    {
        if (ModelState.IsValid)
        {
            _context.Order.Add(order);

            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        return View(order);
    }

    public IActionResult Edit(int ID)
    {
        var order = _context.Order.Find(ID);

        if (order == null)
        {
            return NotFound();
        }
        return View(order);
    }
    [HttpPost]

    public IActionResult Edit(OrderModel order)
    {
        if (ModelState.IsValid)
        {
            _context.Entry(order).State = EntityState.Modified;

            _context.SaveChanges();

            return RedirectToAction("Index");
        }
        return View(order);
    }
    public IActionResult Delete(int ID)
    {
        var order = _context.Order.Find(ID);

        if (order == null)
        {
            return NotFound();
        }

        return View(order);
    }

    [HttpPost, ActionName("Delete")]
    public IActionResult DeleteConfirmed(int ID)
    {
        var order = _context.Order.Find(ID);

        if (order == null)
        {
            return NotFound();
        }

        _context.Order.Remove(order);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }
}

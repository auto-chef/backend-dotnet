using AutoChef.Data;
using AutoChef.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AutoChef.Controllers;
public class UserController : Controller
{

    private readonly ApplicationDbContext _context;

    public UserController(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        return View(_context.User.ToList());
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(UserModel user)
    {
        if (ModelState.IsValid)
        {
            user.CPF = user.CPF.Replace(".", "").Replace("-", "");

            _context.User.Add(user);

            _context.SaveChanges();

            return RedirectToAction("Index");
        }
        return View(user);
    }

    public IActionResult Edit(int id) 
    {
        var user = _context.User.Find(id);

        if (user == null)
        {
            return NotFound();
        }
        return View(user);
    }
    [HttpPost]

    public IActionResult Edit(UserModel user)
    {
        if (ModelState.IsValid)
        {
            user.CPF = user.CPF.Replace(".", "").Replace("-", "");

            _context.Entry(user).State = EntityState.Modified;

            _context.SaveChanges();

            return RedirectToAction("Index");
        }
        // print errors on console
        foreach (var modelState in ViewData.ModelState.Values)
        {
            foreach (var error in modelState.Errors)
            {
                System.Diagnostics.Debug.WriteLine("ERRO: " + error.ErrorMessage);
            }
        }
        return View(user);
    }
    public IActionResult Delete(int ID)
    {
        var user = _context.User.Find(ID);

        if (user == null)
        {
            return NotFound();
        }

        return View(user);
    }

    [HttpPost, ActionName("Delete")]
    public IActionResult DeleteConfirmed(int ID)
    {
        var user = _context.User.Find(ID);

        if (user == null)
        {
            return NotFound();
        }

        _context.User.Remove(user);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }

}

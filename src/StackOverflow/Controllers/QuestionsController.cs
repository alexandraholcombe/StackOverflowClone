using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StackOverflow.Models;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace StackOverflow.Controllers
{
    public class QuestionsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public IActionResult Index()
        {
            return View(db.Questions.ToList());
        }

        public IActionResult Details(int id)
        {
            var thisQuestion = db.Questions.FirstOrDefault(questions => questions.Id == id);
            return View(thisQuestion);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Question question)
        {
            db.Questions.Add(question);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var thisQuestion = db.Questions.FirstOrDefault(questions => questions.Id == id);
            return View(thisQuestion);
        }

        [HttpPost]
        public IActionResult Edit(Question question)
        {
            db.Entry(question).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var thisQuestion = db.Questions.FirstOrDefault(questions => questions.Id == id);
            return View(thisQuestion);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var thisQuestion = db.Questions.FirstOrDefault(questions => questions.Id == id);
            db.Questions.Remove(thisQuestion);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StackOverflow.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace StackOverflow.Controllers
{
    [Authorize]
    public class QuestionsController : Controller
    {
        //private readonly MyApplicationDbContext _db;

        //public QuestionsController(MyApplicationDbContext db)
        //{
        //    _db = db;
        //}
        private MyApplicationDbContext _db = new MyApplicationDbContext();
        public IActionResult Index()
        {
            return View(_db.Questions.ToList());
        }

        public IActionResult Details(int id)
        {
            var thisQuestion = _db.Questions.FirstOrDefault(questions => questions.Id == id);
            return View(thisQuestion);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Question question)
        {
            _db.Questions.Add(question);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var thisQuestion = _db.Questions.FirstOrDefault(questions => questions.Id == id);
            return View(thisQuestion);
        }

        [HttpPost]
        public IActionResult Edit(Question question)
        {
            _db.Entry(question).State = EntityState.Modified;
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var thisQuestion = _db.Questions.FirstOrDefault(questions => questions.Id == id);
            return View(thisQuestion);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var thisQuestion = _db.Questions.FirstOrDefault(questions => questions.Id == id);
            _db.Questions.Remove(thisQuestion);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}

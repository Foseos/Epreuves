using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Application.Models;

namespace Application.Controllers
{
    public class BusinessObjectsController : Controller
    {
        private readonly BusinessObjectRepository _repository;
        public BusinessObjectsController(BusinessObjectRepository repository)
        {
            _repository = repository;
        }

        public ActionResult Index()
        {
            var businessObjects = _repository.GetAll();
            return View(businessObjects);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(BusinessObject businessObject)
        {
            if (ModelState.IsValid)
            {
                _repository.Insert(businessObject);
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Edit(int id)
        {
            var businessObject = _repository.GetById(id);
            return View(businessObject);
        }

        [HttpPost]
        public ActionResult Edit(BusinessObject businessObject)
        {
            if (ModelState.IsValid)
            {
                _repository.Update(businessObject);
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Delete(int id)
        {
            var businessObject = _repository.GetById(id);
            return View(businessObject);
        }

        [HttpPost]
        public ActionResult Delete(BusinessObject businessObject)
        {
            _repository.Delete(businessObject.Id);
            return RedirectToAction("Index");
        }
    }

}
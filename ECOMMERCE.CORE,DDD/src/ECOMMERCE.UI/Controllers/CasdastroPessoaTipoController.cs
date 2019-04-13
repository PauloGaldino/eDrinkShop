using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECOMMERCE.UI.Controllers
{
    public class CasdastroPessoaTipoController : Controller
    {
        // GET: CasdastroPessoaTipo
        public ActionResult Index()
        {
            return View();
        }

        // GET: CasdastroPessoaTipo/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CasdastroPessoaTipo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CasdastroPessoaTipo/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CasdastroPessoaTipo/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CasdastroPessoaTipo/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CasdastroPessoaTipo/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CasdastroPessoaTipo/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
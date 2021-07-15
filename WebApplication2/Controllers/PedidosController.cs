using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class PedidosController : Controller
    {
        private Context db = new Context();

        // GET: Pedidos
        public ActionResult Index()
        {
            var pedido = db.Pedido.Include(p => p.Clientes).Include(p => p.Produtos);
            return View(pedido.ToList());
        }

        // GET: Pedidos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pedidos pedidos = db.Pedido.Find(id);
            if (pedidos == null)
            {
                return HttpNotFound();
            }
            return View(pedidos);
        }

        // GET: Pedidos/Create
        public ActionResult Create()
        {
            ViewBag.IdCliente = new SelectList(db.Cliente, "IdCliente", "NomeCompleto");
            ViewBag.IdProdutos = new SelectList(db.Produto, "IdProdutos", "Nome");
            return View();
        }

        // POST: Pedidos/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdPedidos,IdCliente,IdProdutos,DataPedido")] Pedidos pedidos)
        {
            if (ModelState.IsValid)
            {
                db.Pedido.Add(pedidos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdCliente = new SelectList(db.Cliente, "IdCliente", "NomeCompleto", pedidos.IdCliente);
            ViewBag.IdProdutos = new SelectList(db.Produto, "IdProdutos", "Nome", pedidos.IdProdutos);
            return View(pedidos);
        }

        // GET: Pedidos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pedidos pedidos = db.Pedido.Find(id);
            if (pedidos == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdCliente = new SelectList(db.Cliente, "IdCliente", "NomeCompleto", pedidos.IdCliente);
            ViewBag.IdProdutos = new SelectList(db.Produto, "IdProdutos", "Nome", pedidos.IdProdutos);
            return View(pedidos);
        }

        // POST: Pedidos/Edit/5
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdPedidos,IdCliente,IdProdutos,DataPedido")] Pedidos pedidos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pedidos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdCliente = new SelectList(db.Cliente, "IdCliente", "NomeCompleto", pedidos.IdCliente);
            ViewBag.IdProdutos = new SelectList(db.Produto, "IdProdutos", "Nome", pedidos.IdProdutos);
            return View(pedidos);
        }

        // GET: Pedidos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pedidos pedidos = db.Pedido.Find(id);
            if (pedidos == null)
            {
                return HttpNotFound();
            }
            return View(pedidos);
        }

        // POST: Pedidos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pedidos pedidos = db.Pedido.Find(id);
            db.Pedido.Remove(pedidos);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Configuration;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class EventLogsController : Controller
    {
        private readonly AuditModel db = new AuditModel();

        // GET: EventLogs
        public ActionResult Index()
        {
            Console.WriteLine(ConfigurationManager.ConnectionStrings["AuditModel"]);
            return View(db.EventLogs.ToList().OrderByDescending(x => x.dProcessTimestamp));
        }

        // GET: EventLogs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EventLog eventLog = db.EventLogs.Find(id);
            if (eventLog == null)
            {
                return HttpNotFound();
            }
            return View(eventLog);
        }

        // GET: EventLogs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EventLogs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,vAction,vInput,vOutput,iResult,dProcessTimestamp,vClientInfo")] EventLog eventLog)
        {
            if (ModelState.IsValid)
            {
                db.EventLogs.Add(eventLog);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(eventLog);
        }

        // GET: EventLogs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EventLog eventLog = db.EventLogs.Find(id);
            if (eventLog == null)
            {
                return HttpNotFound();
            }
            return View(eventLog);
        }

        // POST: EventLogs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,vAction,vInput,vOutput,iResult,dProcessTimestamp,vClientInfo")] EventLog eventLog)
        {
            if (ModelState.IsValid)
            {
                db.Entry(eventLog).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(eventLog);
        }

        // GET: EventLogs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EventLog eventLog = db.EventLogs.Find(id);
            if (eventLog == null)
            {
                return HttpNotFound();
            }
            return View(eventLog);
        }

        // POST: EventLogs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EventLog eventLog = db.EventLogs.Find(id);
            db.EventLogs.Remove(eventLog);
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

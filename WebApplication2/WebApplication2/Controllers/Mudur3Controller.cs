using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models.Entity;

namespace WebApplication2.Controllers
{
    public class Mudur3Controller : Controller
    {
        // GET: Mudur3
        dbo_ogrenciEntities4 db = new dbo_ogrenciEntities4();

        public ActionResult Index()
        {
            var degerler = db.tbl_rapor1.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult Ekle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Ekle(tbl_rapor1 p1)
        {
            db.tbl_rapor1.Add(p1);
            db.SaveChanges();
            return View();
        }
        public ActionResult SIL(int id)
        {
            var sil = db.tbl_rapor1.Find(id);
            db.tbl_rapor1.Remove(sil);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Guncelle(int id)
        {
            var guncelle = db.tbl_rapor1.Find(id);
            return View("Guncelle", guncelle);
        }
        public ActionResult Guncelle1(tbl_rapor1 p1)
        {
            var gnc = db.tbl_rapor1.Find(p1.rid);
            gnc.kisiad = p1.kisiad;
            gnc.kisibilgi = p1.kisibilgi;
            gnc.kisibas = p1.kisibas;
            gnc.kisibit = p1.kisibit;




            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
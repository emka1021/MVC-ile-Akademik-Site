using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models.Entity;

namespace WebApplication2.Controllers
{
    public class AkademiController : Controller
    {
        dbo_ogrenciEntities4 db = new dbo_ogrenciEntities4();
        // GET: Akademi
        public ActionResult Index()
        {
            var degerler = db.tbl_ogretmenler.ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult Ekle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Ekle(tbl_ogretmenler p1)
        {
            db.tbl_ogretmenler.Add(p1);
            db.SaveChanges();
            return View();
        }
        public ActionResult SIL(int id)
        {
            var sil = db.tbl_ogretmenler.Find(id);
            db.tbl_ogretmenler.Remove(sil);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Guncelle(int id)
        {
            var guncelle = db.tbl_ogretmenler.Find(id);
            return View("Guncelle", guncelle);
        }
        public ActionResult Guncelle1(tbl_ogretmenler p1)
        {
            var gnc = db.tbl_ogretmenler.Find(p1.ogid);
            gnc.ogad = p1.ogad;
            gnc.ogbolum = p1.ogbolum;
            gnc.ogbas = p1.ogbas;



            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }

}
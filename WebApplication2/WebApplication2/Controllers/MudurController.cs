using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models.Entity;

namespace WebApplication2.Controllers
{
    public class MudurController : Controller
    {
        // GET: Mudur
        dbo_ogrenciEntities4 db = new dbo_ogrenciEntities4();

        public ActionResult OgrenciBilgi()
        {
            var degerler = db.tbl_ogrenci.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YenKtegori()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YenKtegori(tbl_ogrenci p1)
        {
            db.tbl_ogrenci.Add(p1);
            db.SaveChanges();
            return View();
        }
        public ActionResult SIL(int id)
        {
            var sil = db.tbl_ogrenci.Find(id);
            db.tbl_ogrenci.Remove(sil);
            db.SaveChanges();
            return RedirectToAction("OgrenciBilgi");
        }
        public ActionResult Guncelle(int id)
        {
            var guncelle = db.tbl_ogrenci.Find(id);
            return View("Guncelle", guncelle);
        }
        public ActionResult Guncelle1(tbl_ogrenci p1)
        {
            var gnc = db.tbl_ogrenci.Find(p1.oid);
            gnc.oadı = p1.oadı;
            gnc.ono = p1.ono;
            gnc.obolum = p1.obolum;
            gnc.okredi = p1.okredi;
            gnc.odurum = p1.odurum;


            db.SaveChanges();
            return RedirectToAction("OgrenciBilgi");
        }

        public ActionResult MezunEt()
        {
            var mezunOgrenciler = db.tbl_ogrenci.Where(o => o.okredi >= 2).ToList();

            foreach (var ogrenci in mezunOgrenciler)
            {
                if (ogrenci.okredi >= 2)
                {
                    ogrenci.odurum = "Mezun";
                }
                else
                {
                    ViewBag.ErrorMessage = "Öğrencinin kredi notu 2'den düşük olduğu için mezun edilemez!";
                    return View();
                }
            }

            db.SaveChanges();

            return RedirectToAction("OgrenciBilgi", "Ogrenci");
        }
    }
}
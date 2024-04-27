using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models.Entity;

namespace WebApplication2.Controllers
{
    public class PersonelController : Controller
    




        {
           
    
        
            private readonly dbo_ogrenciEntities4 db = new dbo_ogrenciEntities4();

            // Kullanıcı giriş sayfası
            public ActionResult Personel()
            {
                return View();
            }

            // Kullanıcı girişi kontrolü
            [HttpPost]
            public ActionResult Personel(string kullaniciAdi, string sifre)
            {
                // Veritabanından kullanıcıyı ara
                var personel = db.tbl_personel.FirstOrDefault(p => p.personelkulad == kullaniciAdi && p.personelsifre == sifre);

                // Kullanıcı varsa oturum aç ve yönlendir
                if (personel != null)
                {
                    Session["Yetki"] = kullaniciAdi;
                    return RedirectToAction("Personel", "Personel"); // Örnek olarak Home/Index'e yönlendiriliyor
                }
                else
                {
                    ViewBag.ErrorMessage = "Geçersiz kullanıcı adı veya şifre!";
                    return View();
                }
            }
        }
    }


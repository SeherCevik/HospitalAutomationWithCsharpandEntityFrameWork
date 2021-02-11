using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFrameWorkHastaneOto
{
    class Doktor
    {
        public int ID { get; set; }
        public string Adi { get; set; }
        public string Soyadi { get; set; }
        public List<Hasta> hastalar { get; set; }
        [NotMapped]
        public string DoktorBilgi
        {
            get
            {
                return Adi + Soyadi;
            }
            
        }
        public Doktor()
        {
            hastalar = new List<Hasta>();
        }



    }
    class DoktorOp
    {
        public static void Ekle(Doktor doktor)
        {
            using (HastaneDbContext db = new HastaneDbContext())
            {
                db.doktorlar.Add(doktor);
                db.SaveChanges();
            }
        }
        public static void Sil(Doktor doktor)
        {
            using (HastaneDbContext db = new HastaneDbContext())
            {
                db.doktorlar.Remove(doktor);
                //db.Entry<Hasta>(hasta).State = EntityState.Deleted;
                db.SaveChanges();
            }
        }
        //-------------------------------------------------------------//
        public static Doktor IdIleDoktorGetir(int ID)
        {
            using (HastaneDbContext db = new HastaneDbContext())
            {
                return db.doktorlar.FirstOrDefault(d => d.ID == ID);
                //from h in hastalar where h.id == id anlamına geliyor
            }
        }

        //-------------------------------------------------------------//
        public static List<Doktor> TumDoktorlariGetir()
        {
            using (HastaneDbContext db = new HastaneDbContext())
            {
                return db.doktorlar.ToList();
            }

        }
        //-------------------------------------------------------------//
        public static void DoktorDuzenle(Doktor doktor)
        {
            using (HastaneDbContext db = new HastaneDbContext())
            {
                db.Entry<Doktor>(doktor).State = EntityState.Modified;
                db.SaveChanges();

            }
        }
        public static Doktor AdinaGoreDoktorGetir(string adi)
        {
            using (HastaneDbContext db = new HastaneDbContext())
            {
                return db.doktorlar.FirstOrDefault(d => d.Adi == adi);
                //from h in hastalar where h.id == id anlamına geliyor
            }
        }

    }
    //public static Doktor Ekle(Doktor doktor)

    //{
    //    using (HastaneDbContext db = new HastaneDbContext())
    //    {
    //        db.doktorlar.Add(doktor);
    //        //db.Entry<Hasta>(hasta).State = EntityState.Added;
    //        //var entity = db.Entry(hasta);
    //        //entity.State = EntityState.Added;
    //        db.SaveChanges();
    //        return doktor;
    //    }
    //}
    //-------------------------------------------------------------//


}

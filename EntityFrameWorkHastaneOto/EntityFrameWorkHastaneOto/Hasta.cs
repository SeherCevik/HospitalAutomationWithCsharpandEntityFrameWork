using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace EntityFrameWorkHastaneOto
{
    class Hasta
    {
        taniler = new List<Tani>();
            doktorlar = new List<Doktor>();
        public List<Tani> taniler { get; set; }
        public int ID { get; set; }
        [MaxLength(20)]
        public string Adi { get; set; }
        [StringLength(30, MinimumLength = 3)]
        [Required]
        public string Soyadi { get; set; }
        
        [StringLength(maximumLength: 11, MinimumLength = 11)]
        public string TC { get; set; }
        public HastaDetay hastadetay { get; set; }

        public List<Doktor> doktorlar { get; set; }

        public Hasta()
        {
            doktorlar = new List<Doktor>();
        }
    }

    class HastaOp
    {
        public static Hasta HastaEkle(Hasta hasta)
        
        {
            using (HastaneDbContext db = new HastaneDbContext())
            {
                db.Hasta.Add(hasta);
                //db.Entry<Hasta>(hasta).State = EntityState.Added;
                //var entity = db.Entry(hasta);
                //entity.State = EntityState.Added;
                db.SaveChanges();
                return hasta;
                
            }
        }
        public static Hasta HastaEkle(Hasta hasta , int DoktorId)

        {
            using (HastaneDbContext db = new HastaneDbContext())
            {
                var doktor = (from dr in db.doktorlar
                             where dr.ID == DoktorId
                             select dr).FirstOrDefault();
              //  Doktor dr = db.doktorlar.FirstOrDefault(x => x.ID == doktor.ID);
                hasta.doktorlar.Add(doktor);
                db.Hasta.Add(hasta);
                //db.Entry<Hasta>(hasta).State = EntityState.Added;
                //var entity = db.Entry(hasta);
                //entity.State = EntityState.Added;
                db.SaveChanges();
                return hasta;

            }
        }
        //-------------------------------------------------------------//
        public static void HastaSil(Hasta hasta)
        {
            using (HastaneDbContext db = new HastaneDbContext())
            {
                db.Hasta.Remove(hasta);
                //db.Entry<Hasta>(hasta).State = EntityState.Deleted;
                db.SaveChanges();
            }
        }
        //-------------------------------------------------------------//
        public static Hasta IdIleGetir(int ID)
        {
            using (HastaneDbContext db = new HastaneDbContext())
            {
                return db.Hasta.FirstOrDefault(h=> h.ID==ID);
                //from h in hastalar where h.id == id anlamına geliyor
            }
        }
        
        //-------------------------------------------------------------//
        public static List<Hasta> TumKayitlariGetir()
        {
            using (HastaneDbContext db = new HastaneDbContext())
            {
                return db.Hasta.Include("doktorlar").ToList();
            }

        }
        //-------------------------------------------------------------//
        public static void HastaDuzenle(Hasta hasta)
        {
            using (HastaneDbContext db = new HastaneDbContext())
            {
                db.Entry<Hasta>(hasta).State=EntityState.Modified;
                db.SaveChanges();
                
            }
        }
    }
}

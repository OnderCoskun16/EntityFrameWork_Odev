using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EksiSozluk
{
    public class Konu
    {
        private static DateTime mDateTime;

        [Key]
        public int ID { get; set; }

        [Column("Konu Başlığı")]
        [StringLength(50)] // max 100
        public string Title { get; set; }

        //[Column("TarihSaat")]
        //public DateTime DateAndTime
        //{
        //    get { return DateTime.UtcNow; }
        //    set { mDateTime = value; }
        //}
        //[Column("KonuYaziSayisi")]
        //public bool CountWrite { get; set; }

        [Column("Açıklama")]
        [StringLength(300)] // max 100
        public string Description { get; set; }

        [ForeignKey("Category")] // Foreign key tanımlıyoruz..Navigation Property ismi olacak...
        public int Catg_ID { get; set; }

        public Categories Category { get; set; }

        public List<Kullanici> Kullanicilar { get; set; }

    }
}

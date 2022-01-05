using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EksiSozluk
{
    public class Kullanici
    {

        [Key]
        public int ID { get; set; }

        [Column("KullaniciAdi")]
        [StringLength(100)] // max 100
        public string NickName { get; set; }

        [ForeignKey("Konular")] // Foreign key tanımlıyoruz..Navigation Property ismi olacak...
        public int KonuID { get; set; }

        public List<Konu> Konular { get; set; }
    }
}

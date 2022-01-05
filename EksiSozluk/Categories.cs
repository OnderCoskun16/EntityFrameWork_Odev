using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EksiSozluk
{
    public class Categories
    {
        [Key]
        public int ID { get; set; }

        [Column("Kategori Adı")]
        [StringLength(100)] // max 100
        public string Name { get; set; }        

        public List<Konu> Konular { get; set; }
    }
}

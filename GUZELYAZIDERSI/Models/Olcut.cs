using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUZELYAZIDERSI.Models
{
    public class Olcut
    {
        public int OlcutID { get; set; }

        public int YaziTuruID { get; set; }   // <-- Yeni

        public string Kategori { get; set; }

        public string OlcutAdi { get; set; }

        public string Aciklama { get; set; }

        public int MaksPuan { get; set; }

        public int Sira { get; set; }

        public bool Aktif { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUZELYAZIDERSI.Models
{
    public class YaziTuru
    {
        public int YaziTuruID { get; set; }

        public string YaziTuruAdi { get; set; }

        public int Sira { get; set; }

        public bool Aktif { get; set; }

        public override string ToString()
        {
            return YaziTuruAdi;
        }
    }
}

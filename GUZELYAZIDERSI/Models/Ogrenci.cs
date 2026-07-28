using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUZELYAZIDERSI.Models
{
    public class Ogrenci
    {
        public int OGRID { get; set; }

        public int OGRNO { get; set; }

        public string OGRADSOYAD { get; set; }

        public byte SINIF { get; set; }

        public string SUBE { get; set; }

        public string CINSIYET { get; set; }

        public bool AKTIF { get; set; }

        public string OgrenciBilgisi
        {
            get
            {
                return OGRNO + " - " + OGRADSOYAD;
            }
        }
    }
}

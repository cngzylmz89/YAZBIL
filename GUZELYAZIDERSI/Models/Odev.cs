using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUZELYAZIDERSI.Models
{
    public class Odev
    {
        public int ODEVID { get; set; }

        public int OGRID { get; set; }

        public DateTime VERILMETARIHI { get; set; }

        public string ODEV { get; set; }

        public bool YAPILDI { get; set; }

        public DateTime? KONTROLTARIHI { get; set; }

        public string ACIKLAMA { get; set; }
    }
}

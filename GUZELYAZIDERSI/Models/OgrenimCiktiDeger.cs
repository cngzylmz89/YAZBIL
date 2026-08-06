using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUZELYAZIDERSI.Models
{
    public class OgrenimCiktiDeger
    {
        public int ID { get; set; }

        public int OGRID { get; set; }

        public int YAZIID { get; set; }

        public string AMACCIKTIKODU { get; set; }

        /// <summary>
        /// 0=Yetersiz
        /// 1=Kısmen Yeterli
        /// 2=Yeterli
        /// </summary>
        public byte DUZEY { get; set; }

        public byte PUAN { get; set; }

        public DateTime TARIH { get; set; }
    }
}

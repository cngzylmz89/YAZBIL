namespace GUZELYAZIDERSI.Models
{
    public class OgrenimCikti
    {
        // Primary Key
        public string AMACCIKTIKODU { get; set; }

        // Amaç Kodu (Örn: T.D.5.1)
        public string AMACKODU { get; set; }

        // Beceri Alanı (Dinleme, Okuma, Yazma, Konuşma...)
        public string BECERIALANI { get; set; }

        // Amaç
        public string AMAC { get; set; }

        // Öğrenim Çıktısı
        public string OGRENIMCIKTISI { get; set; }

        // Açıklama
        public string ACIKLAMA { get; set; }

        // ComboBox'ta amaçları güzel göstermek için
        public string AmacBilgisi
        {
            get
            {
                return AMACKODU + " - " + AMAC;
            }
        }

        // ComboBox'ta öğrenim çıktılarını güzel göstermek için
        public string CiktiBilgisi
        {
            get
            {
                return AMACCIKTIKODU + " - " + OGRENIMCIKTISI;
            }
        }
    }
}
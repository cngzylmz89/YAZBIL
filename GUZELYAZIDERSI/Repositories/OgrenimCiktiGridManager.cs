using GUZELYAZIDERSI.Models;
using System.Drawing;
using System.Windows.Forms;

namespace GUZELYAZIDERSI.Classes
{
    public static class OgrenimCiktiGridManager
    {
        public static void SatirBoya(DataGridViewRow row,
                                     OgrenimCiktiDeger deger)
        {
            // Önce bütün hücreleri beyaz yap
            foreach (DataGridViewCell cell in row.Cells)
                cell.Style.BackColor = Color.White;

            Color renk;

            if (deger == null)
            {
                renk = Color.MistyRose;          // değerlendirilmemiş
            }
            else
            {
                switch (deger.DUZEY)
                {
                    case 0:
                        renk = Color.Moccasin;      // yetersiz
                        break;

                    case 1:
                        renk = Color.LemonChiffon;  // kısmen yeterli
                        break;

                    case 2:
                        renk = Color.Honeydew;      // yeterli
                        break;

                    default:
                        renk = Color.White;
                        break;
                }
            }

            // Sadece kod sütununu boya
            row.Cells["colKod"].Style.BackColor = renk;
        }
    }
}
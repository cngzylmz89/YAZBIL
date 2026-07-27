using GUZELYAZIDERSI.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;

namespace GUZELYAZIDERSI.Repositories
{
    public class OgrenciRepository : BaseRepository
    {
        /// <summary>
        /// DataRow'u Ogrenci nesnesine dönüştürür.
        /// </summary>
        private Ogrenci Map(DataRow row)
        {
            return new Ogrenci
            {
                OGRID = Convert.ToInt32(row["OGRID"]),
                OGRNO = Convert.ToInt32(row["OGRNO"]),
                OGRADSOYAD = row["OGRADSOYAD"].ToString(),
                SINIF = Convert.ToByte(row["SINIF"]),
                SUBE = row["SUBE"].ToString(),
                CINSIYET = row["CINSIYET"].ToString(),
                AKTIF = Convert.ToBoolean(row["AKTIF"])
            };
        }

        /// <summary>
        /// Seçilen sınıfa ait aktif öğrencileri getirir.
        /// </summary>
        public List<Ogrenci> SinifaGoreGetir(byte sinif)
        {
            List<Ogrenci> liste = new List<Ogrenci>();

            string sql = @"SELECT *
                           FROM tblOGRENCILER
                           WHERE SINIF = ?
                           AND AKTIF = True
                           ORDER BY OGRNO";

            DataTable dt = GetDataTable(
                sql,
                new OleDbParameter("@P1", sinif));

            foreach (DataRow row in dt.Rows)
            {
                liste.Add(Map(row));
            }

            return liste;
        }

        /// <summary>
        /// Öğrenci numarasına göre öğrenciyi getirir.
        /// </summary>
        public Ogrenci OgrenciNumarasinaGoreGetir(int ogrNo)
        {
            string sql = @"SELECT *
                           FROM tblOGRENCILER
                           WHERE OGRNO = ?";

            DataTable dt = GetDataTable(
                sql,
                new OleDbParameter("@P1", ogrNo));

            if (dt.Rows.Count == 0)
                return null;

            return Map(dt.Rows[0]);
        }

        /// <summary>
        /// Öğrenci numarasından OGRID bilgisini döndürür.
        /// </summary>
        public int OgrenciIDGetir(int ogrNo)
        {
            string sql = @"SELECT OGRID
                           FROM tblOGRENCILER
                           WHERE OGRNO = ?";

            object sonuc = Scalar(
                sql,
                new OleDbParameter("@P1", ogrNo));

            if (sonuc == null || sonuc == DBNull.Value)
                return 0;

            return Convert.ToInt32(sonuc);
        }
    }
}
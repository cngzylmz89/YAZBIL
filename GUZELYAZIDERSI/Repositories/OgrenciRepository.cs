using GUZELYAZIDERSI.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;

namespace GUZELYAZIDERSI.Repositories
{
    public class OgrenciRepository : BaseRepository
    {
        /// <summary>
        /// DataRow'u Ogrenci nesnesine dönüştürür.
        /// </summary>
        /// 
        public List<string> SubeleriGetir(byte sinif)
        {
            List<string> liste = new List<string>();

            string sql = @"SELECT DISTINCT SUBE
                   FROM tblOGRENCILER
                   WHERE SINIF = ?
                   AND AKTIF = True
                   ORDER BY SUBE";

            DataTable dt = GetDataTable(
                sql,
                new OleDbParameter("@P1", sinif));

            foreach (DataRow row in dt.Rows)
            {
                liste.Add(row["SUBE"].ToString());
            }

            return liste;
        }

        /// <summary>
        /// Seçilen sınıf ve şubeye ait öğrencileri getirir.
        /// </summary>
        public List<Ogrenci> SinifSubeyeGoreGetir(byte sinif, string sube)
        {
            List<Ogrenci> liste = new List<Ogrenci>();

            string sql = @"SELECT *
                   FROM tblOGRENCILER
                   WHERE SINIF = ?
                   AND SUBE = ?
                   AND AKTIF = True
                   ORDER BY OGRNO";

            DataTable dt = GetDataTable(
                sql,
                new OleDbParameter("@P1", sinif),
                new OleDbParameter("@P2", sube));

            foreach (DataRow row in dt.Rows)
            {
                liste.Add(Map(row));
            }

            return liste;
        }
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
        /// Seçilen sınıfa ait aktif öğrencileri getirir.
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

        /// <summary>
        /// Öğrenci numarasına göre arama yapar.
        /// </summary>
        public List<Ogrenci> OgrenciAra(string ogrNo)
        {
            List<Ogrenci> liste = new List<Ogrenci>();

            string sql = @"SELECT *
                   FROM tblOGRENCILER
                   WHERE OGRNO LIKE ?
                   AND AKTIF = True
                   ORDER BY OGRNO";

            DataTable dt = GetDataTable(
                sql,
                new OleDbParameter("@P1", ogrNo + "*"));
           
            foreach (DataRow row in dt.Rows)
            {
                liste.Add(Map(row));
            }

            return liste;
        }

        /// <summary>
        /// Seçilen sınıfa ait şubeleri getirir.
        /// </summary>
       
    }
}
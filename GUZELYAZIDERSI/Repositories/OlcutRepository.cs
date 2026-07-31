using GUZELYAZIDERSI.Classes;
using GUZELYAZIDERSI.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;

namespace GUZELYAZIDERSI.Repositories
{
    public class OlcutRepository: BaseRepository
    {
        public List<Olcut> OlcutleriGetir(int yaziTuruID, string kategori)
        {
            List<Olcut> liste = new List<Olcut>();

            using (OleDbConnection con = Database.GetConnection())
            {
                con.Open();

                string sql = @"
        SELECT
            OLCUTID,
            YAZITURUID,
            KATEGORI,
            OLCUTADI,
            ACIKLAMA,
            MAXPUAN,
            SIRA,
            AKTIF
        FROM tblOLCUTLER
        WHERE YAZITURUID = ?
          AND KATEGORI = ?
          AND AKTIF = True
        ORDER BY SIRA";

                using (OleDbCommand cmd = new OleDbCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@P1", yaziTuruID);
                    cmd.Parameters.AddWithValue("@P2", kategori);

                    using (OleDbDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            Olcut olcut = new Olcut();

                            olcut.OlcutID = Convert.ToInt32(dr["OLCUTID"]);
                            olcut.YaziTuruID = Convert.ToInt32(dr["YAZITURUID"]);
                            olcut.Kategori = dr["KATEGORI"].ToString();
                            olcut.OlcutAdi = dr["OLCUTADI"].ToString();
                            olcut.Aciklama = dr["ACIKLAMA"].ToString();
                            olcut.MaksPuan = Convert.ToInt32(dr["MAXPUAN"]);
                            olcut.Aktif = Convert.ToBoolean(dr["AKTIF"]);
                            olcut.Sira = Convert.ToInt32(dr["SIRA"]);





                            liste.Add(olcut);
                        }
                    }
                }
            }

            return liste;
        }

        public DataTable OlcutleriGetirTable(int yaziTuruID, string kategori)
        {
            string sql = @"
    SELECT
        OLCUTID,
        OLCUTADI,
        ACIKLAMA,
        MAXPUAN
    FROM tblOLCUTLER
    WHERE YAZITURUID = ?
      AND KATEGORI = ?
    ORDER BY SIRA";

            return GetDataTable(
                sql,
                new OleDbParameter("@P1", yaziTuruID),
                new OleDbParameter("@P2", kategori));
        }
    
    }
}

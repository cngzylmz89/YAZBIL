using System;
using System.Collections.Generic;
using System.Data.OleDb;
using GUZELYAZIDERSI.Classes;
using GUZELYAZIDERSI.Models;

namespace GUZELYAZIDERSI.Repositories
{
    public class OlcutRepository
    {
        public List<Olcut> OlcutleriGetir(string kategori)
        {
            List<Olcut> liste = new List<Olcut>();

            using (OleDbConnection con = Database.GetConnection())
            {
                con.Open();

                string sql =
                @"SELECT
            OLCUTID,
            KATEGORI,
            OLCUTADI,
            MAKSPUAN,
            SIRA,
            AKTIF
          FROM tblOLCUTLER
          WHERE KATEGORI=?
          AND AKTIF=True
          ORDER BY SIRA";

                using (OleDbCommand cmd = new OleDbCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@P1", kategori);

                    using (OleDbDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            Olcut olcut = new Olcut();

                            olcut.OlcutID = Convert.ToInt32(dr["OLCUTID"]);
                            olcut.Kategori = dr["KATEGORI"].ToString();
                            olcut.OlcutAdi = dr["OLCUTADI"].ToString();
                            olcut.MaksPuan = Convert.ToInt32(dr["MAKSPUAN"]);
                            olcut.Aktif = Convert.ToBoolean(dr["AKTIF"]);
                            olcut.Sira = Convert.ToInt32(dr["SIRA"]);

                            liste.Add(olcut);
                        }
                    }
                }
            }

            return liste;
        }
    }
}

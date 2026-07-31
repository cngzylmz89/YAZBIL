using GUZELYAZIDERSI.Classes;
using GUZELYAZIDERSI.Models;
using System;
using System.Collections.Generic;
using System.Data.OleDb;

namespace GUZELYAZIDERSI.Repositories
{
    public class YaziTuruRepository
    {
        public List<YaziTuru> TumunuGetir()
        {
            List<YaziTuru> liste = new List<YaziTuru>();

            using (OleDbConnection con = Database.GetConnection())
            {
                con.Open();

                string sql = @"
                    SELECT
                        YAZITURUID,
                        YAZITURU,
                        SIRA,
                        AKTIF
                    FROM tblYAZITURU
                    WHERE AKTIF=True
                    ORDER BY SIRA";

                using (OleDbCommand cmd = new OleDbCommand(sql, con))
                using (OleDbDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        YaziTuru yaziTuru = new YaziTuru();

                        yaziTuru.YaziTuruID = Convert.ToInt32(dr["YAZITURUID"]);
                        yaziTuru.YaziTuruAdi = dr["YAZITURU"].ToString();
                        yaziTuru.Sira = Convert.ToInt32(dr["SIRA"]);
                        yaziTuru.Aktif = Convert.ToBoolean(dr["AKTIF"]);

                        liste.Add(yaziTuru);
                    }
                }
            }

            return liste;
        }
    }
}
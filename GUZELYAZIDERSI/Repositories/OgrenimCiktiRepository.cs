using GUZELYAZIDERSI.Classes;
using GUZELYAZIDERSI.Models;
using System;
using System.Collections.Generic;
using System.Data.OleDb;

namespace GUZELYAZIDERSI.Repositories
{
    public class OgrenimCiktiRepository
    {
        public List<string> BeceriAlanlariniGetir()
        {
            List<string> liste = new List<string>();

            using (OleDbConnection con = Database.GetConnection())
            {
                con.Open();

                string sql =
                @"SELECT DISTINCT BECERIALANI
                  FROM tblOGRENIMCIKTILARI
                  ORDER BY BECERIALANI";

                using (OleDbCommand cmd = new OleDbCommand(sql, con))
                using (OleDbDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        liste.Add(dr["BECERIALANI"].ToString());
                    }
                }
            }

            return liste;
        }

        public List<OgrenimCikti> AmaclariGetir(string beceriAlani)
        {
            List<OgrenimCikti> liste = new List<OgrenimCikti>();

            using (OleDbConnection con = Database.GetConnection())
            {
                con.Open();

                string sql =
                @"SELECT DISTINCT
                        AMACKODU,
                        AMAC
                  FROM tblOGRENIMCIKTILARI
                  WHERE BECERIALANI=?
                  ORDER BY AMACKODU";

                using (OleDbCommand cmd = new OleDbCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@P1", beceriAlani);

                    using (OleDbDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            liste.Add(new OgrenimCikti()
                            {
                                AMACKODU = dr["AMACKODU"].ToString(),
                                AMAC = dr["AMAC"].ToString()
                            });
                        }
                    }
                }
            }

            return liste;
        }

        public List<OgrenimCikti> OgrenimCiktilariniGetir(string amacKodu)
        {
            List<OgrenimCikti> liste = new List<OgrenimCikti>();

            using (OleDbConnection con = Database.GetConnection())
            {
                con.Open();

                string sql =
                @"SELECT *
                  FROM tblOGRENIMCIKTILARI
                  WHERE AMACKODU=?
                  ORDER BY AMACCIKTIKODU";

                using (OleDbCommand cmd = new OleDbCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@P1", amacKodu);

                    using (OleDbDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            OgrenimCikti c = new OgrenimCikti();

                            c.AMACCIKTIKODU = dr["AMACCIKTIKODU"].ToString();
                            c.AMACKODU = dr["AMACKODU"].ToString();
                            c.BECERIALANI = dr["BECERIALANI"].ToString();
                            c.AMAC = dr["AMAC"].ToString();
                            c.OGRENIMCIKTISI = dr["OGRENIMCIKTISI"].ToString();
                            c.ACIKLAMA = dr["ACIKLAMA"].ToString();

                            liste.Add(c);
                        }
                    }
                }
            }

            return liste;
        }

        public OgrenimCiktiDeger Getir(int ogrID, string amacCiktiKodu)
        {
            using (OleDbConnection con = Database.GetConnection())
            {
                con.Open();

                string sql =
                @"SELECT *
          FROM tblOGRENIMCIKTIDEGER
          WHERE OGRID=?
          AND AMACCIKTIKODU=?";

                using (OleDbCommand cmd = new OleDbCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@P1", ogrID);
                    cmd.Parameters.AddWithValue("@P2", amacCiktiKodu);

                    using (OleDbDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            return new OgrenimCiktiDeger()
                            {
                                OGRID = Convert.ToInt32(dr["OGRID"]),
                                AMACCIKTIKODU = dr["AMACCIKTIKODU"].ToString(),
                                DUZEY = Convert.ToByte(dr["DUZEY"])
                            };
                        }
                    }
                }
            }

            return null;
        }

        public List<OgrenimCikti> Ara(string metin)
        {
            List<OgrenimCikti> liste = new List<OgrenimCikti>();

            using (OleDbConnection con = Database.GetConnection())
            {
                con.Open();

                string sql = @"
SELECT
    AMACCIKTIKODU,
    AMACKODU,
    BECERIALANI,
    AMAC,
    OGRENIMCIKTISI,
    ACIKLAMA
FROM tblOGRENIMCIKTILARI
WHERE
      AMACCIKTIKODU LIKE ?
   OR AMACKODU LIKE ?
   OR BECERIALANI LIKE ?
   OR AMAC LIKE ?
   OR OGRENIMCIKTISI LIKE ?
ORDER BY AMACCIKTIKODU";

                using (OleDbCommand cmd = new OleDbCommand(sql, con))
                {
                    string ara = "%" + metin + "%";

                    cmd.Parameters.AddWithValue("@P1", ara);
                    cmd.Parameters.AddWithValue("@P2", ara);
                    cmd.Parameters.AddWithValue("@P3", ara);
                    cmd.Parameters.AddWithValue("@P4", ara);
                    cmd.Parameters.AddWithValue("@P5", ara);

                    using (OleDbDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            OgrenimCikti c = new OgrenimCikti();

                            c.AMACCIKTIKODU = dr["AMACCIKTIKODU"].ToString();
                            c.AMACKODU = dr["AMACKODU"].ToString();
                            c.BECERIALANI = dr["BECERIALANI"].ToString();
                            c.AMAC = dr["AMAC"].ToString();
                            c.OGRENIMCIKTISI = dr["OGRENIMCIKTISI"].ToString();
                            c.ACIKLAMA = dr["ACIKLAMA"].ToString();

                            liste.Add(c);
                        }
                    }
                }
            }

            return liste;
        }

        public List<OgrenimCikti> TumunuGetir()
        {
            return Ara("");
        }
    }
}
    

using GUZELYAZIDERSI.Classes;
using GUZELYAZIDERSI.Models;
using System;
using System.Data.OleDb;

namespace GUZELYAZIDERSI.Repositories
{
    public class OgrenimCiktiDegerRepository : BaseRepository
    {
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
                            OgrenimCiktiDeger deger =
                                new OgrenimCiktiDeger();

                            deger.OGRID = Convert.ToInt32(dr["OGRID"]);
                            deger.AMACCIKTIKODU = dr["AMACCIKTIKODU"].ToString();
                            deger.DUZEY = Convert.ToByte(dr["DUZEY"]);

                            return deger;
                        }
                    }
                }
            }

            return null;
        }
    }
}
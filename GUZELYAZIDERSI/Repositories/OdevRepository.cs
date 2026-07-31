using GUZELYAZIDERSI.Classes;
using GUZELYAZIDERSI.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUZELYAZIDERSI.Repositories
{
    public class OdevRepository : BaseRepository
    {
        private Odev Map(DataRow row)
        {
            return new Odev
            {
                ODEVID = Convert.ToInt32(row["ODEVID"]),
                OGRID = Convert.ToInt32(row["OGRID"]),
                VERILMETARIHI = Convert.ToDateTime(row["VERILMETARIHI"]),
                ODEV = row["ODEV"].ToString(),
                YAPILDI = Convert.ToBoolean(row["YAPILDI"]),

                KONTROLTARIHI =
                    row["KONTROLTARIHI"] == DBNull.Value
                    ? (DateTime?)null
                    : Convert.ToDateTime(row["KONTROLTARIHI"]),

                ACIKLAMA =
                    row["ACIKLAMA"] == DBNull.Value
                    ? ""
                    : row["ACIKLAMA"].ToString()
            };
        }

        public Odev SonOdeviGetir(int ogrID)
        {
            string sql = @"SELECT TOP 1 *
                   FROM tblODEV
                   WHERE OGRID = ?
                   ORDER BY VERILMETARIHI DESC";

            DataTable dt = GetDataTable(
                sql,
                new OleDbParameter("@P1", ogrID));

            if (dt.Rows.Count == 0)
                return null;

            return Map(dt.Rows[0]);
        }
        public bool OdevEkle(Odev odev)
        {
            string sql = @"INSERT INTO tblODEV
(OGRID, VERILMETARIHI, ODEV, YAPILDI)
VALUES (?,?,?,?)";

            OleDbCommand cmd = new OleDbCommand(sql);

            cmd.Parameters.AddWithValue("@P1", odev.OGRID);
            cmd.Parameters.AddWithValue("@P2", odev.VERILMETARIHI);
            cmd.Parameters.AddWithValue("@P3", odev.ODEV);
            cmd.Parameters.AddWithValue("@P4", odev.YAPILDI);

            return Database.ExecuteNonQuery(cmd) > 0;
        }
        //public bool OdevEkle(Odev odev)
        //{
        //    string sql = @"INSERT INTO tblODEV
        //          (OGRID,
        //           VERILMETARIHI,
        //           ODEV,
        //           YAPILDI,
        //           KONTROLTARIHI,
        //           ACIKLAMA)

        //          VALUES
        //          (?,?,?,?,?,?)";

        //    return ExecuteBool(
        //        sql,
        //        new OleDbParameter("@P1", odev.OGRID),
        //        new OleDbParameter("@P2", odev.VERILMETARIHI),
        //        new OleDbParameter("@P3", odev.ODEV),
        //        new OleDbParameter("@P4", odev.YAPILDI),
        //        new OleDbParameter("@P5",
        //            (object)odev.KONTROLTARIHI ?? DBNull.Value),
        //        new OleDbParameter("@P6",
        //            (object)odev.ACIKLAMA ?? DBNull.Value)
        //    );
        //}

        public bool OdevDurumGuncelle(int odevID,
                              bool yapildi,
                              DateTime? kontrolTarihi)
        {
            string sql = @"UPDATE tblODEV
                   SET YAPILDI = ?,
                       KONTROLTARIHI = ?
                   WHERE ODEVID = ?";

            return ExecuteBool(
                sql,
                new OleDbParameter("@P1", yapildi),
                new OleDbParameter("@P2",
                    (object)kontrolTarihi ?? DBNull.Value),
                new OleDbParameter("@P3", odevID)
            );
        }
    }
    }

using GUZELYAZIDERSI.Classes;
using System;
using System.Data;
using System.Data.OleDb;

namespace GUZELYAZIDERSI.Repositories
{
    public abstract class BaseRepository
    {
        protected DataTable GetDataTable(string sql, params OleDbParameter[] parameters)
        {
            OleDbCommand cmd = new OleDbCommand(sql);

            if (parameters != null)
                cmd.Parameters.AddRange(parameters);

            return Database.FillDataTable(cmd);
        }

        protected int Execute(string sql, params OleDbParameter[] parameters)
        {
            OleDbCommand cmd = new OleDbCommand(sql);

            if (parameters != null)
                cmd.Parameters.AddRange(parameters);

            return Database.ExecuteNonQuery(cmd);
        }

        /// <summary>
        /// İşlem başarılı ise true döndürür.
        /// </summary>
        protected bool ExecuteBool(string sql, params OleDbParameter[] parameters)
        {
            return Execute(sql, parameters) > 0;
        }

        /// <summary>
        /// Kayıt var mı kontrolü yapar.
        /// </summary>
        protected bool Exists(string sql, params OleDbParameter[] parameters)
        {
            object sonuc = Scalar(sql, parameters);

            if (sonuc == null || sonuc == DBNull.Value)
                return false;

            return Convert.ToInt32(sonuc) > 0;
        }
        protected object Scalar(string sql, params OleDbParameter[] parameters)
        {
            OleDbCommand cmd = new OleDbCommand(sql);

            if (parameters != null)
                cmd.Parameters.AddRange(parameters);

            return Database.ExecuteScalar(cmd);
        }
    }
}
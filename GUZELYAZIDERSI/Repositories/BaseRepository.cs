using GUZELYAZIDERSI.Classes;
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

        protected object Scalar(string sql, params OleDbParameter[] parameters)
        {
            OleDbCommand cmd = new OleDbCommand(sql);

            if (parameters != null)
                cmd.Parameters.AddRange(parameters);

            return Database.ExecuteScalar(cmd);
        }
    }
}
using System;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Windows.Forms;

namespace GUZELYAZIDERSI.Classes
{
    public static class Database
    {

       
        // AppData klasörü
        public static readonly string AppFolder =
            Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                "YAZBIL");

        // Kullanılacak veritabanı
        public static readonly string DatabasePath =
            Path.Combine(AppFolder, "YAZBIL.accdb");

        // Program içindeki şablon veritabanı
        public static readonly string TemplateDatabase =
            Path.Combine(Application.StartupPath, "Data", "YAZBIL.accdb");

        /// <summary>
        /// Program ilk açıldığında çağrılır.
        /// </summary>
        public static void Initialize()
        {
            if (!File.Exists(TemplateDatabase))
            {
                MessageBox.Show(
                    "Şablon veritabanı bulunamadı.",
                    "YAZBİL",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                Application.Exit();
                return;
            }
            // AppData klasörü yoksa oluştur.
            if (!Directory.Exists(AppFolder))
                Directory.CreateDirectory(AppFolder);

            // Veritabanı yoksa Data klasöründen kopyala.
            if (!File.Exists(DatabasePath))
            {
                File.Copy(TemplateDatabase, DatabasePath);
            }
        }

        /// <summary>
        /// Yeni bir Access bağlantısı döndürür.
        /// </summary>
        public static OleDbConnection GetConnection()
        {
            

            string connectionString =
                @"Provider=Microsoft.ACE.OLEDB.12.0;" +
                @"Data Source=" + DatabasePath +
                @";Persist Security Info=False;";

            return new OleDbConnection(connectionString);
        }

        public static bool TestConnection()
        {
            try
            {
                using (OleDbConnection con = GetConnection())
                {
                    con.Open();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
        public static int ExecuteNonQuery(OleDbCommand cmd)
        {
            
            using (cmd.Connection = GetConnection())
            {
                cmd.Connection.Open();

                try
                {
                    
                    return cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        cmd.CommandText + Environment.NewLine +
                        Environment.NewLine +
                        ex.ToString());

                    throw;
                }
            }
        }
        //public static int ExecuteNonQuery(OleDbCommand cmd)
        //{
        //    try
        //    {
        //        using (cmd.Connection = GetConnection())
        //        {
        //            cmd.Connection.Open();
        //            return cmd.ExecuteNonQuery();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //        return 0;
        //    }
        //}
        public static object ExecuteScalar(OleDbCommand cmd)
        {
            using (cmd.Connection = GetConnection())
            {
                cmd.Connection.Open();

                return cmd.ExecuteScalar();
            }
        }

        public static DataTable FillDataTable(OleDbCommand cmd)
        {
            using (cmd.Connection = GetConnection())
            {
                cmd.Connection.Open();

                DataTable dt = new DataTable();

                OleDbDataAdapter da =
                    new OleDbDataAdapter(cmd);

                da.Fill(dt);

                return dt;
            }
        }
    }
}
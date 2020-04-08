using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Diagnostics;

namespace LessonA
{
    static class Program
    {
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            SqlConnection connection = GetSqlConnection();

            try
            {
                connection.Open();
                Application.Run(new Form1(connection));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace, ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (System.IO.StreamWriter sw = new System.IO.StreamWriter(
                    Process.GetCurrentProcess().MainModule.FileName.Replace(".exe",".err"),
                    true,
                    System.Text.Encoding.GetEncoding("shift_jis")))
                {
                    sw.WriteLine(ex.Message);
                    sw.Close();
                }
                return;
            }
            finally
            {
                try
                {
                    connection.Close();
                }
                catch
                {
                }
            }
        }

        /// <summary>
        /// App.configから接続情報を取得
        /// </summary>
        /// <returns></returns>
        static SqlConnection GetSqlConnection()
        {
            string connectionSettingsName = "db";
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings[connectionSettingsName].ConnectionString;
                return new SqlConnection(connectionString);
            }
            catch (ConfigurationErrorsException ex)
            {
                throw;
            }
            catch (NullReferenceException ex)
            {
                throw;
            }
        }
    }
}
